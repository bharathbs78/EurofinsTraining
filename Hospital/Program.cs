using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string title { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string residentialAddress { get; set; }
        public string phone { get; set; }
        public Gender gender { get; set; }
    }
public enum Gender
    {
        Male,
        Female
    }
    class Patient : Person
    {
        public DateTime AdmittedDate { get; set; }
        public List<string> Allergies { get; set; } = new List<string>();
        public string PatientName { get; set; }
        public int Age { get; set; }
    }
    class Employee : Person
    {
        public DateTime DateOfJoin { get; set; }
        public string Education { get; set; }
        public string GetDoctorSpecialization()
        {
            return (this as Doctor).speciality;
        }
        public bool isEmployeeAConsultantDoctor()
        {
            return (this as Doctor).isConsultantDoctor();
        }
    }
    class Doctor : Employee
    {
        public string speciality { get; set; }
        public bool isConsultantDoctor()
        {
            return this is ConsultantDoctor;
        }

    }
    class Receptionist : Employee
    {

    }
    class Nurse : Employee
    {

    }
    class ConsultantDoctor : Doctor
    {

    }
    class InternalDoctor : Doctor
    {

    }
    class Ward
    {
        public List<Patient> Patients { get; set; }= new List<Patient>();
        public WardType WardType { get; set; }
        public string WardName { get; set; }
        public double basicCost { get; set; }
        public double GetWardCost()
        {
            return WardCostCalculator.findWardCost(basicCost, WardType);
        }
        public int GetWardCount() { return Patients.Count; }
    }
    class Hospital
    {
        public string Name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public List<Ward> Wards { get; set; }=new List<Ward>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public int GetTotalPatients()
        {
            int total = 0;
            foreach(var ward in Wards)
            {
                total += ward.GetWardCount();
            }
            return total;
        }
        public int GetTotalPatientsByWard(Ward ward)
        {
            return ward.GetWardCount();
        }
        public int GetTotalDoctors()
        {
            return Employees.Count(emp => emp is Doctor);
        }
        public Employee[] getDoctorsBySpecialization(string specialization)
        {
            return Employees.FindAll(doc => doc is Doctor && doc.GetDoctorSpecialization().Equals(specialization)).ToArray();
        }
        public int TotalConsultants()
        {
            return Employees.Count(emp => emp is Doctor && emp.isEmployeeAConsultantDoctor());
        }
        public double GetWardCostByType(WardType wardType)
        {
            return Wards.FindAll(ward => ward.WardType == wardType).Sum(ward => ward.GetWardCost());
        }
    }
    enum WardType
    {
        IntensiveCareUnit,
        GeneralUnit,
        PediatricUnit,
        SurgicalUnit
    }
    class WardCostCalculator
    {
        public static double findWardCost(double basic,WardType type)
        {
            switch (type)
            {
                case WardType.IntensiveCareUnit:
                    return basic * 0.1;
                case WardType.GeneralUnit:
                    return basic * 0.2;
                case WardType.PediatricUnit:
                    return basic * 0.25;
                case WardType.SurgicalUnit:
                    return basic * 0.4;
                default:
                    return 0;
            }
        }
    }
}

