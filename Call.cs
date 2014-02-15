namespace GSMSystem
{
    using System;

    public class Call
    {
        private DateTime timeOfCall;
        private string dialedNumber;
        private int duration;

        public Call(string dialedNumber, int duration)
        {
            this.timeOfCall = DateTime.Now;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }

        public DateTime TimeOfCall
        {
            get { return this.timeOfCall; }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
        }

        public int Duration
        {
            get { return this.duration; }
        }
    }
}
