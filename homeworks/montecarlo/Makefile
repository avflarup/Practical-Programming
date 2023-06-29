DIR = ../../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))

all : Out.txt Err.svg

Out.txt : main.exe
	mono $< > Out.txt

Err.svg : err.gpi
	gnuplot $<

main.exe : main.cs matrix.dll mc.dll
	mcs $< $(DLLS)

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./$@ $^

mc.dll : montecarlo.cs matrix.dll
	mcs -target:library -out:./$@ $< $(DLLS)

clean : 
	rm -f *.txt *.svg *.exe *.dll 

