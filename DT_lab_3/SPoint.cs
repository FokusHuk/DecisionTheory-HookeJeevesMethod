using System;
using System.Collections.Generic;
using System.Text;

namespace DT_lab_3
{
    public class SPoint
    {
        public readonly double[] coordinates;
        private double _value;

        public SPoint(double[] coordinates)
        {
            this.coordinates = coordinates;

            _value = 0;
        }

        public double Value { get => _value; set => _value = value; }

        public static SPoint operator *(double arg1, SPoint arg2)
        {
            double[] coordinates = new double[arg2.coordinates.Length];
            arg2.coordinates.CopyTo(coordinates, 0);

            for (int i = 0; i < coordinates.Length; i++)
                coordinates[i] *= arg1;

            return new SPoint(coordinates);
        }

        public static SPoint operator *(SPoint arg1, double arg2)
        {
            double[] coordinates = new double[arg1.coordinates.Length];
            arg1.coordinates.CopyTo(coordinates, 0);

            for (int i = 0; i < coordinates.Length; i++)
                coordinates[i] *= arg2;

            return new SPoint(coordinates);
        }

        public static SPoint operator -(SPoint arg1, SPoint arg2)
        {
            double[] coordinates = new double[arg1.coordinates.Length];
            arg1.coordinates.CopyTo(coordinates, 0);

            for (int i = 0; i < coordinates.Length; i++)
                coordinates[i] -= arg2.coordinates[i];

            return new SPoint(coordinates);
        }

        public static SPoint operator +(SPoint arg1, SPoint arg2)
        {
            double[] coordinates = new double[arg1.coordinates.Length];
            arg1.coordinates.CopyTo(coordinates, 0);

            for (int i = 0; i < coordinates.Length; i++)
                coordinates[i] += arg2.coordinates[i];

            return new SPoint(coordinates);
        }

        public override string ToString()
        {
            string ret = "coordinates: { ";

            if (coordinates.Length != 0)
                ret += Math.Round(coordinates[0], 2).ToString();

            for (int i = 1; i < coordinates.Length; i++)
                ret += ", " + Math.Round(coordinates[i], 2).ToString();

            ret += " } \nfunc: " + Math.Round(Value, 2).ToString();

            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is SPoint)
            {
                SPoint point = (SPoint)obj;

                for (int i = 0; i < coordinates.Length; i++)
                {
                    if (Math.Round(coordinates[i], 10) != Math.Round(point.coordinates[i], 10))
                        return false;
                }

                return true;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public SPoint copy()
        {
            SPoint copy = new SPoint(new double[coordinates.Length]);
            coordinates.CopyTo(copy.coordinates, 0);
            return copy;
        }
    }
}
