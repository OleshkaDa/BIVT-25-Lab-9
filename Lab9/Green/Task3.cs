using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9.Green
{
    public class Task3 : Green
    {
        private string _sequence;
        private string[] _output;

        public string[] Output => _output;

        public Task3(string input, string sequence) : base(input)
        {
            _sequence = sequence;
            _output = new string[0];


        }

        private string[] Splituem()
        {
            char[] simbols = new char[]
            {
                ' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '\t',
                '-', '—', '(', ')', '[', ']', '{', '}', '"', '\'', ' '
             };

            var words = Input
                    .Split(simbols)
                    .Where(w => w.Length>0)
                    .ToArray();
            return words;
        }


        public string[] Resenie()
        {
            string[] graznie_slova = new string[10000];
            int k = 0;

            string[] words = Splituem();
            string lowerSequence = _sequence.ToLower();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];              // оригинал
                string lowerWord = word.ToLower();   // для сравнения

                if (lowerWord.Contains(lowerSequence))
                {
                    bool est = false;

                    for (int m = 0; m < k; m++)
                    {
                        // сравниваем без учета регистра
                        if (string.Equals(graznie_slova[m], word, StringComparison.OrdinalIgnoreCase))
                        {
                            est = true;
                            break;
                        }
                    }

                    if (!est)
                    {
                        // добавляем ориг
                        graznie_slova[k++] = word;
                    }
                }
            }

            string[] result = new string[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = graznie_slova[i];
            }

            return result;
        }

        public override void Review()
        {
            _output = Resenie();
        }

        public override string ToString()
        {
            return _output == null || _output.Length == 0
                ? ""
                : string.Join("\r\n", _output);
        }
    }

}

