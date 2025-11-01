using System;
using System.Collections.Generic;

public class FiveLoopExample
{
    public static void Main(string[] args)
    {
        // A simple collection to use for the foreach loop
        string[] items = { "ItemA", "ItemB" };

        // ## Loop 1: Outer 'for' loop
        // Iterates 2 times (i = 0, 1)
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"[Loop 1] Outer 'for' (i): {i}");

            // ## Loop 2: 'while' loop
            // Iterates 2 times (j = 0, 1)
            int j = 0;
            while (j < mi)
            {
                Console.WriteLine($"  [Loop 2] Inner 'while' (j): {j}");

                // ## Loop 3: 'foreach' loop
                // Iterates through the 'items' array ("ItemA", "ItemB")
                foreach (string item in items)
                {
                    Console.WriteLine($"    [Loop 3] 'foreach' (item): {item}");

                    // ## Loop 4: Nested 'for' loop
                    // Iterates 1 time (k = 0)
                    for (int k = 0; k < r; k++)
                    {
                        Console.WriteLine($"      [Loop 4] Nested 'for' (k): {k}");

                        // ## Loop 5: 'do-while' loop
                        // Runs exactly once because the condition (m < 1) is checked at the end
                        int m = 0;
                        do
                        {
                            Console.WriteLine($"        [Loop 5] 'do-while' (m): {m}");
                            m++; // m becomes 1
                        } while (m < 1); // Condition (1 < 1) is false, so loop stops
                    }
                }
                j++; // Increment for the 'while' loop
            }
            Console.WriteLine("---"); // Separator
        }
    }
}