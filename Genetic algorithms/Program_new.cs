using System;
using System.Threading;

namespace GeneticGenericAlgorithm
{
    public class Program
    {
        /// <summary>
        /// The mutation rate
        /// </summary>
        private const float MUTATION_RATE = 0.01f;

        /// <summary>
        /// The population size
        /// </summary>
        private const int POPULATION_SIZE = 5;

        /// <summary>
        /// The target phrase
        /// </summary>
        private const string TARGET_PHRASE = "winters are cold in australia";

        /// <summary>
        /// The Genetic Algoritm
        /// </summary>
        private static GeneticAlgoritm<char> ga;

        /// <summary>
        /// The random object for everything
        /// </summary>
        private static Random random;

        /// <summary>
        /// Creates the valid chars.
        /// </summary>
        /// <returns></returns>
        public static char[] CreateValidChars()
        {
            var validChars = new char[27];
            var j = 0;
            for (int i = 97; i < 123; i++)
            {
                validChars[j] = (char)i;
                j++;
            }
            validChars[j] = ' ';
            return validChars;
        }

        /// <summary>
        /// the Fitness function.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <returns></returns>
        public static float FitnessFunction(int arg)
        {
            float score = 0f;
            DNA<char> dna = ga.Population[arg];
            for (int i = 0; i < dna.Genes.Length; i++)
            {
                if (dna.Genes[i] == TARGET_PHRASE[i])
                {
                    score++;
                }
                score = score / TARGET_PHRASE.Length;
                //score = (int)Math.Pow(2, score);
            }
            return score;
        }

        /// <summary>
        /// Gets the random gene.
        /// </summary>
        /// <returns></returns>
        public static char GetRandomGene()
        {
            var validChars = CreateValidChars();
            return validChars[random.Next(validChars.Length)];
        }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Setup();
            while (true)
            {
                if (!Update())
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Setups the algorithm.
        /// </summary>
        private static void Setup()
        {
            random = new Random();
            ga = new GeneticAlgoritm<char>(POPULATION_SIZE, MUTATION_RATE,
                new Random(), TARGET_PHRASE, GetRandomGene, FitnessFunction);
        }

        /// <summary>
        /// Updates everytime.
        /// </summary>
        /// <returns></returns>
        private static bool Update()
        {
            ga.CreateNewGenration();
            Console.WriteLine("Genration: {0}", ga.GenCount);
            foreach (var item in ga.Population)
            {
                Console.WriteLine(string.Concat(item.Genes));
            }
            Thread.Sleep(100);
            Console.Clear();
            return true;
        }
    }
}