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


	}
}
