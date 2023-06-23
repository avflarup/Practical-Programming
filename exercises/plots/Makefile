#From lecture 7

DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)

all: Gamma.svg Erf.svg Lngamma.svg

Gamma.svg : gamma.gpi gamma.data factorials.data
	gnuplot $<

Erf.svg : erf.gpi erf.data erf1.data
	gnuplot $<

Lngamma.svg : lngamma.gpi lngamma.data lngamma1.data
	gnuplot $<

gamma.data : main.exe
	mono $< -gamma > $@

erf.data : main.exe 
	mono $< -erf > $@

lngamma.data : main.exe
	mono $< -lngamma > $@

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:$@ $(CODE) $(DLLS)

sfuns.dll : gamma.cs erf.cs lngamma.cs
	mcs -target:library -out:$@ $^

factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@

main: main.exe sfuns.dll
	mkbundle -o $@ --simple $^


erf1.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 0.5 0.52 >>$@
	echo 1 0.84 >>$@
	echo 2 0.995 >>$@

lngamma1.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 1 0 >>$@
	echo 2 0.693 >>$@
	echo 3 1.79 >>$@

clean:
	$(RM) *.exe *.dll *.svg *.data main
