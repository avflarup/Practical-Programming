//Based on http://212.27.24.106:8080/prog/matlib/roots/

using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){

	Console.WriteLine($"Simple one 2D equation");
	Console.WriteLine($"12x+9y=0");
	Console.WriteLine($"-3x+2y+5=0");
	vector guess = new vector(1, -1);
	Func<vector, vector> g = v =>{
		vector u = new vector(v.size);
		u[0] = 12*v[0]+9*v[1];
		u[1] = -3*v[0] + 2*v[1]+5;
		return u;
	};
	var res = roots.newton(g, guess, 1e-7);
	Console.WriteLine($"Start guess is {guess[0]}, {guess[1]}");
	Console.WriteLine($"Calculated {res[0]}, {res[1]}");



vector c = new vector("1,1");
int n=c.size;
matrix A = new matrix(n,n);
var rnd=new System.Random(1);
for(int i=0;i<n;i++)
for(int j=0;j<n;j++)A[i,j]=2*(rnd.NextDouble()-0.5);
int ncalls=0;
Func<vector,vector> f;

f = delegate(vector z){
	ncalls++;
	vector r=new vector(2);
	double x=z[0],y=z[1],b=100;
	r[0]=2*(1-x)*(-1)+b*2*(y-x*x)*(-1)*2*x;
	r[1]=b*2*(y-x*x);
	return r;
	};

f = z => {// Rosenbrock
	ncalls++;
	vector r=new vector(2);
	double x=z[0],y=z[1],a=1,b=100;
	r[0]=a*(1-x);
	r[1]=b*(y-x*x);
	return r;
	};

//f = (z)=>{ ncalls++; return (A*(z-c)).map(t=>t*t*t); };
//f = (z)=>{ ncalls++; return (A*(z-c)).map(t=>Sin(t)); };
//double ene=3;
//f = (z)=>{ ncalls++; return new vector(ene*z[0]-z[1]*z[0],z[0]*z[0]-1); };

double eps=1e-7;
vector start = new vector("7 -7");

start.print("\nnewton on Rosenbrock's valley function:\nstart point:");
	ncalls=0; var p = roots.newton(f,start,eps);
	WriteLine($"nsteps={roots.nsteps} ncalls={ncalls}");
	p.print("root=");
	f(p).print("f(root)=");
	WriteLine($"Real roots are 1, 1");
	WriteLine($"eps            = {eps}");
	WriteLine($"f(root).norm() = {f(p).norm()}");
	if(f(p).norm()<eps)WriteLine("test passed");
	else                  WriteLine("test failed");
}
}
