using System;
using static System.Math;

class main{
	public static void Main(string[] args){
	foreach(var arg in args){
		var words = arg.Split(':');
		if(words[0]=="-numbers"){
			var numbers=words[1].Split(',');
			foreach(var number in numbers){
				double x = double.Parse(number);
				Console.WriteLine($"Sin({x}) = {Sin(x)}, Cos({x}) = {Cos(x)}");
				}
			}
		}
	}
}


