using System.Text.Json.Serialization;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Models
{
    public class State 
    {
        public int BucketX { get; set; }
        public int BucketY { get; set; }
        public string Explanation { get; set; }
        [JsonIgnore]
        public State ParentState { get; set; } // Added property to track parent state
    }
}
