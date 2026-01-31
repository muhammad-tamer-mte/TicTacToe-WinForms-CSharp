# Tic-Tac-Toe Game (C# WinForms)
![.NET](https://img.shields.io/badge/.NET-4.8-blue)
![License](https://img.shields.io/badge/license-MIT-green)

- Language: C#
- Framework: .NET Framework 4.8
- Type: Windows Forms
- Description: Classic Tic Tac Toe game with UI

A classic **Tic-Tac-Toe game** built with **C#** and **Windows Forms (.NET Framework)**.  
This game supports **Player vs Player (PvP)** and **Player vs Computer (PvC)** modes with a simple, interactive GUI.

* * *

## 🎮 Features

-   **Two Game Modes:**
    
    -   Player vs Player (PvP)
        
    -   Player vs Computer (PvC) using simple random move selection (not AI-based)
        
-   **Dynamic Form Layout:** Automatically resizes for different game modes  
    
-   **Customizable Player Names** and character choice (**X** or **O**)
    
-   **Interactive GUI:** Clickable cells with instant feedback
    
-   **Win Detection:** Highlights the winning combination
    
-   **Draw Detection:** Recognizes tied games
    
-   **Reset & Replay:** Restart the game at any time
    
-   **Back to Menu:** Return to main menu without restarting the app
    

* * *

## 📸 Screenshots

### Initial Version
![](screenshots/initial/main-menu.png)

### Version 1.0
| Main Menu | Gameplay |
| --- | --- |
| ![](screenshots/v1/main-menu.png) | ![](screenshots/v1/gameplay.png) |

* * *

## 💻 Installation

1.  Clone the repository:
    
    `git clone https://github.com/your-username/TicTacToe-WinForms.git`
    
2.  Open the solution file in **Visual Studio**.
    
3.  Build and run the project.
    

* * *

## ⚙️ Project Structure

CSharp/  
└── WinForms/  
  └── TicTacToe/  
    ├── frmStart.cs # Main menu and game setup  
    ├── frmGame.cs # Game logic and gameplay UI  
    ├── Program.cs # Entry point  
    ├── TicTacToe.sln # Visual Studio solution file  
    └── Properties/  
      └── Resources.resx # X and O images

* * *

## 📝 How to Play

1.  Open the game in Visual Studio or run the compiled executable.
    
2.  Choose a game mode (PvP or PvC).
    
3.  Enter player names and select a character (X or O).
    
4.  Click on a cell to place your mark.
    
5.  The game automatically checks for winners or draws.
    
6.  Use **Reset** to replay or **Back** to return to the menu.
    

* * *

## 🚀 Future Improvements

-   Implement a smarter AI for PvC mode
    
-   Add animations and sound effects
    
-   Add multiple game themes

-   Track player scores across sessions
    

## 📄 License

This project is open-source and available under the **MIT License**.