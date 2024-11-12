using System;
using System.Collections.Specialized;
using System.Xml.Serialization;
using CSharp_lab_3;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Вариант 16");

        Exercise1();    // Задание 1
        Console.WriteLine();

        Exercise2();    // Задание 2
        Console.WriteLine();

        Exercise3();    // Задание 3
        Console.WriteLine();

        Exercise4();    // Задание 4
        Console.WriteLine();

        Exercise5();    // Задание 5
        Console.WriteLine();

        Exercise6();    // Задание 6
        Console.WriteLine();

        Exercise7();    // Задание 7
        Console.WriteLine();

        Exercise8();    // Задание 8
        Console.WriteLine();
    }

    private static void Exercise1()
    {
        // Задание 1
        Console.WriteLine("Задание 1.");
        // Массив NxM, заполненный с клавиатуры
        int n1, m1;

        Console.WriteLine("Массив NxM");
        try
        {
            Console.Write("Введите количество строк массива: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            if (n1 < 1) throw new Exception();
        
            Console.Write("Введите количество столбцов массива: ");
            m1 = Convert.ToInt32(Console.ReadLine());
            if (m1 < 1) throw new Exception();

        }catch
        {
            Console.WriteLine("Неправильно набран размер массива!");
            return;
        }

        Matrix matrix1;
        try
        {
            matrix1 = new Matrix(n1, m1);
        }
        catch
        {
            Console.WriteLine("Некорректно введены данные для массива");
            return;
        }

        Console.WriteLine("\nПолученный массив:");
        Console.WriteLine(matrix1.ToString());
        Console.WriteLine();

        // Массив NxN со случайными числами
        int n2;

        Console.WriteLine("Массив NxN со случайными числами");
        try
        {
            Console.Write("Введите размер массива: ");
            n2 = Convert.ToInt32(Console.ReadLine());
            if (n2 < 1) throw new Exception();
        }
        catch
        {
            Console.WriteLine("Неправильно набран размер массива!");
            return;
        }

        Matrix matrix2 = new Matrix(n2);

        Console.WriteLine("\nПолученный массив:");
        Console.WriteLine(matrix2.ToString());
        Console.WriteLine();

        // Массив NxN, заполненный по главной диагонали и ниже
        uint n3;

        Console.WriteLine("Массив NxN, заполненный по главной диагонали и ниже");
        try
        {
            Console.Write("Введите размер массива: ");
            n3 = Convert.ToUInt32(Console.ReadLine());
            if (n3 == 0) throw new Exception();
        }
        catch
        {
            Console.WriteLine("Неправильно набран размер массива!");
            return;
        }

        Matrix matrix3 = new Matrix(n3);

        Console.WriteLine("\nПолученный массив:");
        Console.WriteLine(matrix3.ToString());
    }
    private static void Exercise2()
    {
        // Задание 2
        Console.WriteLine("Задание 2.");
        // Вводим новый массив
        int n, m;

        try
        {
            Console.Write("Введите количество строк массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 1) throw new Exception();

            Console.Write("Введите количество столбцов массива: ");
            m = Convert.ToInt32(Console.ReadLine());
            if (m < 1) throw new Exception();

        }
        catch
        {
            Console.WriteLine("Неправильно набран размер массива!");
            return;
        }
        
        // Создаём матрицу NxM и выводим её на экран
        Matrix matrix = new Matrix(n, m);
        Console.WriteLine("Массив выглядит следующим образом: ");
        Console.WriteLine(matrix.ToString());
        Console.WriteLine();

        // Проверяем, существует ли нужный столбец
        bool canSlitMatrix = matrix.CanSplitMatrix();

        // Выводим результат
        if (canSlitMatrix)
            Console.WriteLine("Массив можно разбить");
        else
            Console.WriteLine("Массив нельзя разбить");
    }
    private static void Exercise3() 
    {
        // Задание 3

        Console.WriteLine("Задание 3.");

        // Вводим матрицы и их размеры
        Matrix A, B, C, result;
        uint n1, n2, n3;

        try
        {
            Console.Write("Введите размер матрицы А: ");
            n1 = Convert.ToUInt32(Console.ReadLine());
            if (n1 == 0) throw new Exception();

            Console.Write("Введите размер матрицы B: ");
            n2 = Convert.ToUInt32(Console.ReadLine());
            if (n2 == 0) throw new Exception();

            Console.Write("Введите размер матрицы C: ");
            n3 = Convert.ToUInt32(Console.ReadLine());
            if (n3 == 0) throw new Exception();
        } catch
        {
            Console.WriteLine("Неправильно введен размер матрицы");
            return;
        }

        // Создаём матрицы для работы
        A = new Matrix(n1);
        B = new Matrix(n2);
        C = new Matrix(n3);

        // Вывод матриц А, B и С
        Console.WriteLine("Матрица А:");
        Console.WriteLine(A.ToString());
        Console.WriteLine("Матрица B:");
        Console.WriteLine(B.ToString());
        Console.WriteLine("Матрица C:");
        Console.WriteLine(C.ToString());

        // Само выражение
        try
        {
            result = A + (B - 3 * !C);  // Здесь ! - транспонирование матрицы
        }
        catch
        {
            Console.WriteLine("Размеры матриц не подходят для данной операции");
            return;
        }
        
        // Вывод результата
        Console.WriteLine("Результат:");
        Console.WriteLine(result.ToString());
    }


    private static void Exercise4()
    {
        // Задание 4
        Console.WriteLine("Задание 4.");

        // Даём имена файлам
        string inputFilePath = "input.bin";
        string outputFilePath = "output.bin";

        // Генерация исходного файла с случайными числовыми данными
        GenerateRandomBinFile(inputFilePath, 50); // Допустим в нём 50 чисел
        Console.WriteLine();

        // Чтение чисел из исходного файла и запись подходящих чисел в новый файл
        CopyMatchingNumbers(inputFilePath, outputFilePath);

        Console.WriteLine("Задание выполнено. Проверьте файл {0}", outputFilePath);
    }
    // Метод генерации чисел в bin-файле
    private static void GenerateRandomBinFile(string filePath, int count)
    {
        Console.WriteLine("Содержимое файла {0}", filePath);
        Random random = new Random();
        // Используем using для автоматического контроля за ресурсами
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                // Генерируем число от -999 до 999
                int number = random.Next(-999, 1000);
                // Записываем его в файл
                writer.Write(number);

                // Выводим в консоль для вида
                Console.Write(number + " ");
            }
        }
    }
    // Метод для чтения и подходящих чисел
    private static void CopyMatchingNumbers(string inputFilePath, string outputFilePath)
    {
        Console.WriteLine("Содержимое файла {0}", outputFilePath);

        // Используем using для автоматического контроля за ресурсами
        using (BinaryReader reader = new BinaryReader(File.Open(inputFilePath, FileMode.Open)))
        using (BinaryWriter writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
        {
            // Пока файл не кончился
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                // Получаем число
                int number = reader.ReadInt32();
                // Проверяем, начинается и заканчивается ли оно на одну и ту же цифру
                if (IsStartAndEndDigitSame(number))
                {
                    // Если да, то записываем в другой файл
                    writer.Write(number);
                    Console.Write(number + " ");
                }
            }
        }
        Console.WriteLine();
    }
    // Метод для проверки, начинается и заканчивается ли число на одну и ту же цифру
    static bool IsStartAndEndDigitSame(int number)
    {
        string numStr = Math.Abs(number).ToString(); // Убираем знак для отрицательных чисел
        return numStr[0] == numStr[numStr.Length - 1];
    }


    private static void Exercise5()
    {
        // Задание 5.
        Console.WriteLine("Задание 5.");

        // Даём имя файлу
        string filePath = "toys.bin";

        // Количество случайных чисел в файле (вводит пользователь)
        uint count;
        try
        {
            Console.Write("Введите количество записей для генерации: ");
            count = Convert.ToUInt32(Console.ReadLine());
            if (count == 0) throw new Exception();
        }
        catch
        {
            Console.WriteLine("Неправильно набрано число");
            return;
        }

        Console.WriteLine("Файл содержит следующий список игрушек:");

        // Создаём массив игрушек и заполняем им файл
        GenerateFileToysData(filePath, count);
        Console.WriteLine();

        // Читаем из файла информацию об игрушках в виде кортежа из трёх значений
        (double averagePrice, int minAge, int maxAge) = GetCubesInfo(filePath);

        // Выводим результаты (средняя стоимость выводится с двумя знаками после запятой
        Console.WriteLine($"Средняя стоимость кубиков: {averagePrice:F2} руб.");
        Console.WriteLine($"Возрастные ограничения кубиков: от {minAge} до {maxAge} лет.");
    }
    // Генерация списка игрушек для записи в файл
    private static void GenerateFileToysData(string filePath, uint count)
    {
        // Создаём генератор и массив с именами игрушек
        Random random = new Random();
        string[] names = ["Кубики", "Куклы", "Пазлы", "Машинки"];

        // Создаём массив игрушек
        Toy[] toys = new Toy[count];

        // Каждой игрушке даём имя, цену и возрастные рамки
        for (int i = 0; i < toys.Length; i++)
        {
            // Случайное имя
            string name = names[random.Next(4)];
            // Случайная цена
            int price = random.Next(1000);
            // Случайные возрастные рамки (от 0 до 18)
            int minAge = random.Next(19);
            int maxAge = random.Next(19);

            // Присваиваем значения
            toys[i] = new Toy(name, price, minAge, maxAge);

            // Вывод в консоль для наглядности
            Console.WriteLine($"{toys[i].Name}\t{toys[i].Price}\t{toys[i].MinAge}\t{toys[i].MaxAge}");
        }

        // Записываем массив в файл filePath с помощью xml-сериализации
        Serialize(filePath, toys);
    }
    // Сериализация в файл
    private static void Serialize(string filePath, Toy[] toys)
    {
        XmlSerializer xml = new XmlSerializer(typeof(Toy[]));

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            xml.Serialize(fileStream, toys);
        }
    }
    // Поиск и расчёт информации о кубиках
    private static (double, int, int) GetCubesInfo(string filePath) 
    {
        // Создаём новый массив игрушек
        Toy[] toys = null;
        XmlSerializer xml = new XmlSerializer(typeof(Toy[]));

        // Записываем в него данные из файла
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            toys = (Toy[])xml.Deserialize(fileStream);
        }

        // Если массив игрушек пуст, то возвращаем нули
        if (toys == null) 
        {
            Console.WriteLine("Список игрушек пуст");
            return (0, 0, 0);
        }

        double totalCubePrice = 0;      // Стоимость всех кубиков
        int minAge = int.MaxValue;      // Минимальный возраст
        int maxAge = int.MinValue;      // Максимальный возраст
        int cubeCount = 0;              // Счётчик кубиков

        // Для каждой игрушки в массиве проверяем
        foreach (var toy in toys)
        {
            // Является ли она кубиками
            if (toy.Name == "Кубики")
            {
                // Если да, то прибавляем к сумме 
                totalCubePrice += toy.Price;
                // Увеличиваем счётчик
                cubeCount++;
                // Расчёт возрастных рамок кубиков
                if (toy.MinAge < minAge) minAge = toy.MinAge;
                if (toy.MaxAge > maxAge) maxAge = toy.MaxAge;
            }
        }

        // Высчитываем возрастные рамки в случае отсутствия кубиков среди записей
        if (cubeCount == 0)
        {
            return (0, 0, 0);
        }

        // Средняя стоимость кубиков
        double averagePrice = cubeCount > 0 ? totalCubePrice / cubeCount : 0;

        // Возвращаем кортеж из средней стоимости и возрастных рамок
        return (averagePrice, minAge, maxAge);
    }


    private static void Exercise6()
    {
        // Задание 6
        Console.WriteLine("Задание 6.");

        // Задаём имена файлов
        string inputFilePath = "numbers.txt";
        string outputFilePath = "exercise6.txt";

        // Количество случайных чисел для записи в файл и коэффициент уменьшения (вводит пользователь)
        uint count, k;
        try
        {
            Console.Write("Введите количество чисел для генерации: ");
            count = Convert.ToUInt32(Console.ReadLine());
            if (count == 0) throw new Exception();

            Console.Write("Введите коэффициент уменьшения k (целое положительное число): ");
            k = Convert.ToUInt32(Console.ReadLine());
            if (k == 0) throw new Exception();
        } catch
        {
            Console.WriteLine("Неправильно набрано число");
            return;
        }

        // Заполнение исходного файла случайными данными
        GenerateRandomTxtFile(inputFilePath, count);

        // Уменьшение чисел в k раз и запись в новый файл
        ProcessFile(inputFilePath, outputFilePath, k);

        Console.WriteLine($"Обработка завершена. Проверьте файл {outputFilePath}");
    }
    // Генерация чисел для записи в txt-файл
    private static void GenerateRandomTxtFile(string filePath, uint count)
    {
        // Генератор чисел
        Random random = new Random();

        // Используем using для автоматического контроля за ресурсами
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Генерируем count случайных чисел 
            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(-999, 1000);  // от -999 до 999
                writer.WriteLine(randomNumber);     // Записываем в файл числа по одному в строке
            }
        }
    }
    // Создание нового txt-файла с преображенными числами
    private static void ProcessFile(string inputFilePath, string outputFilePath, uint k) 
    {
        // Открываем файл на чтение
        using (StreamReader reader = new StreamReader(inputFilePath))
        // Открываем файл на запись
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            string line;
            // Читаем файл построчно, пока не достигнем конца файла
            while ((line = reader.ReadLine()) != null)
            {
                // Пробуем преобразовать строку в целое число
                if (int.TryParse(line, out int number))
                {
                    // Уменьшаем число в k раз
                    int result = number / (int)k;
                    // Записываем число в другой файл
                    writer.WriteLine(result);
                }
            }
        }
    }


    private static void Exercise7()
    {
        // Задание 7
        Console.WriteLine("Задание 7.");

        // Задаём имя файла
        string filePath = "exercise7.txt";

        // Задаём количество чисел для генерации
        uint rows, countPerRow;
        try
        {
            Console.Write("Введите количество строк в файле: ");
            rows = Convert.ToUInt32(Console.ReadLine());
            if (rows == 0) throw new Exception();

            Console.Write("Введите количество чисел в строке: ");
            countPerRow = Convert.ToUInt32(Console.ReadLine());
            if (countPerRow == 0) throw new Exception();
        } catch
        {
            Console.WriteLine("Неправильно набрано число");
            return;
        }

        // Генерируем случайные числа в файл
        GenerateRandomNumbersTxtFile(filePath, rows, countPerRow);
        // Считаем сумму первого и максимального элементов
        int sum = SumFirstAndMax(filePath);

        // Выводим результат
        Console.WriteLine($"Сумма первого и максимального элементов: {sum}");
    }

    // Генерируем числа по несколько в строке и записываем их в txt-файл
    private static void GenerateRandomNumbersTxtFile(string filePath, uint rows, uint countPerRow)
    {
        // Создаём генератор
        Random random = new Random();

        // Открываем файл на запись
        // Используем using для автоматического контроля за ресурсами
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Проходимся по всем строкам
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < countPerRow; j++)
                {
                    // Генерируем число от -999 до 999
                    int value = random.Next(-999, 1000);
                    // Записываем число в файл через пробел
                    writer.Write(value + " ");
                }
                // Переходим на новую строку
                writer.WriteLine();
            }
        }
    }
    // Считаем сумму первого и максимального элементов
    private static int SumFirstAndMax(string filePath)
    {
        int? firstNumber = null;        // Первый элемент из файла
        int maxNumber = int.MinValue;   // Максимальный элемент из файла

        using (StreamReader reader = new StreamReader(filePath)) 
        {
            string line;
            // Считываем построчно файл
            while ((line = reader.ReadLine()) != null)
            {
                int currentNumber = 0;  // Текущее число
                int index = 0;          // Количество проработанных чисел

                // Проходимся по строке
                for (int i = 0; i <= line.Length; i++)
                {
                    // Если встречаем конец строки или пробел
                    if (i == line.Length || line[i] == ' ')
                    {
                        // Если перед нами первое число в файле, то записываем его в firstNumber
                        if (index == 0 && firstNumber == null)
                            firstNumber = currentNumber;
                        // Если перед нами максимальное число, то записываем его в maxNumber
                        if (currentNumber > maxNumber)
                            maxNumber = currentNumber;

                        // Начинаем составлять новое число
                        currentNumber = 0;
                        // Увеличиваем количество чисел
                        index++;
                    }
                    else
                    {
                        // Составляем число
                        currentNumber = currentNumber * 10 + (line[i] - '0');
                    }
                }
            }
        }
        // Если первого элемента нет, значит файл был пуст, возвращаем 0
        if (firstNumber == null)
            return 0;

        // Возвращаем значение первого элемента + максимальный элемент
        return firstNumber.Value + maxNumber;
    }


    private static void Exercise8()
    {
        // Задание 8
        Console.WriteLine("Задание 8.");

        // Задаём имена файлам
        string inputFilePath = "exercise8_input.txt";
        string outputFilePath = "exercise8_output.txt";

        using (StreamReader reader = new StreamReader(inputFilePath))
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
            // Проверка, если строка не пустая и ее длина больше 1 для второй буквы
                if (line.Length > 0 && line[0] == 'б' || (line.Length > 1 && line[1] == 'б'))
                {
                    writer.WriteLine(line); // Записываем строку в выходной файл
                }
            }
        }
        Console.WriteLine($"Обработка завершена. Подходящие строки записаны в файл {outputFilePath}");
    }
}