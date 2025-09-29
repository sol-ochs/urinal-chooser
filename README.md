# Urinal Chooser

An F# console application that selects the optimal urinal in a row of occupied and unoccupied urinals based on a defined set of rules.

## Why This Project?

I created this project as an exercise to practice F# and functional programming concepts.

## The Algorithm

*"We hold these rules to be self-evident, that not all urinals are created equal."*

Given a row of occupied (1) and unoccupied (0) urinals, the application chooses the optimal urinal based on these hierarchical rules:

1. **Maximum Distance**: Choose the urinal with the greatest distance from any occupied urinal
2. **Edge Preference**: When distances are equal, prefer edge urinals over middle ones
3. **Proximity**: When all else is equal, choose the nearest available option

## Usage

### Run the app
```bash
# from repo root
dotnet run --project src/UrinalChooser/UrinalChooser.fsproj
```

### Example session
```
Welcome to Urinal Chooser!
Enter rows of urinals as 0/1 (1 = occupied, 0 = empty).
Type 'q' to quit.

row> 10001
[x][ ][ ][ ][x]
       ^
```

### Build and test
```bash
# Restore dependencies
dotnet restore UrinalChooser.sln

# Build the solution
dotnet build UrinalChooser.sln

# Run tests
dotnet test UrinalChooser.sln
```

## Requirements

- .NET 10.0 SDK
- F# compiler (included with .NET SDK)
