using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Area51Elevator
{
    internal class Elevator
    {
        List<Agent> Agents { get; set; }
        SemaphoreSlim Semaphore { get; set; }
        public int CurrentFloor { get; set; } = 0;
        //public int LastFloor { get; set; } = 0;


        string[] floors = new string[]
        {
            "G (Floor 1)",
            "S (Floor 2)",
            "T1 (Floor 3)",
            "T2 (Floor 4)"
        };

        public Elevator()
        {
            Agents = new List<Agent>();
            Semaphore = new SemaphoreSlim(1, 1); // edit: the elevator is tiny
        }

        public void EnterElevator(Agent agent)
        {
            Semaphore.Wait();
            lock (Agents)
            {
                Agents.Add(agent);
            }
        }
        public void LeaveElevator(Agent agent)
        {
            lock (Agents)
            {
                Agents.Remove(agent);
            }
            Semaphore.Release();
        }
        public void MoveUp(int floor)
        {

            Thread.Sleep(1000);
            for (int i = CurrentFloor; i < floor; i++)
            {
                CurrentFloor++;
                Thread.Sleep(1000);
                Console.WriteLine($"Floor: {floors[i]}");
            }
            Thread.Sleep(1000);
        }
        public void MoveDown(int floor)
        {
            Thread.Sleep(1000);
            for (int i = CurrentFloor - 1; i >= floor; i--)
            {
                CurrentFloor--;
                Thread.Sleep(1000);
                Console.WriteLine($"Floor: {floors[i]}");
            }
            Thread.Sleep(1000);

        }
        public void CallElevator(int floor)
        {
            if (CurrentFloor != 0) Console.WriteLine($"Elevator is going to floor {floor}");            

            if (floor > CurrentFloor) MoveUp(floor);
                
            else if (floor < CurrentFloor) MoveDown(floor);
                
            else
            {
                if (CurrentFloor != 0) Console.WriteLine($"Elevator is already on floor {CurrentFloor}");
                MoveDown(floor);
            }
        }
        //public void ResetFloor()
        //{
        //    for (int i = CurrentFloor - 1; i > -1; i--)
        //    {
        //        CurrentFloor--;

        //    }
        //    CurrentFloor = 0;
        //    LastFloor = 0;
        //}
        

    }
}
