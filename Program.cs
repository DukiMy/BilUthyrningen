using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Program
{

    static List<RentalOffice> rentalOffices = new List<RentalOffice>();
    public Random rand = new Random();


    public static void IterateDays(int days)
    {
        for (int i = 0; i < rentalOffices.Count; i++)
        {
            for (int j = 0; j < rentalOffices[i].cars.Count; j++)
            {
                rentalOffices[i].cars[j].ChangeValues(days);
            }
        }
    }

    public static void ChooseRentalOffice(int idNum)
    {
        for (int i = 0; i < rentalOffices.Count; i++)
        {
            if (rentalOffices[i].IdNumber == idNum)
            {
                rentalOffices[i].SecondMenu();
                break;
            }
        }
    }

    public static int CalcTotalRevenue()
    {
        int result = 0;

        for (int i = 0; i < rentalOffices.Count; i++)
        {
            result += rentalOffices[i].CalcRevenue();
        }

        return result;
    }

    public static void PresentAllCars()
    {
        for (int i = 0; i < rentalOffices.Count; i++)
        {
            rentalOffices[i].PresentCars();
        }
    }

    public static void PresentAllOffices()
    {
        for (int i = 0; i < rentalOffices.Count; i++)
        {
            Console.WriteLine($"Kontor nummer: {rentalOffices[i].IdNumber}");
        }
    }

    public static void SetUpOffices()
    {
        for (int i = 0; i < 30; i++)
        {
            rentalOffices.Add(new RentalOffice(i));
        }
    }

    public static int Input()
    {
        int result = 0;
        bool loop = false;

        do
        {
            if (int.TryParse(Console.ReadLine(), out result))
            {
                loop = false;
            }
            else
            {
                Console.Beep(900, 100);
                Thread.Sleep(70);
                Console.Beep(400, 650);

                loop = true;
            }
        } while (loop);

        return result;
    }

    static public void StartMenu()
    {
        bool loop = true;

        do
        {
            Console.WriteLine("\tVad vill du göra?\n" +
                              "\t1. Välj hyreskontor.\n" +
                              "\t2. Se totala intäkter för alla kontor.\n" +
                              "\t3. Visa lista över alla bilar.\n" +
                              "\t4. Gör en tidsresa.\n" +
                              "\t5. Avsluta programmet.");

            switch (Input())
            {
                case 1:
                    PresentAllOffices();
                    Console.WriteLine("Skriv in kontorets id-nummer.");
                    ChooseRentalOffice(Input());
                    break;

                case 2:
                    Console.WriteLine($"Totala intäkter är: {CalcTotalRevenue():C0}");
                    break;
                case 3:
                    PresentAllCars();
                    break;
                case 4:
                    Console.WriteLine("Hur många dagar frammåt i tiden vill ni resa?");
                    IterateDays(Input());
                    break;
                case 5:
                    loop = false;
                    break;
            }
        } while (loop);
    }

    public static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("sv-SE", false);

        SetUpOffices();

        StartMenu();
    }
}