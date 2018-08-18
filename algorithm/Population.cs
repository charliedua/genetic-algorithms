using System;
using System.Collections;
using System.Collections.Generic;

namespace algorithm
{
    public class Population
    {
        public List<Entity> Entities { get; set; }

        public Population(IEnumerable<Entity> entities)
        {
            Entities = new List<Entity>(entities);
        }
    }
}