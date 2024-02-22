using ChicksGold.Projects.Onboarding.WaterJugs.Models;
using System.IO;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Helpers
{
    public static class Solver
    {
        public static List<State> SolveWaterJugChallenge(int jug1Capacity, int jug2Capacity, int targetAmount)
        {
            // Use BFS to explore possible jug states
            Queue<(Jug, Jug, State)> queue = new Queue<(Jug, Jug, State)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            State initialState = new State { BucketX = 0, BucketY = 0, Explanation = "Initial State" };
            queue.Enqueue((new Jug(jug1Capacity), new Jug(jug2Capacity), initialState));

            while (queue.Count > 0)
            {
                (Jug jug1, Jug jug2, State state) = queue.Dequeue();

                if (visited.Contains((jug1.CurrentAmount, jug2.CurrentAmount)))
                {
                    continue;
                }

                visited.Add((jug1.CurrentAmount, jug2.CurrentAmount));

                if (jug1.CurrentAmount == targetAmount)
                {
                    // Solution found, return path as list of states
                    List<State> solutionPath = new List<State>();
                    while (state != null)
                    {
                        solutionPath.Insert(0, state);
                        state = state.ParentState;
                    }
                    return solutionPath;
                }

                // Explore possible actions (fill, empty, transfer)
                ExploreAction(jug1, jug2, queue, state);
            }

            return null; // No solution found
        }

        private static void ExploreAction(Jug jug1, Jug jug2, Queue<(Jug, Jug, State)> queue, State parentState)
        {
            // Fill Jug 1
            Jug newJug1 = new Jug(jug1.Capacity);
            newJug1.CurrentAmount = jug1.Capacity;
            State newState = new State { BucketX = newJug1.CurrentAmount, BucketY = jug2.CurrentAmount, Explanation = "Fill Jug X" };
            newState.ParentState = parentState;
            queue.Enqueue((newJug1, jug2, newState));

            // Empty Jug 1
            newJug1 = new Jug(jug1.Capacity);
            newState = new State { BucketX = 0, BucketY = jug2.CurrentAmount, Explanation = "Empty Jug X" };
            newState.ParentState = parentState;
            queue.Enqueue((newJug1, jug2, newState));

            // Transfer Jug 1 to Jug 2
            if (jug1.CurrentAmount > 0)
            {
                Jug newJug2 = new Jug(jug2.Capacity);
                newJug2.CurrentAmount = jug2.CurrentAmount + Math.Min(jug1.CurrentAmount, jug2.Capacity - jug2.CurrentAmount);
                newState = new State
                {
                    BucketX = jug1.CurrentAmount - Math.Min(jug1.CurrentAmount, jug2.Capacity - jug2.CurrentAmount),
                    BucketY = newJug2.CurrentAmount,
                    Explanation = $"Transfer {Math.Min(jug1.CurrentAmount, jug2.Capacity - jug2.CurrentAmount)} from Jug X to Jug Y"
                };
                newState.ParentState = parentState;
                queue.Enqueue((jug1, newJug2, newState));
            }

            // Transfer Jug 2 to Jug 1
            if (jug2.CurrentAmount > 0)
            {
                Jug newJug1t = new Jug(jug1.Capacity);
                newJug1.CurrentAmount = jug1.CurrentAmount + Math.Min(jug2.CurrentAmount, jug1.Capacity - jug1.CurrentAmount);
                newState = new State
                {
                    BucketX = newJug1t.CurrentAmount,
                    BucketY = jug2.CurrentAmount - Math.Min(jug2.CurrentAmount, jug1.Capacity - jug1.CurrentAmount),
                    Explanation = $"Transfer {Math.Min(jug2.CurrentAmount, jug1.Capacity - jug1.CurrentAmount)} from Jug Y to Jug X"
                };
                newState.ParentState = parentState;
                queue.Enqueue((newJug1t, jug2, newState));
            }
        }
    }


}
