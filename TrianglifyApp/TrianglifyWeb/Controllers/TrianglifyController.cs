using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TrianglifyWeb.BusinessObject;
using TrianglifyWeb.Exceptions;
using TrianglifyWeb.Model;

namespace TrianglifyWeb.Controllers
{
   [RoutePrefix("trianglify")]
    public class TrianglifyController : ApiController
    {

        IPolygonIdentificator<Model.Triangle> triangleIdentificator = new TriangleIdenfier();
       
        // GET: api/Trianglify/5
        //public string Get(int id)
        //{
        //    return "value";
       // }


        [Route("identify")]
        [HttpGet()]
        [AcceptVerbs("GET")]
        public JsonResult<TriangleVO> IdentifyURI([FromUri]Double sideA, [FromUri]Double sideB, [FromUri]Double sideC)
        {
            TriangleVO tvo = new TriangleVO();
            try
            {
                tvo.Triangle = triangleIdentificator.Identify(new Model.Triangle(sideA, sideB, sideC)); ;
            }
            catch (InvalidTriangleException e)
            {
                tvo.Exception = e;
            }
            return Json(tvo);

        }

        // POST: api/Trianglify
        // public void Post([FromBody]string value)
        //   {
        //  }

        // PUT: api/Trianglify/5
        //   public void Put(int id, [FromBody]string value)
        //{
        //  }

        // DELETE: api/Trianglify/5
        //  public void Delete(int id)
        //{
        //  }
    }
}
