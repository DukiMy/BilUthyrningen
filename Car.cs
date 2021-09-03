using System;

class Car : Program
{
    public int IdNumber { get; set; }
    public Model Model { get; set; }
    public int Mileage { get; set; }
    public int PricePerDay { get; set; }
    public int Revenue { get; set; }

    public void ChangeValues(int days)
    {
        Mileage += days * rand.Next(5, 60);
        Revenue += PricePerDay * days;
    }

    public void ThirdMenu()
    {
        bool loop = true;

        do
        {
            Console.WriteLine("\tVad vill du göra?\n" +
                              "\t1. Se vad bilen kostar att hyra.\n" +
                              "\t2. Se hur mycket bilen har rullat.\n" +
                              "\t3. Se vad det är för bilmodell.\n" +
                              "\t4. Se intäkterna för denna bil.\n" +
                              "\t5. Tillbaka till föregående meny.");

            switch (Input())
            {
                case 1:
                    Console.WriteLine($"Bilen kostar {PricePerDay:C0} per dag.");
                    break;

                case 2:
                    Console.WriteLine($"Bilen har rullat {Mileage:N0} mil.");
                    break;
                case 3:
                    Console.WriteLine($"Bilen är en {Model}.");
                    break;
                case 4:
                    Console.WriteLine($"Denna bil har tjänat in {Revenue:C0}");
                    break;
                case 5:
                    loop = false;
                    break;
            }
        } while (loop);
    }

    public Car(int idNumber, Model model, int mileage, int pricePerDay)
    {
        IdNumber = idNumber;
        Model = model;
        Mileage = mileage;
        PricePerDay = pricePerDay;
    }
}