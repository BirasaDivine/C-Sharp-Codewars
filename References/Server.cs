public class Server : ISystem {
    public string Status { get; set; }

    public void Operate() {
        Console.WriteLine($"Server is {Status}");
    }
}