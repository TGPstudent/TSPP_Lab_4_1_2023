//TSPP_Lab_4_1_2023 Створення класів в C#. 
using System;

namespace TSPP_Lab_4_1_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            //Українська в консоль
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
           // Виділення пам'яті під масив класів
            Operation [] Bas = new Operation [10];

            var usCulture = new System.Globalization.CultureInfo("uk-UA");
            DateTime dt = new DateTime();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Bas[i] = new Operation();
                    Console.Write("\n Введiть дату операції:");
                    string D = Console.ReadLine();
                    if (D.Trim() != "" && DateTime.TryParse(D, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out dt))
                        Bas[i].Date = dt;
                    else throw new FormatException();

                    Console.Write(" Введiть номер рахунку абонента:");
                    Bas[i].Nom_account = Console.ReadLine();

                    Console.Write(" Введiть прізвище та ініціали абонента:");
                    Bas[i].Name = Console.ReadLine();

                    int key;
                    float temp_cash = 0;

                    do
                    {
                        Console.Write(" Оберіть тип операції натиснувши: 1-безготівка, 2 - готівка: ");
                        key = int.Parse(Console.ReadLine());
                        if (key == 1)
                        {

                            Console.Write(" Введіть суму безготівкової операції (суму витрат зі знаком мінус): ");
                            temp_cash = float.Parse(Console.ReadLine());

                            if (Operation.Bal(Bas, i) + temp_cash >= 0)
                            {
                                Bas[i].NonCash = temp_cash;
                                Bas[i].Cash = 0;
                                Bas[i].Balance = Operation.Bal(Bas, i) + Bas[i].NonCash;
                            }
                            else Console.Write(" Для здійснення операції недостатньо коштів на рахунку!");

                        }
                        else if (key == 2)
                        {
                            Console.Write(" Введіть суму готівкової операції (суму переказу зі знаком мінус): ");
                            temp_cash = float.Parse(Console.ReadLine());
                            if (Operation.Bal(Bas, i) + temp_cash >= 0)
                            {
                                Bas[i].Cash = temp_cash;
                                Bas[i].NonCash = 0;
                                Bas[i].Balance = Operation.Bal(Bas, i) + Bas[i].Cash;
                            }
                            else Console.WriteLine(" Для здійснення операції недостатньо коштів на рахунку!");
                        }
                        else Console.WriteLine(" Біда! Введіть номер 1 або номер 2; Iнших операцій не передбачено.");
                    }
                    while (key != 1 && key != 2);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Не введено номер рахунку чи прізвище абонента ");
            }
            catch (Exception zx)
            {
                Console.WriteLine("Упс! Сталась помилка" + zx.Message);
            }
            Console.Clear();

            //Виведення бази данних в консоль
            Console.WriteLine(" \n Ви ввели наступний список операцій клієнтів: \n");
            Operation.Print(Bas);

            //Введення даних для фільтрування
            try
            {
                DateTime dat_min = new DateTime();
                Console.Write(" \n Введіть дату початку відбору операцій: ");
                string D_min = Console.ReadLine();
                if (D_min.Trim() != "" && DateTime.TryParse(D_min, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out dat_min)) ;
                else throw new FormatException();
                DateTime dat_max = new DateTime();
                Console.Write(" Введіть дату закінчення відбору операцій: ");
                string D_max = Console.ReadLine();
                if (D_max.Trim() != "" && DateTime.TryParse(D_max, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out dat_max)) ;
                else throw new FormatException();
                Console.Write(" Введіть граничну суму безготівкового переказу: ");
                float gran = float.Parse(Console.ReadLine());
                //Виведення відфільтрованих даних
                Operation.Filtr_Print(Bas, dat_min, dat_max, gran);
            }
            catch (Exception zx)
            {
                Console.WriteLine("Упс! Сталась помилка" + zx.Message);
            }
            
            Console.ReadKey();
        }
               
    }
}
