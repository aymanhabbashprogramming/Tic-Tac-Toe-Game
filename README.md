# Tic Tac Toe Game X - O

![Game Screenshot](images/screenshot.png)

A simple Tic Tac Toe desktop game developed using **C#** and **Windows Forms**.

This project was created as a learning project to practice desktop application development, game logic, and different programming techniques.

---

## ✨ Features

* Two-player game (Player 1 vs Player 2)
* Turn-based gameplay
* Prevents selecting an occupied cell
* Automatically detects the winner
* Detects draw games
* Highlights the winning row, column, or diagonal
* Restart button to start a new game
* The game board is drawn manually using the **Graphics** class and the **Paint** event

---

## 🕹️ How to Play

* Player 1 starts with **X**.
* Player 2 plays with **O**.
* Players take turns selecting an empty cell.
* The first player to complete a row, column, or diagonal wins.
* If all cells are filled without a winner, the game ends in a draw.

---

## 🧠 How Winner Detection Works

One of the main ideas in this project is using **binary numbers (bit patterns)** instead of checking every possible winning combination manually.

Each cell on the board represents one bit.

When a player selects a cell, the corresponding bit is turned on.

The program stores all possible winning combinations as binary patterns.

After every move, the player's bits are compared with these patterns using **Bitwise Operations**.

This approach makes winner detection simple, fast, and easy to maintain.

The same binary logic is also used to detect a draw by checking whether all board positions have been occupied.

---

## 🎨 Drawing the Game Board

The game grid is not created using button borders.

Instead, it is drawn manually using the **Graphics** class inside the **Paint** event.

This provides better control over the appearance of the board while giving practical experience with custom drawing in Windows Forms.

---

## 🛠️ Technologies Used

* C#
* Windows Forms
* Graphics (GDI+)
* Bitwise Operations
* Visual Studio

---

## 📋 Requirements

* Windows OS
* Visual Studio
* .NET Framework