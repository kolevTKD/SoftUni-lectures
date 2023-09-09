namespace _01.ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PARAM_CANNOT_BE_ZERO_OR_NEGATIVE, nameof(Length)));
                }
                else
                {
                    length = value;
                }
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PARAM_CANNOT_BE_ZERO_OR_NEGATIVE, nameof(Width)));
                }
                else
                {
                    width = value;
                }
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PARAM_CANNOT_BE_ZERO_OR_NEGATIVE, nameof(Height)));
                }
                else
                {
                    height = value;
                }
            }
        }

        public double SurfaceArea() => (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
        public double LateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);
        public double Volume() => Length * Width * Height;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():F2}")
              .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}")
              .AppendLine($"Volume - {Volume():F2}");

            return sb.ToString().Trim();
        }
    }
}
