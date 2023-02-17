using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Student("bha",89),
                new Student("sha",84),
                new Student("abc",85),
                new Professor("xyz",5),
                new Professor("lmn",4)
            };
            foreach(Person person in people)
            {
                if (person.isOutstanding())
                {
                    if (person is Student student)
                        student.Display();
                    else if(person is Professor professor)
                    {
                        professor.Print();
                    }
                }
            }
        }
    }
    abstract class Person
    {
        public string Name { get; set; }
        public Person()
        {

        }
        public Person(string name)
        {
            Name = name;
        }
        public abstract bool isOutstanding();
    }
    class Professor:Person
    {
        public int BooksPublished { get; set; }
        public Professor():base()
        {

        }
        public Professor(string name,int booksPublished):base(name)
        {
            this.BooksPublished = booksPublished;
        }
        public void Print()
        {
            Console.WriteLine($"Name: {this.Name} Books Published : {BooksPublished}");
        }
        public override bool isOutstanding()
        {
            return BooksPublished > 4;
        }
    }
    class Student:Person
    {
        public double Percentage { get; set; }  
        public Student() : base()
        {

        }
        public Student(string name,double Percentage) : base(name)
        {
            this.Percentage = Percentage;
        }
        public void Display()
        {
            Console.WriteLine($"Name : {Name} Percentage: {Percentage}");
        }
        public override bool isOutstanding()
        {
            return Percentage > 85;
        }
    }
}
