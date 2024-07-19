# SimpleLogger

For English, please refer to [README.md](README.md).

Для русского языка, пожалуйста, смотрите [README.ru.md](README.ru.md).

### v1.1.2 Notes
- Addeв availability to choose: create default 'logs' folder or use custom path;
  
```csharp
// logger with default options
var logger = new Logger();

// logger with custom 'logs' folder
var logger = new Logger( new SimpleLoggerOptions
{
    Folder = "C:\\Users\\username\\logs"
}) ;
```
- Added availability to choose which logging type to use:
    - write only to console
    - write only to file
    - write as default to both file and console
 
```csharp
// logger with only console logs
var options = new SimpleLoggerOptions
{
    LoggingType = LoggingType.ConsoleOnly
};

var logger = new Logger(options);

// logger with only file logs
var options = new SimpleLoggerOptions
{
    LoggingType = LoggingType.FileOnly,
};

var logger = new Logger(options);
```

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
        var logger = new Logger();

        logger.Info("Hello, SimpleLogger!");

        try
        {
            int result = 10 / int.Parse("0");
        }
        catch (Exception ex)
        {
            logger.Error("An error occurred while performing the operation.", ex);
        }
    }
}

```

## Output examples
### Console output:
![console](https://github.com/algmironov/SimpleLogger/blob/master/img/console.png)

### File output:
![logFile](https://github.com/algmironov/SimpleLogger/blob/master/img/logFile.png)

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
