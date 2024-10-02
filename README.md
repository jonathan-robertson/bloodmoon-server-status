# BloodMoon Server Status

[![🧪 Tested On 7DTD 1.1 (b14)](https://img.shields.io/badge/🧪%20Tested%20On-7DTD%201.1%20(b14)-blue.svg)](https://7daystodie.com/) [![📦 Automated Release](https://github.com/jonathan-robertson/bloodmoon-server-status/actions/workflows/release.yml/badge.svg)](https://github.com/jonathan-robertson/bloodmoon-server-status/actions/workflows/release.yml)

- [BloodMoon Server Status](#bloodmoon-server-status)
  - [Summary](#summary)
    - [Support](#support)
  - [Features](#features)
    - [Example Usage](#example-usage)
  - [Setup](#setup)
    - [Environment / EAC / Hosting Requirements](#environment--eac--hosting-requirements)
    - [Map Considerations for Installation or UnInstallation](#map-considerations-for-installation-or-uninstallation)
    - [Windows PC (Single Player or Hosting P2P)](#windows-pc-single-player-or-hosting-p2p)
      - [Critical Reminders](#critical-reminders)
    - [Windows/Linux Installation (Server via FTP from Windows PC)](#windowslinux-installation-server-via-ftp-from-windows-pc)
    - [Linux Server Installation (Server via SSH)](#linux-server-installation-server-via-ssh)

## Summary

Auto-update clients with BloodMoon status via a CVAR to fill gap left by broken IsBloodMoon trigger in buffs.xml.

### Support

🗪 If you would like support for this mod, please feel free to reach out to me via [Discord](https://discord.gg/hYa2sNHXya) (my username is `kanaverum`).

## Features

🤝 This mod does nothing functional on its own, but instead enables new server-side functionality for other mods:

> 🔍 This is - in essence - a temporary workaround to support server-side versions of mods that currently rely on the `IsBloodMoon` requirement found in `buffs.xml`. If The Fun Pimps update the `IsBloodMoon` requirement for `buffs.xml`, this mod will no longer be necessary and I'd recommend for players to use that requirement instead.

- Each time a player connects, BloodMoon begins, or BloodMoon ends, a new CVAR `is_bloodmoon` updates for players to either `0` or `1`:
  - `0` means the BloodMoon event is currently ***inactive***
  - `1` means the BloodMoon event is currently ***active***

> ℹ️ Reminder: if playing a local game, BloodMoon might not start if the host isn't at least level 5.

### Example Usage

Any time you would've used a requirement like this:

```xml
<requirement name="IsBloodMoon" operation="Equals" value="1"/>
```

instead use something like this:

```xml
<requirement name="CVarCompare" cvar="is_bloodmoon" operation="Equals" value="1" />
```

## Setup

Without proper installation, this mod will not work as expected. Using this guide should help to complete the installation properly.

If you have trouble getting things working, you can reach out to me for support via [Support](#support).

### Environment / EAC / Hosting Requirements

Environment | Compatible | Does EAC Need to be Disabled? | Who needs to install?
--- | --- | --- | ---
Dedicated Server | Yes | no | only server
Peer-to-Peer Hosting | Yes | only on the host | only the host
Single Player Game | Yes | Yes | self (of course)

> 🤔 If you aren't sure what some of this means, details steps are provided below to walk you through the setup process.

### Map Considerations for Installation or UnInstallation

- Does **adding** this mod require a fresh map?
  - ✅ No! You can drop this mod into an ongoing map without any trouble.
- Does **removing** this mod require a fresh map?
  - ✅ No! You can remove this mod from an ongoing map without any trouble, but you might want to confirm if any other mods depend on this one before you do.

### Windows PC (Single Player or Hosting P2P)

> ℹ️ If you plan to host a multiplayer game, only the host PC will need to install this mod. Other players connecting to your session do not need to install anything for this mod to work 😉

1. 📦 Download the latest release by navigating to [this link](https://github.com/jonathan-robertson/bloodmoon-server-status/releases/latest/) and clicking the link for `bloodmoon-server-status.zip`
2. 📂 Unzip this file to a folder named `bloodmoon-server-status` by right-clicking it and choosing the `Extract All...` option (you will find Windows suggests extracting to a new folder named `bloodmoon-server-status` - this is the option you want to use)
3. 🕵️ Locate and create your mods folder (if missing): in another window, paste this address into to the address bar: `%APPDATA%\7DaysToDie`, then enter your `Mods` folder by double-clicking it. If no `Mods` folder is present, you will first need to create it, then enter your `Mods` folder after that
4. 🚚 Move this new `bloodmoon-server-status` folder into your `Mods` folder by dragging & dropping or cutting/copying & pasting, whichever you prefer
5. ♻️ Stop the game if it's currently running, then start the game again without EAC by navigating to your install folder and running `7DaysToDie.exe`
    - running from Steam or other launchers usually starts 7 Days up with the `7DaysToDie_EAC.exe` program instead, but running 7 Days directly will skip EAC startup

#### Critical Reminders

- ⚠️ it is **NECESSARY** for the host to run with EAC disabled or the DLL file in this mod will not be able to run
- 😉 other players **DO NOT** need to disable EAC in order to connect to your game session, so you don't need to walk them through these steps
- 🔑 it is also **HIGHLY RECOMMENDED** to add a password to your game session
  - while disabling EAC is 100% necessary (for P2P or single player) to run this mod properly, it also allows other players to run any mods they want on their end (which could be used to gain access to admin commands and/or grief you or your other players)
  - please note that *dedicated servers* do not have this limitation and can have EAC fully enabled; we have setup guides for dedicated servers as well, listed in the next 2 sections: [Windows/Linux Installation (Server via FTP from Windows PC)](#windowslinux-installation-server-via-ftp-from-windows-pc) and [Linux Server Installation (Server via SSH)](#linux-server-installation-server-via-ssh)

### Windows/Linux Installation (Server via FTP from Windows PC)

1. 📦 Download the latest release by navigating to [this link](https://github.com/jonathan-robertson/bloodmoon-server-status/releases/latest/) and clicking the link for `bloodmoon-server-status.zip`
2. 📂 Unzip this file to a folder named `bloodmoon-server-status` by right-clicking it and choosing the `Extract All...` option (you will find Windows suggests extracting to a new folder named `bloodmoon-server-status` - this is the option you want to use)
3. 🕵️ Locate and create your mods folder (if missing):
    - Windows PC or Server: in another window, paste this address into to the address bar: `%APPDATA%\7DaysToDie`, then enter your `Mods` folder by double-clicking it. If no `Mods` folder is present, you will first need to create it, then enter your `Mods` folder after that
    - FTP: in another window, connect to your server via FTP and navigate to the game folder that should contain your `Mods` folder (if no `Mods` folder is present, you will need to create it in the appropriate location), then enter your `Mods` folder. If you are confused about where your mods folder should go, reach out to your host.
4. 🚚 Move this new `bloodmoon-server-status` folder into your `Mods` folder by dragging & dropping or cutting/copying & pasting, whichever you prefer
5. ♻️ Restart your server to allow this mod to take effect and monitor your logs to ensure it starts successfully:
    - you can search the logs for the word `BloodMoonServerStatus`; the name of this mod will appear with that phrase and all log lines it produces will be presented with this prefix for quick reference

### Linux Server Installation (Server via SSH)

1. 🔍 [SSH](https://www.digitalocean.com/community/tutorials/how-to-use-ssh-to-connect-to-a-remote-server) into your server and navigate to the `Mods` folder on your server
    - if you installed 7 Days to Die with [LinuxGSM](https://linuxgsm.com/servers/sdtdserver/) (which I'd highly recommend), the default mods folder will be under `~/serverfiles/Mods` (which you may have to create)
2. 📦 Download the latest `bloodmoon-server-status.zip` release from [this link](https://github.com/jonathan-robertson/bloodmoon-server-status/releases/latest/) with whatever tool you prefer
    - example: `wget https://github.com/jonathan-robertson/bloodmoon-server-status/releases/latest/download/bloodmoon-server-status.zip`
3. 📂 Unzip this file to a folder by the same name: `unzip bloodmoon-server-status.zip -d bloodmoon-server-status`
    - you may need to install `unzip` if it isn't already installed: `sudo apt-get update && sudo apt-get install unzip`
    - once unzipped, you can remove the bloodmoon-server-status download with `rm bloodmoon-server-status.zip`
4. ♻️ Restart your server to allow this mod to take effect and monitor your logs to ensure it starts successfully:
    - you can search the logs for the word `BloodMoonServerStatus`; the name of this mod will appear with that phrase and all log lines it produces will be presented with this prefix for quick reference
    - rather than monitoring telnet, I'd recommend viewing the console logs directly because mod and DLL registration happens very early in the startup process and you may miss it if you connect via telnet after this happens
    - you can reference your server config file to identify your logs folder
    - if you installed 7 Days to Die with [LinuxGSM](https://linuxgsm.com/servers/sdtdserver/), your console log will be under `log/console/sdtdserver-console.log`
    - I'd highly recommend using `less` to open this file for a variety of reasons: it's safe to view active files with, easy to search, and can be automatically tailed/followed by pressing a keyboard shortcut so you can monitor logs in realtime
      - follow: `SHIFT+F` (use `CTRL+C` to exit follow mode)
      - exit: `q` to exit less when not in follow mode
      - search: `/BloodMoonServerStatus` [enter] to enter search mode for the lines that will be produced by this mod; while in search mode, use `n` to navigate to the next match or `SHIFT+n` to navigate to the previous match
