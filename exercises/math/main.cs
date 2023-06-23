using System; 

class math{
	static void Main(){
		double sqrt2 = Math.Sqrt(2.0);
		double pow2 = Math.Pow(2.0, 1.0/5.0);
		double epi = Math.Exp(Math.PI);
		double pie = Math.Pow(Math.PI, Math.E);

		Console.WriteLine($"sqrt2 = {sqrt2}, sqrt2^2 = {sqrt2 * sqrt2}");
		Console.WriteLine($"2^(1/5) = {pow2}, (2^(1/5))^5 = {pow2*pow2*pow2*pow2*pow2}");
		Console.WriteLine($"e^pi = {epi}, ln(e^pi) = {Math.Log(epi)}");
		Console.WriteLine($"pi^e = {pie}, ");
		Console.WriteLine($"gamma(1) = {sfuns.gamma(1.0)}");
		Console.WriteLine($"gamma(2) = {sfuns.gamma(2.0)}");
		Console.WriteLine($"gamma(3) = {sfuns.gamma(3.0)}");
		Console.WriteLine($"gamma(10) = {sfuns.gamma(10.0)}");

		Console.WriteLine($"lngamma(-1) = {sfuns.lngamma(-1.0)}");
		Console.WriteLine($"lngamma(1) = {sfuns.lngamma(1.0)}");
		Console.WriteLine($"lngamma(10) = {sfuns.lngamma(10.0)}");
	}
}
