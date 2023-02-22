using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLabs
{
    internal class Lab3
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle();
            try
            {
                vehicle.IncreaseSpeed(101);
            }
            catch(SpeedMoreThanMaximumSpeedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class Vehicle
    {
        public int currentSpeed { get; set; }
        public int maximumSpeed { get; set; } = 100;
        public Vehicle()
        {
            currentSpeed = 0;
        }
        public void IncreaseSpeed(int speed)
        {
            if (currentSpeed + speed > maximumSpeed)
                throw new SpeedMoreThanMaximumSpeedException("Speed more than maximum speed");
            currentSpeed += speed;
        }
    }
    class SpeedMoreThanMaximumSpeedException : ApplicationException
    {
        public Exception innerException;
        public string ErrorMessage { get; private set; }
        public SpeedMoreThanMaximumSpeedException(string msg):base(msg) { }
    }
}
