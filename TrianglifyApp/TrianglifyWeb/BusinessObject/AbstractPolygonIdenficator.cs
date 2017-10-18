
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrianglifyWeb.Model;

namespace TrianglifyWeb.BusinessObject
{
    public abstract class AbstractPolygonIdenficator<Polygon> : IPolygonIdentificator<Polygon>
    {
        public abstract void Validate(Polygon polygon) ;
        public abstract void Classificate(Polygon polygon);
        public Polygon Identify(Polygon polygon)
        {
                Validate(polygon);
                Classificate(polygon);
		        return polygon;
	    }

        
    }
}
