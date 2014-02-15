
namespace GSMSystem
{
    using System;

    public class Battery
    {
        private string model;
        private TimeSpan? hoursIdle;
        private TimeSpan? hoursTalk;
        private BatteryType? type;

        #region Constructors
        public Battery()
            : this(null)
        {
        }
        public Battery(string model)
            : this(model, null)
        {
        }
        public Battery(string model, TimeSpan? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }
        public Battery(string model, 
            TimeSpan? hoursIdle, TimeSpan? hoursTalk)
            :this(model, hoursIdle, hoursIdle, null)
        {            
        }
        public Battery(string model, TimeSpan? hoursIdle, 
            TimeSpan? hoursTalk, BatteryType? type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }
        #endregion

        #region Properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public TimeSpan? HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }
        public TimeSpan? HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }
        public BatteryType? Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        #endregion
    }
}
