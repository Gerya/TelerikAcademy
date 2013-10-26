using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicStore.Model;

namespace MusicStoreWebApplication.Controllers
{
    public class ArtistsController : ApiController
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public ArtistsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Artists
        public IEnumerable<Artist> GetArtists()
        {
            return db.Artists.Include("Songs").Include("Albums").AsEnumerable();
        }

        // GET api/Artists/5
        public Artist GetArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var artistToUpdate = db.Artists.FirstOrDefault(a => a.ArtistId == id);

            if (artistToUpdate != null && artist != null)
            {
                artistToUpdate.ArtistName = artist.ArtistName ?? artistToUpdate.ArtistName;
                artistToUpdate.Country = artist.Country ?? artistToUpdate.Country;
                artistToUpdate.DateOfBirth = artist.DateOfBirth ?? artistToUpdate.DateOfBirth;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(artistToUpdate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Artists
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}