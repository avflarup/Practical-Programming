Out.txt : main.exe
	mono $< > $@

main.exe : main.cs
	mcs $<

clean :
	rm -f [oO]ut.txt *.exe
