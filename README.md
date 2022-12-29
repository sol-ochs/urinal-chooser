# UrinalChooser

UrinalChooser is a simple console application that, given a row of occupied and unoccupied urinals, will indicate the correct choice of urinal based on a set of rules.

The rules are designed to mimic the unspoken rules of etiquette that are believed to be elemental and self-evident to any modern gentleman.

## Rules

The rules are as follows:
1. Choose the urinal with the maximum distance between it and other occupied urinals.
2. An edge urinal is preferable to a middle urinal.
3. All else equal, choose the nearest urinal.

## Why tho?

I started this as a fun project to work on while I study the F# language.

## Usage

```
Enter a row of urinals as 1s and 0s with 1s indicating 'Occupied' and 0s indicating 'Unoccupied': 
10001
[x][ ][ ][ ][x]
       ^      
```

## Requirements

* F# 7
* .NET 6.0
