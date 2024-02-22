# Water Jug Challenge Solver

This C# application solves the Water Jug Challenge, measuring a target amount of water using two jugs with different capacities.

## Functionality

- User can input jug capacities and target amount (command-line or UI).
- Application finds the most efficient solution using BFS algorithm.
- Displays step-by-step actions or "No Solution" if not possible.

## Running the Application

- Clone or download the repository.
- Build the solution in Visual Studio (or your IDE).
- Run the `WaterJugChallenge` executable (or use the API endpoint).
- Enter jug capacities and target amount (command-line) or use the UI controls.
- The solution will be displayed.

## Algorithmic Approach

The solver uses Breadth-First Search (BFS) to explore all possible states of the jugs, starting from the initial state. It tracks visited states to avoid revisiting and finds the shortest path to the target amount.

## Test Cases

- Jug1: 3, Jug2: 5, Target: 4 (Solution: Fill Jug1, Transfer to Jug2, Fill Jug1, Transfer to Jug2)
- Jug1: 2, Jug2: 6, Target: 5 (No Solution)
- Jug1: 4, Jug2: 9, Target: 7 (Solution: Fill Jug1, Transfer to Jug2, Fill Jug2, Empty Jug2, Transfer from Jug1 to Jug
