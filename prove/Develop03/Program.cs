using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Represents a word in the scripture
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }
    }

    // Represents the reference of the scripture
    public class Reference
    {
        public string Book { get; private set; }
        public string Chapter { get; private set; }
        public string Verse { get; private set; }

        public Reference(string book, string chapter, string verse)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
        }

        public Reference(string book, string chapter, string startVerse, string endVerse)
        {
            Book = book;
            Chapter = chapter;
            Verse = $"{startVerse}-{endVerse}";
        }

        public override string ToString()
        {
            return $"{Book} {Chapter}:{Verse}";
        }
    }

    // Represents the scripture itself
    public class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> Words { get; set; }

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public void HideRandomWord()
        {
            Random rand = new Random();
            int index = rand.Next(Words.Count);
            Words[index].IsHidden = true;
        }

        public string Display()
        {
            return $"{Reference}\n" + string.Join(" ", Words.Select(w => w.IsHidden ? "_____" : w.Text));
        }

        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("John", "3", "16");
            Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Display());
                Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                if (!scripture.AllWordsHidden())
                {
                    scripture.HideRandomWord();
                }

                if (scripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All words are now hidden. Goodbye!");
                    break;
                }
            }
        }
    }
}
