using System;
using System.Web.Helpers;
using System.Web.Http;
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

        public JsonResult GetAnswers(int clientId)
        {
            dynamic result;
            try
            {
                result = scoreService.GetClientAnswers(clientId);
            }

            catch (ScoringSystemException e)
            {
                result = e.Message;
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
