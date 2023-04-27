using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pedigree
{
    internal class PedigreeTests
    {
        // Helper methods
        static string CatToString(Cat cat)
        {
            if (cat == null) return "null";
            string str = $"{cat.Name} ({cat.Age})";
            if (cat.NextSibling != null)
            {
                str = str + $" and has sibling {cat.NextSibling.Name}";
            }
            if (cat.FirstChild != null)
            {
                str = str + $" and has child {cat.FirstChild.Name}";
            }
            return str;
        }

        static string PedigreeToString(Pedigree pedigree)
        {
            string str = "Pedigree:\n";
            foreach (Cat cat in pedigree.ToArray())
            {
                str += CatToString(cat) + "\n";
            }
            return str;
        }

        [Test("ToArray empty pedigree should return array of length 0 when using ToArray")]
        public TestResult EmptyPedigree()
        {
            Pedigree pedigree = new Pedigree();
            // Check that the pedigree is empty
            Cat[] cats = pedigree.ToArray();
            string inputAsStr = PedigreeToString(pedigree);
            string expectedOutputAsStr = "0";
            int actual = cats.Length;
            bool passingCondition = cats.Length == 0;
            return new TestResult(inputAsStr, expectedOutputAsStr, actual.ToString(), passingCondition);
        }

        static void AddOneCatToEmptyPedigree()
        {
            Pedigree pedigree = new Pedigree();
            pedigree.AddCat("Paws");
            // Check that the pedigree is empty
            Cat[] cats = pedigree.ToArray();
            Console.WriteLine($"{cats.Length} cats found");
            foreach (Cat cat in cats)
            {
                Console.WriteLine($"{cat.Name} ({cat.Age})");
            }
        }

        [Test("AddCat add multiple cats to empty pedigree should make a pedigree of multiple cats")]
        public TestResult AddMultipleCatsToEmptyPedigree()
        {
            Pedigree pedigree = new Pedigree();
            pedigree.AddCat("Paws");
            pedigree.AddCat("Fluffy");
            pedigree.AddCat("Bunny");
            pedigree.AddCat("Cloud");
            // Check that the pedigree is empty
            Cat[] cats = pedigree.ToArray();
            return new TestResult(
                Input: "[Paws, Fluffy, Bunny, Cloud] with no mothers",
                Expected: "[Paws, Fluffy, Bunny, Cloud] all with age 0",
                Actual: PedigreeToString(pedigree),
                Passed: cats.Length == 4 && cats[0].Name == "Paws" && cats[0].Age == 0 
                && cats[3].Name == "Cloud" && cats[3].Age == 0
            );
        }

        static void AddCatsToValidMothers()
        {
            Pedigree pedigree = new Pedigree();
            pedigree.AddCat("Paws");
            pedigree.AddCat("Fluffy", "Paws");
            pedigree.AddCat("Bunny", "Fluffy");
            pedigree.AddCat("Cloud", "Paws");

            Cat[] cats = pedigree.ToArray();
            Console.WriteLine($"{cats.Length} cats found");
            foreach (Cat cat in cats)
            {
                Console.WriteLine(CatToString(cat));
            }
        }

        static void AddCatsToInvalidMother()
        {
            Pedigree pedigree = new Pedigree();
            pedigree.AddCat("Paws");
            pedigree.AddCat("Cloud", "Fluffy");

            Cat[] cats = pedigree.ToArray();
            Console.WriteLine($"{cats.Length} cats found");
            foreach (Cat cat in cats)
            {
                Console.WriteLine(CatToString(cat));
            }
        }

        static void FindCatPedigreeEmpty()
        {
            Pedigree pedigree = new Pedigree();

            Cat cat = pedigree.FindCat("Paws");
            Console.WriteLine(CatToString(cat));
        }

        static void FindCatPedigreeSizeOne()
        {
            Pedigree pedigree = new Pedigree();
            pedigree.AddCat("Paws");

            Cat cat = pedigree.FindCat("Paws");
            Console.WriteLine(CatToString(cat));
        }
    }
}
