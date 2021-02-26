namespace Heap.Entity
{
    using System;
    using System.Collections;

    public class Heap
    {
        private readonly int[] _items = new int[10];
        private int _size;

        public void Insert(int value)
        {
            if (_size == _items.Length)
            {
                throw new OutOfMemoryException("Arrays are filled");
            }

            _items[_size++] = value;

            BubbleUp();
        }

        private void BubbleUp()
        {
            var index = _size - 1;

            while (index > 0 && _items[index] > _items[GetParentIndex(index)])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        public int Remove()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("No items to remove");
            }

            var largestItem = _items[0];

            _items[0] = _items[--_size];

            var index = 0;

            while (index <= _size && !ValidParent(index))
            {
                var largestChildIndex = LargerChildIndex(index);
                Swap(index, largestChildIndex);
                index = largestChildIndex;
            }

            return largestItem;
        }

        private bool IsEmpty()
        {
            return _size == 0;
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
            {
                return index;
            }

            if (!HasRightChild(index))
            {
                return LeftChildIndex(index);
            }

            var largestChildIndex = LeftChild(index) > RightChild(index)
                ? LeftChildIndex(index)
                : RightChildIndex(index);

            return largestChildIndex;
        }

        private bool ValidParent(int index)
        {
            if (!HasLeftChild(index))
            {
                return true;
            }

            var isValidParent = _items[index] >= LeftChild(index);

            if (HasRightChild(index))
            {
                isValidParent &= _items[index] >= RightChild(index);
            }

            return isValidParent;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) < _size;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) < _size;
        }

        private int RightChild(int index)
        {
            return _items[RightChildIndex(index)];
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int LeftChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public IEnumerable GetItems()
        {
            return _items;
        }
    }
}