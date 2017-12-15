using Microsoft.AspNetCore.Mvc;
using DiffPlex.DiffBuilder;
//using System.IO;

namespace WebDiffer.Controllers
{
    public class DiffController : Controller
    {
        private readonly ISideBySideDiffBuilder diffBuilder;

        public DiffController(ISideBySideDiffBuilder bidiffBuilder)
        {
            diffBuilder = bidiffBuilder;
        }


        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Diff(string oldText, string newText)
        {
            var model = diffBuilder.BuildDiffModel(oldText ?? string.Empty, newText ?? string.Empty);

            return View(model);
        }

        public IActionResult DiffFiles(string oldText, string newText)
        {

            if (System.IO.File.Exists(oldText) && System.IO.File.Exists(oldText))
            {
                var model = diffBuilder.BuildDiffModel(System.IO.File.ReadAllText(oldText) ?? string.Empty, System.IO.File.ReadAllText(newText) ?? string.Empty);

                return View(model);
            }
            else
            {
                var model = diffBuilder.BuildDiffModel(oldText ?? string.Empty, newText ?? string.Empty);

                return View(model);
            }
        }

        public IActionResult Files(string oldText, string newText)
        {

            return View();
        }

    }
}
