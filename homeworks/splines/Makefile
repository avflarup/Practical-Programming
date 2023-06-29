

all : Out.txt Lspline.svg

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs splines.dll
	mcs $< -reference:splines.dll

splines.dll : splines.cs
	mcs -target:library -out:./$@ $^

Lspline.svg : lspline.gpi
	gnuplot $<

clean :
	rm -f *.txt *.svg *.exe *.dll


