// From http://212.27.24.106:8080/prog/matlib/roots/

using System;
using static System.Console;
public static partial class roots{
public static int nsteps=0,nstepsmax=99;

public static vector newton
(Func<vector,vector> f, vector x, double eps=1e-3, vector dx=null){
	vector fx=f(x),z,fz;
	nsteps=0;
	do{	nsteps++;
		matrix J=jacobian(f,x,fx,dx);
		var qrJ=new givensQR(J);
		vector Dx=qrJ.solve(-fx);
		double lambda=2;
		do{// backtracking linesearch
			lambda/=2;
			z=x+Dx*lambda;
			fz=f(z);
		}while(fz.norm()>(1-lambda/2)*fx.norm() && lambda>1.0/1024);
		x=z;
		fx=fz;
	}while(fx.norm()>eps && nsteps<nstepsmax);
	return x;
}//newton

}//roots
