using System;
using System.ComponentModel.Composition;
using Ruminoid.Studio.Storage;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Ruminoid.Studio.Utils
{
    [Export]
    public sealed class LogHelper : IDisposable
    {
        private readonly Logger _logger;

        public LogHelper()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.Async(x => x.Console())
                .WriteTo.Async(x => x.File(StorageHelper.GetFileToWrite("Logs", "RuminoidStudio-.log")))
                .CreateLogger();
        }

        public ContextLogger CreateContextLogger(object context)
        {
            return new ContextLogger(_logger, ReflectionHelper.GetFullName(context));
        }

        public void Dispose()
        {
            _logger.Dispose();
            Log.CloseAndFlush();
        }
    }

    public sealed class ContextLogger
    {
        private readonly Logger _logger;

        // ReSharper disable once InconsistentNaming
        private readonly string caller;

        internal ContextLogger(Logger logger, string caller)
        {
            _logger = logger;
            this.caller = caller;
        }

        public void Log(
            LogEventLevel level,
            string messageTemplate,
            params object[] propertyValues)
        {
            object[] newPropertyValues = new object[propertyValues.Length + 1];
            newPropertyValues[0] = caller;
            propertyValues.CopyTo(newPropertyValues, 1);

            _logger.Write(level, "{Caller} " + messageTemplate, newPropertyValues);
        }
    }
}
