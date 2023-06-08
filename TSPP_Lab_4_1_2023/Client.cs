using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP_Lab_4_1_2023
{
    class Client
    {
        //поля класу
        private DateTime date; //дата
        private string name;//Прізвище клієнта
        private string nom_account;//Номер рахунку
        private float nonCash;// Бензготівка
        private float cash;//Готівка
        private float balance;//Залишок
        public Client() //Конструктор без параметрів
        {

        }
        public void Input ()//Метод без параметрів вводу даних
        {
            data
            Console.Write("\n Введiть прізвище та ініціали клієнта:");
            name = Console.ReadLine();
            Console.Write("\n Введiть прізвище та ініціали клієнта:");
            name = Console.ReadLine();
            Console.Write("\n Введіть суму безготівкової операції:");
            nonCash = float.Parse(Console.ReadLine());
            Console.Write("\n Введіть суму готівкової операції:");
            cash = float.Parse(Console.ReadLine());
            Console.Write("\n Введіть залишок на рахунку клієнта:");
            cash = float.Parse(Console.ReadLine());
        }






    }
}