using System;


using System.Collections.Generic;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scripture object
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            // Display the complete scripture
            Console.Clear();
            Console.WriteLine(scripture.Reference);
            Console.WriteLine(scripture.Text);

            // Prompt the user to press enter or type quit
            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            // Hide random words until all words are hidden
            while (input.ToLower() != "quit")
            {
                scripture.HideRandomWords();
                Console.Clear();
                Console.WriteLine(scripture.Reference);
                Console.WriteLine(scripture.HiddenText);
                input = Console.ReadLine();
            }
        }
    }

    public class Scripture
    {
        public string Reference { get; set; }
        public string Text { get; set; }
        public string HiddenText { get; set; }
        private List<Word> words;

        public Scripture(string reference, string text)
        {
            Reference = reference;
            Text = text;
            words = new List<Word>();

            // Split the text into individual words
            string[] wordArray = Text.Split(' ');
            foreach (string word in wordArray)
            {
                words.Add(new Word(word));
            }
        }

        public void HideRandomWords()
        {
            // Randomly select a word to hide
            Random rand = new Random();
            Word wordToHide = words[rand.Next(words.Count)];

            // Hide the word
            wordToHide.Hide();

            // Update the hidden text
            HiddenText = "";
            foreach (Word word in words)
            {
                HiddenText += word.HiddenText + " ";
            }
        }
    }

    public class Word
    {
        public string Text { get; set; }
        public string HiddenText { get; set; }
        private int length;

        public Word(string text)
        {
            Text = text;
            length = Text.Length;
            HiddenText = Text;
        }

        public void Hide()
        {
            // Replace the word with underscores
            HiddenText = new string('_', length);
        }
    }
}