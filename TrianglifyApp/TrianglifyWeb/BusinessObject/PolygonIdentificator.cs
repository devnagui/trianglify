using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrianglifyWeb.Model;

namespace TrianglifyWeb.BusinessObject
{
    interface IPolygonIdentificator<Polygon>
    {
         void Validate(Polygon polygon);
         void Classificate(Polygon polygon);
        Polygon Identify(Polygon polygon);
    }
}
