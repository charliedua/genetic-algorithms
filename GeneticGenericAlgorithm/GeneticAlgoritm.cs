using System;
using System.Collections.Generic;

namespace GeneticGenericAlgorithm
{
    public class GeneticAlgoritm<T>
    {
        public int GenCount;
        public List<DNA<T>> Population;
        private readonly float _mutationRate;
        private readonly Random _random;
        private readonly string _target;
        private readonly int PopulationSize;
        private float fitnessSum;
        private List<DNA<T>> newPopulation;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneticAlgoritm{T}"/> class.
        /// </summary>
        /// <param name="populationSize">Size of the population.</param>
        /// <param name="mutationRate">The mutation rate.</param>
        /// <param name="random">The random.</param>
        /// <param name="target">The target.</param>
        /// <param name="getRandomGene">The get random gene.</param>
        /// <param name="fitnessFunction">The fitness function.</param>
        public GeneticAlgoritm(int populationSize, float mutationRate,
            Random random, string target, Func<T> getRandomGene,
            Func<int, float> fitnessFunction)
        {
            GenCount = 1;
            _target = target;
            _random = random;
            _mutationRate = mutationRate;
            PopulationSize = populationSize;
            Population = new List<DNA<T>>(PopulationSize);
            newPopulation = new List<DNA<T>>(PopulationSize);
            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new DNA<T>(_random, target.Length,
                    getRandomGene, fitnessFunction));
            }
        }

        /// <summary>
        /// Calculates the fitness.
        /// </summary>
        public void CalcFitness()
        {
            fitnessSum = 0;
            for (int i = 0; i < Population.Count; i++)
            {
                fitnessSum += Population[i].CalcFitness(i);
            }
        }

        /// <summary>
        /// Creates the new genration.
        /// </summary>
        public void CreateNewGenration()
        {
            if (Population.Count > 0)
            {
                CalcFitness();
                Population.Sort(CompareDna);
            }
            // List<DNA<T>> newPopulation = new List<DNA<T>>(PopulationSize);
            newPopulation.Clear();

            for (int i = 0; i < Population.Count; i++)
            {
                var mom = PickOne();
                var dad = PickOne();
                var child = mom.Crossover(dad);
                child.Mutate(_mutationRate);
                newPopulation.Add(child);
            }
            Swap(Population, newPopulation);
            GenCount++;
        }

        /// <summary>
        /// Picks the one.
        /// </summary>
        /// <returns></returns>
        public DNA<T> PickOne()
        {
            float randomNumber = _random.Next(1, 101) / 100 * fitnessSum;
            for (int i = 0; i < Population.Count; i++)
            {
                if (randomNumber < Population[i].Fitness)
                {
                    return Population[i];
                }
                randomNumber -= Population[i].Fitness;
            }
            return null;
        }

        /// <summary>
        /// Swaps the DNAs.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        public void Swap(List<DNA<T>> a, List<DNA<T>> b)
        {
            List<DNA<T>> temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Compares the dna.
        /// </summary>
        /// <param name="dnaA">The dna a.</param>
        /// <param name="dnaB">The dna b.</param>
        /// <returns></returns>
        private int CompareDna(DNA<T> dnaA, DNA<T> dnaB)
        {
            if (dnaA.Fitness > dnaB.Fitness)
                return -1;
            else if (dnaA.Fitness < dnaB.Fitness)
                return 1;
            else
                return 0;
        }
    }
}