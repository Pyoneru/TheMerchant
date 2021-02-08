using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public class CLIMenu
    {
        #region Properties and fields
        public string Title { get; set; }

        public string Description { get; set; }

        public int Count
        {
            get
            {
                return cliOptions.Count;
            }
            private set
            {
                Count = value;
            }
        }

        private List<string> cliOptions;
        #endregion

        #region Ctors
        public CLIMenu()
        {
            Title = Description = "";
            cliOptions = new List<string>();
        }

        public CLIMenu(string title)
        {
            Description = "";
            Title = title;
            cliOptions = new List<string>();
        }

        public CLIMenu(string title, string description)
        {
            Title = title;
            Description = description;
            cliOptions = new List<string>();
        }
        #endregion

        #region Methods
        public string GetOptionName(int index)
        {
            if (index >= 0 && index < Count)
                return cliOptions[index];
            else return null;
        }

        public void Add(string cliOption)
        {
            cliOptions.Add(cliOption);
        }

        public void RemoveAt(int index)
        {
            cliOptions.RemoveAt(index);
        }
        #endregion
    }
}
