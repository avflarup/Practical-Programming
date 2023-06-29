using System;
using static System.Math;

public class main{
	public static void Main(){
		var rnd = new Random(69);
		int n = 8;
		matrix A = new matrix(n, n);
		for(int i=0; i<n; i++){
			for(int j=i; j<n; j++){
				double number = rnd.Next(0, 100);
				A[i, j] = number;
				if(i!=j) {A[j,i] = number;}
			}

		}
		Console.WriteLine($"Symmetric matrix A:");
		A.print();

		Console.WriteLine($"Eigenvalue-decomp:");
		(vector w, matrix V) = jacobi.cyclic(A);
		matrix D = new matrix(n,n);
		for(int i=0; i<n; i++){
			D[i,i] = w[i];
		}
		Console.WriteLine($"V^T A V = D? {(V.transpose()*A*V).approx(D)}");
		Console.WriteLine($"V D V^T = A? {(V*D*V.transpose()).approx(A)}");
		Console.WriteLine($"V^T V = I? {(V.transpose()*V).approx(matrix.id(n))}");
		Console.WriteLine($"V V^T = I? {(V*V.transpose()).approx(matrix.id(n))}");
		
	}


}


