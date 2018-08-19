using System;

namespace GeneticGenericAlgorithm
{
    public class DNA<T>
    {
        private readonly Random _random;
        public T[] Genes { get; private set; }
        public int Size { get; private set; }
        private readonly Func<T> GetRandomGene;
        private readonly Func<int, float> FitnessFunction;

        public DNA(Random random, int size, Func<T> getRandomGene,
            Func<int, float> fitnessFunction, bool shouldInitGenes = true)
        {
            _random = random;
            Size = size;
            GetRandomGene = getRandomGene;
            FitnessFunction = fitnessFunction;
            if (shouldInitGenes)
            {
                for (int i = 0; i < Genes.Length; i++)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }

        public float CalcFitness(int index) => FitnessFunction(index);

        public DNA<T> Crossover(DNA<T> partner)
        {
            DNA<T> child = new DNA<T>(_random, Genes.Length, GetRandomGene,
                FitnessFunction, shouldInitGenes: false);

            for (int i = 0; i < Genes.Length; i++)
            {
                child.Genes[i] = _random.NextDouble() < 0.5 ? partner.Genes[i] : this.Genes[i];
            }

            return child;
        }

        private void Mutate(float mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (_random.NextDouble() < mutationRate)
                {
                    Genes[i] = GetRandomGene();
                }
            }
        }
    }
}