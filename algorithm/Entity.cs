using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    public class Entity
    {
        public List<string> _data;

        public Entity(ICollection<string> data)
        {
            _data = new List<string>(data);
            Fitness = 0f;
        }

        public DNA DNA;

        public float Fitness { get; set; }

        public Entity Crossover(Entity entity)
        {
            List<string> data = new List<string>(_data);
            Random random = new Random();
            int midpoint = random.Next(0, _data.Count);
            List<string> endingArr = _data.GetRange(midpoint, _data.Count);
            List<string> startArr = entity._data.GetRange(0, midpoint);
            startArr.AddRange(endingArr);
            return new Entity(startArr);
        }
    }
}