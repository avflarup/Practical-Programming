//From lecture 7
using static System.Console;

class main{
static void Main(string[] args){
	foreach(string arg in args) {
		if (arg == "-gamma"){
			for(double x=-5+1.0/128;x<=5;x+=1.0/64){
				WriteLine($"{x} {sfuns.gamma(x)}");
			}
		}
		
		if (arg == "-erf") {
			for(double x=-3;x<=3;x+=1.0/64){
				WriteLine($"{x} {sfuns.erf(x)}");
			}
		}
		if (arg == "-lngamma") {
			for(double x=0+1/128;x<=5;x+=1.0/64){
				WriteLine($"{x} {sfuns.lngamma(x)}");
			}
		}
	}
}
}
