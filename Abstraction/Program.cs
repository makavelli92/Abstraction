using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    abstract class Client
    {
        public string Name { get; protected set; }
        public double[,] orderArray;
        public int NumberOrder { get; protected set; }
        protected int columns = 0;
        protected int rows = 0; 
        
        public Client(string name)
        {
            Name = name;
            orderArray = new double[5,2];
        }

        public  void AddOrder(double summ)
        {
            if (summ > 0 && summ != 0)
            {
                orderArray[rows, columns++] = ++NumberOrder;
                orderArray[rows++, columns] = summ;
                columns = 0;
            }
            else
                Console.WriteLine("Cумма должна быть больше ноля и не равна ноль!");
        }
    }
    class NormalClient : Client
    {
        public NormalClient(string name) : base(name)
        {
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            st.AppendLine(Name);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < orderArray.GetLength(1); j++)
                {
                    if (j == 0)
                        st.AppendLine("№ заказа: " + orderArray[i, j].ToString());
                    else if (j == 1)
                        st.AppendLine("сумма заказа: " + orderArray[i, j].ToString());
                }
            }
            return st.ToString();
        }
    }
    class VipClient : Client
    {
        public int level;

        public VipClient(string name, int level): base (name)
        {
            Level = level;
        }
        public int Level
        {
            get
            {
                return level;
            }
            private set
            {
                if (value > 0 && value < 5)
                    level = value;
                else
                    Console.WriteLine("Такого уровня доступа не существует!");
            }
        }
        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            st.AppendLine("Имя заказчика: " + Name);
            st.AppendLine("Уровень доступа: " + Level.ToString());
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < orderArray.GetLength(1); j++)
                {
                    if (j == 0)
                        st.AppendLine("№ заказа: " + orderArray[i, j].ToString());
                    else if (j == 1)
                        st.AppendLine("сумма заказа: " + orderArray[i, j].ToString());
                }
            }
            return st.ToString();
        }

    }
    static class ClientSorting
    {
        public static Client[] SortingSumm(Client[] array)
        {
            for (int client = 0; client < array.Length; client++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[client].orderArray[j, 1] == 0)
                            break;
                        if (array[client].orderArray[i, 1] > array[client].orderArray[j, 1])
                        {
                            double temp = array[client].orderArray[j, 1];
                            array[client].orderArray[j, 1] = array[client].orderArray[i, 1];
                            array[client].orderArray[i, 1] = temp;
                        }
                    }
                }
            }
            return array;
        }
        public static VipClient[] SortingLevel(VipClient[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].Level > array[j].Level)
                    {
                        VipClient temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*VipClient ivan = new VipClient("Ivan", 4);
            ivan.AddOrder(451);
            ivan.AddOrder(5674);
            Console.WriteLine(ivan);*/
            VipClient[] array = new VipClient[3];
            array[0] = new VipClient("Anna", 4);
            array[1] = new VipClient("Ivan", 2);
            array[2] = new VipClient("Igor", 3);
            array[0].AddOrder(876);
            array[1].AddOrder(9987);
            array[2].AddOrder(556);
            array[0].AddOrder(456);
            array[2].AddOrder(875);
            array[1].AddOrder(674);
            array[1].AddOrder(7); 
            Client[] array2 = ClientSorting.SortingSumm(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }

            
            Console.ReadLine();
        }
    }
}
