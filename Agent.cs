using System;
using System.Collections.Generic;
using System.Text;

namespace Area51Elevator
{
    internal class Agent
    {
        public string Name { get; set; }
        public string SecurityLevel { get; set; }
        private Elevator Elevator { get; set; }

        int[] lastFloors = new int[]
            {
                0, 0, 0
            };

        public Agent(string name, Elevator elevator, string securityLevel)
        {
            Name = name;
            Elevator = elevator;
            SecurityLevel = securityLevel;
        }

        
        public static int RandomFloorSelection()
        {
            int floor = Random.Shared.Next(1, 5);
            return floor;
        }
        //public void Wait()
        //{
        //    Thread.Sleep(Random.Shared.Next(5000));
        //}
        int floor = RandomFloorSelection();
        public void EnterBuilding()
        {
            Elevator.EnterElevator(this);
            Elevator.CallElevator(0);
            Console.WriteLine($"Agent {Name} with security level {SecurityLevel} has entered the elevator... Beginning ascend.");
            Console.WriteLine("===========================");
            Thread.Sleep(1000);
            Console.WriteLine($"Agent {Name} wants to go to floor {floor}");
            Elevator.MoveUp(floor);
            TryEnterRoom();
            //Console.WriteLine($"Agent {Name} with security level {SecurityLevel} has exited the building");
            Console.WriteLine();
        }
        public void LeaveBuilding()
        {
            Elevator.MoveDown(0);
            Elevator.LeaveElevator(this);

        }
        public void TryEnterRoom()
        {
            int currentFloor = Elevator.CurrentFloor;           

            switch (SecurityLevel)
            {
                case "Confidental":
                    Console.WriteLine($"Agent {Name} is attemping to enter floor {currentFloor}");
                    Thread.Sleep(500);
                    if (currentFloor == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{SecurityLevel} access granted. Agent {Name} is entering the room. \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        lastFloors[0] = Elevator.CurrentFloor;
                        //Console.WriteLine($"Last floor for confidental {lastFloors[0]}");
                        Elevator.LeaveElevator(this);
                        //Elevator.ResetFloor();
                        SpendSomeTime();
                        Elevator.EnterElevator(this);
                        Elevator.CallElevator(lastFloors[0]);
                        LeaveBuilding();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Agent {Name} has left the building.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Access denied.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Elevator.CallElevator(RandomFloorSelection());
                        TryEnterRoom();

                    }
                    break;
                case "Secret":
                    Console.WriteLine($"Agent {Name} is attemping to enter floor {currentFloor}");
                    Thread.Sleep(500);
                    if (currentFloor == 1 || currentFloor == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{SecurityLevel} access granted. Agent {Name} is entering the room. \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        lastFloors[1] = Elevator.CurrentFloor;
                        //Console.WriteLine($"Last floor for secret {lastFloors[1]}");
                        Elevator.LeaveElevator(this);
                        //Elevator.ResetFloor();
                        SpendSomeTime();
                        Elevator.EnterElevator(this);
                        Elevator.CallElevator(lastFloors[1]);
                        LeaveBuilding();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Agent {Name} has left the building.");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Access denied.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Elevator.CallElevator(RandomFloorSelection());
                        TryEnterRoom();

                    }
                    break;
                case "Top-Secret":
                    Console.WriteLine($"Agent {Name} is attemping to enter floor {currentFloor}");
                    Thread.Sleep(500);
                    if (currentFloor == 1 || currentFloor == 2 || currentFloor == 3 || currentFloor == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{SecurityLevel} access granted. Agent {Name} is entering the room. \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        lastFloors[2] = Elevator.CurrentFloor;
                        //Console.WriteLine($"Last floor for top-secret {lastFloors[2]}");
                        Elevator.LeaveElevator(this);
                        //Elevator.ResetFloor();
                        SpendSomeTime();
                        Elevator.EnterElevator(this);
                        Elevator.CallElevator(lastFloors[2]);
                        LeaveBuilding();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Agent {Name} has left the building.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Access denied.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Elevator.CallElevator(RandomFloorSelection());
                        TryEnterRoom();

                        
                    }
                    break;
            }
        }
        //public void SelectARandomFloor()
        //{

        //}
        public void SpendSomeTime()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Agent {Name} is doing some work..");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(Random.Shared.Next(4000,5000));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Agent {Name} finished doing some work..");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
