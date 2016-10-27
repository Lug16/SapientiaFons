using SapientiaFons.Models;
using System.Linq;
using System.Web.Http;

namespace SapientiaFons.Controllers.Api
{
    public class ContentController : ApiController
    {
        private static readonly ApplicationDbContext db = new ApplicationDbContext();

        public ContentModel Get(string shortUrl)
        {
            var subject = db.Subjects.Single(r => r.ShortUrl == shortUrl);
            var materials = db.Materials.Where(r => r.SubjectId == subject.Id).ToArray();

            var body = new ContentBody
            {
                Materials = materials
            };

            var result = new ContentModel()
            {
                Name = subject.Title,
                Description = subject.Description,
                Body = body
            };

            return result;
        }
    }
}
