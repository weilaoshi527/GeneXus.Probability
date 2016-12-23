using System;
using System.Collections.Generic;

namespace ProbabTest
{
	/// <summary>
	/// 批次数据
	/// </summary>
	public class BatchData
	{
		List<double> data;
		/// <summary>
		/// 测量次数
		/// </summary>
		public int Count
		{
			get
			{
				return data.Count;
			}
		}
		/// <summary>
		/// 总和
		/// </summary>
		public double Sum
		{
			get
			{
				double sum=0;
				foreach(double d in data)
					sum+=d;
				return sum;
			}
		}
		/// <summary>
		/// 均值
		/// </summary>
		public double Average
		{
			get 
			{
				return Sum/data.Count;
			}
		}
		/// <summary>
		/// 离差平方和
		/// </summary>
		public double SumOfSquares
		{
			get 
			{
				double ave=Average;
				double sum=0;
				foreach(double d in data)
				{
					sum+=(d-ave)*(d-ave);
				}
				return sum;
			}
		}
		public double this[int i]
		{
			get
			{
				return data[i];
			}
		}
		/// <summary>
		/// 标准方差
		/// </summary>
		public double StandardDeviation
		{
			get
			{
				return Math.Sqrt(SumOfSquares/data.Count);
			}
		}
		/// <summary>
		/// 批内方差
		/// </summary>
		public double  IntraGroupVariance
		{
		 	get
		 	{
				return SumOfSquares/(data.Count-1);
		 	}
		}
		public BatchData()
		{
			data=new List<double>();
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dataStr">用，或空格分隔的测量数据文本</param>
		public BatchData(string dataStr)
		{
			data=new List<double>();
			string[] d=dataStr.Split(new char[]{' ',','},StringSplitOptions.RemoveEmptyEntries);
			foreach(string i in d)
				data.Add(double.Parse(i));
		}
		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="d"></param>
		public void Add(double d)
		{
			data.Add(d);
		}
		/// <summary>
		/// 添加批次数据
		/// </summary>
		/// <param name="d"></param>
		public void Add(double[] d)
		{
			data.AddRange(d);
		}
	}
}
