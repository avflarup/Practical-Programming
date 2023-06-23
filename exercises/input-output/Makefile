
all: Out.txt

Out.txt: cmdline.exe stdin.exe filestream.exe inputfile.txt Makefile
	>$@
	mono $< -numbers:1,2,3,4,5 1>>$@
	echo 1 2 3 4 5 | mono stdin.exe 2>>$@
	mono filestream.exe -input:inputfile.txt -output:outfile.txt
	cat outfile.txt >>$@

cmdline.exe : cmdline.cs
	mcs $<

stdin.exe : stdin.cs
	mcs $<

filestream.exe : filestream.cs
	#mcs $<
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

inputfile.txt : Makefile
	echo 1 >$@
	echo 2 >>$@
	echo 3 >>$@

clean :
	rm -f *.txt *.exe
