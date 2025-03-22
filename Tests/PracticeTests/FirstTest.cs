namespace PracticeTests
{
    [TestFixture]
    public sealed class FirstTest
    {
        [Test]
        public void CheckNUnit()
        {
            Assert.True(true);
        }

        [Test]
        public void CheckRandomShaffle()
        {
            var random = new Random();
            var list = new int[]{1,2,3,4,5,6,7,8,9,10};
            random.Shuffle<int>(list);
            Console.WriteLine(string.Join(",", list));
        }
    }
}
