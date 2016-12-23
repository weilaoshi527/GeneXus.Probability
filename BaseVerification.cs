using System;
using System.Collections.Generic;

namespace ProbabTest
{
	/// <summary>
	/// Description of BaseVerification.
	/// </summary>
	public class BaseVerification
	{
		protected List<BatchData> batches;
		protected double checkedValue;
		
		public BaseVerification(double beta)
		{
			batches=new List<BatchData>();
			checkedValue=beta;
		}
		public BaseVerification()
		{
			batches=new List<BatchData>();
		}
		/// <summary>
		/// 批次总数
		/// </summary>
		public int BatchCount
		{
			get 
			{
				return batches.Count;
			}
		}
		/// <summary>
		/// 测量次数
		/// </summary>
		public int MeasuringTimes
		{
			get 
			{
				if(batches.Count>0)
					return batches[0].Count;
				return 0;
			}
		}		
		/// <summary>
		/// 添加测量数据
		/// </summary>
		/// <param name="data">测量数据</param>
		public void Add(BatchData data)
		{
			batches.Add(data);
		}
	}
}
