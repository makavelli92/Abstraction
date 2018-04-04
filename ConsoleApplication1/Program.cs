using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// is, as
namespace Abstract
{
    abstract class AbstractBaseClass
    {
        // 1.
        // Обычный метод передается производному классу как при наследовании от конкретного класса.
        public void SimpleMethod()
        {
            Console.WriteLine("AbstractBaseClass.SimpleMethod");
        }

        // 2.
        // Виртуальный метод передается производному классу как при наследовании от конкретного класса.
        virtual public void VirtualMethod()
        {
            Console.WriteLine("AbstractBaseClass.VirtualMethod");
        }

        // 3.
        // Абстрактный метод - реализуется в производном классе.
        abstract public void AbstractMethod();
    }

    class DerivedClass : AbstractBaseClass
    {
        // Переопределяем виртуальный метод VirtualMethod() базового абстрактного класса.
        // Если мы не переопределим виртуальный метод, то будет использован метод из базового класса.

          public  void VirtualMethod()
          {
              Console.WriteLine("DerivedClass.VirtualMethod();");
          }

        // Реализуем абстрактный метод AbstractMethod() базового абстрактного класса.

        public override void AbstractMethod()
        {
            Console.WriteLine("DerivedClass.AbstractMethod();");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractBaseClass instance = new DerivedClass();

            instance.SimpleMethod();
            instance.VirtualMethod();
            instance.AbstractMethod();

            //Delay.
            Console.ReadKey();
        }
    }
}
