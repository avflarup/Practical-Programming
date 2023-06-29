using System;
using System.IO;

public class main{
	public static void Main(){
		Func<vector,double> f = v => {
			if(v[0]*v[0]+v[1]*v[1] <= 1) return 1;
			else return 0;
		};
		vector a = new vector(-1, -1);
		vector b = new vector(1, 1);

		//estimating area of circle
		var N = 100000;
		(var A, var err) = mc.plainmc(f, a, b, N);
		Console.WriteLine($"Area of circle is {A}+- {err}");

		//plotting purposes
		var output = new StreamWriter("err.txt");
		int stop = 10000;
		for(int i=0; i<stop; i+=100) {
			(var area, var pred_err) = mc.plainmc(f, a, b, i);
			double act_err = Math.Abs(Math.PI-area);
			output.WriteLine($"{i}, {pred_err}, {act_err}");
		}
		Console.WriteLine($"Plot of error can be seen on Err.svg");
		vector c = new vector(0, 0, 0);
		vector d = new vector(Math.PI, Math.PI, Math.PI);
		int n = 1000000;
		Func<vector, double> g = v => Math.Pow(Math.PI, -3)*Math.Pow(1-Math.Cos(v[0])*Math.Cos(v[1])*Math.Cos(v[2]),-1);
		(var res, var er) = mc.plainmc(g, c, d, n);
		Console.WriteLine($"The integral estimated to be {res} +- {er}. Should be 1.3932. Is within the uncertainty");
	}
}
