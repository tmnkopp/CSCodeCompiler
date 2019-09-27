﻿using CSCodeCompiler.Extentions;
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
                    string idtext = metric.IDText;
                    string met = metric.MetricText;
                }
            }
        }
    }
    

    public class DataCallTicket
    {
        public string Key{ get; set; } 
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
        public string IDText { get; set; }
        public string MetricText { get; set; }
        public string MetricPickList { get; set; }
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
            DirectoryInfo DI = new DirectoryInfo($"{AppSettings.BasePath}\\jira\\saop2019");
            foreach (var file in DI.GetFiles("*.xml", SearchOption.AllDirectories))
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                FileReader r = new FileReader(file.FullName);
                htmlDoc.LoadHtml(r.Read());

                DataCallTicket ticket = new DataCallTicket();
                ticket.Key = htmlDoc.DocumentNode.SelectSingleNode("//item/key").InnerHtml;  

                string desc = htmlDoc.DocumentNode.SelectSingleNode("//item/description").InnerHtml;
                desc = WebUtility.HtmlDecode(desc);
                desc = desc.CleanHTML();
                 
                htmlDoc.LoadHtml(desc); 
                HtmlNodeCollection pnodes = htmlDoc.DocumentNode.SelectNodes("//p");
                
                DataCallMetric metric = new DataCallMetric(); 
                foreach (var pnode in pnodes)
                { 
                    rex = new Regex(@"<p>.{0,2}Section");
                    if (rex.IsMatch(pnode.OuterHtml))
                    { 
                        ticket.Section = pnode.InnerHtml;
                    } 

                    if (metric.IDText == null)
                    {
                        rex = new Regex(@"\d{1,3}\w{1,2}\.");
                        if (rex.IsMatch(pnode.OuterHtml))
                        { 
                            metric.IDText = pnode.InnerHtml;
                        }
                    }
                    if (metric.MetricText == null && metric.IDText != null)
                    {
                        rex = new Regex(@"<p>.{15,500}</p>");
                        if (rex.IsMatch(pnode.OuterHtml))
                        {
                            metric.MetricText = pnode.InnerHtml;
                            ticket.Metrics.Add(metric);
                            metric = new DataCallMetric();
                        }
                    }
                    //if (metric.MetricPickList == null && metric.MetricText != null)
                    //{
                    //    rex = new Regex(@"ol>.{15,500}/ol>");
                    //    if (rex.IsMatch(pnode.OuterHtml))
                    //    {
                    //        metric.MetricPickList = pnode.InnerHtml;
                    //        ticket.Metrics.Add(metric);
                    //        metric = new DataCallMetric();
                    //    }
                    //} 
                }
                //ticket.Metrics.Add(metric);
                Tickets.Add(ticket); 
            } 
        } 
    }
}



//inserting metric tags for readability 
//int cnt = 1;
//foreach (var match in Regex.Matches(desc, @"<p>\d{1,3}\w{1,2}\.")) {
//    string metID = match.ToString();
//    if (cnt > 1)
//        desc = desc.Replace(metID, $"</metric><metric id=\"{cnt.ToString()}\">{metID}");
//    else
//        desc = desc.Replace(metID, $"<metric id=\"{cnt.ToString()}\">{metID}");
//    cnt++;
//}
// -- inserting metric tags for readability 
