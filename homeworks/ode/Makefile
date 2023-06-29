DIR = ../../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))

all : Out.txt Cos.svg Harm.svg

Out.txt : main.exe
	mono $< > $@

Cos.svg : cos.gpi
	gnuplot $<

Harm.svg : harm.gpi
	gnuplot $<

main.exe : main.cs matrix.dll ode.dll genlist.dll
	mcs $< $(DLLS)

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./$@ $^

ode.dll : ode.cs matrix.dll genlist.dll
	mcs -target:library -out:./$@ $< $(DLLS)

genlist.dll : ../../exercises/generic_list/genlist.cs
	mcs -target:library -out:./$@ $^

clean : 
	rm -f *.exe *.dll *.txt *.svg

