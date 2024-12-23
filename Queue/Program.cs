var queue = new Queue<string>();

Add(queue, "@gmail.com");
Add(queue, "@hotmail.com");
Add(queue, "@yahoo.com");
Add(queue, "@outlook.com");
Add(queue, "");

var cts = new CancellationToken();

await Task.WhenAll(ProcessQueue(queue, cts), OtherMethod(cts));

static bool Add(Queue<string> queue, string email)
{
    queue.Enqueue(email);
    Console.WriteLine($"Enfileirado: {email}");
    return true;
}

static async Task ProcessQueue(Queue<string> queue, CancellationToken cts)
{
    for(int i = queue.Count -1 ; i >= 0; i--)
    {
        var result = await Send(queue.Peek(), cts);
        if(result == true)
        {
          var item = queue.Dequeue();
          Console.WriteLine($"Removido da fila: {item}");
          
        }
        else
        {
         Console.WriteLine($"Item não é válido: {result}");

        }
    }
    Console.WriteLine("A fila está vazia");
}

//E apenas um teste. Eu sei que eu deveria colocar a validação no metodo add.
static async Task<bool> Send(string email, CancellationToken cts)
{
    if(string.IsNullOrEmpty(email))return false;

    await Task.Delay(10);
    Console.WriteLine($"Processando: {email}");
    return true;
}

static async Task OtherMethod(CancellationToken cts)
{
    for(long i = 0; i < 5; i++ )
    {
        await Task.Delay(11);
        Console.WriteLine($"Outros processos assíncronos {i}");
    }
}