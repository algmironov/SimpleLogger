using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    /// <summary>
    /// Specifies the type of logging to be performed.
    /// </summary>
    public enum LoggingType
    {
        /// <summary>
        /// Logs will be written to the console only.
        /// </summary>
        ConsoleOnly,
        /// <summary>
        /// Logs will be written to files only.
        /// </summary>
        FileOnly,
        /// <summary>
        /// Logs will be written to both files and the console.
        /// </summary>
        FileAndConsole
    }
}
