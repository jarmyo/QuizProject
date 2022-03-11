using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizProject;
using QuizProject.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProject.Pages.ResulterModel.Tests
{
    [TestClass()]
    public class VerificatorTests
    {
        //TODO: Create more test cases
        public static List<Answer> CorrectAnswers { get; set; } = new List<Answer>()
        {
            new Answer() { Id="x", IdQuestion="y", Text="Marathon" }
        };

        [TestMethod()]
        public void CheckTest()
        {
            var data = Verificator.Check(CorrectAnswers, "MARATHON");
            Assert.IsTrue(data.IsCorrect);            
        }
    }
}