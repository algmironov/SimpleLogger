<html lang="ru">

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
