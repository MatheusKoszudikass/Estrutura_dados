var listEmail = new List<string>{"@gmail.com", "@hotmail.com", "@yahoo.com", "@outlook.com"};

var stack = new Stack<string>();

foreach (var email in listEmail)
{
    stack.Push(email);

    Console.WriteLine();
    Console.WriteLine($"Adicionado à pilha: {email}");

    var result = Send(stack);
    Console.WriteLine($"Removido da pilha: {result}");
}

static T Send<T>(Stack<T> stack)
{
    Task.Delay(999999999);
    ViewList(stack, "Pilha antes de remover");

    var removedItem = stack.Pop();
    ViewList(stack, "Pilha após remover");

    return removedItem;
} 

static void ViewList<T>(Stack<T> List, string message)
{
    foreach (var item in List)
    {
        Console.WriteLine($"{message} {item}");
    }
}
