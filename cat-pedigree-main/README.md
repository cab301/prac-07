# Cat Pedigree - Application of Tree Algorithms [[Download Template](https://github.com/cab301/archive/main.zip)]

In this exercise, you will work with two Abstract Data Types, a `Cat` and a `Pedigree`. A `Cat` is a node in the `Pedigree` tree, containing a cat's name and age.

## The Pedigree Tree

The `Cat` class has already been implemented for you, with the following conditions:
- A cat's name must not be null or empty, or longer than 8 characters.
- A cat's age must be between 0 and 30, inclusive.
- Each cat has a reference to its first child, and a reference to its next sibling.

You will need to implement the `Pedigree` class and the following methods:
- **bool AddCat(string catName, string? motherName = null)**: Adds a cat to the pedigree. If the motherName is null, the cat is added to the end of the tree by **depth-first search**. If the motherName is not null, the cat is added as a child of the cat with the given motherName.
- **Cat? FindCat(string catName)**: Returns the cat with the given name, found by **breath-first-search**. If no cat with the given name exists, returns null.
- **Cat[] ToArray()**: Returns an array of all cats in the pedigree, ordered by **depth-first search**.

## Testing

Also create a test plan for both classes, make sure you include valid, invalid and boundary cases. You may use the `TestDriver` class to test your implementation. A test looks like this:

```csharp
class CatTests {
    [Test("Cat.IsValidName(null) should return false")]
    // Each test method must return a TestResult object
    public TestResult TestNullCatName() {
        string inputStr = "IsValidName(null)";
        string expectedStr = "false";
        bool actual = Cat.IsValidName(null);
        // A test result contains:
        // - The string representation of the input
        // - The string representation of the expected output
        // - The string representation of the actual output
        // - A boolean indicating whether the test passed
        return new TestResult(input, expectedStr, actual.ToString(), actual == false);
    }
}
```

After creating the test class, add the following to the `Main` method in `Program.cs`:

```csharp
TestDriver.AddTestClass(typeof(CatTests));
TestDriver.RunAllTests();
```

The output should look like this:

```
╔══════════════════CatTests═══════════════════╗
╟──Cat.IsValidName(null) should return false──╢
> Input:    IsValidName(null)
> Expected: false
> Actual:   False
╟───────────────────Passed────────────────────╢
╠═════════════════════════════════════════════╣
╠════════════════Test Summary═════════════════╣
Passed:
> Cat.IsValidName(null) should return false
───────────────────────────────────────────────
Failed:
╙────────────────1 / 1 passed─────────────────╜
```