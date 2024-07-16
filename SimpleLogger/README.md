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

-----------------------------------------------------------------------------------

## SimpleLogger

SimpleLogger - это простая и мощная библиотека для логирования на C#, позволяющая логировать сообщения различного уровня (информационные, предупреждения, ошибки, фатальные ошибки и отладочные сообщения) в файлы с поддержкой формирования логов по дням.

### Особенности

- Логирование сообщений с указанием времени, файла, метода и строки кода
- Автоматическое создание папки для логов и файлов логов с именами по датам
- Удобные методы для логирования различных уровней сообщений: `Info`, `Warn`, `Error`, `Fatal`, `Debug`

### Установка

Вы можете установить SimpleLogger через NuGet пакет-менеджер. Используйте следующую команду в консоли диспетчера пакетов:

```sh
Install-Package SimpleLogger
```

Или через .NET CLI:

```sh
dotnet add package SimpleLoggerByAlgmironov
```

### Использование

#### Пример кода

Вот пример, как использовать SimpleLogger в вашем проекте:

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
            // Пример кода, который вызывает исключение
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

### Описание методов

`Log` Записывает лог-сообщение с дополнительной информацией о месте вызова.

```csharp
void Log(string message,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string filePath = "",
         [CallerLineNumber] int lineNumber = 0)
```

`Info` Записывает информационное сообщение.

```csharp
void Info(string message,
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string filePath = "",
          [CallerLineNumber] int lineNumber = 0)
```

`Warn` Записывает предупреждающее сообщение.

```csharp
void Warn(string message,
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string filePath = "",
          [CallerLineNumber] int lineNumber = 0)
```

`Error` Записывает сообщение об ошибке вместе с деталями исключения.

```csharp
void Error(string message, Exception ex,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

`Fatal` Записывает сообщение о фатальной ошибке.

```csharp
void Fatal(string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

`Debug` Записывает отладочное сообщение.

```csharp
void Debug(string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```