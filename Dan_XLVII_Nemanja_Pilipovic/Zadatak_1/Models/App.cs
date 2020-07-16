using System;
using System.Collections.Generic;
using System.Threading;

namespace Zadatak_1.Models
{
    class App
    {
        #region Functions

        public void Start()
        {
            List<Car> cars = GetnerateCars();
            WriteInfoAboutCars(cars);
            DriveCarsOverBridge(cars);
        }

        private List<Car> GetnerateCars()
        {
            List<Car> cars = new List<Car>();
            Random r = new Random();
            int numberOfCars = r.Next(1, 16);
            for (int i = 1; i <= numberOfCars; i++)
            {
                int randomDirection = r.Next(0, 2);
                if(randomDirection == 0)
                {
                    Car car = new Car($"Car: {i}", "North");
                    cars.Add(car);
                }
                else
                {
                    Car car = new Car($"Car: {i}", "South");
                    cars.Add(car);
                }
            }
            return cars;
        }

        private void DriveCarsOverBridge(List<Car> cars)
        {
          
        }

        #endregion

        #region Events and Delegates

        public delegate void Notification();

        public event Notification OnNotification;

        public void WriteInfoAboutCars(List<Car> cars)
        {
            OnNotification += () =>
            {
                Console.WriteLine("Number of Cars: {0}", cars.Count);
                foreach (Car car in cars)
                {
                    Console.WriteLine("{0} Direction: {1}",car.Name, car.Direction);
                    //TODO ovde treba ispasati i redosled vozila
                }
            };
            OnNotification.Invoke();
        }

        #endregion
    }
}
