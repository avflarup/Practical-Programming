using System; 
using static System.Math;

public static class main{
	public static void Main(){
		var rnd = new Random(69);
		int n = 10, m = 7;
		matrix A = new matrix(n,m);
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j] = rnd.Next(0,100);
			}
		}
		Console.WriteLine($"A matrix:");
		A.print();
		Console.WriteLine($"Testing decomp");
		(matrix Q, matrix R) = QRGS.decomp(A);
		Console.WriteLine($"After QR the Q matrix is:");
		Q.print();
		Console.WriteLine($"The R matrix is:");
		R.print();
		Console.WriteLine($"Q^) Q should be I:");
		(Q.transpose()*Q).print();
		Console.WriteLine($"QR == A? {A.approx(Q*R)}");



		
		Console.WriteLine($"Testing solve.");
		int n2 = 10;
		matrix A2 = new matrix(n2, n2);
		vector b = new vector(n2);
		for(int i=0; i<n2; i++){
			b[i] = rnd.Next(0, 100); 
			for(int j=0; j<n2; j++){
				A2[i, j] = rnd.Next(0, 100);
			}
		}
		Console.WriteLine($"Matrix A is:");
		A2.print();
		Console.WriteLine($"Vector b is:");
		b.print(); 
		(matrix Q2, matrix R2) = QRGS.decomp(A2);
		vector x = QRGS.solve(Q2, R2, b);
		Console.WriteLine($"Vector x is:");
		x.print();
		Console.WriteLine($"Does Ax = b? {(A2*x).approx(b)}");





		Console.WriteLine($"Testing inverse");
		Console.WriteLine($"We use same square matrix A as before");

		matrix B = QRGS.inverse(Q2, R2);
		Console.WriteLine($"Matrix B is:");
		B.print();
		Console.WriteLine($"Is AB=I? {(A2*B).approx(matrix.id(n2))}");
	}

	
}
