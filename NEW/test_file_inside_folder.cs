using System;
using System.Threading;

public class InefficientLoopProcessor
{
    // WARNING: Use a base size of 5 or less. The complexity is exponential!
    private const int MaxBaseSize = 10;
    
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Highly Inefficient Nested Loop Program ---");
        Console.Write($"Enter a small base number (recommended max: {MaxBaseSize}): ");
        
        int baseSize;

        // Safely get user input, enforcing a maximum to prevent crashes/freezes.
        while (!int.TryParse(Console.ReadLine(), out baseSize) || baseSize <= 0 || baseSize > MaxBaseSize)
        {
            Console.Write($"Invalid input. Please enter a positive whole number, max {MaxBaseSize}: ");
        }

        Console.WriteLine($"\nProcessing started with Base Size: {baseSize}. This will be slow...");
        
        long totalCalculations = 0;
        Random random = new Random();

        // 1. First Loop (i): Controlled by User Input (N iterations)
        for (int i = 1; i <= baseSize; i++)
        {
            // 2. Second Loop (j): Dependent on i (runs i times)
            for (int j = 1; j <= i; j++)
            {
                // 3. Third Loop (k): Dependent on j (runs j times)
                for (int k = 1; k <= j; k++)
                {
                    // 4. Fourth Loop (l): Dependent on a constant factor (5 times)
                    for (int l = 0; l < 5; l++)
                    {
                        // 5. Fifth Loop (m): Inefficiently depends on i and baseSize
                        // It ensures runs regardless of how small i or j is.
                        for (int m = baseSize; m >= i; m--)
                        {
                            // Intentionally adding overhead and delay:
                            // a) Use of Math.Pow is slightly heavy inside a loop
                            // b) Random number generation adds small overhead
                            // c) Thread.Sleep is the primary source of inefficiency
                            double result = Math.Pow(i + j + k + l, 2) * random.NextDouble();
                            
                            // Deliberate 1ms pause per innermost calculation
                            Thread.Sleep(1); 
                            
                            totalCalculations++;
                            
                            // Print status sparingly to avoid massive console spam
                            if (totalCalculations % 100 == 0)
                            {
                                Console.CursorLeft = 0;
                                Console.Write($"Iterations completed: {totalCalculations}...");
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("\n\n--- Process Finished ---");
        Console.WriteLine($"Final Base Size: {baseSize}");
        Console.WriteLine($"Total Innermost Calculations (with 1ms sleep each): {totalCalculations}");
        Console.WriteLine($"Estimated Runtime (ms): {totalCalculations}");
    }
}
