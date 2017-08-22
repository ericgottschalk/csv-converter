using ENG.CSVToSQL.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENG.CSVToSQL.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(string columns, string table)
        {
            if (!string.IsNullOrWhiteSpace(table))
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        if (extension == ".txt" || extension == ".csv")
                        {
                            var bytes = SQLInsertGenerator.Generate(file.InputStream, columns, table);
                            return File(bytes, "application/sql", $"insert_{DateTime.Now.ToString("yyyyMMddhhmmss")}.sql");
                        }
                    }
                }
            }

            return RedirectToAction("Index", "Error");
        }
    }
}