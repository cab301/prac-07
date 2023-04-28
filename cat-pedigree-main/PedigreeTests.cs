using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace pedigree
{
    internal class PedigreeTests
    {
        [Test("Add cat with invalid name to empty pedigree should return false")]
        public TestResult AddCatWithInvalidNameToPedigree()
        {
            Pedigree pedigree = new Pedigree();
            bool result = pedigree.AddCat(null);
            string inputStr = "AddCat(null) to Empty pedigree";
            string expectedOutputStr = "False";
            string actualStr = result.ToString();
            bool passingCondition = result == false;
            return new TestResult(inputStr, expectedOutputStr, actualStr, passingCondition);
        }

        [Test("Add cat with valid name to empty pedigree should return true")]
        public TestResult AddValidCatToEmptyPedigree()
        {
            Pedigree pedigree = new Pedigree();
            bool result = pedigree.AddCat("Paws");
            string inputStr = "AddCat(Paws) to Empty pedigree";
            string expectedOutputStr = "True. Pedigree should contain Paws\n";
            string actualStr = result + ". " + DisplayPedigree(pedigree);
            bool passingCondition = result == true;
            return new TestResult(inputStr, expectedOutputStr, actualStr, passingCondition);
        }

        static string DisplayPedigree(Pedigree pedigree)
        {
            string pedigreeAsStr = "Pedigree:\n";
            Cat[] cats = pedigree.ToArray();
            foreach (Cat cat in cats)
            {
                pedigreeAsStr += DisplayCat(cat) + "\n";
            }
            return pedigreeAsStr;
        }

        static string DisplayCat(Cat cat)
        {
            string catAsStr = $"{cat.Name} ({cat.Age})";
            if (cat.NextSibling != null) catAsStr +=
                    $" and has next sibling in {cat.NextSibling.Name}";
            if (cat.FirstChild != null) catAsStr +=
                    $" and has first child in {cat.FirstChild.Name}";
            return catAsStr;
        }
    }
}
