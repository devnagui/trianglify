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

        private Double sideA;
        private Double sideB;
        private Double sideC;
        private String triangleType;
        private String error;

        public double SideA { get => sideA; set => sideA = value; }
        public double SideB { get => sideB; set => sideB = value; }
        public double SideC { get => sideC; set => sideC = value; }
        public string TriangleType { get => triangleType; set => triangleType = value; }
        public string Error { get => error; set => error = value; }
    }
}