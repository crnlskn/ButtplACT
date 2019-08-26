# WHAT

Software and hardware, interacting in marvelous ways.

There's video games, one of which is Final Fantasy XIV (FFXIV). As is usual with MMOs, there is software to measure your performance in fights, for FFXIV this is [Advanced Combat Tracker (ACT)](https://advancedcombattracker.com). ACT supports plugins and is written in C#, as is the wunderful [Buttplug](https://buttplug.io) library - an open source, BSD-licensed implementation of an open sex toy control protocol.

There's also me, who got bored-slash-inspired, and plugged (ehehehe plugged get it) those things together.

# WHY

No comment.

# HOW

Download a release, unblock the contained dlls, extract them into your ACT folder, load the plugin, configure the plugin, click `Ready!`

Building it yourself should be straight-forward, just get the dependencies with nuget (assuming I configured that right, if not open an issue to make me aware that I didn't) and, well, build the only project in the solution. Or get a programmer friend of yours to do it, maybe.

Configurable events consist of an `action name`, an `attacker`, a `victim`, and an `intensity`. The only necessary entries are `duration` and `intensity`, the former in seconds with one significant digit after the period, e.g. `0.2` for 0.2 seconds or 200 milliseconds. The `action name` is the name of the action as in-game, e.g. `Rage of Halone` or `Regen`. The `victim` and `attacker` strings are the in-game name of a PC or NPC, or `YOU` as special string for the character of the player on the computer where the plugin is running. As an example, if someone where to want to en-/discourage their paladin tank from healing, one could configure the following event, which vibrates at 80% whenever the PC casts clemency:

```
Action name: Clemency
Attacker: YOU
Victim:
Duration: 2
Intensity: 80
```

Additionally the only way to currently react to DoT or HoT ticks is by exploiting the fact that ACT reports them as estimates and adds `(*)` to the action name. Thus an event that vibrates at 30% for 300ms whenever regen ticks would be as follows:

```
Action name: Regen(*)
Attacker: 
Victim:
Duration: 0.3
Intensity: 30
```

A more thorough guide will be released eventually.

The `Scan for devices` button scans for devices. Although Buttplug supports *a lot* of devices as well as different means of connecting them, ButtplACT currently only supports bluetooth vibrators. Do not pair your device with your computer or phone or anything else, just turn it on and click the button. A few seconds later the device will show up in the list next to the button, where you can select it. The device should vibrate at 50% for a short moment when you check the checkbox next to its name.

After all of this is configured you can click the `Ready!` button. This will grey out all the elements and change the `Ready!` text into `Stop` and you're good to go.

# WHO

Me. crnlskn or crnl or noelsken, usually. Bug me on [twitter](https://twitter.com/noelsken) if something seems weird or broken (as long as you don't ask questions that are answered in this README already, please), or give me money on [ko-fi](https://ko-fi.com/crnlskn) to fund further development, like for example electro-stimulation support.
