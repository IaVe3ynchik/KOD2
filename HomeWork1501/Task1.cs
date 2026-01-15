using System;
namespace HomeWork1501
{
    class Task1
    {
        public static void NotMain(){
            object[] objects = new string[10];
            objects[0] = "Hello";
            objects[1] = 42; // Возникает ошибка, так как в массив строк присваеваем число
            Console.WriteLine(objects[1]);
        }

    }
}