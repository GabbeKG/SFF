using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF_Api_App.DB;
using SFF_Api_App.Models;
using System.Xml.Linq;

namespace SFF_Api_App.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly SFF_DbContext _context;
        public LabelController(SFF_DbContext context, int id)
        {
            _context = context;

            new XDeclaration("1.0", null, null);
            XElement query =
                new XElement("EtikettData",
                from i in context.Rented
                where i.Id == id

                select new XElement("EtikettData",
                new XAttribute("FilmNamn", i.movie.Title),
                new XAttribute("Ort", i.studio.Ort),
                new XAttribute("Datum", DateTime.Now)));
            Console.WriteLine(query.ToString());
        }
    }
}