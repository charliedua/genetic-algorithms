using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using algorithm;

// https://natureofcode.com/book/chapter-9-the-evolution-of-code/

namespace Genetic_algorithms
{
    public class Program
    {
        private const float MUTATION_RATE = 0.01f;
        private const int TOTAL_POPULATION = 5;
        private static int gen = 0;

        private static void Main(string[] args)
        {
            string target = "to be or not to be";
            var population = new Entity[TOTAL_POPULATION];
            Random random = new Random();
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new Entity(target.Length, random);
            }
            while (true)
            {
                for (int i = 0; i < population.Length; i++)
                {
                    population[i].CalcFitness(target);
                }

                List<Entity> matingPool = new List<Entity>();

                for (int i = 0; i < population.Length; i++)
                {
                    int n = (int)Math.Round(population[i].Fitness * 100);
                    for (int j = 0; j < n; j++)
                    {
                        matingPool.Add(population[i]);
                        Thread.Sleep(10);
                    }
                }

                //if (matingPool.Count == 0)
                //{
                //    for (int i = 0; i < population.Length; i++)
                //    {
                //        population[i] = new Entity(target.Length);
                //    }
                //    continue;
                //}

                for (int i = 0; i < population.Length; i++)
                {
                    Entity partnerA;
                    Entity partnerB;
                    do
                    {
                        int a = random.Next(matingPool.Count());
                        int b = random.Next(matingPool.Count());
                        partnerA = matingPool[a];
                        partnerB = matingPool[b];
                    } while (partnerA._data.ToString() == partnerB._data.ToString());

                    Entity child = partnerA.Crossover(partnerB, random);

                    child._data.Mutate(MUTATION_RATE);

                    population[i] = child;
                    //Console.Clear();
                    //Console.WriteLine("target  : {0}", target);
                    //Console.WriteLine("Parent 1: {0}", partnerA._data.ToString());
                    //Console.WriteLine("Parent 2: {0}", partnerB._data.ToString());
                    //Console.WriteLine("Child   : {0}", child._data.ToString());
                }
                Console.WriteLine("gen     : {0}", gen);
                gen++;
            }
        }
    }
}