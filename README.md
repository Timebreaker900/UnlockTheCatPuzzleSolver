## UnlockTheCat Pizzle Solver 🚀

A simple command-line solver for the "Unlock The Cat" puzzle game. 
This tool takes a block configuration and finds the sequence of moves to slide the cat block (ID 0) out of the grid.

### 🔧 Prerequisites
.NET 6.0 SDK or newer installed (Download)

Windows, macOS or Linux

IDE: Some Program that can run .cs files

### ⚙️ Configuration

Open Program.cs and locate the initial block list in Main():

```
    // Blocks: ID = 0 is the cat block, others are obstacles
    var blocks = new List<Block> {
    new Block(1, 0, 0, 2, true),    // B1: row 1, cols 1–2 (horizontal)
    // …
    new Block(0, 2, 1, 2, true),    // Cat: row 3, cols 2–3 (horizontal)
    // …
    };
```

Edit the row, col, length, and isHorizontal values to match your puzzle layout. You can refer to docs/grid-layout.png for coordinate mapping.

❗ Example:
![img.png](img.png)

```
    // Blocks: ID = 0 is the cat block, others are obstacles
    var blocks = new List<Block> {
    new Block(1, 0, 0, 2, true),    // B1: row 1, cols 1–2 (horizontal)
    // …
    new Block(0, 2, 1, 2, true),    // Cat: row 3, cols 2–3 (horizontal)
    // …
    };
```


### 📄 License

This project is licensed under the MIT License. See the LICENSE file for details.