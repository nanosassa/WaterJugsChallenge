using ChicksGold.Projects.Onboarding.WaterJugs.Models;
using System.ComponentModel;
using System.Linq;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Helpers
{
    public static class MainLogic
    {
       //public static List<State> Solve(Jug jugX, Jug jugY, int target)
       // {
       //     Queue<State> queue = new Queue<State>();
       //     HashSet<State> visited = new HashSet<State>();

       //     List<State> path = new List<State>();

       //     queue.Enqueue(new State(0, 0));
       //     visited.Add(new State(0, 0));

       //     while (queue.Count > 0)
       //     {
       //         State current = queue.Dequeue();

       //         if (current.x == target || current.y == target)
       //         {
       //             path.Add(current);
       //             return path;
       //         }

       //         foreach (State next in GetNextStates(jugX, jugY, current))
       //         {
       //             if (!visited.Contains(next))
       //             {
       //                 queue.Enqueue(next);
       //                 visited.Add(next);
       //                 path.Add(current);
       //             }
       //         }
       //     }

       //     return null;
       // }

       //static List<State> GetNextStates(Jug jugX, Jug jugY, State current)
       // {
       //     List<State> nextStates = new List<State>();

       //     // Fill X
       //     if (current.x < jugX.Capacity)
       //     {
       //         nextStates.Add(new State(jugX.Capacity, current.y));
       //     }

       //     // Fill Y 
       //     if (current.y < jugY.Capacity)
       //     {
       //         nextStates.Add(new State(current.x, jugY.Capacity));
       //     }

       //     // Empty X
       //     if (current.x > 0)
       //     {
       //         nextStates.Add(new State(0, current.y));
       //     }

       //     // Empty Y
       //     if (current.y > 0)
       //     {
       //         nextStates.Add(new State(current.x, 0));
       //     }

       //     // X -> Y
       //     int spaceInY = jugY.Capacity - current.y;
       //     int transferAmount = Math.Min(spaceInY, current.x);
       //     if (transferAmount > 0)
       //     {
       //         nextStates.Add(new State(current.x - transferAmount, current.y + transferAmount));
       //     }

       //     // Y -> X 
       //     spaceInY = jugX.Capacity - current.x;
       //     transferAmount = Math.Min(spaceInY, current.y);
       //     if (transferAmount > 0)
       //     {
       //         nextStates.Add(new State(current.x + transferAmount, current.y - transferAmount));
       //     }

       //     return nextStates;
       // }
    }
}
