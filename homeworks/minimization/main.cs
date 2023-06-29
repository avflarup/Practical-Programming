//From http://212.27.24.106:8080/prog/matlib/minim

using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	vector c = new vector(1,1);
	int n=c.size;
	matrix A = new matrix(n,n);
	var rnd=new System.Random(1);
	for(int i=0;i<n;i++)
	for(int j=0;j<n;j++)A[i,j]=2*(rnd.NextDouble()-0.5);
	int ncalls=0;
	Func<vector,double> f;

	f = (z)=>{
		ncalls++;
		vector q=(A*(z-c)).map(t=>t*t);
		return Sqrt(q%q);
		};

	double eps;
	vector p,g;
	int nsteps;

//Write("qnewton with sr1: Rosenbrock's valley function\n");
//f=(z)=>{ncalls++; return Pow(1-z[0],2)+100*Pow(z[1]-z[0]*z[0],2);};
//eps=1e-4;
//p = new vector(3,3);
//p.print("start point:");
//ncalls=0;
//nsteps = qnewton.min(f,ref p,eps,method:"sr1");
//WriteLine($"nsteps={nsteps}  ncalls={ncalls}");
//p.print("minimum    :");
//Write($"f(x_min)          = {(float)f(p)}\n");
//g=qnewton.gradient(f,p);
//Write($"|gradient| goal   = {(float)eps}\n");
//Write($"|gradient| actual = {(float)g.norm()}\n");
//if(g.norm()<eps)WriteLine("test passed");
//else            WriteLine("test failed");

Write("Rosenbrock's valley function\n");
f=(z)=>{ncalls++; return Pow(1-z[0],2)+100*Pow(z[1]-z[0]*z[0],2);};
eps=1e-4;
p = new vector(3,3);
p.print("start point:");
ncalls=0;
nsteps = qnewton.min(f,ref p,eps,method:"broyden");
WriteLine($"nsteps={nsteps}  ncalls={ncalls}");
p.print("minimum    :");
Write($"f(x_min)          = {(float)f(p)}\n");
WriteLine($"Theoretical minimum: 1, 1");
g=qnewton.gradient(f,p);
Write($"|gradient| goal   = {(float)eps}\n");
Write($"|gradient| actual = {(float)g.norm()}\n");
if(g.norm()<eps)WriteLine("test passed\n");
else            WriteLine("test failed");

//Write("\nqnewton/sr1: Himmelblau's function\n");
//f=(z)=>{ncalls++;return Pow(z[0]*z[0]+z[1]-11,2)+Pow(z[0]+z[1]*z[1]-7,2);};
//eps=1e-4;
//p = new vector(5,3);
//p.print("start point:");
//ncalls=0;
//nsteps = qnewton.min(f,ref p,eps,method:"sr1");
//WriteLine($"nsteps={nsteps}  ncalls={ncalls}");
//p.print("minimum    :");
//Write($"f(x_min)          = {(float)f(p)}\n");
//g=qnewton.gradient(f,p);
//Write($"|gradient| goal   = {(float)eps}\n");
//Write($"|gradient| actual = {(float)g.norm()}\n");
//if(g.norm()<eps)WriteLine("test pas")d");
//else            WriteLine("test failed");

Write("Himmelblau's function\n");
f=(z)=>{ncalls++;return Pow(z[0]*z[0]+z[1]-11,2)+Pow(z[0]+z[1]*z[1]-7,2);};
eps=1e-4;
p = new vector(5,3);
p.print("start point:");
ncalls=0;
nsteps = qnewton.min(f,ref p,eps,method:"broyden");
WriteLine($"nsteps={nsteps}  ncalls={ncalls}");
p.print("minimum    :");
Write($"f(x_min)          = {(float)f(p)}\n");
g=qnewton.gradient(f,p);
Write($"|gradient| goal   = {(float)eps}\n");
Write($"|gradient| actual = {(float)g.norm()}\n");
if(g.norm()<eps)WriteLine("test passed");
else            WriteLine("test failed");
}
}
