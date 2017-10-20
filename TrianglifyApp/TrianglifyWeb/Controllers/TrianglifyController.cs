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
    [RoutePrefix("api/trianglify")]
    public class TrianglifyController : ApiController
    {

        IPolygonIdentificator<Model.Triangle> triangleIdentificator = new TriangleIdenfier();

        [Route("identifyGet")]
        [HttpGet()]
        [AcceptVerbs("GET")]
        public JsonResult<TriangleVO> IdentifyGet([FromUri]Double sideA, [FromUri]Double sideB, [FromUri]Double sideC)
        {
            TriangleVO tvo = new TriangleVO();
             
            try
            {
                tvo.TriangleType = Enum.GetName(typeof(TriangleType), triangleIdentificator.Identify(new Triangle(tvo.SideA, tvo.SideB, tvo.SideC)).TriangleType);
            }
            catch (InvalidTriangleException e)
            {
                tvo.Error = (e.Message.ToString());
                StatusCode(HttpStatusCode.InternalServerError);
            }
            return Json(tvo);

        }

        [Route("identifyPost")]
        [HttpPost()]
        [AcceptVerbs("POST")]
        public JsonResult<TriangleVO> IdentifyPost([FromBody]TriangleVO tvo)
        {

            try
            {
                tvo.TriangleType=Enum.GetName(typeof(TriangleType), triangleIdentificator.Identify(new Triangle(tvo.SideA, tvo.SideB, tvo.SideC)).TriangleType);
            }
            catch (InvalidTriangleException e)
            {
                tvo.Error = (e.Message.ToString());
                StatusCode(HttpStatusCode.InternalServerError);

            }
            
            return Json(tvo);

        }
    }
}
