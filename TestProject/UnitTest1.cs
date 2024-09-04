using CircularCollectionClassLibrary;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        private enum Season { Spring, Summer, Autumn, Winter }

        [Test]
        public void TestCircularCollectionCirclesBack()
        {
            //ARRANGE
            CircularCollection<Season> circollection = new CircularCollection<Season>();
            circollection.Add(Season.Spring);
            circollection.Add(Season.Summer);
            circollection.Add(Season.Autumn);
            circollection.Add(Season.Winter);

            //ACT & ASSERT
            Assert.That (Season.Spring, Is.EqualTo(circollection.Current), "The current item was wrong.");

            circollection.MoveNext();
            Assert.That(Season.Summer,Is.EqualTo(circollection.Current), "The current item was wrong.");

            circollection.MoveNext();
            Assert.That(Season.Autumn, Is.EqualTo(circollection.Current), "The current item was wrong.");

            circollection.MoveNext();
            Assert.That(Season.Winter, Is.EqualTo(circollection.Current), "The current item was wrong.");

            circollection.MoveNext();
            Assert.That(Season.Spring, Is.EqualTo(circollection.Current), "The current item was wrong.");
        }

        [Test]
        public void TestCompleteCircularCollectionCirclesBack()
        {
            //ARRANGE
            ICompleteCircularCollection<Season> circollection = new CompleteCircularCollection<Season>();
            circollection.Add(Season.Spring);
            circollection.Add(Season.Summer);
            circollection.Add(Season.Autumn);
            circollection.Add(Season.Winter);

            int count = 0;
            foreach (var season in circollection)
            {
                count++;
                System.Console.WriteLine($"{count} : {season}");
                if (count > 100) break;
            }

            //ACT & ASSERT
            Assert.That(count > 100, "The collection doesn't circle.");
        }
    }
}