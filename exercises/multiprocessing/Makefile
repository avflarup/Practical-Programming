N=1e8
TIME = time --portability --append --output $@
Out.txt : main.exe parallel.exe Makefile
	>$@
	$(TIME) mono $< -terms:$N -threads:1 >>$@
	$(TIME) mono $< -terms:$N -threads:2 >>$@
	$(TIME) mono $< -terms:$N -threads:3 >>$@
	$(TIME) mono $< -terms:$N -threads:4 >>$@
	$(TIME) mono parallel.exe -terms:$N -threads:1 >>$@

main.exe : main.cs
	mcs $< 

parallel.exe : parallel.cs
	mcs $<

clean :
	rm -f main.exe Out.txt


