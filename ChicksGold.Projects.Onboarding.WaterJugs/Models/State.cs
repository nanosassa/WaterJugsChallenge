namespace ChicksGold.Projects.Onboarding.WaterJugs.Models
{
    // The State class represents the state of the water jugs at a certain point in time.
    public class State
    {
        // The BucketX property represents the current amount of water in the first jug (Jug X).
        public int BucketX { get; set; }

        // The BucketY property represents the current amount of water in the second jug (Jug Y).
        public int BucketY { get; set; }

        // The Explanation property represents a textual explanation of the action that led to the current state.
        public string Explanation { get; set; }
    }
}
