# DelOutdatedFiles

## General information

.NET tool: Deleting outdated archives files with timestamps or another variable part at the end of the filename (before the extension).

Example:
```text
If files are stored in the archive directory:
  App.db.230102-135347.zip
  App.db.230103-135315.zip
then you can define a mask for them as
  App.db.*.zip
and delete obsolete files by mask
```

**Outdated files are identified by the time they were last written to the files, not by their timestamp.**

**Files are saved no older than the specified number of days (minimum 1),
and, without fail, a certain number of files are saved (minimum 1) for each of the defined masks.**

## Usage

First, a configuration file with deletion rules must be created in the archive directory.

```
Usage:
  DelOutdatedFiles init [options]

Options:
  -d, --directory <directory>                 Path to the directory where the configuration file '.DelOutdatedFiles'
                                              will be created. Default in current directory [default:
                                              e:\!Repos\InfDev\DelOutdatedFiles\src\DelOutdatedFiles\bin\Debug\net7.0]
  -kd, --keep-days <keep-days>                Keep files from the last number of days. Default 40 [default: 40]
  -kc, --keep-count <keep-count>              Keep a minimum number of files. Default 40 [default: 40]
  -tl, --timestamp-length <timestamp-length>  The length of the timestamp of the archives. Masks will be added for
                                              present files, where the specified number of characters before the
                                              extension will be replaced by * [default: 13]
```

Then, as needed, cleanup is called

```
Usage:
  DelOutdatedFiles cleaning [options]

Options:
  -d, --directory <directory>  Path to the directory where deletion will be performed according to ".DelOutdatedFiles". 
                               Default in current directory
```

## Install/Unistall tool


Install tool

```
dotnet tool install DelOutdatedFiles -g
```

Install the tool from the package by running the dotnet tool install command in the DelOutdatedFiles solution folder

```
dotnet tool install --global --add-source ./nupkg DelOutdatedFiles
```

Uninstall tool

```
dotnet tool uninstall DelOutdatedFiles -g
```