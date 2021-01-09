using System;
using System.Collections.Generic;

namespace Google_Stuff_Id76529_Savanchuk_Pavel_Project_2987
{

    class Program
    {
        /// <summary>
        /// Функция для конвертации из инфиксной в постфиксную форму
        /// </summary>
        /// <param name="infix"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        static bool convert(ref string infix, out string postfix)
        {
            // Инициализируем приоритеты знаков
            int prio = 0;
            postfix = "";
            // Инициализируем стэк операторов
            Stack<Char> s1 = new Stack<char>();
            // Начинаем циклом перебирать инфиксную форму
            for (int i = 0; i < infix.Length; i++)
            {
                // Считываем каждый символ отдельно
                char ch = infix[i];
                // Определяем, является ли переменная оператором
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    // В случае когда предыдущих операторов нет, добавляем его в верх стека
                    if (s1.Count <= 0)
                        s1.Push(ch);
                    else
                    {
                        // В противном случае, задаем приоритеты знакам умножения и деления добавляем ее в стек
                        if (s1.Peek() == '*' || s1.Peek() == '/')
                            prio = 1;
                        else
                            prio = 0;
                        if (prio == 1)
                        {
                            // И приоритет знакам сложения и вычитания
                            if (ch == '+' || ch == '-')
                            {
                                // Очищаем верх стека
                                postfix += s1.Pop();
                                i--;
                            }
                            else
                            {
                                // Очищаем верх стека
                                postfix += s1.Pop();
                                i--;
                            }
                        }
                        else
                        {
                            if (ch == '+' || ch == '-')
                            {
                                // Очищаем верх стека массива
                                // Добавляем в верх стека символ
                                postfix += s1.Pop();
                                s1.Push(ch);

                            }
                            else
                                // Добавляем в верх стека символ
                                s1.Push(ch);
                        }
                    }
                }
                else
                {
                    postfix += ch;
                }
            }
            // Определяем длину стека
            int len = s1.Count;
            for (int j = 0; j < len; j++)
                // Выводим постфиксную форму
                postfix += s1.Pop();
            return true;
        }

        static void Main(string[] args)
        {
            // Инициализируем строку для считывания выражения инфиксной формы
            Console.WriteLine("Введите данные для преобразования из инфиксной формы в префиксную форму");
            string infix = Console.ReadLine();
            // Инициализируем строку - разделитель
            string[] tokens = infix.Split(' ');

            // Инициализируем стэк для работы с выражением
            Stack<string> s = new Stack<string>();
            List<string> outputList = new List<string>();
            int n;

            // Начинаем перебор строки при помощи разделителя
            foreach (string c in tokens)
            {
                // Преобразуем тип, в случае удачи получаем true и добавляем в стэк переменную
                if (int.TryParse(c.ToString(), out n))
                {
                    outputList.Add(c);
                }
                // Добавляем обработку скобок
                if (c == "(")
                {
                    // Добавляем в верх стэка скобку
                    s.Push(c);
                }
                // Добавляем обработку скобок
                if (c == ")")
                {
                    while (s.Count != 0 && s.Peek() != "(")
                    {
                        // Добавляем в конец стэка скобку
                        outputList.Add(s.Pop());
                    }
                    s.Pop();
                }
                // Добавляем обработку операторов
                // Если оператор обнаружен, добавляем его в конец стэка
                if (isOperator(c) == true)
                {
                    while (s.Count != 0 && Priority(s.Peek()) >= Priority(c))
                    {
                        // Добавляем в список оператор
                        outputList.Add(s.Pop());
                    }
                    // Добавляем в стэк оператор
                    s.Push(c);
                }
            }
            // Если какой то оператор остался в стеке, добавляем их все и переносим пока стек не опустеет 
            while (s.Count != 0)
            {
                outputList.Add(s.Pop());
            }
            // Циклически выводим полученный результат в списке
            Console.WriteLine("Инфиксная форма:\t" + infix);
            Console.Write("Префиксная форма:\t");
            for (int i = 0; i < outputList.Count; i++)
            {
                Console.Write("{0}", outputList[i]);
            }

            Console.ReadLine();

            // Инициализируем строку для считывания выражения инфиксной формы
            Console.WriteLine("Введите данные для преобразования из инфиксной формы в постфиксную форму");
            infix = Console.ReadLine();

            // Инициализируем переменную постфиксной формы
            string postfix = "";
            // При помощи функции проводим конвертацию
            convert(ref infix, out postfix);
            // Выводим полученнный результат
            Console.WriteLine("Инфиксная форма:\t" + infix);
            Console.WriteLine("Постфиксная форма:\t" + postfix);
            
        }

        /// <summary>
        /// Инициализируем переменную для работы с приоритетом знаков
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static int Priority(string c)
        {
            // Задаем приоритет знаку степени
            if (c == "^")
            {
                return 3;
            }
            // Задаем приоритет знаку умножения или деления
            else if (c == "*" || c == "/")
            {
                return 2;
            }
            // Задаем приоритет знаку сложения или разности
            else if (c == "+" || c == "-")
            {
                return 1;
            }
            // Возвращаем нулевое значение, если знаков нет
            else
            {
                return 0;
            }
        }
        // Функция определяющая является ли переменная операторм
        static bool isOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
