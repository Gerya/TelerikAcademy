using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeJewels.Data;
using CodeJewels.Models;

namespace CodeJewels.Service.Controllers
{
    [RoutePrefix("api")]
    public class CodeJewelsController : ApiController
    {
        private readonly CodeJewelsContext db = new CodeJewelsContext();

        [HttpGet("codejewels")]
        public IEnumerable<CodeJewel> GetCodeJewels()
        {
            return db.CodeJewels.AsEnumerable();
        }

        [HttpGet("codejewels")]
        public HttpResponseMessage GetCodeJewels(string sourceCode, string category = null)
        {
            sourceCode = string.Format("%{0}%", sourceCode);

            var query = db.CodeJewels.Where(cj =>
                    //&& cj.SourceCode.Contains(sourceCode))
                    SqlFunctions.PatIndex(sourceCode, cj.SourceCode) != 0);

            if (category != null)
            {
                query = query.Where(cj => cj.Category.ToLower() == category.ToLower());
            }

            var codejewelCollection = query.AsEnumerable();

            if (codejewelCollection.Count() == 0)
            {
                return Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    "No Code Jewels were found. Try to refine your search query.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, codejewelCollection);
        }

        [HttpGet("codejewels/upvote/{codeJewelId:int:min(1)}")]
        public HttpResponseMessage UpFoteCodeJewel(int codeJewelId)
        {            
            var codejewel = db.CodeJewels.FirstOrDefault(cj => cj.Id == codeJewelId);         

            if (codejewel != null)
            {
                codejewel.Rating += 1;               
                db.SaveChanges();                
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet("codejewels/downvote/{codeJewelId:int:min(1)}")]
        public HttpResponseMessage DownVoteCodeJewel(int codeJewelId)
        {
            var codejewel = db.CodeJewels.FirstOrDefault(cj => cj.Id == codeJewelId);

            if (codejewel != null)
            {
                codejewel.Rating -= 1;

                if (codejewel.Rating < 0)
                {
                    db.CodeJewels.Remove(codejewel);
                }

                db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost("codejewels/create")]
        public HttpResponseMessage CreateCodeJewel(CodeJewel codejewel)
        {
            if (ModelState.IsValid)
            {
                db.CodeJewels.Add(codejewel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, codejewel);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = codejewel.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}