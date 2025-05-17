## Rocket Ascend: Mechanics and Technical Details

---

### Rocket-Jump Mechanic

- **Core Mechanic:** The central feature of Rocket Ascend is rocket-jumping. Players aim a bazooka (using the mouse) and fire downward to propel themselves upward. This mechanic is physics-based, requiring precise timing and aim to control momentum and trajectory through vertical levels.
- **Physics Implementation:** The rocket-jump uses a custom explosion force system. When the bazooka is fired, an explosion applies a force to the player’s Rigidbody2D, pushing them away from the blast point. The force is carefully balanced so that the player is propelled upward without excessive knockback or instability. The system also considers the player’s distance from the explosion and their current mass to ensure consistent jump heights.
- **Player Mass Handling:** The player’s mass dynamically changes depending on their state (grounded or airborne) and when under the effect of jump boosts. Adjusting mass is crucial for making rocket-jumps feel responsive and consistent, especially when chaining jumps or using boosters.

---

### Movement and Control

- **Basic Controls:**  
  - `A`/`D`: Move left/right  
  - `Space`: Jump  
  - `S`: Crouch (reduces hitbox and slows movement)  
  - Mouse: Aim bazooka  
  - Left Click: Shoot
- **Boosters:**  
  - **Speed Boosts (rockets):** Temporarily increase horizontal speed, making movement and jumps more sensitive and challenging.
  - **Jump Boosts (coils):** Temporarily reduce player mass, allowing for higher rocket-jumps and more agile movement.

---

### Level and Obstacle Design

- **Verticality:** Levels are designed to be vertically oriented, requiring players to use rocket-jumps to ascend. Platform distances and ramp angles are set to challenge the player’s mastery of the rocket-jump mechanic.
- **Obstacles:** Include traps (such as spikes that reset progress), moving platforms, bouncy or slippery surfaces (erasers and highlighters), and checkpoints. These elements interact with the rocket-jump physics, demanding precise control and timing.
- **Momentum:** Chaining rocket-jumps can accelerate the player’s ascent, but also increases the risk of falling, adding a layer of skill and risk management.

---

### Technical Systems

- **Engine & Structure:** Built in Unity with C#. The project is modular, with separate scripts for player movement, shooting, physics, audio, UI, and level management.
- **Collision Detection:** Uses a combination of composite and polygon colliders for accurate physics interactions, especially important for the rocket-jump and player movement.
- **Boost Implementation:** Boost items trigger temporary changes in player speed or mass, managed with coroutines to ensure effects are time-limited and reset correctly.
- **Checkpoint System:** Allows players to respawn at the last checkpoint after falling or hitting hazards, supporting smoother play and faster iteration during speedruns.
- **Optimization:** Uses tilemaps for efficient asset management and performance, particularly important for larger, continuous maps.

---

### Audio and Feedback

- **Audio Feedback:** Distinct sound effects for rocket jumps, explosions, pickups, deaths, and checkpoints provide immediate feedback and enhance immersion.
- **UI:** Minimalist, showing only essential information like completion time and rocket jumps used, to keep the focus on gameplay and speedrunning.

---

### Development Challenges

- **Physics Balancing:** Fine-tuning explosion forces and mass adjustments to make rocket-jumping feel fair, consistent, and fun.
- **Camera Control:** Implementing a smooth camera that follows the player’s rapid movements without disrupting gameplay.
- **Playtesting:** Iterative feedback led to improvements in accessibility, collision detection, and the removal of unnecessary collectibles, focusing the challenge on skillful movement and timing.

---

### Summary

Rocket Ascend’s technical core is built around a robust, physics-driven rocket-jump mechanic, with dynamic player mass, precise collision handling, and responsive controls. The game’s systems are designed to challenge players’ mastery of movement and reward skillful, optimized play.

