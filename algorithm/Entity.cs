using System;
using System.Collections.Generic;

namespace algorithm
{
    public class Entity
    {
        public DNA _data;

        public Entity(int target, Random random)
        {
            _data = new DNA(target, random);
            Fitness = 0f;
        }

        public float Fitness { get; set; }

        public void CalcFitness(string target)
        {
            int score = 0;
            for (int i = 0; i < _data.Genes.Length; i++)
            {
                var chars = new List<char>(target.ToCharArray());
                if (chars.Contains(_data.Genes[i]))
                {
                    score++;
                }
                // score = (int)Math.Pow((double)score, (double)2);
            }
            Fitness = (float)score / target.Length;
        }

        /// <summary>
        /// Crossovers the specified partner.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <returns>The child</returns>
        public Entity Crossover(Entity partner, Random random)
        {
            Entity child = new Entity(_data.Genes.Length, random);
            for (int i = 0; i < _data.Genes.Length; i++)
            {
                child._data.Genes[i] = random.NextDouble() < 0.5 ? _data.Genes[i] : partner._data.Genes[i];
            }
            //for (int i = 0; i < _data.Genes.Length; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        child._data.Genes[i] = partner._data.Genes[i];
            //    }
            //    else
            //    {
            //        child._data.Genes[i] = _data.Genes[i];
            //    }
            //    //if (i > midpoint) { child._data.Genes[i] = _data.Genes[i]; }
            //    //else { child._data.Genes[i] = partner._data.Genes[i]; }
            //}
            return child;
        }
    }
}