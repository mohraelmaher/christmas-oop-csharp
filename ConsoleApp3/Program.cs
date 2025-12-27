using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MyApp
{

    /*
     gift -> types of gift 
    each type has its own wrap price proprety
    gift are made in class 
    class choose gift---> user choose the type of gift 
    class santa ---> take gift and deliver 

     */
    abstract class Gift
    {
        private string name = "";
        private string wrapping = "";
        private double price;



        protected Gift(string n) {
            this.name = n;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Wrapping
        {
            get { return wrapping;}
            set {  wrapping = value; }
        }
        public double Price
        {
            get{ return price; }
            set { price = value; }
        }

        public abstract void Wrap();
        public abstract double CalculatePrice();

    }

    class ToyGift : Gift
    {
        public int size;

        protected  ToyGift(int size,string n) : base(n)
        {
            this.size = size;
        }

        public override double CalculatePrice()
        {
            switch (size)
            {
                case 1:
                    this.Price = 20;
                    return Price;
                case 2:
                    this.Price = 40;
                    return Price;
                case 3:
                    this.Price = 80;
                    return Price;
                default :
                    this.Price = 00.0;
                    return Price;
            }
        }
        public override void Wrap()
        {
            Wrapping = "Colorful Cartoon Paper with Ribbon";
           
            Console.WriteLine($"Toy wrapped in {Wrapping}🎁");
            
        }
        public static ToyGift CreateToy(int s)
        {
            return new ToyGift(s, "Toy");
        }
    }

    class BookGift : Gift
    {
        public int page;
        public BookGift(int page, string n) : base(n)
        {
            this.page = page;
        }
        public override double CalculatePrice()
        {
            switch (page) {
                case 80:
                    this.page = 80;
                    Price = page * .5;
                    return Price;
                case 120:
                    this.page = 120;
                    Price = page * .5;
                    return Price;
                default :
                    this.page = 40;
                    Price = page * .5;
                    return Price;
            }
        }
        public override void Wrap()
        {
            Wrapping = "Leather Wrap with Stamp 📚✨";
            Console.WriteLine($"Book wrapped in {Wrapping}");
        }
        public static BookGift CreateBookGift(int p)
        {
            return new BookGift(p, "Book");
        }
        

        
    }

    class ChristmasTreeGift:Gift
    {
        public int hight;

        public ChristmasTreeGift(int h, string n) : base(n)
        {
            this.hight = h;
        }

        public override double CalculatePrice() 
        {

            return hight * 30;
        }

        public override void Wrap()
        {
            Wrapping = "Festive Tree Decoration with Lights";
            Console.WriteLine($"🎁Tree is wrapped in {Wrapping}🎄");
        }

        public static Gift CreateTree(int h)
        {
            return new ChristmasTreeGift(h, "Christmas Tree");
        }

        public  void printTree()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < hight; i++)
            {
                Console.Write(new string(' ', hight - i - 1));
                Console.WriteLine(new string('*', 2 * i + 1));
            }
            Console.WriteLine(new string(' ', hight - 1) + "|");
            Console.WriteLine(new string(' ', hight - 1) + "*");
            Console.ResetColor();
        }
    }


    class ChooseGift
    {
        public Gift? GetGift()
        {
            int choose;
            Console.WriteLine("choose the gift \n1- book\n2-toy\n3-ChrismasTree");
            try
            {
                choose = int.Parse(Console.ReadLine()!);
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("choose number of pages");
                        Console.WriteLine("1- 80");
                        Console.WriteLine("2- 120");

                        int pagesChoice = int.Parse(Console.ReadLine()!);

                        if (pagesChoice == 1)
                            return BookGift.CreateBookGift(80);
                        else
                            return BookGift.CreateBookGift(120);

                    case 2:
                        Console.WriteLine("choose toy size");
                        Console.WriteLine("1- Small");
                        Console.WriteLine("2- Medium");
                        Console.WriteLine("3- Large");

                        int size = int.Parse(Console.ReadLine()!);
                        return ToyGift.CreateToy(size);

                    case 3:
                        Console.WriteLine("enter the height");
                        int h = int.Parse(Console.ReadLine()!);
                        return ChristmasTreeGift.CreateTree(h);


                    default:
                        //Console.WriteLine("Invalid choice");
                        //return ChristmasTreeGift.CreateTree(5);
                        return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        
            

         
        }
    }

    class Santa
    {
        public Santa()
        {
            Console.WriteLine("ho ho ho merry christmas🎅");
        }
        public void Deliver(Gift gift)
        {
            if (gift == null)
                throw new Exception("Invalid gift");
            if (gift is ChristmasTreeGift treeGift)
            {
                Console.WriteLine("Here is your tree 🎄🎁");
                treeGift.printTree(); 
            }

            gift.Wrap();
            Console.WriteLine($"Price = {gift.CalculatePrice()}");
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(" Welcome to Santa's Workshop 🎄🎅 ");
            ChooseGift chooser = new ChooseGift();
            Gift gift = chooser.GetGift();

            Santa santa = new Santa();
            try { 
            santa.Deliver(gift);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.ReadKey();
        }
    }
}

 
