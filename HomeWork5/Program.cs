using System.Text.RegularExpressions;

/// <summary>
/// Считать строку текста из консоли (продвинутое задание: из файла).
/// Строка содержит буквы латинского алфавита, знаки препинания и цифры.
/// Реализовать меню выбора действий:
/// - Найти слова, содержащие максимальное количество цифр.
/// - Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.
/// - Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».
/// - Вывести на экран сначала вопросительные, а затем восклицательные предложения.
/// - Вывести на экран только предложения, не содержащие запятых.
/// - Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
/// Приложение не должно падать ни при каких условиях.
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        var again = false;
        string text = string.Empty;
        Console.WriteLine("Работа с текстом");
        while (true)
        {
            MenuText();
            var operation = GetOperation(0, 6);
            if (operation == 0)
                Environment.Exit(0);
            if (!String.IsNullOrEmpty(text))
            {
                Console.WriteLine("\nПровести операцию с уже заданным текстом? (да/нет)");
                again = Console.ReadLine().ToLower() == "да";
            }
            if (!again)
            {
                text = GetText();
            }
            Console.WriteLine($"\nИсходный текст:\n{text}");
            MakeOperation(operation, ClearText(text));
            Console.WriteLine();
        }
    }

    protected static void MenuText()
    {
        Console.WriteLine("\nВыберите действие (введите номер операции): ");
        Console.WriteLine("1 - Найти слова, содержащие максимальное количество цифр");
        Console.WriteLine("2 - Найти самое длинное слово и определить, сколько раз оно встретилось в тексте");
        Console.WriteLine("3 - Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять»");
        Console.WriteLine("4 - Вывести на экран сначала вопросительные, а затем восклицательные предложения");
        Console.WriteLine("5 - Вывести на экран только предложения, не содержащие запятых");
        Console.WriteLine("6 - Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву");
        Console.WriteLine("0 - Выход из программы");

        Console.WriteLine("\nВаш выбор:");
    }

    protected static int GetOperation(int minCount, int maxCount)
    {
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out var operation) && (operation >= minCount && operation <= maxCount))
                return operation;
            Console.WriteLine("Не удалось распознать номер операции. Пожалуйста, повторите ввод");
        }
    }

    protected static string GetText()
    {
        Console.WriteLine("\nВыберите вариант ввода текста:");
        Console.WriteLine("1 - Ввод в консоль");
        Console.WriteLine("2 - Считать из файла");
        Console.WriteLine("Ваш ввод: ");
        var operation = GetOperation(1, 2);
        if (operation == 1)
        {
            while (true)
            {
                Console.WriteLine("\nВведите текст");
                var str = Console.ReadLine();
                if (!String.IsNullOrEmpty(str))
                    return str;
                Console.WriteLine("Пустая строка. Повторите ввод");
            }
        }
        else
        {
            while (true)
            {
                Console.WriteLine("\nВведите название файла с расширением txt (если хотите ввести текст вручную в окнсоль, введите 1):");
                var input = Console.ReadLine();
                if (input == "1") while (true)
                    {
                        var str = Console.ReadLine();
                        if (!String.IsNullOrEmpty(str))
                            return str;
                        Console.WriteLine("Пустая строка. Повторите ввод");
                    }
                else
                {
                    var fileName = input;
                    if (Path.GetExtension(fileName) != ".txt")
                        Console.WriteLine("Расширение файла должно быть txt");
                    else if
                        (!File.Exists(fileName))
                        Console.WriteLine("Файл не найден");
                    else
                    {
                        string str = File.ReadAllText(fileName);
                        if (string.IsNullOrEmpty(str))
                            Console.WriteLine("Пустой файл. Попробуйте сноваЫ");
                        else return str;
                    }
                }
            }
        }
    }
 
    protected static string ClearText(string text)
    {
        while (text.Contains("  "))
            text = text.Replace("  ", " ");
        while (text.Contains("!!"))
            text = text.Replace("!!", "!");
        while (text.Contains("??"))
            text = text.Replace("??", " ");
        while (text.Contains(".. "))
            text = text.Replace(".. ", " ");
        return text;
        
    }

    protected static void MakeOperation(int operation, string text)
    {
        switch (operation)
        {
            case 1:
                GetMaxNumWords(text);
                break;
            case 2:
                LongestWord(text);
                break;
            case 3:
                ReplaceNumbers(text);
                break;
            case 4:
                QuestionExclamationSentences(text);
                break;
            case 5:
                SentencesNoCommas(text);
                break;
            case 6:
                SameLetterStartsEnds(text);
                break;
        }
    }

    /// <summary>
    /// Правило преобразования:
    /// если в середине слова стоит знак препинания '.', '!', '?', то знак будет считаться концом предложения, а слово будет разделено на два
    /// если в середине слова стоит знак препинания ',', ';', ':', то слово будет разделено на два
    /// </summary>
    /// <param name="text"></param>
    protected static string[] GetWordsArray(string text)
    {
        text = text.Replace("\r\n", " ");
        var textSplit = text.Split(' ').Where(t => !String.IsNullOrEmpty(t)).Where(w => Regex.IsMatch(w, @"\b\w*\S?\w+")).Select(w => w = Regex.Match(w, @"\b\w*\S?\w+").Value).ToArray();
        var wordsArray = new List<string>();
        foreach (var word in textSplit)
        {
            var match = Regex.Match(word, @"\!|\?|\.|\,|\;|\:");
            if (match.Success)
            {
                var words = word.Split(match.Value);
                foreach(var w in words)
                    wordsArray.Add(w);
            }
            else wordsArray.Add(word);

        }
        return wordsArray.ToArray();
    }

    protected static string[] GetSentenceArray(string text)
    {
        text = text.Replace("\r\n", "");
        var sentenceArray = text.Split(new char[] { '.', '!', '?' });
        for (int i = 0; i < sentenceArray.Length; i++)
        {
            var lastCharIndex = text.IndexOf(sentenceArray[i]) + sentenceArray[i].Length;
            if (lastCharIndex == text.Length)
                break;
            sentenceArray[i] += text[lastCharIndex];
        }
        return sentenceArray.Select(s=>s.Trim()).ToArray();
    }

    protected static void GetMaxNumWords(string text)
    {
        var wordsArray = GetWordsArray(text);
        wordsArray = wordsArray.Where(w => Regex.IsMatch(w, @"\d+")).ToArray();
        if (wordsArray.Length == 0)
        {
            Console.WriteLine("\nНе найдно слов с цифрами");
        }
        else
        {
            var wordsNumsLength = new Dictionary<string, int>();
            foreach (var word in wordsArray)
            {
                if (wordsNumsLength.ContainsKey(word))
                    continue;
                var nums = String.Join("", Regex.Matches(word, @"\d+").Select(m => m.Value));
                wordsNumsLength.Add(word, nums.Length);
            }
            var maxNumsLength = wordsNumsLength.Where(wnl => wnl.Value == wordsNumsLength.Max(w => w.Value)).ToArray();

            Console.WriteLine($"\nМаксимальное количество цифр в слове: {wordsNumsLength.Max(w => w.Value)}");
            Console.WriteLine($"Слова с максимальным количеством цифр:");
            foreach (var word in maxNumsLength)
                Console.WriteLine($"Слово \"{word.Key}\""); 
        }
    }

    protected static void LongestWord(string text)
    {
        var wordsArray = GetWordsArray(text);
        var longestWords = wordsArray.Where(w=>w.Length == wordsArray.Max(w=>w.Length)).ToArray();

        Console.WriteLine($"\nСамые длинные слова:");
        foreach(var word in longestWords)
        {
            var count = wordsArray.Where(w => w == longestWords[0]).ToArray().Length;
            Console.WriteLine($"Слово \"{word}\", длина {word.Length}, повторений в тексте {count}");
        }

    }

    protected static void ReplaceNumbers(string text)
    {
        var numbers = new Dictionary<string, string>()
        {
            {"0","ноль"}, {"1","один"},
            {"2","два"}, {"3","три"},
            {"4","четыре"}, {"5","пять"},
            {"6","шесть"}, {"7","семь"},
            {"8","восемь"}, {"9","девять"}
        };
        var str = text;
        foreach (var num in numbers)
            str = str.Replace(num.Key, num.Value);
        Console.WriteLine("\nТекст с заменой цифр на слова:");
        Console.WriteLine(str);

    }

    protected static void QuestionExclamationSentences(string text)
    {
        var sentenceArray = GetSentenceArray(text);
        var questionSentence = sentenceArray.Where(s => s.Last() == '?').ToArray();
        var exclamationSentence = sentenceArray.Where(s => s.Last() == '!').ToArray();
        if (questionSentence.Length == 0)
            Console.WriteLine("\nВ тексте отсутсвуют вопросительные предложения");
        else
        {
            Console.WriteLine("\nВопросительные предложения:");
            foreach(var sentence in questionSentence)
                Console.WriteLine(sentence);
        }
        if (exclamationSentence.Length == 0)
            Console.WriteLine("\nВ тексте отсутсвуют восклицательные предложения");
        else
        {
            Console.WriteLine("\nВосклицательные предложения:");
            foreach(var sentence in exclamationSentence)
                Console.WriteLine(sentence);
        }
    }

    protected static void SentencesNoCommas(string text)
    {
        var sentenceArray = GetSentenceArray(text);
        var sentenceNoCommas = sentenceArray.Where(s => !s.Contains(",")).ToArray();
        if (sentenceNoCommas.Length == 0)
            Console.WriteLine("\nВ тексте отсутсвуют предложения без запятых");
        else
        {
            Console.WriteLine("\nПредложения без запятых:");
            foreach (var sentence in sentenceNoCommas)
                Console.WriteLine(sentence);
        }
    }

    protected static void SameLetterStartsEnds(string text)
    {
        var wordsArray = GetWordsArray(text);
        wordsArray = wordsArray.Where(w => w.Length > 1 && w.First() == w.Last()).ToArray();
        if (wordsArray.Length == 0)
            Console.WriteLine("Не удалось найти слова, которые начинаются и заканчиваются на одну и туже букву");
        else
        {
            Console.WriteLine($"\nСлова, которые начинаются и заканчиваются на одну и туже букву:");
            foreach(var word in wordsArray)
                Console.WriteLine(word);
        }
    }
}

