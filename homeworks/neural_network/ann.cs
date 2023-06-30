using System;

public class ann{
   int n; /* number of hidden neurons */
   Func<double,double> f = x => x*Exp(-x*x); /* activation function */
   vector p; /* network parameters */
   ann(int n){/* constructor */
   this.n = n;
   this.f = f;
   this.p = p;
   }
   public double response(double x){
      /* return the response of the network to the input signal x */
	   // Is the weighted sum
	double Fp = 0;
	for(int i=0; i<this.n; i++){
		F+= this.f((x-p[3*i])/p[3*i+1])*p[3*i+2];
	}
	return F;
     }
   public void train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
	   this.x = x;
	   this.y = y;
	   Func<vector, double> C = p => {
		double cost = 0;
		for(int i=0; i<x.size; i++){
			cost += (response(x[i])-y[i])*(response(x[i])-y[i])
		}
	   }
	   vector pp = p;
	   var steps = qnewton.min(C, ref pp);

	   


   }
}
