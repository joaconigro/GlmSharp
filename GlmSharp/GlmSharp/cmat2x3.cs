using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace GlmSharp
{
    [Serializable]
    public struct cmat2x3 : IReadOnlyList<Complex>, IEquatable<cmat2x3>
    {
        // Matrix fields mXY
        public Complex m00, m01, m02; // Column 0
        public Complex m10, m11, m12; // Column 1
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public Complex[,] Values => new[,] { { m00, m01, m02 }, { m10, m11, m12 } };
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public Complex[] Values1D => new[] { m00, m01, m02, m10, m11, m12 };
        
        /// <summary>
        /// Returns the column nr 0
        /// </summary>
        public cvec3 Column0 => new cvec3(m00, m01, m02);
        
        /// <summary>
        /// Returns the column nr 1
        /// </summary>
        public cvec3 Column1 => new cvec3(m10, m11, m12);
        
        /// <summary>
        /// Returns the row nr 0
        /// </summary>
        public cvec2 Row0 => new cvec2(m00, m10);
        
        /// <summary>
        /// Returns the row nr 1
        /// </summary>
        public cvec2 Row1 => new cvec2(m01, m11);
        
        /// <summary>
        /// Returns the row nr 2
        /// </summary>
        public cvec2 Row2 => new cvec2(m02, m12);
        
        /// <summary>
        /// Predefined all-zero matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly cmat2x3 Zero = new cmat2x3(default(Complex), default(Complex), default(Complex), default(Complex), default(Complex), default(Complex));
        
        /// <summary>
        /// Predefined all-ones matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly cmat2x3 Ones = new cmat2x3(1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
        
        /// <summary>
        /// Predefined identity matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly cmat2x3 Identity = new cmat2x3(1.0, default(Complex), default(Complex), default(Complex), 1.0, default(Complex));
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public cmat2x3(Complex m00, Complex m01, Complex m02, Complex m10, Complex m11, Complex m12)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
        }
        
        /// <summary>
        /// Copy constructor
        /// </summary>
        public cmat2x3(cmat2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }
        
        /// <summary>
        /// Column constructor
        /// </summary>
        public cmat2x3(cvec3 c0, cvec3 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all FieldCount.
        /// </summary>
        public IEnumerator<Complex> GetEnumerator()
        {
            yield return m00;
            yield return m01;
            yield return m02;
            yield return m10;
            yield return m11;
            yield return m12;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all FieldCount.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Returns the number of FieldCount (6).
        /// </summary>
        public int Count => 6;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public Complex this[int fieldIndex]
        {
            get
            {
                switch (fieldIndex)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m02;
                    case 3: return m10;
                    case 4: return m11;
                    case 5: return m12;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
            set
            {
                switch (fieldIndex)
                {
                    case 0: this.m00 = value; break;
                    case 1: this.m01 = value; break;
                    case 2: this.m02 = value; break;
                    case 3: this.m10 = value; break;
                    case 4: this.m11 = value; break;
                    case 5: this.m12 = value; break;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public Complex this[int col, int row]
        {
            get
            {
                return this[col * 3 + row];
            }
            set
            {
                this[col * 3 + row] = value;
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(cmat2x3 rhs) => m00.Equals(rhs.m00) && m01.Equals(rhs.m01) && m02.Equals(rhs.m02) && m10.Equals(rhs.m10) && m11.Equals(rhs.m11) && m12.Equals(rhs.m12);
        
        /// <summary>
        /// Returns true iff this equals rhs type- and component-wise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is cmat2x3 && Equals((cmat2x3) obj);
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(cmat2x3 lhs, cmat2x3 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(cmat2x3 lhs, cmat2x3 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public cmat3x2 Transposed => new cmat3x2(m00, m10, m01, m11, m02, m12);
        
        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public double Length => (double)Math.Sqrt(m00.LengthSqr() + m01.LengthSqr() + m02.LengthSqr() + m10.LengthSqr() + m11.LengthSqr() + m12.LengthSqr());
        
        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public double LengthSqr => m00.LengthSqr() + m01.LengthSqr() + m02.LengthSqr() + m10.LengthSqr() + m11.LengthSqr() + m12.LengthSqr();
        
        /// <summary>
        /// Returns the sum of all FieldCount.
        /// </summary>
        public Complex Sum => m00 + m01 + m02 + m10 + m11 + m12;
        
        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public double Norm => (double)Math.Sqrt(m00.LengthSqr() + m01.LengthSqr() + m02.LengthSqr() + m10.LengthSqr() + m11.LengthSqr() + m12.LengthSqr());
        
        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public double Norm1 => m00.Magnitude + m01.Magnitude + m02.Magnitude + m10.Magnitude + m11.Magnitude + m12.Magnitude;
        
        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public double Norm2 => (double)Math.Sqrt(m00.LengthSqr() + m01.LengthSqr() + m02.LengthSqr() + m10.LengthSqr() + m11.LengthSqr() + m12.LengthSqr());
        
        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public Complex NormMax => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(m00.Magnitude, m01.Magnitude), m02.Magnitude), m10.Magnitude), m11.Magnitude), m12.Magnitude);
        
        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => Math.Pow(Math.Pow((double)m00.Magnitude, p) + Math.Pow((double)m01.Magnitude, p) + Math.Pow((double)m02.Magnitude, p) + Math.Pow((double)m10.Magnitude, p) + Math.Pow((double)m11.Magnitude, p) + Math.Pow((double)m12.Magnitude, p), 1 / p);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication cmat2x3 * cmat2 -> cmat2x3.
        /// </summary>
        public static cmat2x3 operator*(cmat2x3 lhs, cmat2 rhs) => new cmat2x3(lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01, lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11, lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01, lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11, lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01, lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication cmat2x3 * cmat3x2 -> cmat3.
        /// </summary>
        public static cmat3 operator*(cmat2x3 lhs, cmat3x2 rhs) => new cmat3(lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01, lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11, lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21, lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01, lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11, lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21, lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01, lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11, lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication cmat2x3 * cmat4x2 -> cmat4x3.
        /// </summary>
        public static cmat4x3 operator*(cmat2x3 lhs, cmat4x2 rhs) => new cmat4x3(lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01, lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11, lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21, lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31, lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01, lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11, lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21, lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31, lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01, lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11, lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21, lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static cmat2x3 operator+(cmat2x3 lhs, cmat2x3 rhs) => new cmat2x3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static cmat2x3 operator+(cmat2x3 lhs, Complex rhs) => new cmat2x3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static cmat2x3 operator+(Complex lhs, cmat2x3 rhs) => new cmat2x3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static cmat2x3 operator-(cmat2x3 lhs, cmat2x3 rhs) => new cmat2x3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static cmat2x3 operator-(cmat2x3 lhs, Complex rhs) => new cmat2x3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static cmat2x3 operator-(Complex lhs, cmat2x3 rhs) => new cmat2x3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12);
    }
}