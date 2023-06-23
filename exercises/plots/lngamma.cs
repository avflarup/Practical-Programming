using System;
using static System.Math;

public static partial class sfuns {	
public static double lngamma(double x){
		if (x <= 0) {
			return double.NaN;
		}
		if (x < 9) {
			return lngamma(x + 1) - Math.Log(x);
		}
		double lngamma1 = x*Math.Log(x+1.0/(12.0*x - 1.0 / (10.0*x))) - x + Math.Log(2.0*Math.PI/x)/2.0;
		return lngamma1;
	}
}
