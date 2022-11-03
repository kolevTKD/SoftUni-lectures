using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double heigth)
        {
            Length = length;
            Width = width;
            Height = heigth;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PARAM_CANNOT_BE_ZERO_OT_NEGATIVE, nameof(this.Length)));
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PARAM_CANNOT_BE_ZERO_OT_NEGATIVE, nameof(this.Width)));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PARAM_CANNOT_BE_ZERO_OT_NEGATIVE, nameof(this.Height)));
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
            => LateralSurfaceArea() + (2 * this.Width * this.Length);

        public double LateralSurfaceArea()
            => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double Volume()
            => this.Length * this.Width * this.Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {Volume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
