DLLS = $(addprefix -reference:,$(filter %.dll,$^))
DIR = ../../matlib/matrix

all: Out.txt Fit.svg

Out.txt : main.exe
	mono main.exe -input:data.txt > $@

Fit.svg : fit.gpi data.txt
	gnuplot $<

main.exe : main.cs matrix.dll qgrs.dll lsf.dll
	mcs -target:exe main.cs $(DLLS)

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./$@ $^ 

qgrs.dll : ../linear_equations/qrgs.cs
	mcs -target:library -out:./$@ $^ -reference:matrix.dll

lsf.dll : lsf.cs
	mcs -target:library -out:./$@ $^ -reference:matrix.dll -reference:qgrs.dll

clean :
	rm -f *.dll [oO]ut.txt *.svg *.exe
