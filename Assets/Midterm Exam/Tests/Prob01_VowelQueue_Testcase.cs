using System.Collections.Generic;
using NUnit.Framework;
using MidtermExam.Prob01;

namespace MidtermExam.Tests
{
    [TestFixture, Category("MidtermExam"), Category("Prob01")]
    public class Prob01_VowelQueue_Testcase
    {
        [TestCase(new string[] { }, 0)]
        [TestCase(new[] { "a" }, 1)]
        [TestCase(new[] { "a", "e", "i", "o", "u" }, 5)]
        [TestCase(new[] { "a", "b", "e", "c", "i", "d", "o", "u" }, 5)]
        [TestCase(new[] { "b", "c", "d", "f" }, 0)]
        [TestCase(new[] { "a", "a", "a", "e", "e" }, 5)]
        [TestCase(new[] { "A", null, "ae", "", " ", "u" }, 1)]
        public void CountsAndPreservesQueue(string[] input, int expected)
        {
            var queue = new Queue<string>(input);
            var counter = new VowelCounter();
            Assert.That(counter.AS01_CountVowels(queue), Is.EqualTo(expected));
            Assert.That(queue.ToArray(), Is.EqualTo(input), "Queue contents/order changed.");
            Assert.That(counter.AS01_CountVowels(queue), Is.EqualTo(expected));
            Assert.That(queue.ToArray(), Is.EqualTo(input), "Repeated call changed queue.");
        }

        [Test]
        public void NullQueueReturnsZero()
        {
            Assert.That(new VowelCounter().AS01_CountVowels(null), Is.Zero);
        }
    }
}
