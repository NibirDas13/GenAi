using System;

public class ComplexNestedLoops
{
    public static void Main(string[] args)
    {
        // --- 1. Get User Input ---
        Console.Write("Enter a base number for the loop size (e.g., 5): ");
        int baseSize;

        // Use int.TryParse for safe input validation
        // This loops until the user enters a valid positive number.
        while (!int.TryParse(Console.ReadLine(), out baseSize) || baseSize <= 0)
        {
            Console.Write("Invalid input. Please enter a positive whole number: ");
        }

        Console.WriteLine($"--- Starting loops with base size: {baseSize} ---\n");
        
        // Use 'long' in case the user enters a large number,
        // as the iteration count grows very quickly.
        long totalInnerIterations = 0;

        // --- 2. Complex Nested Loops ---

        // ## Loop 1: Outer 'for' loop
        // This loop's length is directly controlled by the user's 'baseSize'.
        for (int i = 1; i <= baseSize; i++)
        {
            Console.WriteLine($"Loop 1 (i = {i})");

            // ## Loop 2: Middle 'while' loop
            // This loop's length depends on the current value of 'i'.
            // It will run 'i' times.
            int j = 1;
            while (j <= i)
            {
                Console.WriteLine($"  Loop 2 (j = {j})");

                // ## Loop 3: Inner 'for' loop
                // This loop's length depends on the current value of 'j'.
                // It will run 'j' times.
                for (int k = 1; k <= j; k++)
                {
                    Console.WriteLine($"    Loop 3 (k = {k}) - Processing work...");
                    totalInnerIterations++; // Count every single innermost action
                }
                
                j++; // Increment the counter for the 'while' loop
            }
            Console.WriteLine("  ---"); // Separator for clarity
        }

        // --- 3. Final Result ---
        Console.WriteLine("\nLooping complete.");
        Console.WriteLine($"Total 'innermost' operations performed: {totalInnerIterations}");
    }
}