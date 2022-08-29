using System;

namespace RitAutomationTestTask3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Тесты");
            Console.WriteLine("Замена первого элемента: " + FirstElementReplaceTest());
            Console.WriteLine("Замена центарльного элемента: " + MiddleElementReplaceTest());
            Console.WriteLine("Замена последнего элемента: " + LastElementReplaceTest());
            Console.WriteLine();
            Console.WriteLine("Объединение пустых списков: " + ZeroElementsMergeTest());
            Console.WriteLine("Объединение списков (первый пустой): " + FirstListZeroElementsMergeTest());
            Console.WriteLine("Объединение списков (второй пустой): " + SecondListZeroElementsMergeTest());
            Console.WriteLine("Объединение списков: " + MergeTest());
        }

        public static bool FirstElementReplaceTest()
        {
            var list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Replace(0, 5);

            return list[0] == 5
                && list[1] == 2
                && list[2] == 3
                && list[3] == 4;
        }

        public static bool MiddleElementReplaceTest()
        {
            var list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Replace(2, 5);

            return list[0] == 1
                && list[1] == 2
                && list[2] == 5
                && list[3] == 4;
        }

        public static bool LastElementReplaceTest()
        {
            var list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Replace(3, 5);

            return list[0] == 1
                && list[1] == 2
                && list[2] == 3
                && list[3] == 5;
        }

        public static bool ZeroElementsMergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();

            var list3 = list.Merge(list2);

            return list3.IsEmpty;
        }

        public static bool FirstListZeroElementsMergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();
            list2.Add(1);

            var list3 = list.Merge(list2);

            return list3[0] == 1;
        }

        public static bool SecondListZeroElementsMergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();
            list.Add(1);

            var list3 = list.Merge(list2);

            return list3[0] == 1;
        }

        public static bool MergeTest()
        {
            var list = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list2.Add(1);
            list2.Add(3);

            var list3 = list.Merge(list2);

            return list3[0] == 1
                && list3[1] == 2
                && list3[2] == 3
                && list3[3] == 1
                && list3[4] == 3;
        }
    }
}
