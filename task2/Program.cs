namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number of days attended");
            int att = Convert.ToInt32(Console.ReadLine());
            if (att >= 20)
                Console.WriteLine("Excellent Attendance");
            else if (att >=10)
                Console.WriteLine("Eligible");
            else 
                Console.WriteLine("Not Eligible");
                


        }
    }
}
