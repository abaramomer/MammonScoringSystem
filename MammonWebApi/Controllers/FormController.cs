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

        public ActionResult Index(string clientLink)
        {
            ViewData["ClientLink"] = clientLink;
            if (!string.IsNullOrEmpty(clientLink) && formService.IsLinkCorrect(clientLink))
            {
                var questions = formService.GetFormQuestions();
                return View(questions);
            }

            return RedirectToAction("IncorrectLink",  "Form");
        }

        public ActionResult IncorrectLink()
        {
            return View();
        }

        public ActionResult CalibrateCoefficients()
        {
            var questions = formService.GetFormQuestions();
            return View(questions);
        }

        public JsonResult SaveForm(string clientLink, string answers)
        {
            List<FormAnswerModel> userAnswers = (List<FormAnswerModel>)JsonConvert
                .DeserializeObject(answers, typeof (List<FormAnswerModel>));

            formService.SaveForm(int.Parse(clientLink), userAnswers);

            return Json("/Form/Info", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Info()
        {
            ViewData["Message"] = "Ваши ответы учтены. Спасибо за прохождение анкеты";

            return View();
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