# Water Jug Problem Solver

This project provides a solution to the classic Water Jug Problem using .NET Core 6 and C#. The problem is solved using a breadth-first search algorithm to explore all possible states of the jugs.

## Algorithmic Approach

The solution to the water jug problem is found using a breadth-first search (BFS) algorithm. BFS is an algorithm for traversing or searching tree or graph data structures. It starts at the tree root (or some arbitrary node of a graph, sometimes referred to as a 'search key') and explores the neighbor nodes at the present depth prior to moving on to nodes at the next depth level.

## Test Cases for Validation

Here are some test cases you can use to validate the solution:

1. Test Case 1: `x = 10, y = 2, z = 4`
   Expected Outcome: A list of actions that leads to either jug containing 4 liters of water.

2. Test Case 2: `x = 100, y = 2, z = 96`
   Expected Outcome: A list of actions that leads to either jug containing 96 liters of water.

3. Test Case 3: `x = 2, y = 6, z = 5`
   Expected Outcome: "No Solution", as it's impossible to measure 5 liters of water with jugs of 2 and 6 liters.

## Running the Tests

To run the tests, follow these steps:

1. Open your project in Visual Studio.
2. Build your solution.
3. Open the Test Explorer window (go to Test > Windows > Test Explorer).
4. Click on "Run All" in the Test Explorer window to run all your tests.

The tests will then run, and you'll be able to see the results in the Test Explorer window. If a test fails, you can click on it to see more details about what went wrong.

## Instruction to Run the Program

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Run the program using the .NET CLI: `dotnet run`.
4. Upon running the program, a Swagger window will open where you can manually test the endpoint.

## Contributing

Contributions are welcome! Please read the contributing guidelines before getting started.

## License

This project is licensed under the terms of the MIT license. See the LICENSE file for details.
