DIR = ../matlib/matrix
DLLS = $(addprefix -reference:,$(filter %.dll,$^))

all : Out.txt Sin.svg Exp.svg

Out.txt : main.exe
	mono $< > $@

Sin.svg : sin.gpi
	gnuplot $<

Exp.svg : exp.gpi
	gnuplot $<

main.exe : main.cs matrix.dll ode2.dll genlist.dll
	mcs $< $(DLLS)

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./$@ $^

ode2.dll : ode2.cs matrix.dll genlist.dll
	mcs -target:library -out:./$@ $< $(DLLS)

genlist.dll : ../exercises/generic_list/genlist.cs
	mcs -target:library -out:./$@ $^

clean : 
	rm -f *.exe *.dll *.txt *.svg


