using static Area51Elevator.Agent;

namespace Area51Elevator
{
    internal class Program
    {
        static SemaphoreSlim semaphore;
        static string[] securityLevels = new string[]
        {
            "Confidental",
            "Secret",
            "Top-Secret"
        };

        
        //static void Elevator(object objParam)
        //{
        //    string agentName = (string)objParam;
        //    semaphore.Wait();
        //    for (int i = 0; i < floors.Length; i++)
        //    {
                
        //        Thread.Sleep(1000);
        //        Console.WriteLine($"Agent {agentName}: {floors[i]}");
                
        //    }
        //    semaphore.Release();
        //}
        static void Main(string[] args)
        {
            //semaphore = new SemaphoreSlim(1, 3);
            //Agent[] agents = new Agent[3];
            //Thread[] threads = new Thread[3];
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(Elevator);
            //    threads[i].Start((i + 1).ToString());
            //}

            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}
            
            Elevator elevator = new Elevator();
            List<Agent> agents = new List<Agent>();
            int numberOfAgents = 3;
            for (int i = 0; i < numberOfAgents; i++)
            {
                Agent agent = new Agent((i + 1).ToString(), elevator, securityLevels[Random.Shared.Next(0, 3)]);
                agents.Add(agent);
              
            }

            Thread[] agentThread = agents
            .Select(s => new Thread(s.EnterBuilding))
            .ToArray();

            foreach (Thread thread in agentThread) thread.Start();
            foreach (Thread thread in agentThread) thread.Join();
            




        }
    }
}
