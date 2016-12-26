using System;

namespace ProbabTest
{
	/// <summary>
	/// 用参考物质进行正确度验证的实验
	/// </summary>
	public class AccuracyFromRefMaterial:BaseVerification
	{
		/// <summary>
		/// 参考物质赋值 单位mg/dL,默认值40
		/// </summary>
		public double XfromRef;		
		/// <summary>
		/// 室间质评结果标准差，默认值1.73,
		/// </summary>
		public double Sprogram;		
		/// <summary>
		/// 参加室间质评的实验室数量，默认值135
		/// </summary>
		public int LabsCount;		
		/// <summary>
		/// 假排除率，默认值0.01
		/// </summary>
		public double FalseRejectionRate;	
		
		double t;				//t分布值
		
		public AccuracyFromRefMaterial():base()
		{
			XfromRef=40;
			Sprogram=1.73;
			LabsCount=135;
			FalseRejectionRate=0.01;
			t=-1.0;
		}
		/// <summary>
		/// 总均值
		/// </summary>
		public double Average
		{
			get
			{
				double sum=0;
				foreach(LabData data in batches)
					for(int i=0;i<data.Count;i++)
						sum+=data[i];
				sum=sum/(BatchCount*MeasuringTimes);
				return sum;
			}
		}
		/// <summary>
		/// 参考物质测量偏移值
		/// </summary>
		public double Deviant
		{
			get
			{
				return Average-XfromRef;
			}
		}
		/// <summary>
		/// 标准差
		/// </summary>
		public double StandardDeviation
		{
			get
			{
				double sum=0;
				double ave=Average;
				foreach(LabData data in batches)
					for(int i=0;i<data.Count;i++)
						sum+=(data[i]-ave)*(data[i]-ave);
				return Math.Sqrt(sum/(MeasuringTimes*BatchCount-1));
			}
		}
		/// <summary>
		/// 参考物质测量标准不确定度
		/// </summary>
		public double Uncertainty
		{
			get
			{
				return Sprogram/Math.Sqrt(LabsCount);
			}
		}
		/// <summary>
		/// 自由度，对应公式24,原文有误!
		/// </summary>
		public int Freedom
		{
			get
			{
				return MeasuringTimes*BatchCount -1;
			}
		}
		/// <summary>
		/// 验证区间的下限
		/// </summary>
		public double MinOfInterval
		{
			get
			{
				if(t<0)
					t= Probability.re_t(Freedom,1-FalseRejectionRate);
				return Average-t*Math.Sqrt(StandardDeviation*StandardDeviation +Uncertainty *Uncertainty);
			}
		}
		/// <summary>
		/// 验证区间的上限
		/// </summary>
		public double MaxOfInterval
		{
			get
			{
				if(t<0)
					t= Probability.re_t(Freedom,1-FalseRejectionRate);
				return Average+t*Math.Sqrt(StandardDeviation*StandardDeviation +Uncertainty *Uncertainty);
			}
		}
	}
}
