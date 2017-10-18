using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrianglifyWeb.Exceptions
{
    [Serializable()]
    public class InvalidPolygonException : Exception
    {
        public InvalidPolygonException(string message) : base(message)
        {
        }
    }
}