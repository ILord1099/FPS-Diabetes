using UnityEngine;

namespace Helper
{
    [System.Serializable]
    public class CircularBuffer<T>
    {
        private T[] _buffer;
        private int _front, _back, _capacity;

        private bool IsEmpty => Count == 0;

        private bool IsFull => Count == _capacity;

        public int Count { get; private set; }

        public CircularBuffer(int capacity)
        {
            _capacity = capacity;
            Clear();
        }

        public bool Contains(T item)
        {
            if (_buffer[_back] is null) return false;

            for (var i = 0; i < _buffer.Length; i++)
            {
                var t = _buffer[i];
                if (t.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Enqueue(T item)
        {
            if (IsFull) return;

            Count++;
            _buffer[_back] = item;
            _back = (_back + 1) % _capacity;
        }

        public T Dequeue()
        {
            if (IsEmpty) return default;

            Count--;
            var item = _buffer[_front];
            _front = (_front + 1) % _capacity;
            return item;
        }

        public bool TryDequeue(out T item)
        {
            if (IsEmpty)
            {
                item = default;
                return false;
            }

            item = Dequeue();
            return true;
        }

        public T Peek() => IsEmpty ? default : _buffer[_front];

        public bool TryPeek(out T item)
        {
            if (IsEmpty)
            {
                item = default;
                return false;
            }

            item = Peek();
            return true;
        }

        public void Clear()
        {
            _buffer = new T[_capacity];

            Count = _front = _back = 0;
        }
    }
}