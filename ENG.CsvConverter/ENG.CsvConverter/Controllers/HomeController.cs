using ENG.CsvConverter.Application;
using ENG.CsvConverter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENG.CsvConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly CsvConverterApplication application;

        public HomeController()
        {
            application = new CsvConverterApplication();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(ConvertRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var extension = Path.GetExtension(model.File.FileName);
            if (extension == ".txt" || extension == ".csv")
            {
                var bytes = application.Generate(model.File.InputStream, model.Props, model.ObjectName, model.Separator, model.Type);
                return File(bytes, GetContentType(model.Type), $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.{GetExtension(model.Type)}");
            }

            return RedirectToAction("Index", "Error");
        }

        private object GetExtension(enumConvertType type)
        {
            switch (type)
            {
                case enumConvertType.SQL:
                    return "sql";

                case enumConvertType.JSON:
                    return "json";

                default:
                    return string.Empty;
            }
        }

        private string GetContentType(enumConvertType type)
        {
            switch (type)
            {
                case enumConvertType.SQL:
                    return "application/sql";

                case enumConvertType.JSON:
                    return "application/json";

                default:
                    return string.Empty;
            }
        }
    }
}