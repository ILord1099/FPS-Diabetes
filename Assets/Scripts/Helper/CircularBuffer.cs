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

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularBuffer{T}"/> class.
        /// </summary>
        /// <param name="capacity"> default value is 1</param>
        public CircularBuffer(int capacity = 1)
        {
            _capacity = capacity;
            Clear();
        }

        /// <summary>
        /// Determines whether the CircularBuffer contains a specific value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds an object to the end of the CircularBuffer.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (IsFull) return;

            Count++;
            _buffer[_back] = item;
            _back = (_back + 1) % _capacity;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the CircularBuffer.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty) return default;

            Count--;
            var item = _buffer[_front];
            _front = (_front + 1) % _capacity;
            return item;
        }

        /// <summary>
        /// Tries to remove and return the object at the beginning of the CircularBuffer.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the object at the beginning of the CircularBuffer without removing it.
        /// </summary>
        /// <returns></returns>
        public T Peek() => IsEmpty ? default : _buffer[_front];

        
        /// <summary>
        /// Tries to return the object at the beginning of the CircularBuffer without removing it.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Removes all objects from the CircularBuffer.
        /// </summary>
        public void Clear()
        {
            _buffer = new T[_capacity];

            Count = _front = _back = 0;
        }
    }
}