namespace Lab12_Aksana.Patrubeika_Practice.Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //реализовать компонент View в ваших самостоятельных работах при помощи делегатов +
            //Используя событийную модель реализовать подпись на событие:
            //Автосалон - пустой автосалон(закончились автомобили)
            //Реализовать подписку минимум 2 разных классов на событие(функционал реализации -на ваше усмотрение)
            //1) Если добавляется новый элемент, а достигнут лимит(лимит указываете сами)
            //2) Если удаляется элемент, а такого элемента в списке нет
            //3) Если изменяется элемент, а такого элемента в списке нет
            //Для этих случаев разработать собственные классы с ошибками
            //Все ошибки обработать блоками try catch в вызывающем методе

            //Exception
            //Если добавляется новый элемент, а лимит достигнут
            //Если удаляется элемент, а такого элемента в списке  нет
            //Если изменяется элемент, а такого элемента в списке нет

            #endregion

            CarShop cars = new CarShop();

            //add cars
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
            cars.AddCar
                (
                new Car()
                {
                    Brand = "BMW",
                    Price = 250,
                    Engine = "Disel"
                }
                );
            

            //remove car            
            Console.WriteLine(cars.ShowCar());
            Console.WriteLine("Enter brand of car for deleting:");
            var car = Console.ReadLine();
            cars.RemoveCar(car);
            //Console.WriteLine(cars.RemoveCar(car));


            //change of price           
            Console.WriteLine(cars.ShowCar());
            Console.WriteLine("Enter brand to change price:");
            var carDiscount = Convert.ToString(Console.ReadLine());
            Console.WriteLine(cars.DiscountCar(carDiscount));
        }
    }    
}