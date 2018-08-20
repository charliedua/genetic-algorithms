using System;
using System.Collections.Generic;
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
        private const int POPULATION_SIZE = 500;

        /// <summary>
        /// The target phrase
        /// </summary>
        private const string TARGET_PHRASE = "Though the English Wikipedia reached three million articles in August 2009 the growth of the edition in terms of the numbers of articles and of contributors appears to have peaked around early 2007 Around 1800 articles were added daily to the encyclopedia in 2006 by 2013 that average was roughly 800 A team at the Palo Alto Research Center attributed this slowing of growth ";

        //private const string TARGET_PHRASE = "Charlie Dua";

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
            var validChars = new List<char>();
            for (int i = 32; i < 123; i++)
            {
                validChars.Add((char)i);
            }
            return validChars.ToArray();
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
            }
            score = score / TARGET_PHRASE.Length;
            score = (float)(Math.Pow(2, score) - 1) / (2 - 1);
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
            Console.Clear();
            Console.WriteLine("Finished!");
            Console.WriteLine("Genration: {0}", ga.GenCount);
            //foreach (var item in ga.Population)
            //{
            Console.WriteLine("Data   : {0}", string.Concat(ga.newPopulation[0].Genes));
            Console.WriteLine("target : {0}", TARGET_PHRASE);
            Console.WriteLine("Fitness: {0}%", string.Concat(ga.newPopulation[0].Fitness * 100));
            Console.ReadLine();
        }

        /// <summary>
        /// Setups the algorithm.
        /// </summary>
        private static void Setup()
        {
            Console.WriteLine("Please Be patient it is working");
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
            // Console.Write('.');
            //{
            Console.Clear();
            Console.WriteLine("Genration: {0}", ga.GenCount);
            Console.WriteLine("Data   : {0}", string.Concat(ga.newPopulation[0].Genes));
            Console.WriteLine("target : {0}", TARGET_PHRASE);
            Console.WriteLine("Fitness: {0}%", string.Concat(ga.newPopulation[0].Fitness * 100));
            if (string.Concat(ga.Population[0].Genes) == TARGET_PHRASE)
            {
                return false;
            }
            return true;
        }
    }
}