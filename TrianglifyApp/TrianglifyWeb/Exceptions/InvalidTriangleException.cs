using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrianglifyWeb.Exceptions
{
    
    public class InvalidTriangleException : InvalidPolygonException
    {
        public InvalidTriangleException(string message) : base(message)
        {
        }
    }
}
