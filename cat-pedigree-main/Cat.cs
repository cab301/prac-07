/// <summary>
/// A cat in a pedigree of female cats.
/// </summary>
class Cat {
    private string name;
    private int age;
    public string? Name {
        get { return name; }
        set {
            if (!IsValidName(value)) {
                throw new System.ArgumentException("Invalid name");
            }
            name = value;
        }
    }
    public int Age {
        get { return age; }
        set {
            if (!IsValidAge(value)) {
                throw new System.ArgumentException("Invalid age");
            }
            age = value;
        }
    }
    public Cat FirstChild {get; set;}
    public Cat NextSibling {get; set;}

    /// <summary>
    /// Create a cat with a name and age
    /// </summary>
    /// <param name="name">The cat's name</param>
    /// <param name="age">The cat's age</param>
    public Cat(string? name, int age) {
        Name = name;
        Age = age;
    }

    /// <summary>
    /// Check if the name is valid (non-null and non-empty). 
    /// The maximum length of a name is 8 characters.
    /// </summary>
    /// <param name="name">The name to check</param>
    /// <returns>True if the name is non-null and non-empty, false otherwise</returns>
    public static bool IsValidName(string? name) {
        if (name == null) {
            return false;
        }
        return name.Length >= 1 && name.Length <= 8;
    }

    /// <summary>
    /// Check if the age is valid (non-negative, and at most than 30)
    /// </summary>
    /// <param name="age">The age to check</param>
    /// <returns>True if the age is between 0 and 30 (inclusive), false otherwise</returns>
    public static bool IsValidAge(int age) {
        return age >= 0 && age <= 30;
    }
}