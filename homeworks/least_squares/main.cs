using System;
using System.IO;
using System.Collections.Generic;

public static class main{
	public static void Main(){
		var fs = new Func<double,double>[] {z => 1.0, z => -z};	

		//Reading files -- from https://stackoverflow.com/questions/52636738/how-to-get-data-from-a-text-file-in-c-sharp
		string[] rawLines = File.ReadAllLines("data.txt");
		int n = rawLines.Length;
		vector xs = new vector(n);
		vector ys = new vector(n);
		vector dy = new vector(n);
		int i=0;
		foreach(var line in rawLines) {
		 	var data = line.Split(' ');
    			xs[i] = Convert.ToInt32(data[0]);
    			var y = Convert.ToDouble(data[1]);
			ys[i] = Math.Log(y);
    			dy[i] = Convert.ToDouble(data[2])/y;
			i++;
		}
		(vector c, matrix S) = lsf.lsfit(fs, xs, ys, dy);

		Console.WriteLine($"The fitted data can be seen in Fit.svg.");
	
		var output = new StreamWriter("fit.txt", false);
		double a = Math.Exp(c[0]);
		double lambda = c[1];
		for(double x=0+1/64; x<=15; x+=1.0/64){
			double y = a*Math.Exp(-lambda*x);
			output.WriteLine($"{x}, {y}");
		}
		output.Close();

		Console.WriteLine($"The fitted T_1/2 is {Math.Log(2)/lambda}");
		// Value from wikipedia
		Console.WriteLine($"The known T_1/2 of Ra-224 is 3.63 d. The fitted value is not close");
		S.print("hjg");
		Console.WriteLine($"The uncertainty on the fitted value is {Math.Sqrt(S[1,1]*S[1,1])} so todays value does not lie within the uncertainties.");



		
}
}

