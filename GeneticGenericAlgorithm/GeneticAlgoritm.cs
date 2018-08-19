using System;
using System.Collections.Generic;

namespace GeneticGenericAlgorithm
{
    public class GeneticAlgoritm<T>
    {
        private readonly string _target;
        private readonly int PopulationSize;
        private readonly Random _random;
        private readonly float MutationRate;
        public int GenCount;
        public List<DNA<T>> Population;

        public GeneticAlgoritm(int populationSize, float mutationRate,
            Random random, string target, Func<T> getRandomGene,
            Func<int, float> fitnessFunction)
        {
            GenCount = 1;
            _target = target;
            _random = random;
            PopulationSize = populationSize;
            Population = new List<DNA<T>>(PopulationSize);
            throw new NotImplementedException();
        }

        public void CreateNewGenration()
        {
            List<DNA<T>> newPopulation = new List<DNA<T>>(PopulationSize);
        }

        public void PickOne()
        {
            Population
        }
    }
}