namespace ChicksGold.Projects.Onboarding.WaterJugs.Models
{    public class Jug
    {
        public int Capacity { get; set; }
        public int CurrentAmount { get; set; }

        public Jug(int capacity)
        {
            Capacity = capacity;
            CurrentAmount = 0;
        }

        public void Fill()
        {
            CurrentAmount = Capacity;
        }

        public void Empty()
        {
            CurrentAmount = 0;
        }

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
