# Iranian Agent Surveillance Simulation

## 🕵️ Overview

This project simulates a **surveillance-based strategy game**, where the goal is to monitor Iranian agents by attaching different types of sensors to them. Each agent has **specific sensor vulnerabilities**, and the player (the "Investigation Manager") must determine the most effective way to track agents by matching the correct sensors to their weaknesses.

## 🎯 Objective

As the **Investigation Manager**, your task is to:

1. Assign sensors (e.g., motion sensors) to Iranian agents.
2. Each agent has a hidden **list of sensor vulnerabilities**.
3. Your goal is to **maximize detection effectiveness** by attaching sensors that match the agent's vulnerabilities.
4. The system compares the assigned sensors to the vulnerability list and calculates a **match score** (match rate).

The game is about **logic, pattern recognition, and partial information**. You don’t know the vulnerabilities of the agents ahead of time – you must figure them out based on trial, deduction, or rules added later in the simulation.

---

## 🧱 Project Structure

- **`Sensor` (abstract)**: Base class for all sensors. Has a name and an activation mechanism.
  - `MotionSensor` – a sample concrete implementation.
- **`IranianAgent` (abstract)**: Base class for all agent types. Holds:
  - Agent name and ID.
  - A private list of sensors the agent is vulnerable to.
  - A private list of attached sensors.
- **Agent types**:
  - `JuniorAgent`
  - `SectionChief`
  - `UnitCommander`
  - `HighCommander`
- All agent types inherit from `IranianAgent` and may later include logic for specific vulnerabilities.
- **`InvestigationManager`**:
  - Entry point of the simulation.
  - Responsible for managing the game.
  - Runs the simulation with a welcome message and game loop (TBD).
  - **Includes the matching logic between sensors and vulnerabilities**.

---

## 🔍 Planned Feature: Sensor Match Evaluation

In the `InvestigationManager` class, a method will be added to compare each agent's **attached sensors** with their **vulnerability list**, calculating the **sensor match rate**. This score will be used to determine how effectively the agent is being tracked.

Example method signature:

```csharp
public int EvaluateSensorMatch(IranianAgent agent)
# SensorProject
