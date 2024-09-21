# OpenMediaDownloader
OpenMediaDownloader (omd for short) is an application written in C# to simplify the use of yt-dlp. The purpose is to easily download videos and audio from various major websites on the internet. It will automatically download the highest quality video/audio in mp4/mp3 formats.

This project is old and probably won't work in the near future.

## Usage
OpenMediaDownloader can be ran from the command line, or directly. You may need to add it to your path variable to run it from the command line.

````bash
omd --help
````

## Versioning
This program abides by the [SEMANTIC VERSIONING](https://semver.org/). Packages are published in MAJOR.MINOR.PATCH version format.

## Dependencies
All builds are standalone and will run on your OS without any issue. If you wish to build from scratch, you will need to download the dependencies.
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/)
- [yt-dlp](https://github.com/yt-dlp/yt-dlp)
- [FFmpeg](https://ffmpeg.org/)
- [YamlDotNet](https://github.com/aaubry/YamlDotNet) (Unused for now, not required for build)

## Known Bugs
These are all bugs that are known.
- If given a link without a video attached, the application will still ask you if you want audio or video. Choosing video results in a crash.
- The Ctrl+C keybind sometimes gets interrupted during a user input. It should close and it does not. This seems to only happen when attached to a debugger however and I have not observed it happening on the final build.

## License
The OpenMediaDownloader project is licensed under [GPLv3](*).

The Logger project is licensed under [GPLv3](*).

## Credits
OpenMediaDownloader uses the following binaries for operation. All binaries are unmodified and carry their original licenses.
- [yt-dlp](https://github.com/yt-dlp/yt-dlp) is used for downloading media.
- [FFmpeg](https://ffmpeg.org/) is used for encoding and conversions.