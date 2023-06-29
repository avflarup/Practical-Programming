#From lecture 5
Out.txt : main.exe input.txt
	mono $< < input.txt > Out.txt
main.exe : main.cs genlist.dll
	mcs -target:exe -out:$@ \
		$(addprefix -reference:,$(filter %.dll,$^)) \
		$(filter %.cs,$^)

genlist.dll : genlist.cs
	mcs -target:library -out:$@ $<

clean:
	rm -f *.exe *.dll [Oo]ut* log*
