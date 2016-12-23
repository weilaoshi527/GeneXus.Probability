/*
 * Created by SharpDevelop.
 * User: abcde
 * Date: 2016/12/22
 * Time: 14:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProbabTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Console.WriteLine(Probability.re_t(1,0.975).ToString());
			
			// TODO: Implement Functionality Here
			PrecisionVerification precision=new PrecisionVerification(2.0);
			
			precision.Add(new BatchData("140,140,140"));
			precision.Add(new BatchData("138,139,138"));
			precision.Add(new BatchData("143,144,144"));
			precision.Add(new BatchData("143,143,142"));
			precision.Add(new BatchData("142,143,141"));
			
			Console.WriteLine(precision.GroupStandardDeviation);
			Console.WriteLine(precision.PrecisionValue);
			
			AccuracyFromPatientSample accuracy=new AccuracyFromPatientSample(2.0);
			accuracy.Add(new BatchData("76 127 256 303 29 345 42 154 398 93 240 72 312 99 375 168 59 183 213 436"));
			accuracy.Add(new BatchData("77 121 262 294 25 348 41 154 388 92 239 69 308 101 375 162 54 185 204 431"));		
			
			Console.WriteLine(accuracy.MinOfInterval);
			Console.WriteLine(accuracy.MaxOfInterval);
			
			AccuracyFromRefMaterial accuracy2=new AccuracyFromRefMaterial();
			accuracy2.Add(new BatchData("37 38"));
			accuracy2.Add(new BatchData("39 37"));
			accuracy2.Add(new BatchData("38 36"));
			accuracy2.Add(new BatchData("39 38"));
			accuracy2.Add(new BatchData("38 37"));
			Console.WriteLine(accuracy2.MinOfInterval);
			Console.WriteLine(accuracy2.MaxOfInterval);
			
			LinearRegression linear=new LinearRegression();
			linear.Add(new BatchData("4.7 7.8 10.4 13.0 15.5"));
			linear.Add(new BatchData("4.6 7.6 10.2 13.1 15.3"));
			Console.WriteLine(linear.Slope);
			Console.WriteLine(linear.Origin);
			Console.WriteLine(linear.Relation*linear.Relation);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}