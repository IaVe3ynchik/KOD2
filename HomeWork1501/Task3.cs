using System;
namespace HomeWork1501
{
    class Vehicle { }
    class Car : Vehicle { }
    class Task3
    {
        public static void NotMain(){
            Action<Vehicle> repairVehicle = v => Console.WriteLine($"Repairing {v.GetType().Name}");
            Action<Car> repairCar = repairVehicle;
            repairCar(new Car());
        }

    }
}
// Код работает, потому что делегат Action поддерживает контрвариантность, а также класс Car наследуется от класса Vehicle 