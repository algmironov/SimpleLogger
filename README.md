# SimpleLogger

SimpleLogger is a simple and powerful logging library for C# that allows logging messages of various levels (information, warnings, errors, fatal errors, and debug messages) to files, supporting log rotation by day.

## Features

- Logs messages with timestamps, file names, method names, and line numbers
- Automatically creates the logs folder and log files with date-based names
- Convenient methods for logging messages at different levels: `Info`, `Warn`, `Error`, `Fatal`, `Debug`


## Installation

You can install SimpleLogger via the NuGet package manager. Use the following command in the Package Manager Console:

```sh
Install-Package SimpleLoggerByAlgmironov
```

Or via .NET CLI:
```sh
dotnet add package SimpleLoggerByAlgmironov
```

## Usage
### Code example

Here is an example of how to use SimpleLogger in your project:

```csharp

using SimpleLogger;
using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();

        try
        {
            // Example code that causes an exception
            int result = 10 / int.Parse("0");
        }
        catch (Exception ex)
        {
            logger.Error("An error occurred while performing the operation.", ex);
        }

        logger.Info("This is an informational message.");
        logger.Warn("This is a warning message.");
        logger.Fatal("This is a fatal error message.");
        logger.Debug("This is a debug message.");
    }
}

```

## Method Descriptions
`Log`
Logs a message with additional information about the source of the log.

```csharp
void Log(string message,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string filePath = "",
         [CallerLineNumber] int lineNumber = 0)
```

`Info`
Logs an informational message.

```csharp
void Info(string message,
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string filePath = "",
          [CallerLineNumber] int lineNumber = 0)
```
`Warn`
Logs a warning message.

```csharp
void Warn(string message,
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string filePath = "",
          [CallerLineNumber] int lineNumber = 0)
```

`Error`
Logs an error message along with exception details.

```csharp
void Error(string message, Exception ex,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

`Fatal`
Logs a fatal error message.

```csharp
void Fatal(string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

`Debug`
Logs a debug message.

```csharp
void Debug(string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

## License
This project is licensed under the MIT License. See the LICENSE file for details.
