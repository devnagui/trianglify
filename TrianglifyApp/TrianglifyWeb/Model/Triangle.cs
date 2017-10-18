using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrianglifyWeb.Model
{


    public class Triangle : Polygon
    {
        public const int MaxSides = 3;

        private TriangleType triangleType;
        
        public TriangleType TriangleType
        {
            get { return triangleType; }
            set { triangleType = value; } 
        }

        public Triangle(Double a, Double b, Double c) : base (MaxSides)
        {
            Sides.Insert(0, a);
            Sides.Insert(1, b);
            Sides.Insert(2, c);

        }
    }

    public enum TriangleType
    {
        NOT_VALID = -1,
        EQUILATERAL = 3,
        ISOSCELES = 2,
        SCALENE = 0
    }
}
