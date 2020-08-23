using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAlgos
{
    class ArrayList<T>
    {
        protected T[] arr;
        protected long _length = 0;
        protected long _size = 0;

        public ArrayList(T[] arr)
        {
            // initialize ArrayList by making object array double the size of the initializing array
            int initArrLen = (arr.Length > 0) ? arr.Length : 1;
            this.arr = new T[initArrLen * 2];

            // setting object properties
            _length = initArrLen;
            _size = initArrLen * 2;

            // copy array values to object array
            arr.CopyTo(this.arr, 0);
        }

        public void Add(T item)
        {
            // check if object arr is full then double arr length
            if (_length == _size) DoubleArr();

            // add item to arr
            arr[_length++] = item;
        }

        public void Add(T[] item)
        {
            if (_length == _size) DoubleArr();
            item.CopyTo(arr, 0);
            _length += item.Length;
        }

        public T At(long index) 
        {
            return (index >= _length) ? throw new IndexOutOfRangeException($"Index {index} exceeds ArrayList range.") : arr[index];
        }

        public T[] Splice(long startIndex, long endIndex)
        {
            if (startIndex >= _length ) throw new IndexOutOfRangeException($"startIndex {startIndex} exceeds ArrayList range.");
            if (endIndex >= _length ) throw new IndexOutOfRangeException($"endIndex {endIndex} exceeds ArrayList range.");
            if (startIndex > endIndex && endIndex > 0) throw new IndexOutOfRangeException($" {startIndex} > {endIndex}. startIndex cannot be greater than endIndex unless endIndex is negative.");
            
            if (endIndex < 0) return SpliceToEnd(startIndex + endIndex + (_length - 1));
            return SpliceMid(startIndex, endIndex);
        }


        protected T[] SpliceToEnd(long index)
        {
            // create new array with size of _length-index and fill it
            long newSize = _length - index;
            T[] newArr = new T[newSize];

            for(long i = 0; i < newSize; i++)
            {
                newArr[i] = arr[index++];
            }

            return newArr;
        }

        protected T[] SpliceMid(long startIndex, long endIndex)
        {
            // create new array with size of endIndex - startIndex + 1 and fill it
            long arrSize = endIndex - startIndex + 1;
            T[] newArr = new T[arrSize];
            for(long i = 0; i < arrSize; i++)
            {
                newArr[i] = arr[startIndex++];
            }
            return newArr;
        }

        protected void DoubleArr()
        {
            // create new array double the size of the current array
            T[] newArr = new T[this._size * 2];

            // copy values from the object arr to the new array
            arr.CopyTo(newArr, 0);

            // set object properties
            _length = _size;
            _size *= 2;

            // make object array the newly created array
            arr = newArr;
        }

        public int GetLength()
        {
            return (int) _length;
        }        
        
        public int GetSize()
        {
            return (int) _size;
        }

    }
}
