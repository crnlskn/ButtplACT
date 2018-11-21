# WHAT

Software and hardware, interacting in marvelous ways.

There's video games, one of which is Final Fantasy XIV (FFXIV). As is usual with MMOs, there is software to measure your performance in fights, for FFXIV this is Advanced Combat Tracker (ACT). ACT supports is written in C#, as is the wunderful Buttplug library - an open source, BSD-licensed implementation of an open sex toy control protocol.

There's also me, who got bored-slash-inspired, and plug (he he he plugged get it) those things together.

# WHY

No comment.

# HOW

Download a release, unblock the contained dlls, extract them into your ACT folder, load the plugin, configure the plugin, click `Ready!`

Configuration happens via six elements on the `ButtplACT.dll` tab, the text box next to the `Target` label identifies the target that is to be observed by the plugin. Due to how ACT works, if you want your vibrator to react to your own character being hit, you need to enter `YOU`, for any other character it needs to be the full, exact name, as it appears in the `Encounter` tab.

The text box next to the `Base intensity` label configures the base intensity of vibration during combat, in percent (i.e. 0 to 100), whereas the text next to the `Impact intensity` label configures the impact intensity. Base intensity is to be understood as the intensity of vibration caused purely by being in combat, impact intensity is to be understood as the intensity of vibration when the configured target is the target of any combat action. Basically, base intensity is background vibration just because you're fighting, and impact intensity is a different level of vibration because you got hit.

The `Scan for devices` scans for devices. Although Buttplug supports *a lot* of devices as well as different means of connecting them, ButtplACT currently only supports bluetooth vibrators. Do not pair your device with your computer or phone or anything else, just turn it on and click the button. A few seconds later the device will show up in the list next to the button, where you can select it. The device should vibrate at 50% for a short moment when you check the checkbox next to its name.

After all of this is configured you can click the `Ready!` button. This will grey out all the elements and change the `Ready!` text into `Stop` and you're good to go.
