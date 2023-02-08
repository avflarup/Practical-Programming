using System;

public static class sfuns{
	public static double gamma(double x){
		if (x<0.0) {
			return Math.PI/(Math.Sin(Math.PI*x)*gamma(1.0-x));	
		}
		if (x<9.0) {
			return gamma(x+1.0)/x;
		}
		double lngamma = x*Math.Log(x+1.0/(12.0*x - 1.0 / (10.0*x))) - x + Math.Log(2.0*Math.PI/x)/2.0;
		return Math.Exp(lngamma);
	}
}
