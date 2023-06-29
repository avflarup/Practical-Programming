Out.txt : main.exe
	mono $< > $@

main.exe : main.cs matrix.dll jacobi.dll
	mcs -reference:matrix.dll -reference:jacobi.dll main.cs

matrix.dll : ../../matlib/matrix/matrix.cs ../../matlib/matrix/vector.cs
	mcs -target:library -out:./$@ $^

jacobi.dll : jacobi.cs
	mcs -target:library -out:./$@ $^ -reference:matrix.dll

clean :
	rm -f [oO]ut.txt *.exe *.dll

