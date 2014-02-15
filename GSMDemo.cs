namespace GSMSystem
{
    using System;

    public class GSMDemo
    {
        static void Main()
        {
            GSM g1 = new GSM("Desire S", "HTC", 1000M, "Peter Jackson",
                new Battery("H223", new TimeSpan(20, 30, 0),
                    new TimeSpan(10, 30, 0), BatteryType.NiCd),
                    new Display(5M));

            Console.WriteLine(g1);

            g1.AddCall("8427153",60);
            g1.AddCall("8435153", 60);
            g1.AddCall("8437153", 90);

            g1.ViewCalls();
            Console.WriteLine("total price = {0:C}", g1.CalculatePrice(0.37M));

            g1.RemoveCall("8437153");
            g1.ViewCalls();
            Console.WriteLine("Total price = {0:C}", g1.CalculatePrice(0.37M));

            g1.ClearHistory();
            g1.ViewCalls();

        }
    }
}
