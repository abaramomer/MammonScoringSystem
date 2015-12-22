using System.Web.Mvc;
using ScoringSystem.Services;

namespace MammonWebApi.Controllers
{
    public class FormController : Controller
    {
        private readonly FormService formService;

        public FormController()
        {
            formService = new FormService();
        }

        public ActionResult Index()
        {
            formService.GetAvailableQuestions();
            return View();
        }
    }
}