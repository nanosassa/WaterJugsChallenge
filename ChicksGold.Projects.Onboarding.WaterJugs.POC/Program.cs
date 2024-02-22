using System;
using System.Collections.Generic;

namespace WaterJugChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the capacity of jug X:");
            int xCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the capacity of jug Y:");
            int yCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the desired amount of water (Z):");
            int zAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nSolution:");

            List<Tuple<int, int>> solution = SolveWaterJugProblem(xCapacity, yCapacity, zAmount);
            if (solution == null)
            {
                Console.WriteLine("No solution possible.");
            }
            else
            {
                DisplaySolution(solution);
            }
        }

        static List<Tuple<int, int>> SolveWaterJugProblem(int xCapacity, int yCapacity, int zAmount)
        {
            List<Tuple<int, int>> solution = new List<Tuple<int, int>>();

            if (zAmount % GCD(xCapacity, yCapacity) != 0 || zAmount > Math.Max(xCapacity, yCapacity))
                return null;

            int x = 0, y = 0;

            while (x != zAmount)
            {
                int transferAmount = Math.Min(x, yCapacity - y);
                x -= transferAmount;
                y += transferAmount;
                solution.Add(new Tuple<int, int>(x, y));

                if (x == zAmount)
                    break;

                if (x == 0)
                {
                    x = xCapacity;
                    solution.Add(new Tuple<int, int>(x, y));
                }
                else if (y == yCapacity)
                {
                    y = 0;
                    solution.Add(new Tuple<int, int>(x, y));
                }
            }

            return solution;
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static void DisplaySolution(List<Tuple<int, int>> solution)
        {
            Console.WriteLine("Bucket X | Bucket Y | Explanation");
            Console.WriteLine($"0 | 0 | Initial State");

            foreach (var step in solution)
            {
                Console.WriteLine($"{step.Item1} | {step.Item2} | {GetExplanation(step)}");
            }

            Console.WriteLine($"SOLVED!");
        }

        static string GetExplanation(Tuple<int, int> step)
        {
            if (step.Item1 == 0)
                return "Fill bucket X";
            else
                return "Transfer water from bucket Y to bucket X";
        }
    }
}
