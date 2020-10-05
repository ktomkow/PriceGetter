using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Settings
{
    public class LoggerSettings : ISettings
    {
        public string LogFilepath { get; set; }

        public LoggerSettings() { }

        public LoggerSettings(string filepath)
        {
            this.LogFilepath = filepath;
        }

        public bool IsInitialized()
        {
            return string.IsNullOrWhiteSpace(this.LogFilepath) == false;
        }
    }
}
