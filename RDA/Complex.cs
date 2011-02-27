using System;

namespace RDA
{	
	/// <summary>
    /// Класс комплексных чисел
    /// </summary>
    public class Complex : ICloneable
    {
        private double _mReal;
        private double _mImag;

        #region Конструкторы
        public Complex()
        {
        }

        public Complex (double re)
        {
            _mReal = re;
        }

        public Complex (double re, double im)
        {
            _mReal = re;
            _mImag = im;
        }

        public Complex (Complex x)
        {
            _mReal = x.Real;
            _mImag = x.Imag;
        }
        #endregion

        public double Real
        {
            get { return _mReal; }
            set { _mReal = value; }
        }

        public double Imag
        {
            get { return _mImag; }
            set {_mImag = value; }
        }

        public double Abs
        {
            get { return Math.Sqrt(_mImag * _mImag + _mReal * _mReal); }
        }

        public double Arg
        {
            get { return Math.Atan(_mImag / _mReal); }
        }

        /// <summary>
        /// Получить комплексно-сопряженное число
        /// </summary>
        public Complex GetConjugate()
        {
            return new Complex (_mReal, -_mImag);
        }

        public override string ToString()
        {
            string res = "";

            if (_mReal != 0.0)
            {
                res = _mReal.ToString();
            }

            if (_mImag != 0.0)
            {
                if (_mImag > 0)
                {
                    res += "+";
                }

                res += _mImag + "i";
            }

            return res;
        }

        #region Перегруженные операторы сложения
        public static Complex operator + (Complex c1, Complex c2)
        {
            return new Complex (c1.Real + c2.Real, c1.Imag + c2.Imag);
        }

        public static Complex operator + (Complex c1, double c2)
        {
            return new Complex (c1.Real + c2, c1.Imag);
        }

        public static Complex operator + (double  c1, Complex c2)
        {
            return new Complex (c1 + c2.Real, c2.Imag);
        }
        #endregion


        #region Перегруженные операторы вычитания
        public static Complex operator - (Complex c1, Complex c2)
        {
            return new Complex (c1.Real - c2.Real, c1.Imag - c2.Imag);
        }

        public static Complex operator - (Complex c1, double c2)
        {
            return new Complex (c1.Real - c2, c1.Imag);
        }

        public static Complex operator - (double  c1, Complex c2)
        {
            return new Complex (c1 - c2.Real, -c2.Imag);
        }
        #endregion


        #region Перегруженные операторы умножения
        public static Complex operator * (Complex c1, Complex c2)
        {
            return new Complex (c1.Real * c2.Real - c1.Imag * c2.Imag,
                c1.Real * c2.Imag + c1.Imag * c2.Real);
        }

        public static Complex operator * (Complex c1, double c2)
        {
            return new Complex (c1.Real * c2, c1.Imag * c2);
        }

        public static Complex operator * (double c1, Complex c2)
        {
            return new Complex (c1 * c2.Real, c1 * c2.Imag);
        }
        #endregion


        #region Перегруженные операторы деления
        public static Complex operator / (Complex c1, Complex c2)
        {
            double denominator = c2.Real * c2.Real + c2.Imag * c2.Imag;
            return new Complex ((c1.Real * c2.Real + c1.Imag * c2.Imag) / denominator,
                (c2.Real * c1.Imag - c2.Imag * c1.Real) / denominator);
        }

        public static Complex operator / (Complex c1, double c2)
        {
            return new Complex (c1.Real / c2, c1.Imag / c2);
        }

        public static Complex operator / (double c1, Complex c2)
        {
            double denominator = c2.Real * c2.Real + c2.Imag * c2.Imag;
            return new Complex ((c1 * c2.Real) / denominator, (-c2.Imag * c1) / denominator);
        }
        #endregion

        public static bool operator == (Complex c1, Complex c2)
        {
            return c1.Real == c2.Real && c1.Imag == c2.Imag;
        }

        public static bool operator != (Complex c1, Complex c2)
        {
            return c1.Real != c2.Real || c1.Imag != c2.Imag;
        }

        public override bool Equals(object obj)
        {
            return this == (Complex)obj;
        }

        public override int GetHashCode()
        {
            return _mReal.GetHashCode() + _mImag.GetHashCode();
        }


        #region ICloneable Members

        public object Clone()
        {
            return new Complex (_mReal, _mImag);
        }

        #endregion
    }
}
