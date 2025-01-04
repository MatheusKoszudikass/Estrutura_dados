
var bst = new BinarySearchTree();

bst.Insert(50);
bst.Insert(30);
bst.Insert(70);
bst.Insert(20);
bst.Insert(40);
bst.Insert(60);
bst.Insert(80);

Console.WriteLine("Árvore em ordem:");
bst.InOrderTraversal();

Console.WriteLine($"\nBuscando valor 40: {(bst.Search(40) ? "Encontrado" : "Não encontrado")}");
Console.WriteLine($"Buscando valor 90: {(bst.Search(90) ? "Encontrado" : "Não encontrado")}");

internal record Node(int Data)
{
    public Node? Left;
    public Node? Right;
}

internal class BinarySearchTree
{
    private Node? _root;

    public void Insert(int value)
    {
        _root = InsertRecursively(_root, value);
    }

    private static Node? InsertRecursively(Node? root, int value)
    {
        return root switch
        {
            null => new Node(value),
            _ when value < root.Data => root with { Left = InsertRecursively(root.Left, value) },
            _ when value > root.Data => root with { Right = InsertRecursively(root.Right, value) },
            _ => root
        };
    }

    public bool Search(int value)
    {
        return SearchRecursively(_root, value);
    }

    private static bool SearchRecursively(Node? root, int value)
    {
        return root switch
        {
            null => false,
            _ when value < root.Data => SearchRecursively(root.Left, value),
            _ when value > root.Data => SearchRecursively(root.Right, value),
            _ => true
        };
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRecursively(_root);
        Console.WriteLine();
    }

    private static void InOrderTraversalRecursively(Node? root)
    {
        if (root == null) return;
        InOrderTraversalRecursively(root.Left);
        Console.Write(root.Data + " ");
        InOrderTraversalRecursively(root.Right);
    }
}
