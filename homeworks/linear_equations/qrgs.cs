using System;

public static class QRGS{
	public static (matrix,matrix) decomp(matrix A){
	matrix Q=A.copy();
	matrix R=new matrix(A.size2,A.size2);
	for(int i = 0; i<A.size2; i++){
		R[i,i] = Q[i].norm();
		Q[i] /= R[i,i];
		for(int j=i+1; j<A.size2; j++){
			R[i,j] = Q[i].dot(Q[j]);
			Q[j] -= Q[i]*R[i,j];
		}

	}
	

      return (Q,R);
      }
   public static vector solve(matrix Q, matrix R, vector b){
	vector c = Q.T*b;

	for(int i=c.size-1; i>=0; i--) {
		double sum=0;
		for(int k=i+1; k<c.size; k++) sum+=R[i,k]*c[k];
		c[i]=(c[i]-sum)/R[i,i];
	}
	return c;
   }

	public static double det(matrix R){
		double sum = 1;
		for(int i=0; i<R.size2; i++){
			sum *= R[i,i];
		}
		return sum;

	}
	public static matrix inverse(matrix Q,matrix R){
		matrix A = new matrix(Q.size2, Q.size1);
		for(int i=0; i<Q.size2; i++){
			vector e = new vector(Q.size1);
			e[i] = 1;
			vector x = solve(Q, R, e);
			A[i] = x;
		}
		return A;
	


}
}
