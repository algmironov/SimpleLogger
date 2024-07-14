using System.Runtime.CompilerServices;

namespace SimpleLogger
{
    /// <summary>
    /// Provides logging functionality with different log levels.
    /// </summary>
    public class Logger
    {
        private string _folder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _folder = Path.Combine(appDirectory, "Logs");

            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
        }

        /// <summary>
        /// Logs a message with additional information about the source of the log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="memberName">The name of the calling method. This is automatically set by the compiler.</param>
        /// <param name="filePath">The file path of the source code. This is automatically set by the compiler.</param>
        /// <param name="lineNumber">The line number in the source code. This is automatically set by the compiler.</param>
        public void Log(string message,
                         [CallerMemberName] string memberName = "",
                         [CallerFilePath] string filePath = "",
                         [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                var source = filePath.Split('\\').Last();
                var file = GetCurrentLogFile();
                var logMessage = $"[{GetCurrentTime()}] {message} --- file: {source} --- method: {memberName} --- line: {lineNumber};\n";
                File.AppendAllTextAsync(file, logMessage);
                Console.WriteLine(logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception {ex} occured during log writing to file");
            }
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="memberName">The name of the calling method. This is automatically set by the compiler.</param>
        /// <param name="filePath">The file path of the source code. This is automatically set by the compiler.</param>
        /// <param name="lineNumber">The line number in the source code. This is automatically set by the compiler.</param>
        public void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"INFO: {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="memberName">The name of the calling method. This is automatically set by the compiler.</param>
        /// <param name="filePath">The file path of the source code. This is automatically set by the compiler.</param>
        /// <param name="lineNumber">The line number in the source code. This is automatically set by the compiler.</param>

        public void Warn(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"WARN: {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="memberName">The name of the calling method. This is automatically set by the compiler.</param>
        /// <param name="filePath">The file path of the source code. This is automatically set by the compiler.</param>
        /// <param name="lineNumber">The line number in the source code. This is automatically set by the compiler.</param>

        public void Error(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                var errorMessage = $"ERROR: {message} at : {ex.StackTrace.Split(':').Last()}";
                Log(errorMessage, memberName, filePath, lineNumber);
            }
            catch (Exception)
            {
                var errorMessage = $"ERROR: {message}";
                Log(errorMessage, memberName, filePath, lineNumber);
            }
            
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="memberName">The name of the calling method. This is automatically set by the compiler.</param>
        /// <param name="filePath">The file path of the source code. This is automatically set by the compiler.</param>
        /// <param name="lineNumber">The line number in the source code. This is automatically set by the compiler.</param>

        public void Fatal(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"FATAL: {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="memberName">The name of the calling method. This is automatically set by the compiler.</param>
        /// <param name="filePath">The file path of the source code. This is automatically set by the compiler.</param>
        /// <param name="lineNumber">The line number in the source code. This is automatically set by the compiler.</param>

        public void Debug(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            var infoMessage = $"DEBUG: {message}";
            Log(infoMessage, memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Gets the current log file based on the date.
        /// </summary>
        /// <returns>The path to the current log file.</returns>

        private string GetCurrentLogFile()
        {
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"{currentDate}.log";
            var filePath = Path.Combine(_folder, fileName);
            if (File.Exists(filePath))
            {
                return filePath;
            }
            File.Create(filePath);
            return filePath;
        }

        /// <summary>
        /// Gets the current time in the format "yyyy-MM-dd HH:mm:ss:fff".
        /// </summary>
        /// <returns>The current time as a string.</returns>

        private string GetCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
        }

    }
}
