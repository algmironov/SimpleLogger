using NUnit.Framework.Internal;

using SimpleLogger;

using Logger = SimpleLogger.Logger;

namespace SimpleLoggerTests
{

    [TestFixture]
    public class LoggerTests
    {
        private string _testLogsFolder;

        [SetUp]
        public void Setup()
        {
            _testLogsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestLogs");
            if (!Directory.Exists(_testLogsFolder))
            {
                Directory.CreateDirectory(_testLogsFolder);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_testLogsFolder))
            {
                Directory.Delete(_testLogsFolder, true);
            }
        }

        [Test]
        public void Log_Info_Message_Is_Written_To_File()
        {
            var loggerOptions = new SimpleLoggerOptions(LoggingType.FileOnly, _testLogsFolder);
            var logger = new Logger(loggerOptions);
            var logMessage = "This is an informational message.";

            logger.Info(logMessage);
            var logFilePath = GetCurrentLogFilePath();

            Assert.That(File.Exists(logFilePath), Is.True);
            var logContent = File.ReadAllText(logFilePath);
            Assert.That(logContent, Does.Contain(logMessage));
        }

        [Test]
        public void Log_Warn_Message_Is_Written_To_File()
        {
            var loggerOptions = new SimpleLoggerOptions(LoggingType.FileOnly, _testLogsFolder);
            var logger = new Logger(loggerOptions);
            var logMessage = "This is a warn message.";

            logger.Warn(logMessage);
            var logFilePath = GetCurrentLogFilePath();

            Assert.That(File.Exists(logFilePath), Is.True);
            var logContent = File.ReadAllText(logFilePath);
            Assert.That(logContent, Does.Contain(logMessage));
        }

        [Test]
        public void Log_Debug_Message_Is_Written_To_File()
        {
            var loggerOptions = new SimpleLoggerOptions(LoggingType.FileOnly, _testLogsFolder);
            var logger = new Logger(loggerOptions);
            var logMessage = "This is a debug message.";

            logger.Debug(logMessage);
            var logFilePath = GetCurrentLogFilePath();

            Assert.That(File.Exists(logFilePath), Is.True);
            var logContent = File.ReadAllText(logFilePath);
            Assert.That(logContent, Does.Contain(logMessage));
        }

        [Test]
        public void Log_Error_Message_Is_Written_To_File()
        {
            var loggerOptions = new SimpleLoggerOptions(LoggingType.FileOnly, _testLogsFolder);
            var logger = new Logger(loggerOptions);
            var logMessage = "This is an error message.";
            var exception = new Exception("Test exception");

            logger.Error(logMessage, exception);
            var logFilePath = GetCurrentLogFilePath();

            Assert.That(File.Exists(logFilePath), Is.True);
            var logContent = File.ReadAllText(logFilePath);
            Assert.That(logContent, Does.Contain(logMessage));
            Assert.That(logContent, Does.Contain("Test exception"));
        }

        private string GetCurrentLogFilePath()
        {
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var fileName = $"{currentDate}.log";
            return Path.Combine(_testLogsFolder, fileName);
        }

    }

}