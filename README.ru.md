<html lang="ru">

## SimpleLogger

SimpleLogger - ��� ������� � ������ ���������� ��� ����������� �� C#, ����������� ���������� ��������� ���������� ������ (��������������, ��������������, ������, ��������� ������ � ���������� ���������) � ����� � ���������� ������������ ����� �� ����.

### �����������

- ����������� ��������� � ��������� �������, �����, ������ � ������ ����
- �������������� �������� ����� ��� ����� � ������ ����� � ������� �� �����
- ������� ������ ��� ����������� ��������� ������� ���������:�`Info`,�`Warn`,�`Error`,�`Fatal`,�`Debug`

### ���������

�� ������ ���������� SimpleLogger ����� NuGet �����-��������. ����������� ��������� ������� � ������� ���������� �������:

```sh
Install-Package SimpleLogger
```

��� ����� .NET CLI:

```sh
dotnet add package SimpleLoggerByAlgmironov
```

### �������������

#### ������ ����

��� ������, ��� ������������ SimpleLogger � ����� �������:

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
            // ������ ����, ������� �������� ����������
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

### �������� �������

`Log`����������� ���-��������� � �������������� ����������� � ����� ������.

```csharp
void Log(string message,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string filePath = "",
         [CallerLineNumber] int lineNumber = 0)
```

`Info`����������� �������������� ���������.

```csharp
void Info(string message,
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string filePath = "",
          [CallerLineNumber] int lineNumber = 0)
```

`Warn`����������� ��������������� ���������.

```csharp
void Warn(string message,
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string filePath = "",
          [CallerLineNumber] int lineNumber = 0)
```

`Error`����������� ��������� �� ������ ������ � �������� ����������.

```csharp
void Error(string message, Exception ex,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

`Fatal`����������� ��������� � ��������� ������.

```csharp
void Fatal(string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```

`Debug`����������� ���������� ���������.

```csharp
void Debug(string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string filePath = "",
           [CallerLineNumber] int lineNumber = 0)
```
