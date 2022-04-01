using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ПР14__1_
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Глазкова, Васина");
            Console.WriteLine("пр14");
            StreamReader sr = new StreamReader(@"Input.txt");
            string text = sr.ReadToEnd();
            Console.WriteLine(text);
            string[] textArray = text.Split(' ');
            //v1
            string search = Console.ReadLine();
            int count = 0;
            foreach (string i in text.Split(',', '.', ':', '!', '?', ' '))
                if (i == search) count++;

            if (count != 0) Console.WriteLine($"Cлово {search} встречается {count} раз.");
            else Console.WriteLine("В тексте нет искомого слова.");
            StreamWriter sw = new StreamWriter(@"Result.txt", false, Encoding.Default);
            sw.WriteLine("Вариант 1");
            sw.WriteLine($"Слово {search} повторяется {count} раз.");
            

            //4
            
            
            string[] textArray1 = text.Split(' ');
            int[] lengthArray = new int[textArray1.Length];
            lengthArray = textArray1.Select(x => DeletePunctiation(x).Length).ToArray();
            Console.WriteLine($"Кол-во коротких слов: {lengthArray.Min()}");
            int count1 = textArray1.Count(x => x.Length == lengthArray.Min());
            Console.WriteLine($"длина короткого слова - {count1}");
            sw.WriteLine("Вариант 4");
            sw.WriteLine($"кол-во коротких слов - {lengthArray.Min()}");
            sw.WriteLine($"длина короткого слова - {count1}");
            
            //8
            string newtext = "";
            foreach (char c in text)
            {
                if (Char.IsUpper(c))
                    newtext += c.ToString().ToLower();
                else
                    newtext += c.ToString().ToUpper();
                       
            }
           
            sw.WriteLine("Вариант 8");
            sw.WriteLine($"{newtext}");

            //2
            string[] textArray2 = text.Split(' ');
            int[] lengthArray1 = new int[textArray2.Length];
            lengthArray1 = textArray2.Select(x => x.Length).ToArray();
            Console.WriteLine(lengthArray1.Max());
            int count2 = textArray2.Count(x => x.Length == lengthArray1.Max());
            Console.WriteLine(count);
            sw.WriteLine("Вариант 4");
            sw.WriteLine($"кол-во длинных слов - {count}");
            sw.WriteLine($"длина длинного слова - {count2}");

            //3
            sw.WriteLine("Вариант 3");
            Console.WriteLine("Слова отсортированные по алфавиту:");
            sw.WriteLine("Слова отсортированные по алфавиту:");
            foreach (string w in textArray.OrderBy(x => x).Distinct())
                
            {   
                Console.WriteLine(DeletePunctiation(w));
                sw.WriteLine(DeletePunctiation(w));
            }


            //6
            sw.WriteLine("Вариант 6");
            
            
            string rusalphabit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string englishalphabit = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int engcount = text.Count(x => englishalphabit.Contains(x));
            int ruscount = text.Count(x => rusalphabit.Contains(x));
            Console.WriteLine("Каких букв больше? ");
            if (ruscount > engcount) Console.WriteLine("Русских букв больше");
            else
                if (ruscount < engcount) Console.WriteLine("Английских букв больше");
            else
                Console.WriteLine("Одинаковое кол-во русских и английских букв");
            sw.WriteLine("Каких букв больше? ");
            if (ruscount > engcount) sw.WriteLine("Русских букв больше");
            else
                if (ruscount < engcount) sw.WriteLine("Английских букв больше");
            else
                sw.WriteLine("Одинаковое кол-во русских и английских букв");



            sw.Close();

            Console.ReadKey();
        }
        private static string DeletePunctiation(string inputword)
        {
            string outword = "";
            string punctuation = ".,?!;;-\"\'()";
            foreach (char simbol in inputword)
                if (!punctuation.Contains(simbol)) outword += simbol;
            return outword;
        }
    }
}
