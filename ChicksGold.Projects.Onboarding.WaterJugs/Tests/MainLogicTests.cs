using NUnit.Framework;
using ChicksGold.Projects.Onboarding.WaterJugs.Helpers;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Tests
{
    public class MainLogicTests
    {
        [Test]
        public void Test1()
        {
            var result = MainLogic.Solve(10, 2, 4);
            Assert.IsTrue(result.Last().BucketX == 4 || result.Last().BucketY == 4);
        }

        [Test]
        public void Test2()
        {
            var result = MainLogic.Solve(100, 2, 96);
            Assert.IsTrue(result.Last().BucketX == 96 || result.Last().BucketY == 96);
        }

        [Test]
        public void Test3()
        {
            var result = MainLogic.Solve(2, 6, 5);
            Assert.AreEqual("No Solution", result.First().Explanation);
        }
    }
}
