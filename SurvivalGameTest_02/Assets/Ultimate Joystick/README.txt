// -/------------------------------------------------------------\- //
// < Thank you for purchasing the Ultimate Joystick UnityPackage! > //
// -\------------------------------------------------------------/- //

Support Email: tankandhealerstudio@outlook.com
Contact Form: http://www.tankandhealerstudio.com/contact-us.html
Official Documentation: Inside Unity, go to Window / Tank and Healer Studio / Ultimate Joystick.

// --------------------- //
// --- HOW TO CREATE --- //
// --------------------- //
	To create a Ultimate Joystick in your scene, simply find the Ultimate Joystick prefab that you want to use in your
scene and do one of the following: 
	• Click the "Add to Scene" button at the bottom of the Ultimate Joystick's inspector.
	• Click and Drag the Ultimate Joystick prefab into your scene.
Prefabs are located at Assets / Ultimate Joystick / Prefabs.

// ------------------------ //
// --- HOW TO REFERENCE --- //
// ------------------------ //
	The Ultimate Joystick is very easy to reference to other scripts. Simply assign a name to the Ultimate Joystick
inside of the Script Reference section of the inspector. After naming the Ultimate Joystick, you will be presented
with example code that has been generated for that particular Ultimate Joystick. Now we can get that joystick's
position by creating variables at run time and storing the result from the static functions: 'GetHorizontalAxis' and
'GetVerticalAxis'. Let's assume that we want to use a joystick for a characters movement. The first thing to do is to
assign the name "Movement" in the Joystick Name variable located in the Script Reference section of the Ultimate
Joystick. After that, we need to create two float variables to store the result of the joystick's position returned by
the functions mentioned earlier. In order to get the "Movement" joystick's position, we need to pass in the name 
"Movement" as the parameter.

	// CODE EXAMPLE //
	float h = UltimateJoystick.GetHorizontalAxis( "Movement" );
	float v = UltimateJoystick.GetVerticalAxis( "Movement" );

The h variable now contains the value of the horizontal position that the Movement joystick was in at the moment it was
referenced, while the v variable contains the vertical value of the "Movement" joystick. Now we can use these values in
any way that is desired. For example, a common way to use this kind of input in a character's movement script is to create
a Vector3 variable for movement direction, and put in the appropriate values of the Ultimate Joystick's position.

	// CODE EXAMPLE //
	Vector3 movementDirection = new Vector3( h, 0, v );

In the above example, the h and v variables are used to give the movement direction values in the X and Z directions. This
is because you generally don't want your character to move in the Y direction unless the user jumps. That is why we put
v into the Z value of the movementDirection variable. Understanding how to use the values from any input is important when
creating character controllers, so experiment with the values and try to understand how the mobile input can be used in
different ways.

// ------------------------ //
// --------- NOTE --------- //
// ------------------------ //
For more information about each function and how to use it, please see the Official Documentation provided with the Ultimate
Joystick package. It can be found at Window / Tank and Healer Studio / Ultimate Joystick.

	// --- ATTENTION JAVASCRIPT USERS --- //
	If you are using Javascript to program your game, you may be unable to reference the Ultimate Joystick in it's current folder
structure. In order for us to upload this package to the Unity Asset Store, we are required to put all the files within a single
sub-folder. This means that we cannot have a Plugins folder. For more information about the Plugins folder and script compilation
order, please look into Unity's documentation. In short, C# scripts are compiled in a different pass than Javascript, which means
that Javascript cannot reference C# scripts without them being placed in a special folder. In order to reference the Simple Health
Bar script from Javascript, simply create a folder in your main Assets folder named "Plugins", and place the UltimateJoystick.cs
script into the Plugins folder.


// ------------------------ //
// ------ CHANGE LOG ------ //
// ------------------------ //
VERSION 2.5: MAJOR UPDATE
	• Reordered folders ( again ) to better conform to Unity's new standard for folder structure. This may cause some errors if you
		already had the Ultimate Joystick inside of your project. Please COMPLETELY REMOVE the Ultimate Joystick from your project and
		re-import the Ultimate Joystick after.
[ REASON: Folder Structure Change ]
	• Removed the ability to create an Ultimate Joystick from the Create menu because of the new folder structure. In order to create an
		Ultimate Joystick in your scene, use the method mentioned above.
[ GENERAL CHANGES ]
	• Fixed a small problem with the Animator for the joysticks in the Space Shooter example scene.
	• Major improvements to the Ultimate Joystick Editor.
	• Completely revamped the current Dead Zone option to be more consistent with Unity's default input system.
	• Updated support for game making plugins by exposing two get values: HoriztonalAxis and VerticalAxis.
	• Added a new script to handle updating with screen size. The script is named UltimateJoystickScreenSizeUpdater.
[ RENAMED FUNCTIONS ]
	• Renamed the GetJoystick function to be GetUltimateJoystick.
[ NEW FUNCTIONS ]
	• Added two new functions to use in accord with the new Dead Zone option. These new functions work very similarly to Unity's GetAxisRaw function.
		• GetHorizontalAxisRaw
		• GetVerticalAxisRaw
	• Added an official way to disable and enable the Ultimate Joystick through code.
		• DisableJoystick
		• EnableJoystick
[ REMOVED FUNCTIONS ]
	• Removed the Vector2 GetPosition function. All input values should be obtained through the GetHorizotalAxis and GetVerticalAxis functions.

VERSION 2.1.5:
	• Improvements to the Documentation Window.
	• Minor editor fixes. 
	
VERSION 2.1.4: 
	• Removed the Third Person Example folder and all it's contents because it was using Unity's scripts, which were causing errors
		for some who had the Standard Assets in their folders. 
	• Added two new functions to be used for Disabling and Enabling the Ultimate Joystick at runtime. 
	• Removed the adding of the Ultimate Joystick Updater script while in the editor as it caused strange errors occasionally. 
	
VERSION 2.1.3: 
	• Updated Documentation Window with up-to-date information as well as improving overall functionality of the Documentation Window. 
	• Minor editor fixes. 
	
VERSION 2.1.2: 
	• Removed Touch Actions section from the Editor. All options that were previously in the Touch Actions section are now located in the Style and Options section. 
	• Fixed an issue with the Documentation Window not showing up as intended in some rare cases. 
	
VERSION 2.1.1: 
	• Improved functionality for the basic interaction of the Ultimate Joystick. 
	• Minor change to the Ultimate Joystick editor. 
	
VERSION 2.1: 
	• Removed all example files from the Plugins folder 
	• All example files have been placed in a new folder: Ultimate Joystick Examples 
	• Added new example scene • Updated third-person example with more functionality 
	• Added four new Ultimate Joystick textures • Improved tension accent display functionality 
	• Further improved Ultimate Joystick Editor functionality 
	• Removed Ultimate Joystick PSD from the project files 
	• Added four new functions to increase the efficiency of referencing the Ultimate Joystick 
	• Removed unneeded static functions 
	• Renamed some functions to better reflect their purpose 
	• Added page to Documentation Window to show important changes