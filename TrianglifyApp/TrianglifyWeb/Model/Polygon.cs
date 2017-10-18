using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TrianglifyWeb.Model
{
    [Serializable()]
    public abstract class Polygon
    {
        private List<Double> sides;

        public List<Double> Sides
        {
            get { return sides; }
            set { sides = value; }

        }

        public Polygon(int NumberOfSides)
        {
            sides = new List<Double>(NumberOfSides);

        }
        public Polygon()
        {
            sides = new List<Double>();
        }

        public override bool Equals(object obj)
        {
            var polygon = obj as Polygon;
            return polygon != null &&
                   EqualityComparer<List<double>>.Default.Equals(Sides, polygon.Sides);
        }

        public override int GetHashCode()
        {
            return 1814305551 + EqualityComparer<List<double>>.Default.GetHashCode(Sides);
        }
    }
}
