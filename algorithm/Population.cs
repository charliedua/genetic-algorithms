using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace algorithm
{
    public class Population
    {
        public List<Entity> Entities { get; set; }

        public Population(IEnumerable<Entity> entities)
        {
            Entities = new List<Entity>(entities);
        }

        public List<Entity> GetNextGen()
        {
            Entities.Sort();
            var child = Entities[0].Crossover(Entities[1]);
        }

        public void Mutate()
        {
            throw new NotImplementedException();
        }
    }
}