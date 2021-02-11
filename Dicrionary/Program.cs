using System;
using System.Collections.Generic; 

namespace MyDicrionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary myDictionary = new MyDictionary();
            myDictionary.Add("машина", new HashSet<string>() { " car " });
            myDictionary.Add(" rainbow ", new HashSet<string>() { " радуга " });
            Console.WriteLine(myDictionary.ToString());

            string word, translation;
            HashSet<string> translationSet;

            while(true)
            {
                Console.Write("Введите слово для перевода: ");
                word = Console.ReadLine();
                if (word == "") break;
                Console.Write("Введите перевод (один или несколько через запятую): ");
                translation = Console.ReadLine();
                translationSet = new HashSet<string>(translation.Split(','));
                myDictionary.Add(word, translationSet);
            }

            Console.WriteLine(myDictionary.ToString());
        }
    }
}
