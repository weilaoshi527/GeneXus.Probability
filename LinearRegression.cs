using System;

namespace ProbabTest
{
	/// <summary>
	/// Description of LinearRegression.
	/// </summary>
	public class LinearRegression:BaseVerification
	{
		public LinearRegression():base()
		{
		}
		/// <summary>
		/// 线性数据X
		/// </summary>
		public BatchData X
		{
			get
			{
				BatchData x=new BatchData();
				for(int i=0;i<MeasuringTimes;i++)
					x.Add(i+1);
				return x;
			}
		}
		/// <summary>
		/// 线性数据Y
		/// </summary>
		public BatchData Y
		{
			get	
			{				
				BatchData y=new BatchData();
				for(int i=0;i<MeasuringTimes;i++)
				{
					double average=0;
					for(int j=0;j<BatchCount;j++)
						average +=batches[j][i];
					average=average/BatchCount;
					y.Add(average);
				}
				return y;
			}
		}
		/// <summary>
		/// 相关系数,为什么和文档中算的结果不一样呢？
		/// </summary>
		public double Relation
		{
			get
			{
				BatchData x=X;
				BatchData y=Y;
				
				double sum1=0;				
				double x_ave=x.Average;
				double y_ave=y.Average;
				
				for(int i=0;i<MeasuringTimes;i++)
				{
					sum1+=(x[i]-x_ave)*(y[i]-x_ave);					
				}
				return sum1/(x.StandardDeviation*y.StandardDeviation)/MeasuringTimes;				
			}
		}
		/// <summary>
		/// 斜率
		/// </summary>
		public double Slope
		{
			get
			{
				double sum1=0;
				double sum2=0;				
				BatchData x=X;
				BatchData y=Y;
				for(int i=0;i<MeasuringTimes;i++)
				{
					sum1+=(x[i]-x.Average)*(y[i]-y.Average);
					sum2+=(x[i]-x.Average)*(x[i]-x.Average);					
				}
				return sum1/sum2;
			}
		}
		/// <summary>
		/// 截距
		/// </summary>
		public double Origin
		{
			get
			{
				BatchData x=X;
				BatchData y=Y;
				return y.Average-Slope*x.Average;
			}
		}
	}
}
