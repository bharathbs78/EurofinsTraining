using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Organization organization = new Organization
            {
                Name="Eurofins"
            };
            Trainer trainer = new Trainer();
            trainer.Organization = organization;
            Training training =new Training();
            training.Trainer = trainer;
            Console.WriteLine($"Training Organization Name {training.GetTrainingOrganizationName()}");
            Trainee t1=new Trainee();
            Trainee t2=new Trainee();
            Trainee t3=new Trainee();
            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);
            Console.WriteLine($"Number of Trainees {training.GetNumberOfTrainees()}");

            Unit unit1= new Unit { Duration=120};
            Unit unit2= new Unit { Duration=60};
            Unit unit3= new Unit { Duration=30};
            Unit unit4= new Unit { Duration=120};
            Unit unit5= new Unit { Duration=60};
            Unit unit6= new Unit { Duration=30};
            Module module1 = new Module();
            Module module2 = new Module();
            module1.Units.Add(unit1);
            module1.Units.Add(unit2);
            module1.Units.Add(unit3);
            module2.Units.Add(unit4);
            module2.Units.Add(unit5);
            module2.Units.Add(unit6);
            Course course = new Course();
            course.Modules.Add(module1);
            course.Modules.Add(module2);
            training.Course = course;
            Console.WriteLine("The total duration is "+training.GetTrainingDurationInHours());
        }
    }
    class Organization
    {
        public string Name { get; set; }
    }
    class Trainer
    {
        public Organization Organization { get; set; }
        public List<Trainee> Trainees { get; set; }= new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
    class Trainee
    {
        public Trainer Trainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
    class Training
    {
        public Trainer Trainer { get; set; }    
        public List<Trainee> Trainees { get; set; }=new List<Trainee>();
        public Course Course { get; set; }
        public string GetTrainingOrganizationName()
        {
            return Trainer.Organization.Name;
        }
        public int GetNumberOfTrainees()
        {
            return Trainees.Count;
        }
        public int GetTrainingDurationInHours()
        {
            int totalDuration = 0;
            foreach(var module in Course.Modules)
            {
                foreach(var unit in module.Units)
                    totalDuration += unit.Duration;
            }
            return totalDuration;
        }
        
    }
    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>(); 
    }
    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    class Unit
    {
        public int Duration { get; set; }

        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    class Topic
    {
        public string Name { get; set; }
    }
}
