all : clean restore publish

clean:
	dotnet clean

restore:
	dotnet restore

publish:
	dotnet publish -c Release -r win-x64 --self-contained true /p:DebugType=None /p:DebugSymbols=false
	cp -r lib OpenMediaDownloader/bin/Release/net6.0/win-x64/publish/