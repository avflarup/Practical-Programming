using System;
using static System.Math;

public class main {
	public static void Main(){
		Console.WriteLine($"sqrt(-1) = {cmath.sqrt(-complex.One)}. Should be +-i. Is close");
		Console.WriteLine($"sqrt(i) = {cmath.sqrt(complex.I)}. Should be 1/sqrt(2) + i/sqrt(2). Is close");
		Console.WriteLine($"e^i = {cmath.exp(complex.I)}. Should be 0.54 + 0.84i. Is close");
		Console.WriteLine($"e^(i pi) = {cmath.exp(complex.I*PI)}. Should be -1. Is close");
		Console.WriteLine($"i^i = {cmath.pow(complex.I, complex.I)}. Should be 0.208. Is close");
		Console.WriteLine($"ln(i) = {cmath.log(complex.I)}. Should be i pi /2. Is close");
		Console.WriteLine($"sin(i pi) = {cmath.sin(complex.I*PI)}. Should be 11.55i. Is close");
	}
}
