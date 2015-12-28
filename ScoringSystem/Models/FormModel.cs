using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScoringSystem.Models
{
    public class FormModel
    {
        public string ClientLink { get; set; }

        public List<FormAnswerModel> Answers { get; set; }  
    }
}