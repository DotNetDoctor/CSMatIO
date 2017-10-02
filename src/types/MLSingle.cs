namespace DotNetDoctor.csmatio.types
{
    using System;

    using DotNetDoctor.csmatio.common;

    /// <summary>
	/// This class represents an single-precision (32-bit) floating-point array (matrix)
	/// </summary>
	/// <author>David Zier (david.zier@gmail.com)</author>
	public class MLSingle : MLNumericArray<float>
	{
		#region Constructors

		/// <summary>
		/// Normally this constructor is used only by <c>MatFileReader</c> and <c>MatFileWriter</c>
		/// </summary>
		/// <param name="Name">Array name</param>
		/// <param name="Dims">Array dimensions</param>
		/// <param name="Type">Array type: here <c>mxSINGLE_CLASS</c></param>
		/// <param name="Attributes">Array flags</param>
		public MLSingle(string Name, int[] Dims, int Type, int Attributes)
			: base(Name, Dims, Type, Attributes) { }

		/// <summary>
		/// Create a <c>MLSingle</c> array with given name and dimensions.
		/// </summary>
		/// <param name="Name">Array name</param>
		/// <param name="Dims">Array dimensions</param>
		public MLSingle(string Name, int[] Dims)
			: base(Name, Dims, MLArray.mxSINGLE_CLASS, 0) { }

		/// <summary>
		/// <a href="http://math.nist.gov/javanumerics/jama/">Jama</a> [math.nist.gov] style:
		/// construct a 2D real matrix from a one-dimensional packed array.
		/// </summary>
		/// <param name="Name">Array name</param>
		/// <param name="vals">One-dimensional array of floats, packed by columns</param>
		/// <param name="m">Number of rows</param>
		public MLSingle(string Name, float[] vals, int m)
			: base(Name, MLArray.mxSINGLE_CLASS, vals, m) { }

		/// <summary>
		/// <a href="http://math.nist.gov/javanumerics/jama/">Jama</a> [math.nist.gov] style:
		/// construct a 2D real matrix from <c>byte[][]</c>.
		/// </summary>
		/// <remarks>Note: Array is converted to <c>byte[]</c></remarks>
		/// <param name="Name">Array name</param>
		/// <param name="vals">Two-dimensional array of values</param>
		public MLSingle(string Name, float[][] vals)
			: this(Name, Helpers.Array2DTo1D<float>(vals), vals.Length) { }

		/// <summary>
		/// <a href="http://math.nist.gov/javanumerics/jama/">Jama</a> [math.nist.gov] style:
		/// construct a 2D imaginary matrix from a one-dimensional packed array.
		/// </summary>
		/// <param name="Name">Array name</param>
		/// <param name="Real">One-dimensional array of float for <i>real</i> values, packed by columns</param>
		/// <param name="Imag">One-dimensional array of float for <i>imaginary</i> values, packed by columns</param>
		/// <param name="M">Number of rows</param>
		public MLSingle(string Name, float[] Real, float[] Imag, int M)
			: base(Name, MLArray.mxSINGLE_CLASS, Real, Imag, M) { }


		/// <summary>
		/// <a href="http://math.nist.gov/javanumerics/jama/">Jama</a> [math.nist.gov] style:
		/// construct a 2D imaginary matrix from a one-dimensional packed array.
		/// </summary>
		/// <param name="Name">Array name</param>
		/// <param name="Real">array of arrays of float for <i>real</i> values</param>
		/// <param name="Imag">array of arrays of float for <i>imaginary</i> values</param>
		public MLSingle(string Name, float[][] Real, float[][] Imag)
			: this(Name, Helpers.Array2DTo1D<float>(Real), Helpers.Array2DTo1D<float>(Imag), Real.Length) { }

		#endregion

		/// <summary>
		/// Builds a numeric object from a byte array.
		/// </summary>
		/// <param name="bytes">A byte array containing the data.</param>
		/// <returns>A numeric object</returns>
		protected override object BuildFromBytes2(byte[] bytes)
		{
			return BitConverter.ToSingle(bytes, 0);
		}

		/// <summary>
		/// Gets a byte array from a numeric object.
		/// </summary>
		/// <param name="val">The numeric object to convert into a byte array.</param>
		public override byte[] GetByteArray(object val)
		{
			return BitConverter.GetBytes((float)val);
		}
	}
}
