using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillAssure
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class SkillAssureTrainingModel
    {
        public string ClientName { get; set; }
        public Iteration[] Iterations = new Iteration[3]; 
        public int GetTotalAssessMentsInTheTraining()
        {
            return Iterations.Sum(i => i.Assessments.Count + i.Course.GetCourseAssessments());
        }
        public int GetNumMCQBasedAssessments()
        {
            return Iterations.Sum(i => i.Assessments.Count(a => a.GetAssessmentType()==typeof(MCQQuestion))+i.Course.GetMCQBasedCourseAssessments());
        }
        public int GetHandsOnBasedAssessments()
        {
            return Iterations.Sum(i => i.Assessments.Count(a => a.GetAssessmentType() == typeof(HandsOnQuestion)) + i.Course.GetHandsOnCourseAssessments());
        }
        public int GetTotalScoreOfAllAssessments()
        {
            return Iterations.Sum(i => i.Assessments.Sum(a => a.GetTotalMarks())+i.Course.GetTotalCourseAssessmentMarks());
        }
    }
    class Iteration
    {
        public int IterationNo { get; set; }
        public string Goal { get; set; }
        public Course Course { get; set; }
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
    class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; }= new List<Assessment>();
        public int GetCourseAssessments()
        {
            return Assessments.Count;
        }
        public int GetMCQBasedCourseAssessments()
        {
            return Assessments.Count(a => a.GetAssessmentType()==typeof(MCQQuestion));
        }
        public int GetHandsOnCourseAssessments()
        {
            return Assessments.Count(a => a.GetAssessmentType() == typeof(HandsOnQuestion));
        }
        public int GetTotalCourseAssessmentMarks()
        {
            return Assessments.Sum(a => a.GetTotalMarks());
        }
    }
    class Assessment
    {
        public int AssessmentId { get; set; }
        public string Desc { get; set; }
        public int NoQuestions { get; set; }
        public Calendar DtAssessment { get; set; }
        public List<Question> Questions { get; set; }=new List<Question>();
        public int GetTotalMarks()
        {
            return Questions.Sum(q => q.Marks);
        }
        public Type GetAssessmentType()
        {
            return Questions.ElementAt(0).GetType();
        }
    }
    abstract class Question
    {
        public abstract int Marks { get; set; }
    }
    class MCQQuestion : Question
    {
        public override int Marks { get; set; }
        public string QuestionName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string RightOption { get; set; }
    }
    class HandsOnQuestion : Question
    {
        public override int Marks{get;set;}
        public string QuestionDesc { get; set; }
        public string ReferenceDocument { get; set; }
    }
}
