using System;
using System.Linq;
using static System.Math;

public class ODE2{
	// We use the same driver as in the ODE homework. 
	// It has been changed a little to accomodate the fact that we need both the current
	// and the previous point for the 2-step ode solver.
	public static (genlist<double>,genlist<vector>) driver(
		Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
		double a,                    /* the start-point a */
		vector ya,                   /* y(a) */
		double b,                    /* the end-point of the integration */
		double h=0.01,               /* initial step-size */
		double acc=0.01,             /* absolute accuracy goal */
		double eps=0.01              /* relative accuracy goal */
	){
	if(a>b) throw new ArgumentException("driver: a>b");
	double x1=a; vector y1=ya.copy();
	double x0=a; vector y0=ya.copy();
	var xlist=new genlist<double>(); xlist.add(x0);
	var ylist=new genlist<vector>(); ylist.add(y0);
	// The first step is made with the embedded Runge-Kutta stepper.
	var (yf, _) = rkstep12(f, x1, y1, h);
	x1 += h;
	y1 = yf;
	xlist.add(x1);
	ylist.add(y1);
	do      {
		if(x1>=b) return (xlist,ylist); /* job done */
		if(x1+h>b) h=b-x1;               /* last step should end at b */
		
		var (yh,erv) = step2(f,x0,y0,x1,y1,h);
		double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
		double err = erv.norm();
		if(err<=tol){ // accept step
			x0=x1; y0=y1;
			x1+=h; y1=yh;
			xlist.add(x1);
			ylist.add(y1);
			}
		h *= Min( Pow(tol/err,0.25)*0.95 , 2); // reajust stepsize
		}while(true);
	}//driver
	
	public static (vector, vector) step2 (
		Func<double, vector, vector> f,
		double x0,
		vector y0,
		double x1,
		vector y1, 
		double h) {
		// We use the equations from the book 
		var dy = f(x1, y1);
		vector c = (y0 - y1 + dy * (x1-x0))/((x1-x0)*(x1-x0));
		double x2 = x1 + h;
		vector y2 = y1 + dy*(x2-x1)+c*(x2-x1)*(x2-x1);
		var err = c*h*h;
		return (y2, err);
	}//2step

	public static (vector,vector) rkstep12(
					// This is from the ODE homework. It is only used for the first step
	Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
	double x,                    /* the current value of the variable */
	vector y,                    /* the current value y(x) of the sought function */
	double h)                    /* the step to be taken */
	{
	vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
	vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
	vector yh = y+k1*h;              /* y(x+h) estimate */
	vector er = (k1-k0)*h;           /* error estimate */
	return (yh,er);
	}
}
