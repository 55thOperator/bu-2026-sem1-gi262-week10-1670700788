using NUnit.Framework;
using MidtermExam.Prob03;

namespace MidtermExam.Tests
{
    [TestFixture, Category("MidtermExam"), Category("Prob03")]
    public class Prob03_RecursiveTree_Testcase
    {
        [Test]
        public void NullTreeReturnsZero()
        {
            Assert.That(new TreeCounter().AS03_CountTotalNode(null), Is.Zero);
        }

        [Test]
        public void SingleNodeReturnsOne()
        {
            Assert.That(new TreeCounter().AS03_CountTotalNode(new Node(1)), Is.EqualTo(1));
        }

        [TestCase(true), TestCase(false)]
        public void OneChildReturnsTwo(bool left)
        {
            var root = new Node(1);
            if (left) root.left = new Node(2);
            else root.right = new Node(2);
            Assert.That(new TreeCounter().AS03_CountTotalNode(root), Is.EqualTo(2));
        }

        [Test]
        public void BothChildrenReturnThree()
        {
            Assert.That(new TreeCounter().AS03_CountTotalNode(new Node(1, new Node(2), new Node(3))),
                Is.EqualTo(3));
        }

        [Test]
        public void FiveNodeTree()
        {
            var root = new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3));
            Assert.That(new TreeCounter().AS03_CountTotalNode(root), Is.EqualTo(5));
        }

        [TestCase(true, 4), TestCase(false, 4), TestCase(true, 128), TestCase(false, 128)]
        public void SkewedTree(bool left, int count)
        {
            Node root = null;
            for (int i = 0; i < count; i++)
                root = left ? new Node(i, root) : new Node(i, null, root);
            Assert.That(new TreeCounter().AS03_CountTotalNode(root), Is.EqualTo(count));
        }

        [Test]
        public void ComplexTreeReturnsEight()
        {
            var root = new Node(1,
                new Node(2, new Node(4, new Node(8)), new Node(5)),
                new Node(3, new Node(6), new Node(7)));
            Assert.That(new TreeCounter().AS03_CountTotalNode(root), Is.EqualTo(8));
        }

        [Test]
        public void CountsDuplicateValuesAndPreservesAllNodes()
        {
            var leaf = new Node(-5);
            var left = new Node(7, null, leaf);
            var right = new Node(7);
            var root = new Node(0, left, right);
            var counter = new TreeCounter();
            Assert.That(counter.AS03_CountTotalNode(root), Is.EqualTo(4));
            Assert.That(counter.AS03_CountTotalNode(root), Is.EqualTo(4));
            Assert.That(root.value, Is.Zero);
            Assert.That(root.left, Is.SameAs(left));
            Assert.That(root.right, Is.SameAs(right));
            Assert.That(left.value, Is.EqualTo(7));
            Assert.That(left.left, Is.Null);
            Assert.That(left.right, Is.SameAs(leaf));
            Assert.That(right.value, Is.EqualTo(7));
            Assert.That(right.left, Is.Null);
            Assert.That(right.right, Is.Null);
            Assert.That(leaf.value, Is.EqualTo(-5));
            Assert.That(leaf.left, Is.Null);
            Assert.That(leaf.right, Is.Null);
        }
    }
}
