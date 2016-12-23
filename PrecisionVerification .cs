using System;

namespace ProbabTest
{
	/// <summary>
	/// Description of PrecisionVerification.
	/// </summary>
	public class PrecisionVerification:BaseVerification
	{	
		double C;
		bool probability;
		public void Set_C(double p)
		{
			C=Probability.re_chi2(BatchCount-1,p);
			probability=true;
		}
		public PrecisionVerification(double beta):base(beta)
		{
			probability=false;
		}
		/// <summary>
		/// 重复标准差
		/// </summary>
		public double RepeatedStandardDeviation
		{
			get
			{
				double sum=0;
				foreach(BatchData d in batches)
				{
					sum+=d.IntraGroupVariance;
				}
				return sum/this.BatchCount;
			}
		}
		/// <summary>
		/// 总均值
		/// </summary>
		public double GroupAverage
		{
			get
			{
				double sum=0;
				foreach(BatchData d in batches)
					sum+=d.Average;
				return sum/BatchCount;
			}
		}
		/// <summary>
		/// 批间方差
		/// </summary>
		public double BetweenGroupVariance
		{
			get
			{
				double sum=0;
				foreach(BatchData d in batches)
				{
					double ave=d.Average-GroupAverage;
					sum+=ave*ave;
				}
				return sum/(BatchCount-1);
			}
		}
		/// <summary>
		/// 最终结果：期间标准差
		/// </summary>
		public double GroupStandardDeviation
		{
			get
			{
				double sum=0;
				sum+=(MeasuringTimes-1)*RepeatedStandardDeviation/MeasuringTimes;
				sum+=BetweenGroupVariance;
				return Math.Sqrt(sum);
			}
		}
		/// <summary>
		/// 自由度，对应需求文档中公式9 原文有误!
		/// </summary>
		public double Freedom
		{
			get
			{
				double T=(MeasuringTimes-1)*RepeatedStandardDeviation+MeasuringTimes* BetweenGroupVariance;
				T=T*T;
				double k=(MeasuringTimes-1)*RepeatedStandardDeviation*RepeatedStandardDeviation/BatchCount;
				k+=MeasuringTimes*MeasuringTimes*BetweenGroupVariance*BetweenGroupVariance/(BatchCount-1);
				T=T/k;
				return T;
			}
		}
		public double PrecisionValue
		{
			get
			{	
				double T=Freedom;
				if(!probability)
					C=Probability.re_chi2(BatchCount-1,0.975);
				return checkedValue *Math.Sqrt(C)/Math.Sqrt(T);
			}
		}
	}
	
	
}
