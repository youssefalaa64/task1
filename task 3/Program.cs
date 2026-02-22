using System.ComponentModel.Design;

namespace task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char input;
            List <int> list = new List<int>();
            

            do
            {
                Console.WriteLine("P - Print numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("Q - Quit");
                input = Convert.ToChar(Console.ReadLine());

                if (input == 'P' || input == 'p')
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("[] - the list is empty");
                    }
                    else
                    {
                        Console.Write("[");
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.Write($"{list[i]},");
                        }
                        Console.Write("]");

                    }

                }

                else if (input == 'A' || input == 'a')
                {
                    Console.WriteLine("add a number : ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    list.Add(num);
                    Console.WriteLine($"number {num} added to the list");
                }

                else if (input == 'M' || input == 'm')
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("Unable to calculate the mean - no data");
                    }
                    else
                    {
                        double avg = list.Average();
                        Console.WriteLine(avg);
                    }
                }
                else if (input == 'S' || input == 's')
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("Unable to determine the smallest number - list is empty");
                    }
                    else
                    {
                        int min = list.Min();
                        Console.WriteLine(min);
                    }
                
                }
                else if(input =='L' ||  input == 'l')
                {
                    if(list.Count == 0)
                    {
                        Console.WriteLine("Unable to determine the largest number - list is empty");
                    }
                    else
                    {
                        int max = list.Max();
                        Console.WriteLine(max);
                    }
                }
                else if (input == 'Q' || input == 'q')
                {
                    Console.WriteLine("Goodbye");

                }
                else
                {
                    Console.WriteLine("Unknown selection, please try again");
                }
             
            }
           
             while ( input != 'q' || input != 'Q');
        }
    }
}
