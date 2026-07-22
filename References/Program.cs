using System;

public class Program {
  public static void Main(string[] args) {

   
    FieldAgent agent1 = new FieldAgent();
    agent1.Name = "Agent Smith";
    agent1.SecretCode = 007;

    FieldAgent agent2 = agent1; 
    agent2.SecretCode = 999;

    Console.WriteLine($"agent1 SecretCode: {agent1.SecretCode}");
    Console.WriteLine($"agent2 SecretCode: {agent2.SecretCode}");

    
    File file1 = new File();
    file1.FileName = "Confidential.txt";
    file1.FileSize = 1024;

    File file2 = new File();
    file2.FileName = "Confidential.txt";
    file2.FileSize = 1024;

    bool sameFile = file1 == file2;
    Console.WriteLine($"sameFile: {sameFile}");

    
    Server mainServer = new Server();
    mainServer.Status = "Active";

    Server backupServer = new Server();
    backupServer.Status = "Inactive";

    ISystem[] systems = { mainServer, backupServer };
    foreach (ISystem system in systems) {
        system.Operate();
    }
  }
}