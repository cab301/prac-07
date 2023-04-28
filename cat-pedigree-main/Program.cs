namespace pedigree;
class Program
{
    static void Main(string[] args)
    {
        TestDriver.AddTestClass(typeof(CatTests), typeof(PedigreeTests));
        TestDriver.RunAllTests();
    }
}
