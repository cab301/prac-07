using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pedigree
{
    public class PedigreeTests
    {
        [Test("Test AddCat to empty pedigree should return true")]
        public TestResult AddCatToEmptyPedigree()
        {
            Pedigree pedigree = new Pedigree();
            string input = "Paws";
            string expectedStr = "True";
            bool actual = pedigree.AddCat(input);
            return new TestResult(
                input,
                expectedStr,
                actual.ToString() + PedigreeToString(pedigree),
                actual == true);
        }

        [Test("Test FindCat of empty pedegree should return false")]
        public TestResult FindCatInEmptyPedigree()
        {
            Pedigree pedigree = new Pedigree();
            string inputStr = PedigreeToString(pedigree);
            string expectedStr = "";
            Cat? actual = pedigree.FindCat("Paws");
            return new TestResult(
                inputStr,
                expectedStr,
                CatToString(actual),
                actual == null);
        }

        static string CatToString(Cat cat)
        {
            if (cat == null) return "";
            return $"({cat.Name}, {cat.Age})";
        }

        static string PedigreeToString(Pedigree pedigree)
        {
            string pedigreeAsStr = "";
            Cat[] arrayOfCats = pedigree.ToArray();
            for (int i = 0; i < arrayOfCats.Length; i++)
            {
                Cat cat = arrayOfCats[i];
                pedigreeAsStr += $"({cat.Name}, {cat.Age})";
                if (i != arrayOfCats.Length - 1) pedigreeAsStr += "\n";
            }
            return pedigreeAsStr;
        }
    }
}
