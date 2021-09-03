using System;
using System.Collections.Generic;

class RentalOffice : Program
{
    public int IdNumber { get; set; }
    public List<Car> cars = new List<Car>();

    public Car GetCars(int i)
    {
        return cars[i];
    }

    public void ChooseCar(int idNum)
    {
        for (int i = 0; i < cars.Count; i++)
        {
            if (cars[i].IdNumber == idNum)
            {
                cars[i].ThirdMenu();
                break;
            }
        }
    }

    public int CalcRevenue()
    {
        int totalRevenue = 0;

        for (int i = 0; i < cars.Count; i++)
        {
            totalRevenue += cars[i].PricePerDay;
        }

        return totalRevenue;
    }

    public void PresentCars()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            Console.WriteLine($"Id nummer:\t\t{cars[i].IdNumber}\n" +
                              $"Bilmodell:\t\t{cars[i].Model}\n" +
                              $"Kostnad per dag:\t{cars[i].PricePerDay:C0}\n" +
                              $"Rullade mil:\t\t{cars[i].Mileage}\n");
        }
    }

    public void SetupCars()
    {
        for (int i = 0; i < 30; i++)
        {
            cars.Add(new Car(int.Parse($"{IdNumber}{i}"),Model.Volvo + i % 5, rand.Next(0, 25001), rand.Next(750, 3500)));
        }
    }

    public void SecondMenu()
    {
        bool loop = true;

        do
        {
            Console.WriteLine("\tVad vill du göra?\n" +
                              "\t1. Välj en bil.\n" +
                              "\t2. Se hyrkontorets intäkter.\n" +
                              "\t3. Visa lista över alla bilar.\n" +
                              "\t4. Tillbaka till föregående meny.");

            switch (Input())
            {
                case 1:
                    PresentCars();
                    Console.WriteLine("Skriv in bilens id-nummer.");
                    ChooseCar(Input());
                    break;

                case 2:
                    Console.WriteLine($"{CalcRevenue():C0}");
                    break;
                case 3:
                    PresentCars();
                    break;
                case 4:
                    loop = false;
                    break;
            }
        } while (loop);
    }

    public RentalOffice(int idNumber)
    {
        IdNumber = idNumber;

        SetupCars();
    }
}