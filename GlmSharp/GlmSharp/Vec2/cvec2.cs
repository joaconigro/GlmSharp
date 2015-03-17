using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Linq;
using GlmSharp.Swizzle;

// ReSharper disable InconsistentNaming

namespace GlmSharp
{
    
    /// <summary>
    /// A vector of type Complex with 2 components.
    /// </summary>
    [Serializable]
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct cvec2 : IReadOnlyList<Complex>, IEquatable<cvec2>
    {
        
        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public Complex x;
        
        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public Complex y;
        
        /// <summary>
        /// Returns an object that can be used for swizzling (e.g. swizzle.zy)
        /// </summary>
        public swizzle_cvec2 swizzle => new swizzle_cvec2(x, y);
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static cvec2 Zero { get; } = new cvec2(0.0, 0.0);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static cvec2 Ones { get; } = new cvec2(1.0, 1.0);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static cvec2 UnitX { get; } = new cvec2(1.0, 0.0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static cvec2 UnitY { get; } = new cvec2(0.0, 1.0);
        
        /// <summary>
        /// Predefined all-imaginary-ones vector
        /// </summary>
        public static cvec2 ImaginaryOnes { get; } = new cvec2(Complex.ImaginaryOne, Complex.ImaginaryOne);
        
        /// <summary>
        /// Predefined unit-imaginary-X vector
        /// </summary>
        public static cvec2 ImaginaryUnitX { get; } = new cvec2(Complex.ImaginaryOne, 0.0);
        
        /// <summary>
        /// Predefined unit-imaginary-Y vector
        /// </summary>
        public static cvec2 ImaginaryUnitY { get; } = new cvec2(0.0, Complex.ImaginaryOne);
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public Complex[] Values => new[] { x, y };
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public cvec2(Complex x, Complex y)
        {
            this.x = x;
            this.y = y;
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public cvec2(Complex v)
        {
            this.x = v;
            this.y = v;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public cvec2(cvec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public cvec2(cvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public cvec2(cvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        /// <summary>
        /// Explicitly converts this to a cvec3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator cvec3(cvec2 v) => new cvec3((Complex)v.x, (Complex)v.y, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a cvec4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator cvec4(cvec2 v) => new cvec4((Complex)v.x, (Complex)v.y, 0.0, 0.0);
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        public IEnumerator<Complex> GetEnumerator()
        {
            yield return x;
            yield return y;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        public int Count => 2;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public Complex this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: this.x = value; break;
                    case 1: this.y = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(cvec2 rhs) => x.Equals(rhs.x) && y.Equals(rhs.y);
        
        /// <summary>
        /// Returns true iff this equals rhs type- and component-wise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is cvec2 && Equals((cvec2) obj);
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(cvec2 lhs, cvec2 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(cvec2 lhs, cvec2 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((x.GetHashCode()) * 397) ^ y.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        public string ToString(string sep) => x + sep + y;
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator and a format provider for each component.
        /// </summary>
        public string ToString(string sep, IFormatProvider provider) => x.ToString(provider) + sep + y.ToString(provider);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator and a format for each component.
        /// </summary>
        public string ToString(string sep, string format) => x.ToString(format) + sep + y.ToString(format);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator and a format and format provider for each component.
        /// </summary>
        public string ToString(string sep, string format, IFormatProvider provider) => x.ToString(format, provider) + sep + y.ToString(format, provider);
        
        /// <summary>
        /// Returns a vector containing component-wise magnitudes.
        /// </summary>
        public dvec2 Magnitude => new dvec2(x.Magnitude, y.Magnitude);
        
        /// <summary>
        /// Returns a vector containing component-wise phases.
        /// </summary>
        public dvec2 Phase => new dvec2(x.Phase, y.Phase);
        
        /// <summary>
        /// Returns a vector containing component-wise imaginary parts.
        /// </summary>
        public dvec2 Imaginary => new dvec2(x.Imaginary, y.Imaginary);
        
        /// <summary>
        /// Returns a vector containing component-wise real parts.
        /// </summary>
        public dvec2 Real => new dvec2(x.Real, y.Real);
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public double Length => (double)Math.Sqrt(x.LengthSqr() + y.LengthSqr());
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public double LengthSqr => x.LengthSqr() + y.LengthSqr();
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public Complex Sum => x + y;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public double Norm => (double)Math.Sqrt(x.LengthSqr() + y.LengthSqr());
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public double Norm1 => x.Magnitude + y.Magnitude;
        
        /// <summary>
        /// Returns the two-norm of this vector.
        /// </summary>
        public double Norm2 => (double)Math.Sqrt(x.LengthSqr() + y.LengthSqr());
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public Complex NormMax => Math.Max(x.Magnitude, y.Magnitude);
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => Math.Pow(Math.Pow((double)x.Magnitude, p) + Math.Pow((double)y.Magnitude, p), 1 / p);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static cvec2 operator+(cvec2 lhs, cvec2 rhs) => new cvec2(lhs.x + rhs.x, lhs.y + rhs.y);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static cvec2 operator+(cvec2 lhs, Complex rhs) => new cvec2(lhs.x + rhs, lhs.y + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static cvec2 operator+(Complex lhs, cvec2 rhs) => new cvec2(lhs + rhs.x, lhs + rhs.y);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static cvec2 operator-(cvec2 lhs, cvec2 rhs) => new cvec2(lhs.x - rhs.x, lhs.y - rhs.y);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static cvec2 operator-(cvec2 lhs, Complex rhs) => new cvec2(lhs.x - rhs, lhs.y - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static cvec2 operator-(Complex lhs, cvec2 rhs) => new cvec2(lhs - rhs.x, lhs - rhs.y);
        
        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static cvec2 operator/(cvec2 lhs, cvec2 rhs) => new cvec2(lhs.x / rhs.x, lhs.y / rhs.y);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static cvec2 operator/(cvec2 lhs, Complex rhs) => new cvec2(lhs.x / rhs, lhs.y / rhs);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static cvec2 operator/(Complex lhs, cvec2 rhs) => new cvec2(lhs / rhs.x, lhs / rhs.y);
        
        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static cvec2 operator*(cvec2 lhs, cvec2 rhs) => new cvec2(lhs.x * rhs.x, lhs.y * rhs.y);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static cvec2 operator*(cvec2 lhs, Complex rhs) => new cvec2(lhs.x * rhs, lhs.y * rhs);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static cvec2 operator*(Complex lhs, cvec2 rhs) => new cvec2(lhs * rhs.x, lhs * rhs.y);
        
        /// <summary>
        /// Executes a component-wise unary + (add).
        /// </summary>
        public static cvec2 operator+(cvec2 v) => v;
        
        /// <summary>
        /// Executes a component-wise unary - (subtract).
        /// </summary>
        public static cvec2 operator-(cvec2 v) => new cvec2(-v.x, -v.y);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public cvec2 Normalized => this / Length;
        
        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public cvec2 NormalizedSafe => this == Zero ? Zero : this / Length;
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static Complex Dot(cvec2 lhs, cvec2 rhs) => lhs.x * rhs.x + lhs.y * rhs.y;
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(cvec2 lhs, cvec2 rhs) => (lhs - rhs).Length;
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static double DistanceSqr(cvec2 lhs, cvec2 rhs) => (lhs - rhs).LengthSqr;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static cvec2 Reflect(cvec2 I, cvec2 N) => I - 2 * Dot(N, I) * N;
        
        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static Complex Cross(cvec2 l, cvec2 r) => l.x * r.y - l.y * r.x;
        
        /// <summary>
        /// Returns a component-wise executed Abs.
        /// </summary>
        public static dvec2 Abs(cvec2 v) => new dvec2(v.x.Magnitude, v.y.Magnitude);
        
        /// <summary>
        /// Returns a component-wise executed Abs with a scalar.
        /// </summary>
        public static dvec2 Abs(Complex v) => new dvec2(v.Magnitude);
        
        /// <summary>
        /// Returns a component-wise executed HermiteInterpolationOrder3.
        /// </summary>
        public static cvec2 HermiteInterpolationOrder3(cvec2 v) => new cvec2((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y);
        
        /// <summary>
        /// Returns a component-wise executed HermiteInterpolationOrder3 with a scalar.
        /// </summary>
        public static cvec2 HermiteInterpolationOrder3(Complex v) => new cvec2((3 - 2 * v) * v * v);
        
        /// <summary>
        /// Returns a component-wise executed HermiteInterpolationOrder5.
        /// </summary>
        public static cvec2 HermiteInterpolationOrder5(cvec2 v) => new cvec2(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y);
        
        /// <summary>
        /// Returns a component-wise executed HermiteInterpolationOrder5 with a scalar.
        /// </summary>
        public static cvec2 HermiteInterpolationOrder5(Complex v) => new cvec2(((6 * v - 15) * v + 10) * v * v * v);
        
        /// <summary>
        /// Returns a component-wise executed complex Acos.
        /// </summary>
        public static cvec2 Acos(cvec2 v) => new cvec2(Complex.Acos(v.x), Complex.Acos(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Acos with a scalar.
        /// </summary>
        public static cvec2 Acos(Complex s) => new cvec2(Complex.Acos(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Asin.
        /// </summary>
        public static cvec2 Asin(cvec2 v) => new cvec2(Complex.Asin(v.x), Complex.Asin(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Asin with a scalar.
        /// </summary>
        public static cvec2 Asin(Complex s) => new cvec2(Complex.Asin(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Atan.
        /// </summary>
        public static cvec2 Atan(cvec2 v) => new cvec2(Complex.Atan(v.x), Complex.Atan(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Atan with a scalar.
        /// </summary>
        public static cvec2 Atan(Complex s) => new cvec2(Complex.Atan(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Cos.
        /// </summary>
        public static cvec2 Cos(cvec2 v) => new cvec2(Complex.Cos(v.x), Complex.Cos(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Cos with a scalar.
        /// </summary>
        public static cvec2 Cos(Complex s) => new cvec2(Complex.Cos(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Cosh.
        /// </summary>
        public static cvec2 Cosh(cvec2 v) => new cvec2(Complex.Cosh(v.x), Complex.Cosh(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Cosh with a scalar.
        /// </summary>
        public static cvec2 Cosh(Complex s) => new cvec2(Complex.Cosh(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Exp.
        /// </summary>
        public static cvec2 Exp(cvec2 v) => new cvec2(Complex.Exp(v.x), Complex.Exp(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Exp with a scalar.
        /// </summary>
        public static cvec2 Exp(Complex s) => new cvec2(Complex.Exp(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Log.
        /// </summary>
        public static cvec2 Log(cvec2 v) => new cvec2(Complex.Log(v.x), Complex.Log(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Log with a scalar.
        /// </summary>
        public static cvec2 Log(Complex s) => new cvec2(Complex.Log(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Log2.
        /// </summary>
        public static cvec2 Log2(cvec2 v) => new cvec2(Complex.Log(v.x, 2.0), Complex.Log(v.y, 2.0));
        
        /// <summary>
        /// Returns a component-wise executed complex Log2 with a scalar.
        /// </summary>
        public static cvec2 Log2(Complex s) => new cvec2(Complex.Log(s, 2.0));
        
        /// <summary>
        /// Returns a component-wise executed complex Log10.
        /// </summary>
        public static cvec2 Log10(cvec2 v) => new cvec2(Complex.Log10(v.x), Complex.Log10(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Log10 with a scalar.
        /// </summary>
        public static cvec2 Log10(Complex s) => new cvec2(Complex.Log10(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Reciprocal.
        /// </summary>
        public static cvec2 Reciprocal(cvec2 v) => new cvec2(Complex.Reciprocal(v.x), Complex.Reciprocal(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Reciprocal with a scalar.
        /// </summary>
        public static cvec2 Reciprocal(Complex s) => new cvec2(Complex.Reciprocal(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Sin.
        /// </summary>
        public static cvec2 Sin(cvec2 v) => new cvec2(Complex.Sin(v.x), Complex.Sin(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Sin with a scalar.
        /// </summary>
        public static cvec2 Sin(Complex s) => new cvec2(Complex.Sin(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Sinh.
        /// </summary>
        public static cvec2 Sinh(cvec2 v) => new cvec2(Complex.Sinh(v.x), Complex.Sinh(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Sinh with a scalar.
        /// </summary>
        public static cvec2 Sinh(Complex s) => new cvec2(Complex.Sinh(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Sqrt.
        /// </summary>
        public static cvec2 Sqrt(cvec2 v) => new cvec2(Complex.Sqrt(v.x), Complex.Sqrt(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Sqrt with a scalar.
        /// </summary>
        public static cvec2 Sqrt(Complex s) => new cvec2(Complex.Sqrt(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Tan.
        /// </summary>
        public static cvec2 Tan(cvec2 v) => new cvec2(Complex.Tan(v.x), Complex.Tan(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Tan with a scalar.
        /// </summary>
        public static cvec2 Tan(Complex s) => new cvec2(Complex.Tan(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Tanh.
        /// </summary>
        public static cvec2 Tanh(cvec2 v) => new cvec2(Complex.Tanh(v.x), Complex.Tanh(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Tanh with a scalar.
        /// </summary>
        public static cvec2 Tanh(Complex s) => new cvec2(Complex.Tanh(s));
        
        /// <summary>
        /// Returns a component-wise executed complex Conjugate.
        /// </summary>
        public static cvec2 Conjugate(cvec2 v) => new cvec2(Complex.Conjugate(v.x), Complex.Conjugate(v.y));
        
        /// <summary>
        /// Returns a component-wise executed complex Conjugate with a scalar.
        /// </summary>
        public static cvec2 Conjugate(Complex s) => new cvec2(Complex.Conjugate(s));
        
        /// <summary>
        /// Returns a component-wise executed Pow.
        /// </summary>
        public static cvec2 Pow(cvec2 lhs, cvec2 rhs) => new cvec2(Complex.Pow(lhs.x, rhs.x), Complex.Pow(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a component-wise executed Pow with a scalar.
        /// </summary>
        public static cvec2 Pow(cvec2 v, Complex s) => new cvec2(Complex.Pow(v.x, s), Complex.Pow(v.y, s));
        
        /// <summary>
        /// Returns a component-wise executed Pow with a scalar.
        /// </summary>
        public static cvec2 Pow(Complex s, cvec2 v) => new cvec2(Complex.Pow(s, v.x), Complex.Pow(s, v.y));
        
        /// <summary>
        /// Returns a component-wise executed Pow with a scalar.
        /// </summary>
        public static cvec2 Pow(double s, cvec2 v) => new cvec2(Complex.Pow(s, v.x), Complex.Pow(s, v.y));
        
        /// <summary>
        /// Returns a component-wise executed Pow with scalars.
        /// </summary>
        public static cvec2 Pow(Complex lhs, Complex rhs) => new cvec2(Complex.Pow(lhs, rhs));
        
        /// <summary>
        /// Returns a component-wise executed Pow.
        /// </summary>
        public static cvec2 Pow(cvec2 lhs, dvec2 rhs) => new cvec2(Complex.Pow(lhs.x, rhs.x), Complex.Pow(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a component-wise executed Pow with a scalar.
        /// </summary>
        public static cvec2 Pow(cvec2 v, double s) => new cvec2(Complex.Pow(v.x, s), Complex.Pow(v.y, s));
        
        /// <summary>
        /// Returns a component-wise executed Pow with scalars.
        /// </summary>
        public static cvec2 Pow(double lhs, double rhs) => new cvec2(Complex.Pow(lhs, rhs));
        
        /// <summary>
        /// Returns a component-wise executed Log.
        /// </summary>
        public static cvec2 Log(cvec2 lhs, dvec2 rhs) => new cvec2(Complex.Log(lhs.x, rhs.x), Complex.Log(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a component-wise executed Log with a scalar.
        /// </summary>
        public static cvec2 Log(cvec2 v, double s) => new cvec2(Complex.Log(v.x, s), Complex.Log(v.y, s));
        
        /// <summary>
        /// Returns a component-wise executed Log with scalars.
        /// </summary>
        public static cvec2 Log(double lhs, double rhs) => new cvec2(Complex.Log(lhs, rhs));
        
        /// <summary>
        /// Returns a component-wise executed FromPolarCoordinates.
        /// </summary>
        public static cvec2 FromPolarCoordinates(dvec2 lhs, dvec2 rhs) => new cvec2(Complex.FromPolarCoordinates(lhs.x, rhs.x), Complex.FromPolarCoordinates(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a component-wise executed FromPolarCoordinates with a scalar.
        /// </summary>
        public static cvec2 FromPolarCoordinates(double s, dvec2 v) => new cvec2(Complex.FromPolarCoordinates(s, v.x), Complex.FromPolarCoordinates(s, v.y));
        
        /// <summary>
        /// Returns a component-wise executed FromPolarCoordinates with a scalar.
        /// </summary>
        public static cvec2 FromPolarCoordinates(dvec2 v, double s) => new cvec2(Complex.FromPolarCoordinates(v.x, s), Complex.FromPolarCoordinates(v.y, s));
        
        /// <summary>
        /// Returns a component-wise executed Sqr.
        /// </summary>
        public static cvec2 Sqr(cvec2 v) => new cvec2(v.x * v.x, v.y * v.y);
        
        /// <summary>
        /// Returns a component-wise executed Sqr with a scalar.
        /// </summary>
        public static cvec2 Sqr(Complex v) => new cvec2(v * v);
        
        /// <summary>
        /// Returns a component-wise executed Pow2.
        /// </summary>
        public static cvec2 Pow2(cvec2 v) => new cvec2(v.x * v.x, v.y * v.y);
        
        /// <summary>
        /// Returns a component-wise executed Pow2 with a scalar.
        /// </summary>
        public static cvec2 Pow2(Complex v) => new cvec2(v * v);
        
        /// <summary>
        /// Returns a component-wise executed Mix.
        /// </summary>
        public static cvec2 Mix(cvec2 min, cvec2 max, cvec2 a) => new cvec2(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(Complex min, cvec2 max, cvec2 a) => new cvec2(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(cvec2 min, Complex max, cvec2 a) => new cvec2(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(cvec2 min, cvec2 max, Complex a) => new cvec2(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(Complex min, Complex max, cvec2 a) => new cvec2(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(cvec2 min, Complex max, Complex a) => new cvec2(min.x * (1-a) + max * a, min.y * (1-a) + max * a);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(Complex min, cvec2 max, Complex a) => new cvec2(min * (1-a) + max.x * a, min * (1-a) + max.y * a);
        
        /// <summary>
        /// Returns a component-wise executed Mix with scalars.
        /// </summary>
        public static cvec2 Mix(Complex min, Complex max, Complex a) => new cvec2(min * (1-a) + max * a);
    }
}