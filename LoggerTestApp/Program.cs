using System;

using SimpleLogger;

public class Program
{
    static void Main(string[] args)
    {
        var logger = new Logger();

        logger.Log("Просто Log");
        logger.Info("just Info message");
        logger.Warn("just WARN message");
        logger.Error("just ERROR message");
        logger.Log("1Просто Log");
        logger.Info("just Info message");
        logger.Warn("just WARN message");
        logger.Error("just ERROR message");

        logger.Info("Application started successfully.");
        logger.Warn("Low disk space on drive C:.");
        try
        {
            throw new NullReferenceException("Example exception");
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
        logger.Debug("Entering method Main with parameters: args");

    }
}

