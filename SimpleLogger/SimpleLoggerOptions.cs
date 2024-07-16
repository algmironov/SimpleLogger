using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    /// <summary>
    /// Provides configuration options for the SimpleLogger.
    /// </summary>
    public class SimpleLoggerOptions
    {
        /// <summary>
        /// Specifies the type of logging to be performed.
        /// Possible values include: FileOnly, ConsoleOnly, and FileAndConsole.
        /// Default is FileAndConsole.
        /// </summary>
        public LoggingType LoggingType { get; set; } = LoggingType.FileAndConsole;

        /// <summary>
        /// Specifies the folder path where log files will be stored.
        /// Default is a folder named "Logs" within the application's base directory.
        /// </summary>
        public string Folder {  get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoggerOptions"/> class with default values.
        /// </summary>
        public SimpleLoggerOptions() 
        {
            Folder = InitDirectory();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoggerOptions"/> class with the specified logging type.
        /// </summary>
        /// <param name="loggingType">The type of logging to be performed.</param>
        public SimpleLoggerOptions(LoggingType loggingType)
        {
            LoggingType = loggingType;
            Folder = InitDirectory();
        }

        private static string InitDirectory()
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoggerOptions"/> class with the specified logging type and folder path.
        /// </summary>
        /// <param name="loggingType">The type of logging to be performed.</param>
        /// <param name="folderPath">The folder path where log files will be stored.</param>
        public SimpleLoggerOptions(LoggingType loggingType, string folderPath)
        {
            LoggingType = loggingType;

            if(Directory.Exists(folderPath))
            {
                Folder = folderPath;
            }
            else
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
