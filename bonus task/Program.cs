namespace bonus_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("what is your viechle type?  [1 : car, 2 : truck, 3 : motorcycle]");
            int viechletype = Convert.ToInt32(Console.ReadLine());
            double hourprice = 0.0;
            if (viechletype == 1)
                hourprice = 10.0;
            else if (viechletype == 2)
                hourprice = 20.0;
            else if (viechletype == 3)
                hourprice = 5.0;
            else
                Console.WriteLine("Invalid Viechle Type");

                Console.WriteLine("parking duration in hours?");
            int parkingduration = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("what is your membership type? [0 : none , 1 : silver , 2 : gold]");
            int membership = Convert.ToInt32(Console.ReadLine());
            double discount1 = .1;
            double discount2 = .2;

            double totalprice;

            if (parkingduration > 2)
                totalprice = hourprice*2 + ((parkingduration - 2) * 1.5) * hourprice;
            else
                totalprice = parkingduration * hourprice;

            switch (membership)
            {
                case 0:
                    Console.WriteLine("you dont have any membership");
                    Console.WriteLine($"your total price = {totalprice}");
                    break;
                case 1:
                    Console.WriteLine("you have a silver membership");
                    Console.Write("your total price is :");
                    Console.Write(totalprice - discount1 * totalprice);
                    break;



                case 2:
                    Console.WriteLine("you have a gold membership");
                    Console.Write("your total price is :");
                    Console.Write(totalprice - discount2 * totalprice);
                    break;
                 }   
                    




            }


















        }
    }

