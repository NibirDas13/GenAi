using System;

public class LoopExample
{
    public static void Main(string[] args)
    {
        // ## Loop 1: Outer 'for' loop
        // This loop iterates 3 times (i = 0, 1, 2)
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Outer loop (i): {i}");
    
                // ## Loop 2: Inner 'while' loop
                // This loop depends on the outer loop's variable 'i'
                int j = 0;
                while (j <= i)
                {
                    Console.WriteLine($"  Inner while loop (j): {j}");
    
                    // ## Loop 3: Innermost 'for' loop
                    // This loop iterates 2 times (k = 0, 1) for each 'j' iteration
                    for (int k = 0; k < 2; k++)
                    {
                        Console.WriteLine($"    Innermost loop (k): {k} (i={i}, j={j})");
                    }
                    j++; // Increment j for the while loop condition
                }
                Console.WriteLine("  --- End of inner loops ---");
        }
    }
}
