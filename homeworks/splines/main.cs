using System;
using System.IO;

public class main{
	public static void Main(){
		double[] xs = {0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7};
		double[] ys = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){ys[i] = Math.Cos(xs[i]);}
		double[] zs = {0.2, 0.6, 1.1, 1.8, 2.2, 2.6, 2.9, 3.3, 3.6, 4.6, 5.2, 5.6, 6.1, 6.4, 6.9};
		var output = new StreamWriter("data.txt");
		for(int i=0; i<zs.Length; i++){
			double liny = interp.linterp(xs, ys, zs[i]);
			double lininty = interp.linterpInteg(xs, ys, zs[i]);
			output.WriteLine($"{xs[i]} {ys[i]} {zs[i]} {liny} {lininty}");

		}
		output.Close();
		Console.WriteLine($"A plot of cos(x) with values from table as well as the interpolated values can be seen on Lspline.svg");
	}	
}

