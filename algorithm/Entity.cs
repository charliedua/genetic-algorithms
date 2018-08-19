﻿using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    public class Entity
    {
        public DNA _data;

        public Entity(int target)
        {
            _data = new DNA(target);
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
            }
            Fitness = (float)score / target.Length;
        }

        public Entity Crossover(Entity partner)
        {
            Random random = new Random();
            Entity child = new Entity(_data.Genes.Length);
            int midpoint = random.Next(_data.Genes.Length);
            for (int i = 0; i < _data.Genes.Length; i++)
            {
                if (i % 2 == 0)
                {
                    child._data.Genes[i] = partner._data.Genes[i];
                }
                else
                {
                    child._data.Genes[i] = _data.Genes[i];
                }
                //if (i > midpoint) { child._data.Genes[i] = _data.Genes[i]; }
                //else { child._data.Genes[i] = partner._data.Genes[i]; }
            }
            return child;
        }
    }
}