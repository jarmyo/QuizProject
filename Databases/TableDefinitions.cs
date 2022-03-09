﻿using System.ComponentModel.DataAnnotations.Schema;

namespace QuizProject.Databases
{
    /// <summary>
    /// TODO: Create maxleight data anotations
    /// </summary>
    public class Teams
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }
        [Required]
        [StringLength(150)]
        public string SponsorFirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string SpondorLastName { get; set; }
        [Required]
        [StringLength(150)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string State { get; set; }
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
        public string TeamMemberEmails { get; set; }
        public int Score { get; set; }
        /// <summary>
        /// This field joins IdentityContext with this custom table
        /// </summary>
        public string LoginGUID { get; set; }
    }

    public class TeamAnswers
    {
        [Key]
        public string Id { get; set; }
        public string Answer { get; set; }
        public string IdTeam { get; set; }
        public string IdAnswer { get; set; }
    }

    public class Category
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsAviable { get; set; }
        public DateTime AviabilityDate { get; set; }
        [InverseProperty("IdCategoryNavigation")]
        public virtual ICollection<Question> Questions { get; set; }
    }
    public class Question
    {
        public Question()
        {
           
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// This going to be render in plain HTML
        /// </summary>
        public string HtmlBody { get; set; }        
        /// <summary>
        /// How many points earn if win this answer
        /// </summary>
        public int Points { get; set; }
        public string IdCategory { get; set; }
        [ForeignKey(nameof(IdCategory))]
        [InverseProperty(nameof(Category.Questions))]
        public virtual Category IdCategoryNavigation { get; set; }

        [InverseProperty("IdQuestionNavigation")]
        public virtual ICollection<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public Answer()
        {
        }
        [Key]
        public string Id { get; set; }
        public string Text { get; set; }
        public string IdQuestion { get; set; }

        [ForeignKey(nameof(IdQuestion))]
        [InverseProperty(nameof(Question.Answers))]
        public virtual Question IdQuestionNavigation { get; set; }
    }
}