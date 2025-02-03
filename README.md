# Maze Destruction Game

## Overview
This project is a 3D game created using Unity where the player navigates through a destructible maze. The player uses a sledgehammer to destroy blocks while progressing through levels. The maze is procedurally generated based on a `.maz` file, ensuring a unique experience with every playthrough.

## Features

### **Prefabs**
- **Cubes**: Prefabs created for different types of cubes (`R`, `G`, `B`, `T1`, `T2`, `T3`). Each cube has:
  - `Damage.cs` script as a component to manage health and damage
  - Two Box Colliders:
    - Trigger collider for interactions with the hammer
    - Non-trigger collider to ensure cubes are solid
- **Walls**: Prefabs for maze walls (`Wall`) generated dynamically using `CreateMaze.cs`. These walls ensure the player stays within the maze
- **Player**: Player prefab based on Unity's FPSController with modifications for jumping. Uses the default scripts for movement
- **Sledgehammer**: Prefab for the sledgehammer, downloaded from the Unity Asset Store. It is attached to the player to simulate holding the hammer. Includes animations for swinging
- **Particle Effects**: A custom particle effect (`Death-Effect`) simulates the destruction of cubes. The effect involves small cubes flying out and disappearing after landing

### **Scripts**
- **CreateMaze.cs**:
  - Reads the maze layout from a `.maz` file
  - Dynamically generates the maze's cubes, walls, and player placement
  - Ensures the player starts at a "safe" position in the maze
  - Supports game termination with the `X` key and completion at level `L` by pressing `E`

- **Hammer.cs**:
  - Handles hammer animations and interactions with cubes
  - Reads the number of hammers (`K`) from the `.maz` file
  - Reduces the hammer's durability with every hit, changing its color from red to black using pre-made textures
  - Reduces the health of cubes it strikes

- **Damage.cs**:
  - Component attached to cubes to manage their health
  - Reduces cube health when hit by the hammer

## How to Run the Game
1. **Unity Version**: 
   - The game runs on Unity versions 2018.4.14f1 (LTS Release) and 2019.2.17f1
   - It may run with errors on other versions, such as those used in PEP II lab systems

2. **Setup**:
   - Open the project in Unity
   - Ensure the `Assets` folder is included in your Unity project directory

3. **Play the Game**:
   - Press `Play` in the Unity Editor to start the game
   - Use the following keys for interactions:
     - `X`: End the game
     - `E`: Complete the level when on the final level `L`

## Controls
- **Mouse**: Look around
- **WASD**: Move the player
- **Spacebar**: Jump
- **Left Mouse Button**: Use the sledgehammer to destroy cubes
- **X**: Exit the game
- **E**: Finish the game on level `L`
