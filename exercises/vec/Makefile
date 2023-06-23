#From lecture 3-classes
Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs vec.dll
	mcs main.cs -reference:vec.dll -target:exe -out:main.exe

vec.dll : vec.cs
	mcs $< -target:library -out:$@

clean :
	rm -f main.exe Out.txt

