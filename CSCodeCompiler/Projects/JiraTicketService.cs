using CSCodeCompiler.Extentions;
using CSCodeCompiler.IO;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCodeCompiler 
{
    public class JiraTicketService
    {
        public static void Run(string[] args)
        {
            DataCallTicketRepo repo = new DataCallTicketRepo();
            List<DataCallTicket> tickets = repo.Tickets;
            foreach (var ticket in tickets)
            {
                foreach (var metric in ticket.Metrics)
                {
                    string qgroup = ticket.Section;
                    string idtext = metric.MetricID;
                    string met = metric.MetricText;
                }
            }
        }
    }
    


    public class DataCallTicketRepo
    { 
        private List<DataCallTicket> tickets = new List<DataCallTicket>();
        public List<DataCallTicket> Tickets
        {
            get { return tickets; }
            set { tickets = value; }
        }
  
        public DataCallTicketRepo()
        { 
            Init(); 
        }
        private void Init()
        {
            Regex rex;
            DirectoryInfo DI = new DirectoryInfo($"{AppSettings.BasePath}\\jira\\!SAOP2019$DataCallProcessor\\_dest");
            foreach (var file in DI.GetFiles("*.xml" ))
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                FileReader r = new FileReader(file.FullName);
                htmlDoc.LoadHtml(r.Read());

                DataCallTicket ticket = new DataCallTicket();
                ticket.Key = htmlDoc.DocumentNode.SelectSingleNode("//item/key").InnerHtml;
                ticket.Section = htmlDoc.DocumentNode.SelectSingleNode("//item//qgroup").InnerHtml; 
                
                HtmlNodeCollection metricNodes = htmlDoc.DocumentNode.SelectNodes("//metric");
                DataCallMetric metric = new DataCallMetric();
                foreach (var metricNode in metricNodes)
                { 
                    metric.MetricID = metricNode.SelectSingleNode("id-text").InnerHtml;
                    metric.MetricText = metricNode.SelectSingleNode("question-text").InnerHtml;
 
                    HtmlNodeCollection picklistNodes = metricNode.SelectNodes("picklist/li");
                    if (picklistNodes != null)
                    {
                        metric.MetricPickList = new Picklist();
                        foreach (HtmlNode picklistNode  in picklistNodes)
                        {
                            metric.MetricPickList.PicklistItems.Add(new PicklistItem() { Text = picklistNode.InnerHtml });
                            Console.WriteLine(picklistNode.InnerHtml); 
                        }
                   
                    }
                }
                ticket.Metrics.Add(metric);
                Tickets.Add(ticket); 
            } 
        } 
    }
    public class DataCallTicket
    {
        public string Key { get; set; }
        public string Section { get; set; }
        private List<DataCallMetric> metrics = new List<DataCallMetric>();
        public List<DataCallMetric> Metrics
        {
            get { return metrics; }
            set { metrics = value; }
        }
    }
    public class DataCallMetric
    {
        public string MetricID { get; set; }
        public string MetricText { get; set; }
        public Picklist MetricPickList { get; set; }
    }
    public class Picklist
    {
        public string PicklistID { get; set; }
        public string MetricID { get; set; }
        private List<PicklistItem> pickListItems = new List<PicklistItem>();
        public List<PicklistItem> PicklistItems
        {
            get { return pickListItems; }
            set { pickListItems = value; }
        }
    }
    public class PicklistItem
    {
        public string PicklistItemID { get; set; }
        public string Text { get; set; }
    }
    public class MetricControl
    {
        public string ControlType { get; set; } 
    }
}




