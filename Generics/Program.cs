class Program
{
    static void Main()
    {
        
        Console.WriteLine("--- Basic valid/invalid test ---");
        try
        {
            ValidatableAmount validAmount = new ValidatableAmount(50, 0, 100);
            SafeValue<ValidatableAmount> safeAmount = new SafeValue<ValidatableAmount>(validAmount);
            Console.WriteLine($"Accepted valid amount. HasValue: {safeAmount.HasValue()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        try
        {
            ValidatableAmount invalidAmount = new ValidatableAmount(150, 0, 100);
            SafeValue<ValidatableAmount> badSafeAmount = new SafeValue<ValidatableAmount>(invalidAmount);
            Console.WriteLine("This should not print — invalid amount was accepted.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Correctly rejected invalid amount: {ex.Message}");
        }

        // Step 12: SetValue with valid and invalid calls, checking HasValue after failure
        Console.WriteLine("\n--- SetValue error handling ---");
        SafeValue<ValidatableAmount> tracker = null;
        try
        {
            ValidatableAmount initial = new ValidatableAmount(50, 0, 100);
            tracker = new SafeValue<ValidatableAmount>(initial);
            Console.WriteLine($"After construction, HasValue: {tracker.HasValue()}");

            ValidatableAmount goodUpdate = new ValidatableAmount(75, 0, 100);
            tracker.SetValue(goodUpdate);
            Console.WriteLine($"After valid SetValue, HasValue: {tracker.HasValue()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Unexpected error during setup: {ex.Message}");
        }

        try
        {
            ValidatableAmount badUpdate = new ValidatableAmount(999, 0, 100);
            tracker.SetValue(badUpdate);
            Console.WriteLine("This should not print — invalid SetValue succeeded.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Correctly rejected invalid SetValue: {ex.Message}");
            Console.WriteLine($"HasValue after failed SetValue: {tracker.HasValue()}");  // still true — old value untouched
        }

        // Step 13: edge case ranges
        Console.WriteLine("\n--- Edge case ranges ---");

        // Zero value edge case (min 0, max 0)
        try
        {
            ValidatableAmount zeroRange = new ValidatableAmount(0, 0, 0);
            SafeValue<ValidatableAmount> zeroSafe = new SafeValue<ValidatableAmount>(zeroRange);
            Console.WriteLine($"Zero-range (0 to 0) with value 0: accepted, HasValue: {zeroSafe.HasValue()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Zero-range test failed unexpectedly: {ex.Message}");
        }

        // Negative range (-100 to -50)
        try
        {
            ValidatableAmount negativeInRange = new ValidatableAmount(-75, -100, -50);
            SafeValue<ValidatableAmount> negSafe = new SafeValue<ValidatableAmount>(negativeInRange);
            Console.WriteLine($"Negative range (-100 to -50) with value -75: accepted, HasValue: {negSafe.HasValue()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Negative range test failed unexpectedly: {ex.Message}");
        }

        try
        {
            ValidatableAmount negativeOutOfRange = new ValidatableAmount(-10, -100, -50);
            SafeValue<ValidatableAmount> badNegSafe = new SafeValue<ValidatableAmount>(negativeOutOfRange);
            Console.WriteLine("This should not print.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Correctly rejected out-of-range negative value: {ex.Message}");
        }

        // Decimal values (0.01 to 1.00)
        try
        {
            ValidatableAmount decimalInRange = new ValidatableAmount(0.5m, 0.01m, 1.00m);
            SafeValue<ValidatableAmount> decSafe = new SafeValue<ValidatableAmount>(decimalInRange);
            Console.WriteLine($"Decimal range (0.01 to 1.00) with value 0.5: accepted, HasValue: {decSafe.HasValue()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Decimal range test failed unexpectedly: {ex.Message}");
        }
    }
}