using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public class CLIOption
    {
        public string Name { get; }
        public Action Action { get; }
        public CLIOption (string optionName, Action actionToPerform)
        {
            Name = optionName;
            Action = actionToPerform;
        }
    }
}
