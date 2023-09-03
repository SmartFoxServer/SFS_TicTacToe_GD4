# SmartFoxServer Example Projects for Godot 4.x

This series of **C# examples** built for the Godot 4 engine have been developed with **Godot Mono 4.0.3**, but the concepts and the code to interact with the SFS2X API are valid for any version of Godot 4.x (unless otherwise noted).

Each of the tutorials in this series examine a single example, describing its objectives, **offering an insight into the SmartFoxServer features** it wants to highlight. This project includes all the assets required to compile and test the example (both client and — if existing — server side). If necessary, code excerpts are provided in the tutorial itself (see online documentation link below), in order to better explain the approach that was followed to implement a specific feature. At the bottom of the tutorial, additional resources are linked if available.

The tutorials have an increasing complexity, from basic server connection to a complete game with authoritative server code.

Specifically, the examples will showcase:

* basic connection with optional protocol encryption
* room management
* buddy list management
* game rooms and match-making
* **authoritative server in a turn-based game**

The Godot examples provided have been tested for exporting as native executables for Windows and macOS. At the time of writing this article (June 2023) Godot Mono does not yet support exporting for mobile platform or the browser.

# SFS_TicTacToe_GD4
The Tic-Tac-Toe example shows how to develop a full multiplayer turn-based game with Godot and SmartFoxServer 2X by implementing the well-known paper-and-pencil game for two players also known as Noughts and Crosses. In this game players take turns marking the spaces in a three-by-three grid with X or O; the player who succeeds in placing three of their marks in a horizontal, vertical or diagonal row is the winner.

The example expands the lobby application discussed in previous tutorials, to which we added the actual game assets and client logic updating the existing mock-up Game scene.

This example features a server-side Extension which implements the main game logic: it determines if the game should start or stop, validates the player moves, updates the spectators if they join a game already in progress, checks if the victory condition is met, etc.
Using a server-side Extension — or, in other words, having an authoritative server — is a more flexible and secure option with respect to keeping all the game logic on the client-side only. Even if SmartFoxServer provides powerful tools for developing application logic on the client, this approach can be limiting when your games start getting more complex. Additionally, keeping the game state on the server-side allows overall better security from hacking or cheating attempts.
The server-side Extension is dynamically attached to the SFSGame Room when created; it updates the game state and sends game-related events back to the Godot client, which in turn updates the Game scene accordingly.

This example also shows how to deal with two special features provided by Game Rooms: player indexes and spectators. Each user joining a Game Room is automatically assigned a unique player index which facilitates the tasks of starting and stopping the game, determining whose turn is it, etc. Spectators instead can replace players when they leave, by means of a dedicated client request.



<p align="center"> 
<img width="720" alt="matchmaking" src="https://github.com/SmartFoxServer/SFS_MatchMaking_GD4/assets/30838007/c4821c51-4064-4473-80a9-b75da79a34cb">
 </p>

In this document we assume that you already went through the previous tutorials, where we explained the subdivision of the application into three scenes, how to create a GlobalManager class to share the connection to SmartFoxServer among scenes and how to implement the buddy list, the match-making logic and invitations.

## Setup & run
In order to setup and run the example, follow these steps:

1. unzip the examples package;
2. launch the Godot, click on the Import button and navigate to the Connector folder;
3. click the **Build button** in the top right corner of the Godot editor before running the example;

The client's C# code is in the Godot project's *res://scripts* folder, while the SmartFoxServer 2X client API DLLs are in the *res:// folder*.

## Server-side Extension
The server-side Extension is available in two versions: Java and JavaScript, and the game client expects the Java extension to be deployed. At the end of this article we also explain how to use the JavaScript version. Its is freely avaliable from the SmartFox Website for Download.

http://www.smartfoxserver.com/download/get/316

## Deploy the Java Extension
Copy the TicTacToe/ folder from SFS2X-TicTacToe-Ext/deploy/ to your current SFS2X installation under SFS2X/extensions/ See the Online Documentation for more information on how to install SmartFoxServer on you machine and how to include extensions.

The source code is provided under the SFS2X-TicTacToe-Ext/Java/src folder. You can create and setup a new project in your Java IDE of choice as described in the Writing the first Java Extension document of the Java Extensions Development section. Copy the content of the SFS2X-TicTacToe-Ext/Java/src folder to your Java project' source folder.

## Online Tutorial and Documentation
The base code for this example is the same of the previous one, expanded to implement the new features.

The LobbyManager and GameManager classes have been updated to add the logic related to the Game Room creation and join, and the logic to send invitations.

<p align="center"> 
<img width="720" alt="matchmaking" src="https://github.com/SmartFoxServer/SFS_MatchMaking_GD4/assets/30838007/ebbdeeb0-8914-44ea-a74a-beef6f636f0b">
 </p>

To learn more about this template and how it is configured for establishing a connection and handling basic SmartFoxServer events, go to the online documentation and tutorials linked below.

**SmartFoxServer Example Documentation**   

http://docs2x.smartfoxserver.com/ExamplesGodot/lobby-matchmaking

This online documentation includes:
* Client and Server Code
* Creating the Game Room
* Extension initialization
* Game Start and Player Turns
* Game over and restart
* Using the JavaScript Extension
  
 and further **Resource Links**

http://docs2x.smartfoxserver.com/ExamplesGodot/introduction

 <p align="center"> 
<img width="400" alt="connector-login" src="https://github.com/SmartFoxServer/SFS_Connector_GD4/assets/30838007/a8f025fb-5bc0-4ca6-8ce0-8ec808565303">
 </p>

