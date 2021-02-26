using System;

namespace Heaps
{
    using Heap.Entity;
    
    public static class Program
    {
        public static void Main(string[] args)
        {
            var heap = new Heap();
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(3);
            heap.Insert(4);
            heap.Insert(5);
            heap.Insert(6);
            heap.Insert(7);
            heap.Insert(8);
            heap.Insert(9);
            heap.Insert(10);

            foreach (var number in heap.GetItems())
            {
                Console.Write($"{number}\t");
            }

            Console.WriteLine();

            for (var var = 0; var < 10; var++)
            {
                Console.Write($"{heap.Remove()}\t");
            }
        }
    }
}