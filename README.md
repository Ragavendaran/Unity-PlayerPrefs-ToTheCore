<p align="center" style="font-size: 4em;">
⬤
</p>
<p align="center">
Unfair advantage = Less Enjoyment
<p>
<p align="center">
<a href="https://github.com/Ragavendaran/Unity-PlayerPrefs-ToTheCore/releases/latest"><img alt="GitHub release (latest by SemVer including pre-releases)" src="https://img.shields.io/github/downloads-pre/Ragavendaran/Unity-PlayerPrefs-ToTheCore/latest/total"></a>
<a href="https://github.com/Ragavendaran/Unity-PlayerPrefs-ToTheCore/blob/main/LICENSE"><img alt="GitHub" src="https://img.shields.io/github/license/Ragavendaran/Unity-PlayerPrefs-ToTheCore"></a>
</p>

# Introduction

Unity PlayerPrefs Editor [ToTheCore]

Direct editing of entire saved playerPref data stored.

Only supports reading the Unity PlayerPrefs stored in Windows Registry  currently.

# Usage

Download from releases, extract and execute, or compile it yourself.

## Requirements

- Windows
- .NET 6.0

# Compiling

## Visual Studio

1. Open the solution file (.sln) in Visual Studio

2. Switch to Release and Build Project, to make a standalone compiled version.

## Command-Line

### Path for MSBuild.exe

Windows may have different versions accompanying every .NET version installed, in multiple places.

- [Visual Studio Install Directory]\MSBuild\Current\Bin (Tested, Recommended)

- [Windows Installation Drive Letter]:\Windows\Microsoft.NET\Framework(64)\\[.NET version]\

### Command

 1. Make sure MSBuild.exe is in PATH and accessible

 2. Run the below commands inside the cloned repository folder

```shell
dotnet restore
```

```shell
msbuild UnityPlayerPrefsEditor.sln /t:Build /p:Configuration=Release /p:TargetFrameworkVersion=v6.0
```

The built executables will be present inside `bin\Release\net6.0-windows` directory.

# Contributing

- Feel free to request or PR for any feature you would like to become a reality.

- Please be gentle and respectful towards other users.

# Past and Future

- This project was a way for me to practice .NET windows UI apps.

- Here are some plans for the future of this project undertaken by me.
  - Dark Mode (soon)
  - Generalize to allow editing of all PlayerPrefs across all platforms (not anytime soon)

# Before using this tool

<a href="https://store.steampowered.com/app/1988550"><img alt="Static Badge" src="https://img.shields.io/badge/On-Steam-blue"></a>

- This game captivated me with its amazing music.

- This game is completable under reasonable time, completing it is recommended before using this tool.

# Disclaimer

- Not affiliated to the game or Unity in any way, the tools here are presented only for educational purposes.
