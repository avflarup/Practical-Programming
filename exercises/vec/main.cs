// From lecture 3-classes
using System;
using static System.Console;
using static System.Math;
public static class main{

	public static void print(this double x,string s){ /* x.print("x="); */
		Write(s);WriteLine(x);
		}

	public static void print(this double x){ /* x.print() */
		x.print("");
	}

	public static void Main(){
		/*
		int n=9;
		double[] a = new double[n];
		for(int i=0;i<n;i++) Write($"a[{i}]={a[i]} ");
		WriteLine();
		for(int i=0;i<n;i++) a[i]=i;
		for(int i=0;i<n;i++) Write($"a[{i}]={a[i]} ");
		WriteLine();
		WriteLine($"array length = {a.Length}");
		foreach(double ai in a) Write($" ai = {ai} ");
		WriteLine();
		*/
		vec u = new vec(1,2,3);
		vec v = new vec(2,3,4);
		u.print    ("u  =");
		v.print    ("v  =");
		(u+v).print("u+v=");
		(2*u).print("2*u=");
		vec w=u*2;
		w.print("u*2=");
		vec w2=u+6*v-w;
		w2.print("w2=");
		(-u).print("-u=");
		WriteLine($"u%v      = {u % v}");
		WriteLine($"u.dot(v) = {u.dot(v)}");
		WriteLine($"norm of v = {v.norm()}");
		WriteLine($"norm of u = {vec.norm(u)}");
		WriteLine($"v x u = {v.cross(u)}");
		WriteLine($"v approx u = {vec.approx(v, u)}");

		vec vec1 = new vec(4.99999999999999999, 5.0000000000000000001, -0.00000000000000001);
		vec vec2 = new vec(5, 5, 0);
		WriteLine($"vec1 = {vec1}");
		WriteLine($"vec2 = {vec2}");
		WriteLine($"vec1 approx vec2 = {vec1.approx(vec2)}");

	}
}
