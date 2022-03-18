using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizProject.Databases;
using System.Collections.Generic;

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