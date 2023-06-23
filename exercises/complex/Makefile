DIR = ../../matlib/complex    

Out.txt : main.exe
	mono $< >$@

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll : ../../matlib/complex/cmath.cs ../../matlib/complex/complex.cs
	mcs -target:library -out:./cmath.dll $^

clean :
	rm -f main.exe Out.txt
