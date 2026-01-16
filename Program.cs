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

        static void Main(string[] args)
        {

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
