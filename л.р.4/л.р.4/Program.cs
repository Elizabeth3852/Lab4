using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace л.р._4
{
    // Класс транспортное средство
    abstract class Vehicle
    {
        private int price;      // стоимость тр. средства
        private int year;       // год выпуска
        private int maxspeed;   // максимальная скорость
        private int curspeed;   // текущая скорость
        public int Price // свойство стоимости
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        public int Year // свойство года выпуска
        {
            get { return year; }
            set { if (value > 1000 && value <= DateTime.Today.Year) year = value; }
        }
        public int MaxSpeed // свойство максимальной скорости
        {
            get { return maxspeed; }
            set { if (value > 0) maxspeed = value; }
        }
        public int CurrentSpeed // cвойство текущей скорости
        {
            get { return curspeed; }
            set { if (value > maxspeed) throw OutOfMaxBorder; curspeed = value; }
        }
        public virtual void SpeedUp()   // метод увеличения текущей скорости
        {
            CurrentSpeed++;
        }
        public virtual void SpeedDown() // метод уменьшения текущей скорости
        {
            CurrentSpeed--;
        }
        public Vehicle(int price, int maxspeed, int curspeed, int year)
        {
            this.Price = price;
            this.MaxSpeed = maxspeed;
            this.Year = year;
        }
        public Vehicle(int price, int maxspeed, int year)
        {
            // TODO: Complete member initialization
            this.price = price;
            this.maxspeed = maxspeed;
            this.year = year;
        }
        // исключения для классов наследников:
        protected Exception NonBellowZero = new Exception("Исключение, введенное значение не может быть отрицательным!");
        protected Exception OutOfMaxBorder = new Exception("Исключение, превышена максимальна граница!");
        
    }
    class Plane : Vehicle, IComparable<Plane> // класс самолет
    {
        public int height { get; set; } // высота
        public int passengers { get; set; } // пассажиры
        public int MaxPassengers { get; set; }
        public Plane(int price, int maxspeed, int year, int passengers, int height, int maxpassengers): base(price, maxspeed, year)
        {
            this.height = height;
            this.passengers = passengers;
            this.MaxPassengers = maxpassengers;
        }
        public override string ToString()
        {
            return String.Format("Цена: {0}\nМаксимальная скорость: {1}\nГод выпуска: {2}\nПассажиров: {3}",
                this.Price, this.MaxSpeed, this.Year, this.passengers);
        }
        public int CompareTo(Plane obj)
        {
            return this.passengers.CompareTo(obj.passengers);
        }
    }
    class Ship : Vehicle, IComparable<Ship>
    {
        private string port { get; set; }
        private int passengers { get; set; }
        public int MaxPassengers { get; set; }
        public Ship(int price, int maxspeed, int year, string port, int passengers, int maxpassengers): base(price, maxspeed, year)
        {
            this.port = port;
            this.passengers = passengers;
            this.MaxPassengers = maxpassengers;
        }
        public override string ToString()
        {
            return String.Format("Цена: {0}\nМаксимальная скорость: {1}\nГод выпуска: {2}\nПорт приписки: {3}\nПассажиров:{4}",
                this.Price, this.MaxSpeed, this.Year, this.port, this.passengers);
        }
        public int CompareTo(Ship obj)
        {
            return this.Year.CompareTo(obj.Year);
        }
    }
    class Car : Vehicle, IComparable<Car>
    {
        public int Power { get; set; }
        public Car(int price, int maxspeed, int year, int Power): base(price, maxspeed, year)
        {
            this.Power = Power;
        }
        public override void SpeedDown()
        {
            CurrentSpeed -= 15;
        }
        public override void SpeedUp()
        {
            CurrentSpeed += 15;
        }
        public override string ToString()
        {
            return String.Format("Цена: {0}\nМаксимальная скорость: {1}\nГод выпуска: {2}\nМощность: {3}",
                this.Price, this.MaxSpeed,  this.Year, this.Power);
        }
        public int CompareTo(Car obj)
        {
            return this.Price.CompareTo(obj.Price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // подключение List
            // Машины
            List<Car> lcar = new List<Car>();
            lcar.Add(new Car(price: 23075, maxspeed: 240, year: 2009, Power: 331));
            lcar.Add(new Car(price: 24350, maxspeed: 260, year: 2010, Power: 391));
            lcar.Add(new Car(price: 22703, maxspeed: 250, year: 2008, Power: 381));
            lcar.Add(new Car(price: 25080, maxspeed: 235, year: 2004, Power: 351));
            Console.WriteLine("Каталог автомобилей: \n");
            foreach (Car a in lcar)
                Console.WriteLine(a);
            lcar.Sort();
            Console.WriteLine("\nАвтомобили упорядочены по цене: \n");
            foreach (Car a in lcar)
                Console.WriteLine(a);
            Console.ReadLine();

            // Самолет    
            List<Plane> lplane = new List<Plane>();
            lplane.Add(new Plane(price: 5500075, maxspeed: 210, year: 1981, height: 11850, passengers: 190, maxpassengers: 200));
            lplane.Add(new Plane(price: 5515458, maxspeed: 320, year: 1900, height: 13000, passengers: 180, maxpassengers: 220));
            lplane.Add(new Plane(price: 7075289, maxspeed: 225, year: 1984, height: 13000, passengers: 216, maxpassengers: 220));
            lplane.Add(new Plane(price: 6045738, maxspeed: 215, year: 1982, height: 11900, passengers: 200, maxpassengers: 220));
            lplane.Add(new Plane(price: 6575258, maxspeed: 300, year: 1983, height: 12000, passengers: 184, maxpassengers: 190));
            Console.WriteLine("\nКаталог самолетов: \n");
            foreach (Plane a in lplane)
                Console.WriteLine(a);
            lplane.Sort();
            Console.WriteLine("\nСамолеты упорядочены по количеству пассажиров: \n");
            foreach (Plane a in lplane)
                Console.WriteLine(a);
            Console.ReadLine();

            //Корабль
            List<Ship> lship = new List<Ship>();
            lship.Add(new Ship(price: 75000, maxspeed: 250, year: 2009, port: "Port X", passengers: 36, maxpassengers: 40));
            lship.Add(new Ship(price: 40000, maxspeed: 250, year: 2000, port: "Port I", passengers: 25, maxpassengers: 30));
            lship.Add(new Ship(price: 50000, maxspeed: 250, year: 2005, port: "Port III", passengers: 29, maxpassengers: 30));
            lship.Add(new Ship(price: 55000, maxspeed: 250, year: 2006, port: "Port V", passengers: 30, maxpassengers: 30));
            lship.Add(new Ship(price: 45000, maxspeed: 250, year: 2001, port: "Port II", passengers: 28, maxpassengers: 30));
            lship.Add(new Ship(price: 60000, maxspeed: 250, year: 2008, port: "Port VI", passengers: 35, maxpassengers: 50));
            Console.WriteLine("\nКаталог кораблей: \n");
            foreach (Ship a in lship)
                Console.WriteLine(a);
            lship.Sort();
            Console.WriteLine("\nКорабли упорядочены по году выпуска: \n");
            foreach (Ship a in lship)
                Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
      

