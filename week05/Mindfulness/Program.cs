
// To show creativity and exceed the requirements, I added basic error handling 
// here in Program.cs if the user tries to select something invalid from the menu. 

using System;

class Program
{
    static void Main(string[] args)
    {

        var proceed = true;

        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options: \n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Quit");
            Console.Write("Select a choice from the menu: ");
            var userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (userChoice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();

            }
            else if (userChoice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (userChoice == "4")
            {
                proceed = false;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
                Thread.Sleep(2000);
            }

        } while (proceed);


    }
}