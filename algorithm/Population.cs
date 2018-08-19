//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace algorithm
//{
//    public class Population
//    {
//        public readonly int LengthOfString;
//        public readonly int Size;
//        public List<Entity> Entities { get; set; }

//        public Population(IEnumerable<Entity> entities, int size, int lengthOfString)
//        {
//            Entities = entities as List<Entity>;
//            Size = size;
//            LengthOfString = lengthOfString;
//        }

//        /// <summary>
//        /// Genrates a random population.
//        /// </summary>
//        private void RandPopGen()
//        {
//            for (int i = 0; i < Size; i++)
//            {
//                Random random = new Random();
//                StringBuilder builder = new StringBuilder();
//                for (int j = 0; j < LengthOfString; j++)
//                {
//                    builder.Append((char)random.Next(32, 128));
//                }
//                Entities[i] = new Entity(builder.ToString());
//            }
//        }

//        /// <summary>
//        /// Calculates the fitness.
//        /// </summary>
//        public void CalcFitness()
//        {
//        }

//        public List<Entity> GetNextGen()
//        {
//            Entities.Sort();
//            var child = Entities[0].Crossover(Entities[1]);
//        }

//    }
//}