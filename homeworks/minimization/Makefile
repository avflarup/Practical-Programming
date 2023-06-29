#From http://212.27.24.106:8080/prog/matlib/minim/
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

all: Out.txt
Out.txt: main.exe
	mono $< >$@ 2>log

main.exe: main.cs qnewton.dll matlib.dll ; $(MKEXE)

LIBDIR=../../matlib
LIBSRC=\
../roots/givensqr.cs\
$(LIBDIR)/matrix/vector.cs\
$(LIBDIR)/matrix/matrix.cs

matlib.dll: $(LIBSRC) ; $(MKDLL)

qnewton.dll: qnewton.cs simplex.cs matlib.dll ; $(MKDLL)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
