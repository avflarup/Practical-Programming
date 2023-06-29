Out.txt : main.exe
	mono $< > $@

main.exe : main.cs matrix.dll qrgs.dll
	mcs -reference:matrix.dll main.cs -reference:qrgs.dll

matrix.dll : ../../matlib/matrix/matrix.cs ../../matlib/matrix/vector.cs
	mcs -target:library -out:./$@ $^

qrgs.dll : qrgs.cs
	mcs -target:library -out:./$@ $^ -reference:matrix.dll

clean :
	rm -f [oO]ut.txt  *.exe *.dll

