class CatTests {
    [Test("Cat.IsValidName(null) should return false")]
    public TestResult TestNullCatName() {
        string input = "IsValidName(null)";
        string expectedStr = "false";
        bool actual = Cat.IsValidName(null);
        return new TestResult(input, expectedStr, actual.ToString(), actual == false);
    }
}