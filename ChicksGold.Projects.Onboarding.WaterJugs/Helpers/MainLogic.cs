using ChicksGold.Projects.Onboarding.WaterJugs.Models;
using System;
using System.Collections.Generic;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Helpers
{
    // The MainLogic class contains the main logic for solving the water jug problem.
    public static class MainLogic
    {
        // The Solve method solves the water jug problem for given capacities of the jugs and a target amount of water.
        // It uses a breadth-first search algorithm to explore all possible states of the jugs.
        public static List<State> Solve(int x, int y, int z)
        {
                        
            // Validation of non negative arguments
            if (x <= 0 || y <= 0 || z <= 0)
            {
                throw new ArgumentException("X, Y, and Z must be greater than 0.");
            }

            // The visited set keeps track of the states that have already been visited.
            var visited = new HashSet<string>();

            // The queue stores the states to be visited, along with the actions that led to each state.
            var queue = new Queue<Tuple<Jug, Jug, List<State>>>();

            // Initially, both jugs are empty.
            queue.Enqueue(new Tuple<Jug, Jug, List<State>>(new Jug(x), new Jug(y), new List<State>()));

            // The algorithm continues until all states have been visited.
            while (queue.Count > 0)
            {
                // Dequeue the next state and the corresponding list of actions.
                var (jugX, jugY, actions) = queue.Dequeue();

                // If either jug contains the target amount of water, a solution has been found.
                if (jugX.CurrentAmount == z || jugY.CurrentAmount == z)
                {
                    return actions;
                }

                // The current state is represented as a string.
                var state = $"{jugX.CurrentAmount},{jugY.CurrentAmount}";

                // If the current state has already been visited, skip it.
                if (visited.Contains(state))
                {
                    continue;
                }

                // Mark the current state as visited.
                visited.Add(state);

                // The following blocks of code enqueue the states resulting from each possible action.
                // Each new state is accompanied by a new list of actions, which is a copy of the current list of actions plus the new action.

                // Fill jug X
                var newJugX = new Jug(x) { CurrentAmount = x };
                var newActions = new List<State>(actions) { new State { BucketX = newJugX.CurrentAmount, BucketY = jugY.CurrentAmount, Explanation = "Fill bucket X" } };
                queue.Enqueue(new Tuple<Jug, Jug, List<State>>(newJugX, jugY, newActions));

                // Fill jug Y
                var newJugY = new Jug(y) { CurrentAmount = y };
                newActions = new List<State>(actions) { new State { BucketX = jugX.CurrentAmount, BucketY = newJugY.CurrentAmount, Explanation = "Fill bucket Y" } };
                queue.Enqueue(new Tuple<Jug, Jug, List<State>>(jugX, newJugY, newActions));

                // Empty jug X
                newJugX = new Jug(x) { CurrentAmount = 0 };
                newActions = new List<State>(actions) { new State { BucketX = newJugX.CurrentAmount, BucketY = jugY.CurrentAmount, Explanation = "Empty bucket X" } };
                queue.Enqueue(new Tuple<Jug, Jug, List<State>>(newJugX, jugY, newActions));

                // Empty jug Y
                newJugY = new Jug(y) { CurrentAmount = 0 };
                newActions = new List<State>(actions) { new State { BucketX = jugX.CurrentAmount, BucketY = newJugY.CurrentAmount, Explanation = "Empty bucket Y" } };
                queue.Enqueue(new Tuple<Jug, Jug, List<State>>(jugX, newJugY, newActions));

                // Transfer from X to Y
                int amountToTransfer = Math.Min(jugX.CurrentAmount, y - jugY.CurrentAmount);
                newJugX = new Jug(x) { CurrentAmount = jugX.CurrentAmount - amountToTransfer };
                newJugY = new Jug(y) { CurrentAmount = jugY.CurrentAmount + amountToTransfer };
                newActions = new List<State>(actions) { new State { BucketX = newJugX.CurrentAmount, BucketY = newJugY.CurrentAmount, Explanation = "Transfer from bucket X to bucket Y" } };
                queue.Enqueue(new Tuple<Jug, Jug, List<State>>(newJugX, newJugY, newActions));

                // Transfer from Y to X
                amountToTransfer = Math.Min(jugY.CurrentAmount, x - jugX.CurrentAmount);
                newJugX = new Jug(x) { CurrentAmount = jugX.CurrentAmount + amountToTransfer };
                newJugY = new Jug(y) { CurrentAmount = jugY.CurrentAmount - amountToTransfer };
                newActions = new List<State>(actions) { new State { BucketX = newJugX.CurrentAmount, BucketY = newJugY.CurrentAmount, Explanation = "Transfer from bucket Y to bucket X" } };
                queue.Enqueue(new Tuple<Jug, Jug, List<State>>(newJugX, newJugY, newActions));
            }

            // If all states have been visited and no solution has been found, return a state indicating that there is no solution.
            var noSolution = new List<State>();
            noSolution.Add(new State() { Explanation = "No Solution" });

            return noSolution;
        }
    }
}
