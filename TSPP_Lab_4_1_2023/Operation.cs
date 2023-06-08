using System;


namespace TSPP_Lab_4_1_2023
{
    class Operation
    {
        //поля класу
        private DateTime date; //дата
        private string name;//Прізвище клієнта
        private string nom_account;//Номер рахунку
        private float nonCash;// Бензготівка
        private float cash;//Готівка
        private float balance;//Залишок

        public Operation() //Конструктор 
        {
            Balance =  100000.00F;
        }

        //Mетоди
        //Виведення в консоль бази даних
        static public void Print (Operation[] operations)
        {
            Console.WriteLine("  ______________________________________________________________________________________________________________________________");
            Console.WriteLine(" |   Дата операції |  Номер рахунку |  Прізвище ініціали   |  Безготівкова операція  |   Готівкова операція  | Баланс\t\t|");
            Console.WriteLine(" |_________________|________________|______________________|_________________________|_______________________|__________________|");

            //Console.WriteLine(" Дата оп.  № рах.   Фамілія    \tБезг. \t\tГотівк. \tБаланс ");
            if (operations.Length > 1)
            {
                for (int i = 0; i < operations.Length; i++)
                {
                    Console.WriteLine(" |   " + operations[i].Date.ToString("d") + String.Format($"\t   |   {operations[i].Nom_account,-12} | {operations[i].Name, -21}|  {operations[i].NonCash,-23:f2}|  {operations[i].Cash,-21:f2}|  {operations[i].Balance,-16:f2}|"));
                }
                Console.WriteLine(" |_________________|________________|______________________|_________________________|_______________________|__________________|");

            }
            else Console.WriteLine("Записи в базі відсутні");
        }
        //Мінімальна дата в переліку
        static private DateTime Min (Operation[] operations)
        {
            DateTime min = new DateTime();
            min = operations[1].Date;
            for (int i = 1; i < operations.Length-1; i++)
            {
                if (operations[i].Date < min) min = operations[i].Date;
            }
            return min;
        }
        //Максимальна дата в переліку
        static private DateTime Max (Operation[] operations)
        {
            DateTime max = new DateTime();
            max = operations[1].Date;
            for (int i = 1; i < operations.Length - 1; i++)
            {
                if (operations[i].Date > max) max = operations[i].Date;
            }
            return max;
        }
        //Баланс рахунку замовника
        static public float Bal (Operation[] operations, int k)
        {
            float bal = operations[k].Balance;
            for (int i = 0; i < k; i++)
            {
                if (operations[i].Nom_account == operations[k].Nom_account) bal = operations[i].Balance;
            }
            return bal;
        }
        //Виведення в консоль відібраних записів
        static public void Filtr_Print(Operation[] operations, DateTime dat_min, DateTime dat_max, float gran)
        {
            DateTime min = Min (operations);
            DateTime max = Max (operations);
            if (dat_min >= max || dat_max <= min) Console.Write("\n В заданому часовому проміжку операцій не виконувалось");
            else
            {
                Console.WriteLine("  ______________________________________________________________________________________________________________________________");
                Console.WriteLine(" |   Дата операції |  Номер рахунку |  Прізвище ініціали   |  Безготівкова операція  |   Готівкова операція  | Баланс\t\t|");
                Console.WriteLine(" |_________________|________________|______________________|_________________________|_______________________|__________________|");
                for (int i = 0; i < operations.Length; i++)
                {
                    if (operations[i].Date >= dat_min && operations[i].Date <= dat_max && Math.Abs(operations[i].NonCash) > Math.Abs(gran))
                        Console.WriteLine(" |   " + operations[i].Date.ToString("d") + String.Format($"\t   |   {operations[i].Nom_account,-12} | {operations[i].Name,-21}|  {operations[i].NonCash,-23:f2}|  {operations[i].Cash,-21:f2}|  {operations[i].Balance,-16:f2}|"));
                }
                Console.WriteLine(" |_________________|________________|______________________|_________________________|_______________________|__________________|");
            }
        }
        
        //Властивості класу
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        
        public string Nom_account
        {
            get { return nom_account; }
            set
            {
                if (value.Trim() != "") nom_account = value;
                else
                {
                    Console.Write("\n Не введено номер рахунку клієнта");
                    throw new NullReferenceException();
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Trim() != "") name = value;
                else
                {
                    Console.Write("\n Не введено номер рахунку клієнта");
                    throw new NullReferenceException();
                }
            }
        }

        public float NonCash { get; set; }
        public float Cash { get; set; }
        public float Balance { get;  set; }
    }
}
