using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    /// <summary>
    /// Однонаправленный обобщенный список на ссылках
    /// </summary>
    /// <typeparam name="T">Тип хранимых значений</typeparam>
    public class MyList<T> : IList<T>
    {
        /// <summary>
        /// Обертка элемента списка
        /// </summary>
        /// <typeparam name="T">Тип хранимого объекта</typeparam>
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

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count
        {
            get => _count;
        }

        public bool IsReadOnly => false;

        /// <summary>
        /// Создание пустого списка
        /// </summary>
        public MyList()
        {
            this.Clear();
        }

        /// <summary>
        /// Обращение к элементу списка по индексу
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Найденный элемент списка</returns>
        public T this[int index]
        {
            get
            {
                if (index < 0) throw new IndexOutOfRangeException(); // Индекс не должен быть меньше 0
                int CurrentIndex = 0;
                MyListItem<T> CurrentItem = this.FirstItem;
                // Прохождение по элементам, пока индекс текущего элемента не совпавадет с заданным индексом
                while (true)
                {
                    if (CurrentItem == null) throw new IndexOutOfRangeException();
                    if (CurrentIndex == index) return CurrentItem.Value; // Вернуть значение найденного элемента
                    CurrentItem = CurrentItem.Next;
                    CurrentIndex++;
                }
            }
            set
            {
                if (index < 0) throw new IndexOutOfRangeException(); // Индекс не должен быть меньше 0
                int CurrentIndex = 0;
                MyListItem<T> CurrentItem = this.FirstItem;
                // Прохождение по элементам, пока индекс текущего элемента не совпавадет с заданным индексом
                while (true)
                {
                    if (CurrentIndex == index)
                    {
                        CurrentItem.Value = value; // Изменить значение найденного элемента
                        return;
                    }
                    if (CurrentItem == null) throw new IndexOutOfRangeException();
                    CurrentItem = CurrentItem.Next;
                    CurrentIndex++;
                }
            }
        }

        /// <summary>
        /// Добавить элемент в список
        /// </summary>
        /// <param name="value">Значение нового элемента</param>
        public void Add(T value)
        {
            // Если список пуст, добавить элемент в начало
            if (this.FirstItem == null)
            {
                this.FirstItem = new MyListItem<T>(value);
                this._count++;
            }
            else
            {
                MyListItem<T> CurrentItem = FirstItem;
                // Прохождение по элементам списка.
                // Если следующий элемент - null, значит дошли до конца.
                // Добавляем новый элемент в конец.
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

        /// <summary>
        /// Получение индекса объекта в массиве
        /// </summary>
        /// <param name="item">Объект, индекс которого требуется найти</param>
        /// <returns>Индекс найденного объекта. Если объект не найден - возвращает -1</returns>
        public int IndexOf(T item)
        {
            int CurrentIndex = 0;
            MyListItem<T> CurrentItem = this.FirstItem;
            // Пройти по элементам списка. Если значение элемента равно заданному - вернуть индекс элемента.
            while (true)
            {
                if (CurrentItem == null) return -1; // Если дошли до конца, но элемент не найден - вернуть -1
                if (object.Equals(CurrentItem.Value, item)) return CurrentIndex;
                CurrentItem = CurrentItem.Next;
                CurrentIndex++;
            }
        }

        /// <summary>
        /// Вставить новый элемент в указанную позицию
        /// </summary>
        /// <param name="index">Позиция нового элемента</param>
        /// <param name="item">Вставляемый элемент</param>
        public void Insert(int index, T item)
        {
            if (index == 0)
            {
                MyListItem<T> TempItem = this.FirstItem;
                this.FirstItem = new MyListItem<T>(item);
                this.FirstItem.Next = TempItem;
                this._count++;
                return;
            }
            int NextItemIndex = 1;
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (NextItemIndex == index) // Если позиция следующего элемента ([i+1]) равна позиции нового элемента...
                {
                    MyListItem<T> TempItem = CurrentItem.Next; // Сохранение элемента [i+1]
                    CurrentItem.Next = new MyListItem<T>(item); // Вставить новый элемент после текущего элемента ([i])
                    CurrentItem.Next.Next = TempItem; // Поместить элемент [i+1] после вставленного элемента
                    this._count++;
                    return;
                }
                CurrentItem = CurrentItem.Next;
                NextItemIndex++;
            }
        }

        /// <summary>
        /// Удаление элемента на указанной позиции
        /// </summary>
        /// <param name="index">Позиция удаляемого элемента</param>
        public void RemoveAt(int index)
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                this.FirstItem = this.FirstItem.Next;
                this._count--;
                return;
            }
            int NextItemIndex = 1;
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (NextItemIndex == index)
                {
                    // Если позиция следующего элемента равна позиции удаляемого элемента,
                    // Перебросить через него ссылку на следующий элемент и декрементировать счетчик элементов
                    CurrentItem.Next = CurrentItem.Next.Next;
                    this._count--;
                    return;
                }

                if ((CurrentItem = CurrentItem.Next) == null) throw new IndexOutOfRangeException();
                NextItemIndex++;
            }
        }

        /// <summary>
        /// Очищение списка
        /// </summary>
        public void Clear()
        {
            this.FirstItem = null;
            this._count = 0;
        }

        /// <summary>
        /// Проверить, находится ли объект в списке
        /// </summary>
        /// <param name="item">Объект для проверки</param>
        /// <returns>true - если объект в списке, false - в противном случае</returns>
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

        /// <summary>
        /// Вставить элементы списка в массив, начиная с указанной позиции
        /// </summary>
        /// <param name="array">Массив, в который вставляются элементы</param>
        /// <param name="arrayIndex">Индекс массива, с которого начинается вставка элементов</param>
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

        /// <summary>
        /// Удалить указанный объект из списка
        /// </summary>
        /// <param name="item">Удаляемый объект</param>
        /// <returns>true - если объект удален успешно, false - в противном случае</returns>
        public bool Remove(T item)
        {
            if (this.Count == 0) throw new IndexOutOfRangeException();
            MyListItem<T> PrevItem = null;
            MyListItem<T> CurrentItem = this.FirstItem;

            while (true)
            {
                // Если значение текущего объекта равно удаляемому значению,
                // перебросить через него ссылку (удалить из цепочки)
                if (object.Equals(CurrentItem.Value, item))
                {
                    if (PrevItem == null)
                    {
                        this.FirstItem = CurrentItem.Next;
                    }
                    else
                    {
                        PrevItem.Next = CurrentItem.Next;
                    }

                    this._count--;
                    return true;
                }

                PrevItem = CurrentItem;
                if ((CurrentItem = CurrentItem.Next) == null) return false;
            }
            /*
            MyListItem<T> CurrentItem = this.FirstItem;
            while (true)
            {
                if (CurrentItem.Next == null) return false;
                if (object.Equals(CurrentItem.Next.Value, item))
                {
                    CurrentItem.Next = CurrentItem.Next.Next;
                    this._count--;
                    return true;
                };
                if ((CurrentItem = CurrentItem.Next) == null) return false;
            }*/
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
        
        public override string ToString()
        {
            return $"[{string.Join(", ", this)}]";
        }
    }
}
