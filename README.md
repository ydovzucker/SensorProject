

# 🕵️ Iranian Agent Surveillance Simulation

## 🎯 Objective

This is a **surveillance strategy game** where you, the **Investigation Manager**, must track Iranian agents using a network of advanced sensors.

Each agent has hidden vulnerabilities to certain sensors (could be the same sensor multiple times), and you must assign the right sensors to each agent to **maximize detection efficiency**.

Your job:  
Match the right sensors to the right agents — and uncover their weaknesses.

---

## 🧠 How It Works — Program Flow

### 1. System Initialization
- The `InvestigationManager` launches the simulation.
- A single agent (or multiple) is created with:
  - A **name** and **ID**
  - A **vulnerability list** – hidden from the player
  - An **empty attached sensor list**

### 2. Sensor Assignment by Player (Interactive Loop)
- The player is asked to **type the name of a sensor** to attach (e.g., `MotionSensor`).
- The sensor is created and attached to the agent.
- The system checks:
  - How many of the agent's vulnerabilities have been matched so far.
  - For example: `"You matched 1 out of 3 vulnerabilities."`
- This continues **until all vulnerabilities are matched**.

### 3. Victory
- Once the player matches all vulnerabilities, a message like:
  - `"All vulnerabilities matched! Agent fully exposed!"` is shown.

---

## 🔍 Evaluation Logic

Implemented in:
```csharp
public int EvaluateSensorMatch(IranianAgent agent)
