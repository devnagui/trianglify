using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrianglifyWeb.Exceptions;


namespace TrianglifyWeb.Model
{
    [Serializable()]
    public class TriangleVO
    {
        [JsonIgnore]
        private Triangle triangle;
        [JsonIgnore]
        private InvalidTriangleException exception;
        [JsonIgnore]
        public Triangle Triangle{
            get { return triangle; }
            set {triangle = value;}
         }
        [JsonIgnore]
        public InvalidTriangleException Exception
        {
            get { return exception; }
            set { exception = value; }
        }

        public List<Double> Sides
        {
            get { return triangle!=null? triangle.Sides:null; }
            
        }

        public String TriangleType
        {
            get { return triangle != null ? Enum.GetName(typeof(TriangleType), triangle.TriangleType):null; }
        }


        public String Error
        {
            get { return exception!=null? exception.Message:""; }
        }

    }
}