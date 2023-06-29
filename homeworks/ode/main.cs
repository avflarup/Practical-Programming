using System;
using System.IO;

public class main{
	public static void Main(){
		// Solving u'' = -u
		// Can be rewritten y1 = u, y2 = u'
		// => y1' = y2, y2 = -y1
		Func<double, vector, vector> f = (x, y) => {
		vector newy = new vector(2);
		newy[0] = y[1];
		newy[1] = -y[0];
		return newy; 
		};
		//Should give us sin(x)
		vector yi = new vector(0,1);
		(var xs, var ys) = ODE.driver(f, 0, yi, 2*Math.PI);
		var output = new StreamWriter("val.txt", false);
		for(int i=0; i<xs.size; i++){
			output.WriteLine($"{xs[i]}, {ys[i][0]}, {ys[i][1]}");
		}
		output.Close();
		Console.WriteLine($"A graph of u'' = -u with u(0)=0, u'(0)=1 csn be seen on Sin.svg");
		
		//Same constants as in example
		Func<double, vector, vector> g = (x, y) => {
		vector newy = new vector(2);
		newy[0] = y[1];
		newy[1] = -0.25*y[1]-5.0*Math.Sin(y[0]);
		return newy;
		};

		vector y0 = new vector(0.1, 0);
		(var xs1, var ys1) = ODE.driver(g, 0, y0, 10);
		var output2 = new StreamWriter("harm.txt",false);
		for(int i=0; i<xs1.size; i++){
			output2.WriteLine($"{xs1[i]}, {ys1[i][0]}, {ys1[i][1]}");
		}
		output2.Close();


	}	
}
