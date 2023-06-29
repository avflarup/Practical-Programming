#From http://212.27.24.106:8080/prog/matlib/roots/

DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
LIBDIR=../../matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
#	$(LIBDIR)/QR/givensqr.cs

all: Out.txt
Out.txt: main.exe
	mono $< >$@ 2>Log

main.exe: main.cs roots.dll matlib.dll; $(MKEXE)

matlib.dll: $(LIBSRC) givensqr.cs
	mcs $^ -target:library -out:$@

roots.dll:jacobian.cs newton.cs matlib.dll; $(MKLIB)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
