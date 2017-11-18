# lazerman2
2D tile based game engine built with Monogame 

Introduction:
This is the project I have been currently working on. I'm trying to build a custom 2D game engine to make a sequel to the game my brother and I made for school. 

Change log:

9/15/2017 - Created project and began making static manager classes for framework purposes. This includes the Renderer, ResourceManager,               Resources, Camera, and Player.

9/18/2017 - Started to prototype the tile engine and tile objects.

9/21/2017 - Created Level objects to store tile information for a level.

9/24/2017 - Created a Level Manager to be able to load in multiple levels and manage them all outside of the main game class.

9/29/2017 - Started to prototype UI capabilities for the editor and menu systems.

9/30/2017 - Created Window and button objects for the UI.

10/5/2017 - Created a Window Manager to handle all of the Window and UI states.

10/10/2017 - Created an Input Handler to handle and store necessary input information.

10/13/2017 - Created utility functions to be used by the UI such as testing a Mouse position against a rectangle.

10/17/2017 - Created Editor functionality for level editing. Ran into a problem with garbage collection causing frameskips at intervals                during gameplay. 

** Currently working on fixing the garbage collection issue, I've found that it is not a problem so much on a more powerful machine.
