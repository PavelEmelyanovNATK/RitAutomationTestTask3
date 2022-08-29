using NUnit.Framework;
using RitAutomationTestTask3;

namespace RitAutimationTest3
{
    public class Tests
    {
        [Test]
        public void FirstElementReplaceTest()
        {
            var list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Replace(0, 5);



            Assert.That(list[0] == 5
                && list[1] == 2
                && list[2] == 3
                && list[3] == 4
                );
        }

        [Test]
        public void MiddleElementReplaceTest()
        {
            var list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Replace(2, 5);

            Assert.That(list[0] == 1
                && list[1] == 2
                && list[2] == 5
                && list[3] == 4);
        }

        [Test]
        public void LastElementReplaceTest()
        {
            var list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Replace(3, 5);

            Assert.That(list[0] == 1
                && list[1] == 2
                && list[2] == 3
                && list[3] == 5);
        }

        [Test]
        public void ZeroElementsMergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();

            var list3 = list.Merge(list2);

            Assert.That(list3.IsEmpty);
        }

        [Test]
        public void FirstListZeroElementsMergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();
            list2.Add(1);

            var list3 = list.Merge(list2);

            Assert.That(list3[0] == 1);
        }

        [Test]
        public void SecondListZeroElementsMergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();
            list.Add(1);

            var list3 = list.Merge(list2);

            Assert.That(list3[0] == 1);
        }

        [Test]
        public void MergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list2.Add(1);
            list2.Add(3);

            var list3 = list.Merge(list2);

            Assert.That(list3[0] == 1
                && list3[1] == 2
                && list3[2] == 3
                && list3[3] == 1
                && list3[4] == 3);
        }
    }
}