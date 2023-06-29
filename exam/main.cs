using System;
using System.IO;

public class main{
	public static void Main(){
		// We test with u'' = -u -- see ODE homework
		Func<double, vector, vector> f = (x, y) => {
		vector newy = new vector(2);
		newy[0] = y[1];
		newy[1] = -y[0];
		return newy; 
		};
		//Either sin or cos. We give start values so it ends up as sin
		vector yi = new vector(0,1);
		(var xs, var ys) = ODE2.driver(f, 0, yi, 2*Math.PI);
		var output = new StreamWriter("val.txt", false);
		for(int i=0; i<xs.size; i++){
			output.WriteLine($"{xs[i]}, {ys[i][0]}, {ys[i][1]}");
		}
		output.Close();

		// Another test: u'' = u	
		Func<double, vector, vector> g = (x, y) => {
		vector newy = new vector(2);
		newy[0] = y[1];
		newy[1] = y[0];
		return newy; 
		};
		//Either e^x or e^-x. We give start values so it ends up as e^x
		vector yi1 = new vector(0,1);
		(var xs1, var ys1) = ODE2.driver(g, 0, yi1, 3);
		var output1 = new StreamWriter("val1.txt", false);
		for(int i=0; i<xs1.size; i++){
			output1.WriteLine($"{xs1[i]}, {ys1[i][0]}, {ys1[i][1]}");
		}
		output1.Close();

		Console.WriteLine($"We test the implementation using the 2-step method.");
		Console.WriteLine($"We test it on the differential equations:");
		Console.WriteLine($"u'' = u and u'' = -u");
		Console.WriteLine($"These can be seen in the files Exp.svg and Sin.svg respectively");
	}
}
