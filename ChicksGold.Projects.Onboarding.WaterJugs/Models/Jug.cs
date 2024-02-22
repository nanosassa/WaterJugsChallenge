namespace ChicksGold.Projects.Onboarding.WaterJugs.Models
{
    // The Jug class represents a water jug that has a certain capacity and a current amount of water.
    public class Jug
    {
        // The Capacity property represents the maximum amount of water that the jug can hold.
        public int Capacity { get; set; }

        // The CurrentAmount property represents the current amount of water in the jug.
        public int CurrentAmount { get; set; }

        // The constructor initializes a new instance of the Jug class with a specified capacity.
        // It also sets the current amount of water to 0, indicating that the jug is initially empty.
        public Jug(int capacity)
        {
            Capacity = capacity;
            CurrentAmount = 0;
        }

        // The Fill method fills the jug to its maximum capacity.
        public void Fill()
        {
            CurrentAmount = Capacity;
        }

        // The Empty method empties the jug by setting the current amount of water to 0.
        public void Empty()
        {
            CurrentAmount = 0;
        }

        // The Transfer method transfers a specified amount of water from this jug to another jug.
        // It returns false if the specified amount is less than or equal to 0, or greater than the current amount of water in this jug.
        // Otherwise, it calculates the available space in the other jug, and the actual amount of water to transfer.
        // It then decreases the current amount of water in this jug by the actual transfer amount, and increases the current amount of water in the other jug by the same amount.
        // Finally, it returns true to indicate that the transfer was successful.
        public bool Transfer(Jug otherJug, int amount)
        {
            if (amount <= 0 || amount > CurrentAmount)
            {
                return false;
            }

            int availableSpace = otherJug.Capacity - otherJug.CurrentAmount;
            int actualTransfer = Math.Min(amount, availableSpace);

            CurrentAmount -= actualTransfer;
            otherJug.CurrentAmount += actualTransfer;
            return true;
        }
    }
}
