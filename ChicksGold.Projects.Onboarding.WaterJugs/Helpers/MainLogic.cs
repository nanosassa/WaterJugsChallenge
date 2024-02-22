using ChicksGold.Projects.Onboarding.WaterJugs.Models;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Helpers
{
    public static class MainLogic
    {
        public static List<State> Solve(int x, int y, int z)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<Tuple<Jug, Jug, List<State>>>();
            queue.Enqueue(new Tuple<Jug, Jug, List<State>>(new Jug(x), new Jug(y), new List<State>()));

            while (queue.Count > 0)
            {
                var (jugX, jugY, actions) = queue.Dequeue();

                if (jugX.CurrentAmount == z || jugY.CurrentAmount == z)
                {
                    return actions;
                }

                var state = $"{jugX.CurrentAmount},{jugY.CurrentAmount}";
                if (visited.Contains(state))
                {
                    continue;
                }

                visited.Add(state);

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

            // If we have explored all possible states and have not found a solution, we return a state to indicate that there is no solution.
            var noSolution = new List<State>();
            noSolution.Add(new State() { Explanation = "No Solution" });

            return noSolution ;
        }
    }
}
