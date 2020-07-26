# Packet39-Crane-Simulator

Overview: 
	This project is a simulator to train an operator to safely and competently use a truck crane. To increase the immersion and thus utility of this training, the training is conducted in VR with sound. The user sits in the cab of the crane and controls it using levers. The simulator provides a tutorial explaining the controls. The user picks up a container with the crane and move it to another location. The simulator provides warning feedback if the user performs an unsafe maneuver such as dropping the container from too high, and also times the user so they can track their improvement. To offer a more challenging training scenario, the simulator can adjust the size of the target container and can also be set to night mode, with lower visibility. The overall physics of the crane mimic a real one; the container will swing around unpredictably and must be carefully moved slowly so that it does not swing into anything. After using the simulator, the user will have a better understanding of how to safely operate the crane during early training on a real machine.
	
![alt text] (file:///Users/minglanzheng/Desktop/Screen%20Shot%202020-07-26%20at%207.35.48%20AM.png)

Control Reference:
	The crane is controlled with 4 levers in the cockpit. Settings can be adjusted by the screen in front of the user, below the window, which also displays information and warnings. The functions of the levers, from left to right, are as follows:
		1. Boom elevation
		2. Cabin rotation (rotates the whole cabin/boom assembly)
		3. Magnet elevation (raises/lowers the magnet by changing the length of its cable)
		4. Boom extension 
		
Development breakdown:

	Aurelius:
		environment, lighting, textures, movement scripting
		
	Emilio:
		models, movement scripting, lever scripting, XR rigging
		
	Minglan:
		lever scripting, immersive UI, magnet/pickup, physics 
		
	Special thanks to Craig from XRterra for helping us debug so many things
