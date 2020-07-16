using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Zadatak_1.Models
{
    class App
    {
        #region Functions

        public void Start()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            List<Car> cars = GetnerateCars();
            WriteInfoAboutCars(cars);
            if (cars.Count == 1)
            {
                Console.WriteLine("{0} Drive Over Bridge Direction: {1}", cars[0].Name, cars[0].Direction);
            }
            else
            {
                DriveCarsOverBridge(cars);
            }
            s.Stop();
            Console.WriteLine("Application runs for: {0} ms", s.ElapsedMilliseconds);
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
            for (int i = 0; i < cars.Count;)
            {
                if(i == 0)
                {
                    int differentDirectionCar = CheckSymbolsForFirst(cars[i], cars);
                    WriteInfoAboutDirections(i, differentDirectionCar, cars);
                    Console.WriteLine("{0} Waits because direction is {1}", cars[differentDirectionCar].Name , cars[differentDirectionCar].Direction);
                    Thread.Sleep(500);
                    i = differentDirectionCar;
                }
                else
                {
                    int differentDirectionCar = CheckSymbols(cars[i], cars, i);
                    if(differentDirectionCar == 0)
                    {
                        WriteLastDirections(i, cars);
                        break;
                    }
                    else
                    {
                        WriteInfoAboutDirections(i, differentDirectionCar, cars);
                        Console.WriteLine("{0} Waits because direction is {1}", cars[differentDirectionCar].Name, cars[differentDirectionCar].Direction);
                        Thread.Sleep(500);
                        i = differentDirectionCar;
                    }
                }
            }
        }

        private int CheckSymbolsForFirst(Car car, List<Car> cars)
        {
            int diffrenrentDirection = 0;
            for (int i = 0; i < cars.Count; i++)
            {
                if(cars[i].Direction != car.Direction)
                {
                    diffrenrentDirection = i;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return diffrenrentDirection;
        }

        private int CheckSymbols(Car car, List<Car> cars, int indexNumber)
        {
            int diffrenrentDirection = 0;
            for (int i = indexNumber; i < cars.Count; i++)
            {
                if (cars[i].Direction != car.Direction)
                {                    
                    diffrenrentDirection = i;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return diffrenrentDirection;
        }


        private void WriteInfoAboutDirections(int index, int differentDirectionCar, List<Car> cars)
        {
            for (int i = index; i < differentDirectionCar; i++)
            {
                Console.WriteLine("{0} Drive Over Bridge Direction: {1}", cars[i].Name, cars[i].Direction);
            }
        }


        private void WriteLastDirections(int index, List<Car> cars)
        {
            for (int i = index; i < cars.Count; i++)
            {
                Console.WriteLine("{0} Drive Over Bridge Direction: {1}", cars[i].Name, cars[i].Direction);
            }
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
                }
            };
            OnNotification.Invoke();
        }

        #endregion
    }
}
