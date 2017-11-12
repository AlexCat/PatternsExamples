using System;

namespace PatternsExamples.GoF.Structural.Adapter {

    public class Start
    {
        public Start()
        {
            new SqlServerLogSaverAdaper().Save(new ExceptionLogEntry());
        }
    }

    public class SqlServerLogSaverAdaper : ILogSaverAdaper {
        private readonly SqlServerLogSaver _sqlServerLogSaver = new SqlServerLogSaver();
        public void Save(LogEntry logEntry) {
            var simpleEntry = logEntry as SimpleLogEntry;
            if (simpleEntry != null) {
                _sqlServerLogSaver.Save(simpleEntry.EntryDateTime, simpleEntry.Severity.ToString(), simpleEntry.Message);
                return;
            }
            var exceptionEntry = (ExceptionLogEntry)logEntry;
            _sqlServerLogSaver.SaveException(exceptionEntry.EntryDateTime, exceptionEntry.Message, exceptionEntry.Exception);
        }
    }

    internal class SqlServerLogSaver {
        public void Save(DateTime simpleEntryEntryDateTime, string toString, string simpleEntryMessage) {
        }

        public void SaveException(DateTime exceptionEntryEntryDateTime, string exceptionEntryMessage, string exceptionEntryException) {
        }
    }

    public class SimpleLogEntry : LogEntry {
        public Severity Severity { get; set; }
    }

    public enum Severity {
        Low, Standard, High
    }

    public class ExceptionLogEntry : LogEntry {
        public string Exception { get; set; }
    }

    public abstract class LogEntry {
        public DateTime EntryDateTime { get; set; }
        public string Message { get; set; }
    }

    public interface ILogSaverAdaper {
    }
}
