RUN = mono

matrix.dll : vector.cs matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe [Oo]ut*
