using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_lab_3
{
    public class Matrix
    {
        private double[,] array;

        // Конструктор с двумя параметрами int, int
        public Matrix(int n, int m)
        {
            array = new double[n, m];

            // Заполнение диагоналей выше и включая побочную
            for (int diagonal = 0; diagonal < n; diagonal++)
            {
                for (int i = diagonal, j = 0; i >= 0 && j < m; i--, j++)
                {
                    Console.Write("Введите численный элемент ({0},{1}) = ", i, j);
                    array[i,j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            // Заполнение диагоналей ниже побочной
            for (int diagonal = 1; diagonal < m; diagonal++)
            {
                for (int i = n - 1, j = diagonal; i >= 0 && j < m; i--, j++)
                {
                    Console.Write("Введите численный элемент ({0},{1}) = ", i, j);
                    array[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        // Конструктор с 1 параметром int
        public Matrix(int n)
        {
            array = new double[n, n];

            // Заполняем случайными числами из интервала [0; 1]
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Проверка положения элемента относительно побочной диагонали
                    if (j >= n - 1 - i)
                    {
                        // Элементы на побочной диагонали и ниже (меньше или равны 0.5)
                        array[i, j] = random.NextDouble() * 0.5;
                    }
                    else
                    {
                        // Элементы выше побочной диагонали (больше 0.5)
                        array[i, j] = 0.5 + random.NextDouble() * 0.5;
                    }
                }
            }
        }

        // Конструктор с 1 параметром uint
        public Matrix(uint n)
        {
            array = new double[n, n];

            // Заполняем змейкой
            int value = 1;      // начальное значение
            int lineCount = 0;  // счётчик линий

            // Заполнение главной диагонали и ниже неё
            do
            {
                // Для каждой диагонали параллельной главной
                for (int i = 0; i < n - lineCount; i++)
                {
                    // Элементы либо возрастают, либо убывают
                    array[i + lineCount, i] = (lineCount % 2 == 0) ? value++ : --value;
                }

                // Новое стартовое значение вычисляется благодаря счётчику диагоналей
                value = (lineCount % 2 == 0) ? (int)n - lineCount : 1;
                // Увеличиваем счётчик
                lineCount++;
            } while (lineCount < n);
        }

        // Конструктор для задания 3
        public Matrix(uint n, uint m)
        {
            array = new double[n, m];
        }

        // Метод проверки наличия столбца
        public bool CanSplitMatrix()
        {
            // Вычисляем количество столбцов и строк массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            // Пройдём по каждому столбцу, не включая первый и последний
            for (int col = 1; col < cols - 1; col++)
            {
                // Задаём начальные значения для сумм
                double leftSum = 0, rightSum = 0;

                // Вычисляем сумму элементов слева от текущего столбца (не включая его)
                for (int j = 0; j < col; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        leftSum += array[i, j];
                    }
                }

                // Вычисляем сумму элементов справа от текущего столбца (не включая его)
                for (int j = col + 1; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        rightSum += array[i, j];
                    }
                }

                // Проверяем условие
                if (leftSum > rightSum)
                {
                    return true;
                }
            }

            return false;
        }

        // Перегрузка метода ToString()
        public override string ToString()
        {
            // Начальная пустая строка
            string str = "";

            // Проходимся по всему массиву
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // Записываем элементы строки массива
                    str += "\t" + array[i, j];  
                }
                str += "\n";    // Переходим на следующую строку
            }

            return str;
        }

        // Перегрузка операций

        // Сложение
        public static Matrix operator +(Matrix a, Matrix b)
        {
            // Записываем размеры матриц
            int rowsA = a.array.GetLength(0);
            int colsA = a.array.GetLength(1);
            int rowsB = b.array.GetLength(0);
            int colsB = b.array.GetLength(1);

            // Проверяем на возможность проведения операции
            if (rowsA != rowsB || colsA != colsB) 
            {
                throw new Exception();
            }

            // Создаём результирующую матрицу
            Matrix result = new Matrix((uint)rowsA, (uint)colsA);

            // Проходим по всем элементам матриц
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    // Элемент результирующей матрицы равен сумме аналогичных элементов матриц
                    result.array[i, j] = a.array[i, j] + b.array[i, j];
                }
            }

            return result;
        }


        // Вычитание
        public static Matrix operator -(Matrix a, Matrix b) 
        {
            // Записываем размеры матриц
            int rowsA = a.array.GetLength(0);
            int colsA = a.array.GetLength(1);
            int rowsB = b.array.GetLength(0);
            int colsB = b.array.GetLength(1);

            // Проверяем на возможность проведения операции
            if (rowsA != rowsB || colsA != colsB)
            {
                throw new Exception();
            }

            // Создаём результирующую матрицу
            Matrix result = new Matrix((uint)rowsA, (uint)colsA);

            // Проходим по всем элементам матриц
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    // Элемент результирующей матрицы равен разности аналогичных элементов матриц
                    result.array[i, j] = a.array[i, j] - b.array[i, j];
                }
            }

            return result;
        }


        // Умножение числа на матрицу
        public static Matrix operator *(int value, Matrix matrix)
        {
            // Записываем размеры матрицы
            int rows = matrix.array.GetLength(0);
            int cols = matrix.array.GetLength(1);

            // Создаём результирующую матрицу
            Matrix result = new Matrix((uint)rows, (uint)cols);

            // Проходим по всем элементам матрицы
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Элемент результирующей матрицы равен аналогичному элементу матрицы, умноженному на число
                    result.array[i, j] = matrix.array[i, j] * value;
                }
            }

            return result;
        }


        // Транспонирование матрицы (!)
        public static Matrix operator !(Matrix matrix)
        {
            // Записываем размеры матрицы
            int rows = matrix.array.GetLength(0);
            int cols = matrix.array.GetLength(1);

            // Создаём результирующую матрицу
            Matrix result = new Matrix((uint)cols, (uint)rows);

            // Проходим по всем элементам матрицы
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Элемент [i, j] результирующей матрицы равен элементу [j, i] исходной матрицы 
                    result.array[j, i] = matrix.array[i, j];
                }
            }

            return result;
        }
    }
}
