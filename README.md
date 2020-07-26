# VR Packet39-Crane-Simulator

### Overview: <br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This project is a simulator to train an operator to safely and competently use a truck crane. To increase the immersion and thus utility of this training, the training is conducted in VR with audio. The user sits in the cab of the crane and controls it using levers. The user picks up a container with the crane and move it to another location. After using the simulator, the user will have a better understanding of how to safely operate the crane during early training on a real machine.

<p align="center">
<img src="https://i.postimg.cc/c1csTxHJ/Screen-Shot-2020-07-26-at-7-35-48-AM.png"></p>
 

### VR Control Reference: <br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The crane is controlled with 4 levers in the cockpit. Settings can be adjusted by the screen in front of the user, below the window, which also displays information and warnings. The functions of the levers, from left to right, are as follows:

1. Boom elevation
1. Cabin rotation (rotates the whole cabin/boom assembly)
3. Magnet elevation (raises/lowers the magnet by changing the length of its cable)
4. Boom extension

### Highlights: <br>

1. The overall physics of the crane mimic a real one; the pick-up feature simulates the physics of a rope.
2. Flexible training settings: to offer a more challenging training scenario, the simulator can adjust the size of the target container and can switch between **day/night mode**.
3. User-friendly UI: the UI screen provides a **tutorial** explaining the VR controls and provides **warning feedback** if the user performs an unsafe maneuver such as dropping the container from too high.
4. Helpful yet non-distracting **audio**: a “beap” sound once object is attached to pulley, motor sound when the crane is turned on.
5. Cabin rotation speed is limited to reduce motion sickness in VR.
	

		
### Collaboration: <br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Aurelius: environment, lighting, textures, movement scripting <br>
		
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Emilio: models, movement scripting <br>
		
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Minglan: VR control levers, UI Menus, pulley motion & pickup, audio <br>
		
_Special thanks to Craig from XRTerra for helping us debug so many things_


