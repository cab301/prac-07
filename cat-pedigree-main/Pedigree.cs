class Pedigree {
    private Cat? root;

    public Pedigree(){
        root = null;
    }

    /// <summary>
    /// Create a new cat, optionally with a mother cat.
    /// 
    /// Precondition: 
    /// - No cat in the pedigree has the same name as the new cat.
    /// - The new cat's name is valid.
    /// - If the mother cat is not null, the mother cat must exist in the pedigree.
    /// 
    /// Postcondition:
    /// - If the root is null, the new cat is created as the root.
    /// - If the mother cat is not null, the new cat is added as the last child of the mother cat, or the first child if the mother cat has no children.
    /// - If the mother cat is null, the new cat is added as the last cat in the pedigree, by breadth-first search.
    /// - The cat is added to the pedigree.
    /// - The cat's age is set to 0.
    /// 
    /// If the precondition is met, the method returns true.
    /// 
    /// If the precondition is not met, the pedigree is not modified, and the method returns false.
    /// 
    /// </summary>
    /// <param name="catName">The name of the new cat</param>
    /// <param name="motherName">(Optional) the name of the mother cat. Defaults to null.</param>
    /// <returns>true if the new cat was added successfully, false otherwise</returns>
    public bool AddCat(string catName, string? motherName = null) {
        // If the root is null, create the new cat as the root
        Cat newCat = new Cat(catName, 0);
        if (root == null)
        {
            root = newCat;
            return true;
        }

        // If the cat already exists, return false
        Cat? catMatchingName = FindCat(catName);
        if (catMatchingName != null) return false;

        // Find the mother cat
        if (motherName != null)
        {
            Cat? motherCat = FindCat(motherName);
            // If mother not found, return false.
            if (motherCat == null) return false;

            // If found, check if there is any sibling
            Cat? sibling = motherCat.FirstChild;

            // If the mother cat has no children, make the new cat the first child of the mother cat
            if (sibling == null)
            {
                motherCat.FirstChild = newCat;
                return true;
            } 
            // Otherwise, find the last sibling
            else
            {
                // If the mother cat has children, make the new cat the last child of the mother cat
                while (sibling.NextSibling != null)
                {
                    sibling = sibling.NextSibling;
                }
                sibling.NextSibling = newCat;
                return true;
            }
        }
        // If the mother cat is not given, make the new cat the last cat in the pedigree by depth-first search
        else
        {
            Stack<Cat> stack = new Stack<Cat>();
            Cat lastCat = null;
            stack.Push(root);
            while (stack.Count > 0)
            {
                Cat? r = stack.Pop();
                while (r != null)
                {
                    // Visit == setting the LastCat to the current one
                    lastCat = r;
                    if (r.NextSibling != null) stack.Push(r.NextSibling);
                    r = r.NextSibling;
                }
            }
            lastCat.NextSibling = newCat;
            return true;
        }
    }

    /// <summary>
    /// Find a cat in the pedigree by name through a breadth-first search.
    /// 
    /// Precondition:
    /// - The cat must exist in the pedigree.
    /// 
    /// Postcondition:
    /// - The pedigree is not modified.
    /// 
    /// If the cat is found, the method returns the cat.
    /// 
    /// If the cat is not found, the method returns null.
    /// 
    /// </summary>
    /// <param name="name">The name of the cat to find</param>
    /// <returns>The cat if found, null otherwise</returns>
    public Cat? FindCat(string name){
        if (root == null) return null;
        // Find a cat using a breath-first search
        Queue<Cat> queue = new Queue<Cat>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            Cat r = queue.Dequeue();
            // Checking the cat's identity
            if (r.Name == name) return r;
            while (r != null)
            {
                queue.Enqueue(r);
                // Add all children to the queue
                r = r.NextSibling;
            }
        }

        // If the cat is not found, return null
        return null;
    }

    /// <summary>
    /// Convert the pedigree to an array by depth-first search.
    /// 
    /// Precondition: N/A
    /// 
    /// Postcondition:
    /// - The pedigree is not modified.
    /// 
    /// If the pedigree is empty, the method returns an empty array.
    /// 
    /// If the pedigree is not empty, the method returns an array of cats, where the first cat is the root, and the last cat is the last cat in the pedigree by depth-first search.
    /// 
    /// </summary>
    /// <returns>The pedigree as an array</returns>
    public Cat[] ToArray(){

        Stack<Cat> stack = new Stack<Cat>();
        List<Cat> cats = new List<Cat>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            Cat? r = stack.Pop();
            while (r != null)
            {
                // Visit == setting the LastCat to the current one
                cats.Add(r);
                if (r.NextSibling != null) stack.Push(r.NextSibling);
                r = r.NextSibling;
            }
        }
        return cats.ToArray();
    }
}