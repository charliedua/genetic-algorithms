using System;

namespace GeneticGenericAlgorithm
{
    public class DNA<T>
    {
        private readonly Random _random;
        private readonly Func<int, float> FitnessFunction;
        private readonly Func<T> GetRandomGene;

        /// <summary>
        /// Initializes a new instance of the <see cref="DNA{T}"/> class.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="size">The size.</param>
        /// <param name="getRandomGene">The get random gene.</param>
        /// <param name="fitnessFunction">The fitness function.</param>
        /// <param name="shouldInitGenes">if set to <c>true</c> [should initialize genes].</param>
        public DNA(Random random, int size, Func<T> getRandomGene,
            Func<int, float> fitnessFunction, bool shouldInitGenes = true)
        {
            Genes = new T[size];
            _random = random;
            GetRandomGene = getRandomGene;
            FitnessFunction = fitnessFunction;
            Fitness = 0f;
            if (shouldInitGenes)
            {
                for (int i = 0; i < Genes.Length; i++)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }

        /// <summary>
        /// The fitness of this DNA
        /// </summary>
        /// <value>
        /// The fitness.
        /// </value>
        public float Fitness { get; private set; }

        /// <summary>
        /// the genes of this DNA.
        /// </summary>
        /// <value>
        /// The genes.
        /// </value>
        public T[] Genes { get; private set; }

        /// <summary>
        /// Calculates the fitness.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public float CalcFitness(int index)
        {
            Fitness = FitnessFunction(index);
            return Fitness;
        }

        /// <summary>
        /// Crossovers the specified partner.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <returns></returns>
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

        #region "a wish and a way"

        /*
            for (int i = 0; i < Genes.Length; i++)
            {
                if (_random.NextDouble() < _mutationRate)
                {
                    Genes[i] = validChars[_random.Next(validChars.Length)];
                }
            }
        */

        #endregion "a wish and a way"

        /// <summary>
        /// Mutates to the specified mutation rate.
        /// </summary>
        /// <param name="mutationRate">The mutation rate.</param>
        public void Mutate(float mutationRate)
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