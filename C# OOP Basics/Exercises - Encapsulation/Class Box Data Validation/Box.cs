using System;

namespace ClassBoxDataValidation
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get { return lenght; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
                lenght = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;

            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }


        public string GetSurfaceArea(Box box)
        {
            return $"Surface Area - {(2 * this.lenght * this.width) + (2 * this.lenght * this.height) + (2 * this.width * this.height):F2}";
        }
        public string GetLateralSurfaceArea(Box box)
        {
            return $"Lateral Surface Area - {(2 * this.lenght * this.height) + (2 * this.width * this.height):F2}";
        }
        public string GetVolume(Box box)
        {
            return $"Volume - {this.width * this.height * this.lenght:F2}";
        }
    }
}