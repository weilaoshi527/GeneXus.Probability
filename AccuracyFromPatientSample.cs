using System;

namespace ProbabTest
{
	/// <summary>
	/// Description of AccuracyVerification.
	/// </summary>
	public class AccuracyFromPatientSample:BaseVerification
	{
		double t;		
		
		public AccuracyFromPatientSample(double deta):base(deta)
		{
			checkedValue=deta;
			t=-1.0;
		}
		
		public void Set_t(double p)
		{
			t=Probability.re_t(MeasuringTimes-1,p);			
		}
		public LabData Ri
		{
		 	get
		 	{
		 		return batches[0];
		 	}
		}
		public LabData Rc
		{
		 	get
		 	{
		 		return batches[1];
		 	}
		}
		/// <summary>
		/// 绝对偏移
		/// </summary>
		public double AbsoluteOffset
		{
			get
			{
				double sum=0;
				for(int i=0;i<MeasuringTimes;i++)
					sum+=(Ri[i]-Rc[i]);
				return sum/MeasuringTimes;
			}
		}
		/// <summary>
		/// 绝对偏移的标准差
		/// </summary>
		public double StandardDeviation
		{
			get
			{
				double sum=0;
				double a=AbsoluteOffset;
				for(int i=0;i<MeasuringTimes;i++)
				{
					double b=Ri[i]-Rc[i]-a;
					sum+=b*b;
				}
				return Math.Sqrt(sum/(MeasuringTimes-1));
			}
		}
		/// <summary>
		/// 验证区间下限
		/// </summary>
		public double MinOfInterval
		{
			get
			{
				if(t<0)
					t=Probability.re_t(MeasuringTimes-1,0.99);	
				return checkedValue-t*StandardDeviation/Math.Sqrt(MeasuringTimes);
			}
		}
		/// <summary>
		/// 验证区间上限
		/// </summary>
		public double MaxOfInterval
		{
			get
			{
				if(t<0)
					t=Probability.re_t(MeasuringTimes-1,0.99);	
				return checkedValue+t*StandardDeviation/Math.Sqrt(MeasuringTimes);
			}
		}
	}
}
