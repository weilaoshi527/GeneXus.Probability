using System;
using System.Collections.Generic;

namespace ProbabTest
{
	/// <summary>
	/// Description of BaseVerification.
	/// </summary>
	public class BaseVerification
	{
		protected List<LabData> batches;
		protected double checkedValue;	//待校验的值
		
		public BaseVerification(double beta)
		{
			batches=new List<LabData>();
			checkedValue=beta;
		}
		public BaseVerification()
		{
			batches=new List<LabData>();
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
		public void Add(LabData data)
		{
			batches.Add(data);
		}
	}
}
