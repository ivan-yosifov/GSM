namespace GSMSystem
{
    using System;

    public class Display
    {
        private decimal? size;
        private decimal? colors;

        #region Constructors
        public Display()
            : this(null)
        {
        }
        public Display(decimal? size)
            : this(size, null)
        {
        }
        public Display(decimal? size, decimal? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
        #endregion

        #region Properties
        public decimal? Size
        {
            get { return this.size; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalide size: " + value);
                }

                this.size = value;
            }
        }
        public decimal? Colors
        {
            get { return this.colors; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid number of colors: " + value);
                }

                this.colors = value;
            }
        }
        #endregion
                
    }
}
