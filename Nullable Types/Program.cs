using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Smart Temperature Sensor Starting Up...");

        // Task Group 1 Testing Area:
        SensorReading reading = new SensorReading();
        reading.Update(23.5m);
        Console.WriteLine($"Value: {reading.Value}, LastUpdated: {reading.LastUpdated}");

        reading.Update(null);
        Console.WriteLine($"Value: {reading.Value}, LastUpdated: {reading.LastUpdated}");

        // Task Group 2 Testing Area:
        Console.WriteLine("\n--- Validation ---");
        TemperatureSensor sensor = new TemperatureSensor();

        Console.WriteLine(sensor.ValidateReading());   // No reading available.

        sensor.Temperature.Update(75m);
        Console.WriteLine(sensor.ValidateReading());   // out of range

        sensor.Temperature.Update(22.5m);
        Console.WriteLine(sensor.ValidateReading());   // valid

        // Task Group 3 Testing Area:
        Console.WriteLine("\n--- Schedule ---");
        Schedule schedule = new Schedule();
        Console.WriteLine($"Day target (unset): {schedule.GetCurrentTarget(true)}");   // default

        schedule.DayTarget = 24m;
        Console.WriteLine($"Day target (set to 24): {schedule.GetCurrentTarget(true)}");

        // Task Group 4 Testing Area:
        Console.WriteLine("\n--- Status summaries ---");
        SensorReading statusTest = new SensorReading();
        Console.WriteLine(statusTest.GetStatusSummary());   // Status: Unknown, Valid: False — Status is still null

        statusTest.Update(19.9m);
        Console.WriteLine(statusTest.GetStatusSummary());   // Status: OK, Valid: True

        statusTest.Update(null);
        Console.WriteLine(statusTest.GetStatusSummary());   // Status: No Reading, Valid: False
    }
}

public class SensorReading
{
    public decimal? Value { get; private set; }
    public DateTime? LastUpdated { get; private set; }
    public ReadingStatus? Status { get; private set; }

    public void Update(decimal? value)
    {
        Value = value;

        if (Value != null)
        {
            LastUpdated = DateTime.Now;
            Status = new ReadingStatus { Message = "OK", IsValid = true };
        }
        else
        {
            LastUpdated = null;
            Status = new ReadingStatus { Message = "No Reading", IsValid = false };
        }
    }

    public string GetStatusSummary()
    {
        string message = Status?.Message ?? "Unknown";
        bool isValid = Status?.IsValid ?? false;
        return $"Status: {message}, Valid: {isValid}";
    }
}

public class TemperatureSensor
{
    private const decimal MinTemp = -40m;
    private const decimal MaxTemp = 50m;

    public SensorReading Temperature { get; private set; }

    public TemperatureSensor()
    {
        Temperature = new SensorReading();
    }

    public string ValidateReading()
    {
        if (!Temperature.Value.HasValue)
        {
            return "No reading available.";
        }

        if (Temperature.Value < MinTemp || Temperature.Value > MaxTemp)
        {
            return $"Reading {Temperature.Value} is out of range ({MinTemp} to {MaxTemp}).";
        }

        return $"Reading {Temperature.Value} is valid.";
    }
}

public class Schedule
{
    public decimal? DayTarget { get; set; }
    public decimal? NightTarget { get; set; }
    private const decimal DefaultTarget = 20m;

    public decimal GetCurrentTarget(bool isDaytime)
    {
        decimal? target = isDaytime ? DayTarget : NightTarget;
        return target ?? DefaultTarget;
    }
}

public class ReadingStatus
{
    public string? Message { get; set; }
    public bool? IsValid { get; set; }
}