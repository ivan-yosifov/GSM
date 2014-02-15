namespace GSMSystem
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        static private GSM nokiaN95;

        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;

        private Battery battery;
        private Display display;

        private List<Call> calls = new List<Call>();

        #region Constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }
        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {
        }
        public GSM(string model, string manufacturer, decimal? price,
            string owner)
            : this(model, manufacturer, price, owner, new Battery())
        {
        }
        public GSM(string model, string manufacturer, decimal? price,
            string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, 
            new Display())
        {
        }
        public GSM(string model, string manufacturer, decimal? price,
            string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        static GSM()
        {
            nokiaN95 = new GSM("N95", "Nokia", 1000M, "Ivan Yosifov",
                new Battery("H223", new TimeSpan(20, 30, 0),
                    new TimeSpan(5, 45, 0), BatteryType.NiCd),
                    new Display(5M));
        }
        #endregion

        #region Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid manufacturer: {0}", value);
                }
                this.manufacturer = value; 
            }
        }
        public decimal? Price
        {
            get { return this.price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price: " + value);
                }
                this.price = value; 
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalide name: {0}", value);
                }
                this.owner = value; 
            }
        }
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        #endregion

        static public GSM NokiaN95
        {
            get { return nokiaN95; }
        }

        static public string NokiaN95ToString()
        {
            return String.Format("Model: {0} Manufacturer: {1}", nokiaN95.model, nokiaN95.manufacturer);
        }

        public override string ToString()
        {
            return String.Format("Model: \"{0}\" Manufacturer: \"{1}\"",
                this.model, this.manufacturer);
        }

        public void ViewCalls()
        {
            if (calls.Count > 0)
            {
                Console.WriteLine("-------------------Calls List ------------------");
                Console.WriteLine("{0,-10}{1,-13} | {2,-8} | {3}",
                    "Date", "Time", "Number", "Duration");
                foreach (var call in calls)
                {
                    Console.WriteLine("{0,-23} | {1,-8} | {2}",
                        call.TimeOfCall, call.DialedNumber, call.Duration);
                }
                Console.WriteLine
                    ("---------------------------------------------");
            }
            else
            {
                Console.WriteLine("\nNo calls\n");
            }
        }
        
        public void AddCall(string dialedNumber, int duration)
        {
            Call call = new Call(dialedNumber, duration);
            calls.Add(call);
        }

        public void RemoveCall(string numberToDelete)
        {
            int removedCallsCount = 0;

            if (this.calls.Count > 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No calls to delete");
                return;
            }

            for (int i = 0; i < calls.Count; i++)
            {
                if (numberToDelete == calls[i].DialedNumber)
                {
                    calls.Remove(calls[i]);
                    removedCallsCount++;
                }
            }
           
            //for (int i = 0; i < calls.Count; i++)
            //{
            //    if (calls[i].DialedNumber == numberToDelete)
            //    {
            //        calls.RemoveAt(i);
            //        removedCallsCount++;
            //    }
            //}

            if (removedCallsCount > 0)
            {
                Console.WriteLine("{0} calls removed\n",
                    removedCallsCount);
            }
            else
            {
                Console.WriteLine("Call not found");
            }
        }

        public void ClearHistory()
        {
            this.calls.Clear();

            Console.WriteLine("\nAll calls cleared\n");
        }

        public decimal CalculatePrice(decimal costPerMinute)
        {
            long totalSecondCount = 0;
            foreach (var call in calls)
            {
                totalSecondCount += call.Duration;
            }

            decimal total = (totalSecondCount / 60) * costPerMinute;

            return total;
        }
    }
}
