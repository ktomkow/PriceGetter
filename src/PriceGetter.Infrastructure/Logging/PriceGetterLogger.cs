using PriceGetter.Infrastructure.Settings;
using Serilog;
using System;

namespace PriceGetter.Infrastructure.Logging
{
    public class PriceGetterLogger : IPriceGetterLogger
    {
        public PriceGetterLogger(LoggerSettings settings)
        {
            if (settings.IsInitialized())
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(settings.LogFilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            }
        }

        public PriceGetterLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }

        public void Debug(string text)
        {
            Log.Debug(text);
        }

        public void Debug(Exception exception, string text)
        {
            Log.Debug(exception, text);
        }

        public void Error(string text)
        {
            Log.Error(text);
        }

        public void Error(Exception exception, string text)
        {
            Log.Error(exception, text);
        }

        public void Information(string text)
        {
            Log.Information(text);
        }
    }
}
