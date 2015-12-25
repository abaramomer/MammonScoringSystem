using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using ScoringSystem.Models;
using ScoringSystem.Services;

namespace MammonWebApi.Controllers
{
    public class FormController : Controller
    {
        private readonly FormService formService;
        private readonly ScoreService scoreService;

        public FormController()
        {
            scoreService = new ScoreService();
            formService = new FormService();
        }

        public ActionResult Index()
        {
            var questions = formService.GetFormQuestions();
            return View(questions);
        }

        public JsonResult GetScores(string answers)
        {
            List<UserAnswer> userAnswers = (List<UserAnswer>)JsonConvert.DeserializeObject(answers, typeof (List<UserAnswer>));
            scoreService.CalculateScores(userAnswers);
            return Json(new Random().Next(400), JsonRequestBehavior.AllowGet);
        }
    }
}