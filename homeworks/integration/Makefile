DLLS = $(addprefix -reference:,$(filter %.dll,$^))

all : Out.txt Erf.svg

Out.txt : main.exe 
	mono $< > $@

Erf.svg : erf.gpi erf.data
	gnuplot $<

main.exe : main.cs integration.dll
	mcs $< $(DLLS)

integration.dll : integration.cs
	mcs -target:library -out:$@ $<

erf.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 0.5 0.52 >>$@
	echo 1 0.84 >>$@
	echo 2 0.995 >>$@

clean :
	rm -f *.txt *.dll *.svg *.exe

