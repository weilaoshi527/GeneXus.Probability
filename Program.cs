using System;

namespace ProbabTest
{
	class Program
	{
		public static void Main(string[] args)
		{			
			PrecisionVerification precision=new PrecisionVerification(2.0);
			
			precision.Add(new LabData("140,140,140"));
			precision.Add(new LabData("138,139,138"));
			precision.Add(new LabData("143,144,144"));
			precision.Add(new LabData("143,143,142"));
			precision.Add(new LabData("142,143,141"));
			
			//Console.WriteLine(precision.GroupStandardDeviation);
			Console.WriteLine(string.Format("The checked value is {0}",precision.PrecisionValue.ToString(".###")));
			
			AccuracyFromPatientSample accuracy=new AccuracyFromPatientSample(2.0);
			accuracy.Add(new LabData("76 127 256 303 29 345 42 154 398 93 240 72 312 99 375 168 59 183 213 436"));
			accuracy.Add(new LabData("77 121 262 294 25 348 41 154 388 92 239 69 308 101 375 162 54 185 204 431"));		
			
			Console.WriteLine(string.Format("The interval is [{0} {1}]",accuracy.MinOfInterval.ToString(".###"),accuracy.MaxOfInterval.ToString(".###")));
			
			
			AccuracyFromRefMaterial accuracy2=new AccuracyFromRefMaterial();
			accuracy2.Add(new LabData("37 38"));
			accuracy2.Add(new LabData("39 37"));
			accuracy2.Add(new LabData("38 36"));
			accuracy2.Add(new LabData("39 38"));
			accuracy2.Add(new LabData("38 37"));
			Console.WriteLine(string.Format("The interval is [{0} {1}]",accuracy2.MinOfInterval.ToString(".###"),accuracy2.MaxOfInterval.ToString(".###")));
			
			
			LinearRegression linear=new LinearRegression();
			linear.Add(new LabData("4.7 7.8 10.4 13.0 15.5"));
			linear.Add(new LabData("4.6 7.6 10.2 13.1 15.3"));
			Console.WriteLine(string.Format("y={0}x+{1} and R*R is {2}.",linear.Slope,linear.Origin,(linear.Relation*linear.Relation).ToString(".###")));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}