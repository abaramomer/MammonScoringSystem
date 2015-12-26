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

        public FormController()
        {
            formService = new FormService();
        }

        public ActionResult Index()
        {
            var questions = formService.GetFormQuestions();
            return View(questions);
        }

        public ActionResult CalibrateCoefficients()
        {
            var questions = formService.GetFormQuestions();
            return View(questions);
        }

        public JsonResult SaveForm(string answers)
        {
            List<FormAnswerModel> userAnswers = (List<FormAnswerModel>)JsonConvert
                .DeserializeObject(answers, typeof (List<FormAnswerModel>));

            var scores = formService.SaveForm(1, userAnswers);

            return Json(scores, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveCoefficients(string coefficients)
        {
            var newCoefficients = (List<AnswerCoefficientModel>)JsonConvert
                .DeserializeObject(coefficients, typeof(List<AnswerCoefficientModel>));

            formService.SaveCoefficients(newCoefficients);
            
            return Json(new JsonResult(), JsonRequestBehavior.AllowGet);
        }
    }
}