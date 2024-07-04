/// <summary>
/// Создать программу работы с матрицами (двухмерными массивами) c возможностью выбора размера матрицы
/// Элементы вводятся вручную
/// Вывести матрицу на консоль (добавить оформление, чтобы выглядело как матрица)
/// Реализовать меню выбора действий:
/// - Найти количество положительных/отрицательных чисел в матрице
/// - Сортировка элементов матрицы построчно (в двух направлениях)
/// - Инверсия элементов матрицы построчно
/// - Все математические операции реализовать вручную, без использования статических методов класса Array
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Работа с матрицами");
        int line_count = 0, column_count = 0;
        int[,] matrix = new int[line_count, column_count];
        int[,] matrixCopy = new int[line_count, column_count];
        while (true)
        {
            var again = false;
            MenuText();
            var operation = GetOperation();
            if (operation == 0)
                Environment.Exit(0);
            if (line_count > 0 && column_count > 0)
            {
                Console.WriteLine("Провести операцию с уже созданной матрицей? (да/нет)");
                again = Console.ReadLine().ToLower() == "да";
            }
            if (!again)
            {
                CheckInput(ref line_count, "строк");
                CheckInput(ref column_count, "столбцов");
                matrix = new int[line_count, column_count];
                matrixCopy = matrix;
                InputMatrix(ref matrix, line_count, column_count);
            }
            Console.WriteLine("\nИсходная матрица:");
            OutputMatrix(matrixCopy, line_count, column_count);
            MakeOperation(operation, matrix, line_count, column_count);
        }
    }

    protected static void MenuText()
    {
        Console.WriteLine("Выберите действие (введите номер операции): ");
        Console.WriteLine("1 - найти количество положительных элементов в матрице");
        Console.WriteLine("2 - найти количество отрицательных элементов в матрице");
        Console.WriteLine("3 - сортировка элементов матрицы по возрастанию");
        Console.WriteLine("4 - сортировка элементов матрицы по убыванию");
        Console.WriteLine("5 - инверсия элементов матрицы (построчно)");
        Console.WriteLine("0 - выход из приложения");
    }

    protected static int GetOperation()
    {
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out var operation) && (operation >= 0 && operation <= 5))
                return operation;
            Console.WriteLine("Не удалось распознать номер операции. Пожалуйста, повторите ввод");
        }
    }

    protected static void MakeOperation(int operation, int[,] matrix, int line_count, int column_count)
    {
        switch (operation)
        {
            case 1:
                Console.WriteLine($"Количество положительных элементов в матрице: {CountElement(matrix, line_count, column_count, true)}\n");
                break;
            case 2:
                Console.WriteLine($"Количество отрицательных элементов в матрице: {CountElement(matrix, line_count, column_count, false)}\n");
                break;
            case 3:
                MatrixSort(matrix, line_count, column_count, true);
                break;
            case 4:
                MatrixSort(matrix, line_count, column_count, false);
                break;
            case 5:
                MatrixReverse(matrix, line_count, column_count);
                break;
        }
    }

    protected static void CheckInput(ref int variable, string text)
    {
        while (true)
        {
            Console.WriteLine($"Введите количество {text} матрицы:");
            if (Int32.TryParse(Console.ReadLine(), out variable))
                if (variable > 0) break;
                else Console.WriteLine("Размер матрицы должен быть больше нуля");
            else
                Console.WriteLine("Полученная строка не является числом. Повторите ввод");
        }
    }

    protected static void InputMatrix(ref int[,] matrix, int line_count, int column_count)
    {
        Console.WriteLine("Заполнить матрицу рандомными числами от -100 до 100?");
        if (Console.ReadLine().ToLower() == "да")
        {
            var rand = new Random();
            for (int i = 0; i < line_count; i++)
            {
                for (int j = 0; j < column_count; j++)
                    matrix[i, j] = new Random().Next(-100, 100);
            }
            return;
        }

        for (int i = 0; i < line_count; i++)
        {
            for (int j = 0; j < column_count; j++)
            {
                Console.WriteLine($"Введите элемент [{i + 1}][{j + 1}]: ");
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out matrix[i, j]))
                        break;
                    Console.WriteLine("Полученная строка не является числом. Повторите ввод");
                }
            }
        }
    }

    protected static void OutputMatrix(int[,] matrix, int line_count, int column_count)
    {
        for (int i = 0; i < line_count; i++)
        {
            for (int j = 0; j < column_count; j++)
                Console.Write($"{matrix[i, j]}\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    protected static int CountElement(int[,] matrix, int line_count, int column_count, bool positive)
    {
        var count = 0;
        for (int i = 0; i < line_count; i++)
        {
            for (int j = 0; j < column_count; j++)
            {
                if (positive)
                    count += matrix[i, j] > 0 ? 1 : 0;
                else
                    count += matrix[i, j] < 0 ? 1 : 0;
            }
        }
        return count;
    }

    protected static void MatrixSort(int[,] matrix, int line_count, int column_count, bool rise)
    {
        if (rise)
        {
            for (int k = 0; k < line_count * column_count; k++)
                for (int i = 0; i < line_count; i++)
                {
                    for (int j = 0; j < column_count - 1; j++)
                    {
                        if (matrix[i, j] > matrix[i, j + 1])
                        {
                            var temp = matrix[i, j];
                            matrix[i, j] = matrix[i, j + 1];
                            matrix[i, j + 1] = temp;
                        }
                        if (i != line_count - 1 && matrix[i, column_count - 1] > matrix[i + 1, 0])
                        {
                            var temp = matrix[i, column_count - 1];
                            matrix[i, column_count - 1] = matrix[i + 1, 0];
                            matrix[i + 1, 0] = temp;
                        }
                    }
                }

        }
        else
        {
            for (int k = 0; k < line_count * column_count; k++)
                for (int i = 0; i < line_count; i++)
                {
                    for (int j = 0; j < column_count - 1; j++)
                    {
                        if (matrix[i, j] < matrix[i, j + 1])
                        {
                            var temp = matrix[i, j];
                            matrix[i, j] = matrix[i, j + 1];
                            matrix[i, j + 1] = temp;
                        }
                        if (i != line_count - 1 && matrix[i, column_count - 1] < matrix[i + 1, 0])
                        {
                            var temp = matrix[i, column_count - 1];
                            matrix[i, column_count - 1] = matrix[i + 1, 0];
                            matrix[i + 1, 0] = temp;
                        }
                    }
                }
        }
        Console.WriteLine($"Отсортированная по {(rise ? "возрастанию" : "убыванию")} матрица");
        OutputMatrix(matrix, line_count, column_count);
    }

    protected static void MatrixReverse(int[,] matrix, int line_count, int column_count)
    {
        for (int i = 0; i < line_count; i++)
        {
            int start = 0;
            int end = column_count - 1;
            while (start < end)
            {
                var temp = matrix[i, start];
                matrix[i, start] = matrix[i, end];
                matrix[i, end] = temp;
                start++;
                end--;
            }
        }
        Console.WriteLine($"Инверсированная матрица (построчно)");
        OutputMatrix(matrix, line_count, column_count);
    }

}