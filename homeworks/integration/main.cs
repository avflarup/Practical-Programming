using System;
using System.IO;

public static class main{
	public static void Main(){
		Func<double, double> f = x => Math.Sqrt(x);
		double sum = integration.integrate(f, 0, 1);
		Console.WriteLine($"Integral of sqrt(x) = {sum}. Should be 2/3. Is close");
		f = (double x) => 1/Math.Sqrt(x);
		sum = integration.integrate(f, 0, 1);
		Console.WriteLine($"Integral of 1/sqrt(x) = {sum}. Should be 2. Is close");
		f = (double x) => 4*Math.Sqrt(1-x*x);
		sum = integration.integrate(f, 0, 1);
		Console.WriteLine($"Integral of 4 sqrt(1-x^2) = {sum}. Should be Pi. Is close");
		f = (double x) => Math.Log(x)/Math.Sqrt(x);
		sum = integration.integrate(f, 0, 1);
		Console.WriteLine($"Integral of ln(x)/sqrt(x) = {sum}. Should be -4. Is close");

		Func<double, double> erf = null;
		erf = z => {
			if(z<0.0) return -erf(-z);
			if(z>1.0){
				Func<double, double> h = (double t) => Math.Exp(-Math.Pow(z+(1-t)/t, 2))/t/t;
				return 1-(2/Math.Sqrt(Math.PI)*integration.integrate(h, 0, 1));
			}
			Func<double, double> h1 = (double x) => Math.Exp(-x*x);
			return 2/Math.Sqrt(Math.PI)*integration.integrate(h1, 0, z);
		};
		var output = new StreamWriter("val.txt");
		for(double x=-3; x<=3; x+=1.0/64) {
			output.WriteLine($"{x}, {erf(x)}");
		}
		output.Close();
		




	}


}
