using System.Diagnostics;

namespace Lab10_Aksana.Patrubeika_Delegates
{
    public delegate string Show();
    

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //реализовать компонент View в ваших самостоятельных работах при помощи делегатов +
            //Используя событийную модель реализовать подпись на событие:
            //Автосалон - пустой автосалон(закончились автомобили)
            //Реализовать подписку минимум 2 разных классов на событие(функционал реализации -на ваше усмотрение)

            //Exception
            //Если добавляется новый элемент, а лимит достигнут
            //Если удаляется элемент, а такого элемента в списке  нет
            //Если изменяется элемент, а такого элемента в списке нет

            #endregion

            var exitMenue = false;            

            CarShop cars = new CarShop();
            Message message = new Message();
            //Car carPrice = new Car();
            CarStock carStock = new CarStock();
            cars.Empty += Cars_Empty;   //подписались на событие
            Show show = cars.ShowCar;   //передали переменной делегата метод класса
            

            while (!exitMenue)
            { // MENU
                Console.WriteLine("if you want to add a car, press 1");
                Console.WriteLine("if you want to show a car, press 2");
                Console.WriteLine("if you want to remove a car, press 3");
                Console.WriteLine("if you want to change price of a car, press 4");
                Console.WriteLine("if you want to exit press 5");
                var temp = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (temp)
                {
                    case 1:
                        cars.AddCar
                            (
                            new Car()
                            {
                                Brand = "Tesla",
                                Price = 233.236,
                                Engine = "Electric"
                            }
                            );
                        cars.AddCar
                            (
                            new Car()
                            {
                                Brand = "Audi",
                                Price = 300,
                                Engine = "Bensin"
                            }
                            );
                        //cars.AddCar
                        //    (
                        //    new Car()
                        //    {
                        //        Brand = "BMW",
                        //        Price = 250,
                        //        Engine = "Disel"
                        //    }
                        //    );
                        break;

                        case 2:
                        //show car                        
                        Console.WriteLine(show());
                        cars.NotEnoughtCar += carStock.OrderCar;
                        cars.Message2();
                        break;

                        case 3:
                        //remove car
                        cars.NoCar += message.EnterForDeleting;
                        cars.Message();
                        Console.WriteLine(show());
                        var car = Console.ReadLine();
                        cars.RemoveCar(car);
                        Console.Clear() ;
                        break;

                        case 4:
                        //change of price           
                        Console.WriteLine(cars.ShowCar());
                        cars.NoCar += message.EnterForChanging;
                        cars.Message();

                        var carDiscount = Console.ReadLine();
                        Console.WriteLine(cars.DiscountCar(carDiscount));

                        //carPrice.ChangePrice += CarPrice_ChangePrice;
                        break;

                        case 5:
                        Console.WriteLine("Goodbye!");
                        exitMenue = true;
                        break;

                    default:
                        Console.WriteLine("wrong option, please, try again");
                        break;                        
                } 
            }

        }

        private static void CarPrice_ChangePrice(object? sender, EventArgs e)
        {
            Console.WriteLine($"Price {((Car)sender).Brand} was change to {((Car)sender).Price}");
        }

        private static string Cars_Empty()
        {
            return "Shop is empty!";
        }
    }    
}