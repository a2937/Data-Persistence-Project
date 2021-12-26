# Data-Persistence-Project
 
A completion of a Unity tutorial dealing with data persistence. The goal is to have scene data transfer 
scene to scene; and have data saved after a session is ended. The minigame used to demonstrate this 
is Arknoid (commonly known as BrickBreaker) in which you fire a ball at bricks and increase your
score by breaking the blocks. When all the bricks are gone; the game ends. It is a live at [Unity Play](https://play.unity.com/mg/other/webgl-builds-124996).

## Getting Started

Clone the Github repo using ssh and open up the project in Unity. 

### Prerequisites

What things you need to install the software and how to install them

`
[Unity Hub](https://unity.com/download)
`

`
[Visual Studio Code](https://code.visualstudio.com/)
`

Download these and the run the installers. 

## Running the tests 

In Unity ; open up the Test Runner Window (Window > General > Test Runner). In the Window , 
make the PlayMode button get pressed in. Then it "Run all". 

### Break down into end to end tests

`
Player Name tests:  
  - Ensure the name is trimmed: Extra spaces at the end could destroy alignment in the score bar
  - Ensure player name is set and shown on screen: Players need to see their scores with their names
  - Ensure players can't be nameless: A name needs to be shown in the credits in order to look correct
  - Ensure the default player name isn't null:  A name needs to be shown in the credits in order to look correct
`

`
Serialization tests: 
  - Ensure only the top ten scores at most are written to a file: Data will exponentially grow if scores kept 
  getting added and added to high score list 
`

`
Display tests: 
  - Ensure that the high score text is formatted correctly at start: The player needs to see text on one line at start
  - Ensure that the score text is formatted correctly at start: The player needs to see text on one line at start
  - Ensure that the high score text is formatted correctly with a huge score during play:
     The player needs to see text on one line for it to look right
  - Ensure that the score text is formatted correctly at with a huge score during play: 
      The player needs to see text on one line for it to look right
  - Ensure that the game over text is deactivated during play: If the game over text is accidentally left active during the 
    hierarchy ; the player won't see it when the game is boot up. 
  - Ensure that the game over text is activated at game over: If the game over text doesn't appear; the player
      will be very confused
`


### And coding style tests

The Editorconfig dictates the style the code should be in. It is loosely 
based off of my research of the C# compiler's preferred options. 

### Brand new Implemented Features

[X] Main Menu with start button added

[X] Quit Button on Main Menu

[X] Player's name persists across scenes

[X] Player name displayed with the score

[X] Top High Scores persists across sessions

[X] Top High score displays the name

[X] Background Music

[X] Basic sound effects 

## Built With

* [Unity 3D](https://unity.com) - The framework used

## Versioning

[SemVer](http://semver.org/) will be used for versioning. 

## Authors

* **Unity Technologies** - *Initial work* - [Unity Technologies](https://learn.unity.com/tutorial/submission-data-persistence-in-a-new-repo?uv=2020.3&labelRequired=true&pathwayId=5f7e17e1edbc2a5ec21a20af&missionId=5f751af7edbc2a0022cdbbb6#)

* **FFonts** - *Usage of the CCO 8bit font* - [Font link](https://www.ffonts.net/8BIT-WONDER-Nominal.font.download)

* **OpenGameArt** - *Hosting the CCO music and sounds I used* - [Open Game Art](https://opengameart.org/)
## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Unity Staff for coming up with the tutorial for the project

* Open Game Art for their CCO music and sound effects