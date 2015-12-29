using System.Web.Mvc;
using ScoringSystem;
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
            string result;
            try
            {
                result = scoreService.GetActualClientScores(clientId).ToString();
            }

            catch(ScoringSystemException e)
            {
                result = e.Message;
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Answers(int clientId)
        {
            try
            {
                var result = scoreService.GetClientAnswers(clientId);

                return View(result);
            }

            catch (ScoringSystemException e)
            {
                return RedirectToAction("Info", "ScoringSystem");
            }
        }

        public ActionResult Info()
        {
            ViewData["Message"] = "Клиент еще не проходил анкетирование либо его не существует";
            return View();
        }
    }
}
