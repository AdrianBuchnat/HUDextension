# HUD Extension - Non-Invasive UI Overlay 🎮

A custom, external UI overlay built in **C#** to improve accessibility and user experience in RPG games (specifically tailored for Warcraft 3 custom mods). 

### 🎯 The Problem
In certain dynamic RPG scenarios, the default health bars are too small (often just a few pixels high), making it difficult to track character status during intense gameplay. 

### 💡 The Solution
This application creates a scalable, WoW-style health interface overlay. To ensure complete compliance with the game's engine and avoid intrusive memory injection (which could conflict with anti-cheat systems), the application operates entirely externally.

### ⚙️ How it works (Technical Details)
* **P/Invoke & Windows API:** Uses `user32.dll` to obtain window pointers and interact with the OS layer directly from managed C# code.
* **Real-time Image Processing:** Captures specific screen regions (Region of Interest) rather than hooking into the game's memory.
* **Linear Pixel Analysis:** Analyzes the color values of the captured frames in real-time to calculate the exact percentage of the health bar.
* **Asynchronous Overlay:** Renders a large, readable UI on top of the game window without causing frame drops or performance bottlenecks in the main game loop.

### 🚀 Tech Stack
* **Language:** C# (.NET)
* **Key Concepts:** Interoperability (`DllImport`), Screen Capture Algorithms, UI Overlays, Real-time Performance Optimization.

---
*Note: This project is currently in development (WIP) as I continuously optimize the screen reading algorithms to minimize CPU overhead.*
