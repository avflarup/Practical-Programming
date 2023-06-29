using System;
using static System.Math;

public static class lsf{
public static (vector, matrix) lsfit
(Func<double,double>[] fs, vector x, vector y, vector dy){
	int n = x.size, m=fs.Length;
	var A = new matrix(n ,m);
	var b = new vector(n);
	for (int i =0; i<n; i ++){
		b[i]=y[i]/dy[i];
		for (int k=0;k<m; k++) {A[i,k]= fs[k](x[i])/dy[i];}
}
	(matrix Q, matrix R) = QRGS.decomp(A);
	vector c = QRGS.solve(Q,R,b);
	matrix S = QRGS.inverse(Q,R);
	return (c,S);
}
}
