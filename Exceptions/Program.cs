using System;
using System.Collections.Generic;

public class InvalidLogFormatException : Exception
{
    public InvalidLogFormatException(string message) : base(message)
    {
    }
}

public class LogProcessor
{
    private readonly List<string> logEntries;

    public LogProcessor(List<string> logEntries)
    {
        this.logEntries = logEntries ?? throw new ArgumentNullException(nameof(logEntries));
    }

    public void ProcessLogs()
    {
        int processedCount = 0;
        int totalCount = 0;

        try
        {
            foreach (string entry in logEntries)
            {
                totalCount++;
                try
                {
                    ProcessLogEntry(entry);
                    processedCount++;
                }
                catch (InvalidLogFormatException ex) when (entry != null && entry.Contains('|'))
                {
                    Console.WriteLine($"Format error (has separator): {ex.Message}");
                }
                catch (InvalidLogFormatException ex)
                {
                    Console.WriteLine($"Log format error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing entry: {ex.Message}");
                }
            }
        }
        finally
        {
            Console.WriteLine($"Processed {processedCount} out of {totalCount} entries");
        }
    }

    private void ProcessLogEntry(string entry)
    {
        if (string.IsNullOrEmpty(entry))
        {
            throw new InvalidLogFormatException("Empty or null log entry");
        }

        string[] parts = entry.Split('|');

        if (parts.Length != 3)
        {
            throw new InvalidLogFormatException("Invalid format. Expected: timestamp|level|message");
        }

        string level = parts[1].Trim().ToUpper();

        if (level != "ERROR" && level != "WARN" && level != "INFO")
        {
            throw new InvalidLogFormatException($"Invalid log level: {level}. Expected: ERROR, WARN, or INFO");
        }

        Console.WriteLine($"Log Entry - Time: {parts[0].Trim()}, Level: {level}, Message: {parts[2].Trim()}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Testing null list handling");
        try
        {
            LogProcessor nullProcessor = new LogProcessor(null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Null list error: {ex.Message}");
        }
        Console.WriteLine();

        Console.WriteLine("Testing malformed entry");
        List<string> malformedLogs = new List<string>
        {
            "",
            "2024-01-15 10:30:00|INFO|Application started",
            "bad format",
            "2024-01-15 10:31:00|WARN|Low memory warning"
        };
        LogProcessor processor = new LogProcessor(malformedLogs);
        processor.ProcessLogs();
        Console.WriteLine();

        Console.WriteLine("Testing invalid log levels");
        List<string> invalidLevelLogs = new List<string>
        {
            "2024-01-15 10:30:00|DEBUG|This should not work",
            "2024-01-15 10:30:00|INFO|Application started",
            "2024-01-15 10:30:00|CRITICAL|This also should not work"
        };
        processor = new LogProcessor(invalidLevelLogs);
        processor.ProcessLogs();
        Console.WriteLine();

        Console.WriteLine("Testing valid logs");
        List<string> validLogs = new List<string>
        {
            "2024-01-15 10:30:00|INFO|Application started",
            "2024-01-15 10:31:00|WARN|Low memory warning",
            "2024-01-15 10:32:00|ERROR|Process crashed"
        };
        processor = new LogProcessor(validLogs);
        processor.ProcessLogs();
    }
}