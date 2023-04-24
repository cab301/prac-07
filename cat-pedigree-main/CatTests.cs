class CatTests {
    [Test("Cat.IsValidName(null) should return false")]
    public TestResult TestNullCatName() {
        string input = "IsValidName(null)";
        string expectedStr = "false";
        bool actual = Cat.IsValidName(null);
        return new TestResult(input, expectedStr, actual.ToString(), actual == false);
    }

    [Test("Cat.IsValidName(empty string) should return false")]
    public TestResult TestEmptyCatName()
    {
        string input = "";
        string expectedStr = "False";
        bool actual = Cat.IsValidName(input);
        return new TestResult(
            input, 
            expectedStr, 
            actual.ToString(), 
            actual == false);
    }

    [Test("Cat.IsValidName(name of length 9) should return false")]
    public TestResult TestTooLongBoundary()
    {
        string input = "Fluffiest";
        string expectedStr = "False";
        bool actual = Cat.IsValidName(input);
        return new TestResult(
            input,
            expectedStr,
            actual.ToString(),
            actual == false);
    }

    [Test("Cat.IsValidName(name of > 9) should return false")]
    public TestResult TestTooLong()
    {
        string input = "Woolloongabba";
        string expectedStr = "False";
        bool actual = Cat.IsValidName(input);
        return new TestResult(
            input,
            expectedStr,
            actual.ToString(),
            actual == false);
    }

    [Test("Cat.IsValidName(name of length 1) should return true")]
    public TestResult TestValidLower()
    {
        string input = "A";
        string expectedStr = "True";
        bool actual = Cat.IsValidName(input);
        return new TestResult(
            input,
            expectedStr,
            actual.ToString(),
            actual == true);
    }

    [Test("Cat.IsValidName(name of length 8) should return true")]
    public TestResult TestValidUpper()
    {
        string input = "Fluffier";
        string expectedStr = "True";
        bool actual = Cat.IsValidName(input);
        return new TestResult(
            input,
            expectedStr,
            actual.ToString(),
            actual == true);
    }

    [Test("Cat.IsValidName(name of length between 2 and 7) should return true")]
    public TestResult TestValid() {
        string input = "Cat";
        string expectedStr = "True";
        bool actual = Cat.IsValidName(input);
        return new TestResult(
            input,
            expectedStr,
            actual.ToString(),
            actual == true);
    }
}