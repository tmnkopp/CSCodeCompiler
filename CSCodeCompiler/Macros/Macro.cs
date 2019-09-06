﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCodeCompiler.Strategies;
using CSCodeCompiler.IO;
using CSCodeCompiler.Macros;
using System.Configuration;

namespace CSCodeCompiler.Macros
{ 
    public class Macro : IMacro
    {
        private StringBuilder _result = new StringBuilder();
        public Macro()
        { 
            Prepare();
        } 
        public void Prepare()
        { 
            IReader reader = new FileReader();
            _result.Append(reader.Read());
        }
        public void Execute(IStrategy strategy)
        {
            string result = "";       
            result = strategy.Execute(_result.ToString());
            _result.Clear();
            _result.Append(result); 
        }
        public void Execute(List<IStrategy> strategyCollection)
        { 
            foreach (var strategy in strategyCollection)
            {
                Execute(strategy); 
            }
            Cache.Write(_result.ToString());
        }
        public void Commit()
        {
            IWriter writer = new FileWriter();
            writer.Write(_result.ToString());
        }
    }
}
