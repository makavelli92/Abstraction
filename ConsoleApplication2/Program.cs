using System;

// Абстрактный класс может быть унаследован от абстрактного класса.
// Реализация абстрактного метода из базового абстрактного класса, в производном абстрактном классе - не обязательна!

namespace Abstraction
{
    // Абстрактный класс A.
    abstract class AbstractClassA
    {
        public abstract void OperationA();
    }

    // Абстрактный класс B.
    abstract class AbstractClassB : AbstractClassA
    {
        public abstract  void OperationB();
    }

    class Class : AbstractClassB
    {
        public override void OperationA()
        {
            Console.WriteLine("ConcreteClass.OperationA");
        }

        public override void OperationB()
        {
            Console.WriteLine("ConcreteClass.OperationB");
        }
    }

    class Program
    {
        static void Main()
        {
            AbstractClassA instance = new Class();
            instance.
            instance.OperationB();  //  Почему недоступен данный метод?

            Console.ReadKey();
        }
    }
}
