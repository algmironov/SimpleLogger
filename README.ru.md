<html lang="ru">

### v1.1.2 Заметки о выпуске
- Добавлена возможность выбора: создавать папку по-умолчанию для логов или использовать свою директорию;
  
```csharp
// логгер с дефолтными значениями
var logger = new Logger();

// логгер. использующий свою директорию для логов
var logger = new Logger( new SimpleLoggerOptions
{
    Folder = "C:\\Users\\username\\logs"
}) ;
```
- Добавлена возможность выбора типа логирования:
      - запись логов только в консоль
      - запись логов только в файл
      - по-умолчанию запись логов в файл и консоль
  
```csharp
// запись логов только в консоль
var options = new SimpleLoggerOptions
{
    LoggingType = LoggingType.ConsoleOnly
};

var logger = new Logger(options);

// запись логов только в файл
var options = new SimpleLoggerOptions
{
    LoggingType = LoggingType.FileOnly,
};

var logger = new Logger(options);
```

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

## Примеры вывода логов
### Вывод в консоль:
![console](https://github.com/algmironov/SimpleLogger/blob/master/img/console.png)

### Запись в файл:
![logFile](https://github.com/algmironov/SimpleLogger/blob/master/img/logFile.png)

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
