﻿using System.Diagnostics;
using System.Drawing;
using System.Linq;
namespace Collection1125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // коллекции в C#
            // массивы являются неизменяемыми с точки зрения
            // размера
            // коллекция - "Список" 
            // объявляется следующим образом:
            List<int> ints = new List<int>();
            // в таком виде список представляет из себя
            // одномерный массив, пока без значений и размера
            ints.Add(1); // добавление одного элемента в конец списка
            ints.AddRange([1, 2, 3]); // добавление нескольких элементов в конец списка
            int count = ints.Count; // свойство Count возвращает размер коллекции (сколько в ней ячеек со значениями)
            // если в коллекцию планируется добавить сразу много значений
            // то можно установить ей начальную емкость
            ints = new List<int>(100); // здесь мы задаем емкость на 100 элементов
            ints.Add(1); // добавление одного элемента в конец списка
            ints.AddRange([1, 2, 3]);
            Console.WriteLine(ints.Count);
            // за счет накладных расходов на пересоздание
            // массива и копирование данных внутри коллекции
            // List может работать медленее чем обычный массив

            //ints.Clear();// очищает элементы в коллекции
            ints.ForEach(x => Console.WriteLine(x)); //над
                                                     //каждым элементом коллекции выполняется лямбда
            ints.Capacity = 100; // назначение или чтение
                                 // емкости (второй вариант назначения после конструктора)
            ints.Remove(0); // удаление элемента по значению
                            // или ссылке
            ints.RemoveAt(0);// удаление элемента по индексу
            // после удаления объекта из коллекции, у всех
            // элементов справа от удаленного объекта уменьшается индекс на 1
            ints.RemoveAll(x => x == 1);// удаление всех совпадений
                                        // из коллекции, условие задается лямбдой
            ints.Add(1);
            ints.Add(3);
            ints[0] = 1;
            Console.WriteLine(ints[0]);
            var result = ints.Aggregate((x, y) => x * y);// выполнить операцию между всеми элементами
            Console.WriteLine(result);
            bool resultBool = ints.All(x => x == 1);// проверка, все ли элементы удовлетворяют условию
            resultBool = ints.Any(x => x == 1);// проверка, удовлетворяет ли условию хотя бы один элемент
            IEnumerable<int> intsI = ints.AsEnumerable(); // базовый интерфейс для хранения последовательностей
            double average = ints.Average(x => x); // среднее арифметическое
            Console.WriteLine(average);
            var newInts = ints.Concat(intsI).ToList(); // объединение двух последовательностей 
            // в одну последовательность
            resultBool = ints.Contains(newInts[0]);// проверка на то, что элемент содержится в коллекции (происходит проверка по значению или ссылке)
            ints.Distinct(); // возвращает уникальные элементы коллекции
            List<Point> points = new List<Point>();
            var unicXpoints = points.DistinctBy(x => x.X);
            int newCapacity = ints.EnsureCapacity(100); // проверка на то, что емкость соответствует минимальной указанной, если нет, то создается новая емкость и возвращается в виде результата
            var newCol = ints.Except(intsI); // получить разницу коллекций
            ints.Exists(x => x == 1); // проверка на то, что сущесвует значение выполняющее данное условие
            int find = ints.Find(x => x > 1111); // найти элемент по условию, если элемента нет, то будет возращено значение по умолчанию (для ссылочных типов null, для значимых - новый экземлпяр типа)
            //find = ints.First(x => x > 1111); // найти первый элемент по условию, если элемента нет, то будет ошибка
            find = ints.FirstOrDefault(x => x > 1111); // найти первый элемент по условию, если элемента нет, то будет значенеи по умолчанию
            List<int> newColsIns = ints.FindAll(x => x == 1);// найти все элементы по условию 
            ints.Where(x => x == 1); // то же самое, но возвращает IEnumerable<int> в данном случае
            ints.FindLast(x => x == 1); // поиск элемента с конца по условию
            ints.IndexOf(10); // индекс элемента по значению (или ссылке)
            ints.LastIndexOf(10); // индекс элемента по значению (или ссылке) поиск с конца
            ints.FindLastIndex(x => x == 1);// поиск индекса с конца по условию
            // если методы поиска индекса возвращают -1, то это значит, что элемента в коллекции нет
            ints.TrueForAll(x => x == 1);// используется делегат Predicate, аналог All
                                         //  ints.GetRange(0, 100);// получить промежуток начиная с индекса (0) в количестве 100, будет ошибка, если недостаточно элементов
            ints.Insert(0, 10);// вставить элемент 10 по индексу 0
            ints.InsertRange(0, [1, 2, 3]); // то же самое, но вставляем массив или коллекцию
            ints.Intersect(intsI);// получить пересечение двух коллекций
                                  //  ints.RemoveRange(0, 100);// удалить промежуток с 0, в кол-ве 100 элементов
            ints.Reverse();// перевернуть порядок элементов внутри коллекции
            ints.Max(x => x); // найти максимальный элемент, лябмда нужна для комплексных типов, для учета их свойств в условии
            ints.Min(); // найти минимальный элемент 
            ints.Order();// сортировка элементов по возрастанию
            ints.OrderDescending();// сортировка элементов по убыванию
            points.OrderBy(x => x.X);// сортировка с лямбдой для сложных объектов
            points.OrderByDescending(x => x.Y);
            ints.Prepend(10);// добавить элемент в начало
            ints.Skip(10);// пропустить несколько элементов и вернуть остальные в результат
            ints.Take(10); // взять первые 10 элементо и вернуть в результат
            ints.Skip(10).Take(10);// пропустить первые 10 и взять следующие 10
            //ints.Sort();// сортировка по возрастанию
            ints.Sort((x, y) => y.CompareTo(x)); // сортировка с указанием условия сравнения через лямбду
            foreach (var item in ints)
                Console.WriteLine(item);
            ints.TakeWhile(x => x != 10);// получить первые несколько элементов, которые удовлетворяют условию
            ints.ToArray(); // получить массив
            ints.ToList(); // получить список
            ints.TrimExcess();// сузить емкость до кол-ва элементов в коллекции
            Console.Clear();
            // ОАИП задача 30 тема 7
            List<int> array = new List<int>();
            Random random = new Random();
            for(int i = 0; i < 100; i++)
                array.Add(random.Next(0, 100));

            array.ForEach(x => Console.WriteLine(x));

            float countНечетные = array.Count(x => (x & 1) == 1);
            Console.WriteLine((countНечетные/ array.Count).ToString("p"));
        }
    }
}
