using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    public class DNA
    {
        private char[] genes;

        public DNA(int target)
        {
            Random random = new Random(new Random().Next(int.MaxValue));
            genes = new char[target];
            var chars = getCharArray();
            for (int i = 0; i < genes.Length; i++)
            {
                genes[i] = chars[random.Next(27)];
            }
        }

        public char[] Genes { get => genes; set => genes = value; }

        public void Mutate(float mutationRate)
        {
            var chars = getCharArray();
            Random random = new Random();
            for (int i = 0; i < genes.Length; i++)
            {
                if (random.Next(101) / 100 < mutationRate)
                {
                    genes[i] = chars[random.Next(27)];
                }
            }
        }

        public override string ToString()
        {
            return string.Concat(genes);
        }

        private char[] getCharArray()
        {
            char[] chars = new char[27];
            int j = 0;
            for (int i = 97; i < 123; i++)
            {
                chars[j++] = (char)i;
            }
            chars[j] = (char)32; // space
            return chars;
        }
    }
}