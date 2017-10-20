using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrianglifyWeb.Exceptions;
using TrianglifyWeb.Model;

namespace TrianglifyWeb.BusinessObject


{
    public class TriangleIdenfier : AbstractPolygonIdenficator<Triangle>
    {
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// 
        /// <exception cref="InvalidTriangleException" ></exception>
        public override void Validate(Triangle triangle)
        {
            if (triangle == null)
            {
                throw new InvalidTriangleException("Triangle object is null.");
            }
            if (triangle.Sides == null)
            {
                throw new InvalidTriangleException("One or more of the sides are null.");
            }
            if (triangle.Sides.Contains(0d))
            {
                throw new InvalidTriangleException("One or more of the sides are 0.");
            }

            if (triangle.Sides.Min() < 0)
            {
                throw new InvalidTriangleException("One or more of the sides are less than zero.");
            }

            if (!IsValidByConditionOfInequalityOfSides(triangle))
            {
                throw new InvalidTriangleException("One side must be smaller than the sum of the others and bigger than the difference of the module of the other two.");
            }

        }

        private bool IsValidByConditionOfInequalityOfSides(Triangle triangle)
        {
            Double a = triangle.Sides.ElementAt(0);
            Double b = triangle.Sides.ElementAt(1);
            Double c = triangle.Sides.ElementAt(2);
            return IsSideValid(a, b, c) && IsSideValid(b, a, c) && IsSideValid(c, a, b);
        }

        private bool IsSideValid(Double sideToTest, Double otherSide1, Double otherSide2)
        {
            return (Math.Max(otherSide1, otherSide2) - Math.Min(otherSide1, otherSide2)) < sideToTest
                    && sideToTest < (otherSide1 + otherSide2);
        }

        public override void Classificate(Triangle triangle)
        {
            Double biggerSide = triangle.Sides.Max();
            Double smallestSide = triangle.Sides.Min();
            Dictionary<Double, int> frequenciesOfSides = triangle.Sides.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int biggerSideFrequency=0;
            frequenciesOfSides.TryGetValue(biggerSide, out biggerSideFrequency);

            int smallestSideFrequency = 0;
            frequenciesOfSides.TryGetValue(smallestSide, out smallestSideFrequency);
            //If the sides are equal and the frequency is 1, that means that each side is repeated only 1 time
            if (biggerSideFrequency == smallestSideFrequency && biggerSideFrequency == 1)
            {
                //Scalene
                triangle.TriangleType = TriangleType.SCALENE;
                //We could ask for TriangleType.getType(0) but that would be just redundancy...
            }
            else
            {
                //Isosceles or Equilateral, max of both will decide..
                triangle.TriangleType = (TriangleType)Math.Max(biggerSideFrequency, smallestSideFrequency);
            }

        }
    }
}