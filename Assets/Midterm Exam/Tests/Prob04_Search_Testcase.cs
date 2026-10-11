using NUnit.Framework;
using MidtermExam.Prob04;

namespace MidtermExam.Tests
{
    [TestFixture, Category("MidtermExam"), Category("Prob04")]
    public class Prob04_Search_Testcase
    {
        [TestCase(new[] { 34, 21, 56, 12, 78, 90, 11, 23 }, 90, 5)]
        [TestCase(new[] { 4, 2, 4, 1 }, 4, 0)]
        [TestCase(new[] { -3, 0, 9 }, 0, 1)]
        [TestCase(new[] { 1, 2, 3 }, 7, -1)]
        [TestCase(new int[] { }, 1, -1)]
        [TestCase(null, 1, -1)]
        [TestCase(new[] { 7 }, 7, 0)]
        [TestCase(new[] { 7 }, 8, -1)]
        [TestCase(new[] { 9, 2, 2, 1 }, 1, 3)]
        [TestCase(new[] { int.MaxValue, 0, int.MinValue }, int.MinValue, 2)]
        public void SequentialFindsFirstAndPreservesInput(int[] values, int target, int expected)
        {
            int[] before = values == null ? null : (int[])values.Clone();
            Assert.That(new NumberSearch().AS04_SequentialSearch(values, target), Is.EqualTo(expected));
            Assert.That(values, Is.EqualTo(before));
        }

        [TestCase(new[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 }, 23)]
        [TestCase(new[] { 1, 2, 2, 2, 5 }, 2)]
        [TestCase(new[] { -10, -3, 0, 9 }, -10)]
        [TestCase(new[] { 1, 3, 5 }, 4)]
        [TestCase(new[] { 7 }, 7)]
        [TestCase(new[] { 7 }, 8)]
        [TestCase(new int[] { }, 1)]
        [TestCase(null, 1)]
        [TestCase(new[] { 1, 3 }, 1)]
        [TestCase(new[] { 1, 3 }, 3)]
        [TestCase(new[] { 1, 3 }, 0)]
        [TestCase(new[] { 1, 3 }, 4)]
        [TestCase(new[] { 2, 2, 2, 2 }, 2)]
        [TestCase(new[] { int.MinValue, 0, int.MaxValue }, int.MaxValue)]
        [TestCase(new[] { int.MinValue, 0, int.MaxValue }, int.MinValue)]
        public void BinaryFindsAnyMatchAndPreservesInput(int[] values, int target)
        {
            int[] before = values == null ? null : (int[])values.Clone();
            int actual = new NumberSearch().AS05_BinarySearch(values, target);
            // ตัวตรวจยอมรับ index ใดก็ได้ที่มีค่าเท่ากับ target เมื่อข้อมูลมีค่าซ้ำ
            bool exists = values != null && System.Array.IndexOf(values, target) >= 0;
            if (exists)
            {
                Assert.That(actual, Is.GreaterThanOrEqualTo(0).And.LessThan(values.Length));
                Assert.That(values[actual], Is.EqualTo(target));
            }
            else Assert.That(actual, Is.EqualTo(-1));
            Assert.That(values, Is.EqualTo(before));
        }
    }
}
