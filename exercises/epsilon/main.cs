using System;


class epsilon{
	static void Main(){
	Console.WriteLine($"Part 1:");
	max_int();
	min_int();
	Console.WriteLine($"Part 2:");
	machine_eps();
	Console.WriteLine($"Part 3:");
	tiny();
	Console.WriteLine($"Part 4:");
	Console.WriteLine($"Does 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1 == 8*0.1 now? => {approx(0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1, 8*0.1)}");

	
	}
	public static void max_int(){
		int i=1; 
		while(i+1>i) {i++;}
		Console.Write("my max int = {0}\n",i);
		Console.Write($"max int = {int.MaxValue}\n");
	}
	public static void min_int(){
		int i=1; 
		while(i-1<i) {i--;}
		Console.Write("my min int = {0}\n",i);
		Console.Write($"min int = {int.MinValue}\n");
	}
	public static void machine_eps(){
		double x=1; 
		while(1+x!=1) {x/=2;} x*=2;
		Console.WriteLine($"Double machine epsilon = {x}");
		Console.WriteLine($"Should be {Math.Pow(2, -52)}");
		
		float y=1F; 
		while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Console.WriteLine($"Float machine epsilon = {y}");
		Console.WriteLine($"Should be {Math.Pow(2, -23)}");

		}
	
	public static void tiny(){
		int n=(int)1e6;
		double epsilon=Math.Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;

		sumA+=1; 
		for(int i=0;i<n;i++){sumA+=tiny;}
		for(int i=0;i<n;i++){sumB+=tiny;} 
		sumB+=1;

		Console.WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
		Console.WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");

		Console.WriteLine($"This differ because tiny is less than the machine epsilon. Therefore if we add tiny to 1, it will still be 1 since there is no floating point number representation for it");

	}

	public static bool approx
		(double a, double b, double acc=1e-9, double eps=1e-9){
			if(Math.Abs(b-a) < acc) 
				return true;
			else if(Math.Abs(b-a) < Math.Max(Math.Abs(a),Math.Abs(b))*eps) 
				return true;
			else 
				return false;
	}
}




