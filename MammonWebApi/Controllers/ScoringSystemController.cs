using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using ScoringSystem.Services;

namespace MammonWebApi.Controllers
{
    public class ScoringSystemController : Controller
    {
        private readonly ScoreService scoreService;

        public ScoringSystemController()
        {
            scoreService = new ScoreService();
        }

        public JsonResult GetScores(int clientId)
        {
            return Json(scoreService.GetActualClientScores(clientId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuestions(int clientId)
        {
            return Json(scoreService.GetClientAnswers(clientId), JsonRequestBehavior.AllowGet);
        }
    }
}
