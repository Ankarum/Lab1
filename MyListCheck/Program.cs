using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lab1;

namespace MyListCheck
{
    /*
    class MyList<T> : IList<T>
    {
        class MyListItem<T>
        {
            public T Value;
            public MyListItem<T> Next;

            public MyListItem(T val)
            {
                this.Value = val;
                this.Next = null;
            }
        }

        private MyListItem<T> FirstItem;

        private int _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public int Count
        {
            get => _count;
        }

        public MyList()
        {
            this.Clear();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0) throw new IndexOutOfRangeException();
                int CurrentIndex = 0;
                MyListItem<T> CurrentItem = this.FirstItem;
                while (true)
                {
                    if (CurrentItem == null) throw new IndexOutOfRangeException();
                    if (CurrentIndex == index) return CurrentItem.Value;
                    CurrentItem = CurrentItem.Next;
                    CurrentIndex++;
                }
            }
            set
            {
                if (index < 0) throw new IndexOutOfRangeException();
                int CurrentIndex = 0;
                MyListItem<T> CurrentItem = this.FirstItem;
                while (true)
                {
                    if (CurrentItem == null) throw new IndexOutOfRangeException();
                    if (CurrentIndex == index) CurrentItem.Value = value;
                    CurrentItem = CurrentItem.Next;
                    CurrentIndex++;
                }
            }
        }

        public void Add(T value)
        {
            if (this.FirstItem == null)
            {
                this.FirstItem = new MyListItem<T>(value);
                this._count++;
            }
            else
            {
                MyListItem<T> CurrentItem = FirstItem;
                while (true)
                {
                    if (CurrentItem.Next == null)
                    {
                        CurrentItem.Next = new MyListItem<T>(value);
                        this._count++;
                        break;
                    }
                    else
                    {
                        CurrentItem = CurrentItem.Next;
                    }
                }
            }
        }

        public int IndexOf(T item)
        {
            int CurrentIndex = 0;
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (CurrentItem == null) return -1;
                if (object.Equals(CurrentItem.Value, item)) return CurrentIndex;
                CurrentItem = CurrentItem.Next;
                CurrentIndex++;
            }
        }

        public void Insert(int index, T item)
        {
            int NextItemIndex = 1 ;
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (NextItemIndex == index)
                {
                    MyListItem<T> TempItem = CurrentItem.Next;
                    CurrentItem.Next = new MyListItem<T>(item);
                    CurrentItem.Next.Next = TempItem;
                    this._count++;
                    return;
                }
                CurrentItem = CurrentItem.Next;
                NextItemIndex++;
            }
        }

        public void RemoveAt(int index)
        {
            int NextItemIndex = 1;
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (NextItemIndex == index)
                {
                    CurrentItem.Next = CurrentItem.Next.Next;
                    this._count--;
                    return;
                }
                CurrentItem = CurrentItem.Next;
                NextItemIndex++;
            }
        }

        public void Clear()
        {
            this.FirstItem = null;
            this._count = 0;
        }

        public bool Contains(T item)
        {
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (CurrentItem == null) return false;
                if (object.Equals(CurrentItem.Value, item)) return true;
                CurrentItem = CurrentItem.Next;
            }
        }

        public void CopyTo(T[] array, int arrayIndex = 0)
        {
            int CurrentIndex = arrayIndex;
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                array[CurrentIndex] = CurrentItem.Value;
                if ((CurrentItem = CurrentItem.Next) == null) return;
            }
        }

        public bool Remove(T item)
        {
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (CurrentItem == null) return false;
                if (object.Equals(CurrentItem.Next.Value, item))
                {
                    CurrentItem.Next = CurrentItem.Next.Next;
                    this._count--;
                    return true;
                };
                CurrentItem = CurrentItem.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyListItem<T> CurrentItem = this.FirstItem;
            while (CurrentItem != null)
            {
                yield return CurrentItem.Value;
                CurrentItem = CurrentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> testList = new MyList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(65);
            testList.Add(3);
            testList.Add(8);
            testList.Add(3);
            testList.Add(19);
            Console.WriteLine($"{testList.ToString()}\t[1, 2, 65, 3, 8, 3, 19]");
            testList.Remove(3);
            Console.WriteLine($"{testList.ToString()}\t[1, 2, 65, 8, 3, 19]");
            //Assert.AreEqual(testList.ToString(), "[1, 2, 65, 8, 3, 19]");

            Console.WriteLine("Hello World");
            Console.ReadKey();
        }
        /*
        static void Main(string[] args)
        {
            MyList myList = new MyList();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            Console.WriteLine(myList.ToString());
        }
        */
    }
}
