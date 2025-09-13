using System;

namespace lab2
{
    public class Polynomial
    {
        // Інкапсульоване поле
        private double[] coeffs;

        // Властивості
        public int Degree
        {
            get { return coeffs.Length - 1; }
        }

        public double LeadingCoefficient
        {
            get { return coeffs.Length == 0 ? 0 : coeffs[Degree]; }
        }

        // Конструктор
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null || coefficients.Length == 0)
                throw new ArgumentException("Потрібен хоча б один коефіцієнт");

            coeffs = new double[coefficients.Length];
            for (int i = 0; i < coefficients.Length; i++)
                coeffs[i] = coefficients[i];

            TrimTrailingZeros();
        }

        // Індексатор
        public double this[int power]
        {
            get
            {
                if (power < 0) throw new ArgumentOutOfRangeException();
                if (power < coeffs.Length) return coeffs[power];
                return 0;
            }
            set
            {
                if (power < 0) throw new ArgumentOutOfRangeException();
                if (power >= coeffs.Length)
                {
                    Array.Resize(ref coeffs, power + 1);
                }
                coeffs[power] = value;
                TrimTrailingZeros();
            }
        }

        // Оператор +
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int n = Math.Max(a.Degree, b.Degree) + 1;
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                double ai = i <= a.Degree ? a.coeffs[i] : 0;
                double bi = i <= b.Degree ? b.coeffs[i] : 0;
                result[i] = ai + bi;
            }

            return new Polynomial(result);
        }

        // Обчислення значення (схема Горнера, але простим циклом)
        public double Evaluate(double x)
        {
            double res = 0;
            for (int i = Degree; i >= 0; i--)
            {
                res = res * x + coeffs[i];
            }
            return res;
        }

        // Текстове представлення
        public override string ToString()
        {
            if (coeffs.Length == 0) return "0";

            string s = "";
            for (int i = Degree; i >= 0; i--)
            {
                double c = coeffs[i];
                if (Math.Abs(c) < 1e-12) continue;

                if (s != "")
                {
                    if (c >= 0) s += " + ";
                    else s += " - ";
                }
                else
                {
                    if (c < 0) s += "-";
                }

                double absC = Math.Abs(c);

                if (i == 0) s += absC.ToString();
                else if (i == 1) s += (absC == 1 ? "x" : absC + "x");
                else s += (absC == 1 ? "x^" + i : absC + "x^" + i);
            }

            return s == "" ? "0" : s;
        }

        // Допоміжне — прибрати нулі в кінці
        private void TrimTrailingZeros()
        {
            int last = coeffs.Length - 1;
            while (last > 0 && Math.Abs(coeffs[last]) < 1e-12) last--;

            if (last < coeffs.Length - 1)
                Array.Resize(ref coeffs, last + 1);
        }
    }
}
