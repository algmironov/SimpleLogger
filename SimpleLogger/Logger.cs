using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SimpleLogger
{
    public class Logger
    {
        private string _folder;

        public Logger()
        {
            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _folder = Path.Combine(appDirectory, "Logs");

            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
        }

        public void Log(string message,
                         [CallerMemberName] string memberName = "",
                         [CallerFilePath] string filePath = "",
                         [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                var file = GetCurrentLogFile();
                var logMessage = $"{GetCurrentTime()} {message} at method: {memberName} in file: {filePath} at line: {lineNumber};\n";
                File.AppendAllTextAsync(file, logMessage);
                Console.WriteLine(logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception {ex} occured during log writing to file");
            }
        }

        public void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"INFO: {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        public void Warn(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"WARN: {GetCurrentTime()} {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        public void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"ERROR: {GetCurrentTime()} {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        public void Fatal(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"FATAL: {GetCurrentTime()} {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        public void Debug(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"DEBUG: {GetCurrentTime()} {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        private string GetCurrentLogFile()
        {
            var currentDate = DateTime.Now.ToString("ddMMyyyy");
            var fileName = $"{currentDate}.txt";
            var filePath = Path.Combine(_folder, fileName);
            if (File.Exists(filePath))
            {
                return filePath;
            }
            File.Create(filePath);
            return filePath;
        }

        private string GetCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
        }

    }
}
