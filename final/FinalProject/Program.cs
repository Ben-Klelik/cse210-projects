using System;

class Program
{

    static int floor = 1;

    static Character character = new Barbarian();

    static List<Enemy> enemies = [];

    static Menu mainMenu;
    static Menu characterMenu;
    static Menu emptyRoomMenu;

    static Event gameStartEvent;
    static Event enemyEncounterEvent;
    static Event itemSwapEvent;

    static Room emptyRoomEvent;
    static Room enemyRoomEvent;
    static Room specialRoomEvent;
    static Room staircaseRoomEvent;

    static List<Room> bagBase = [];

    static void Main(string[] args)
    {
        DefineEnemies();
        DefineItems();
        DefineBasicMenus();
        DefineEvents();
        DefineRooms();
        MainGameLoop();
    }

    static void MainGameLoop()
    {
        Demo();
        // throw new NotImplementedException();
    }

    static void Demo()
    {
        Console.WriteLine("");
        emptyRoomEvent.Start();
        Console.WriteLine("End of demo");
    }

    static void DefineEnemies()
    {
        enemies.Add(new Enemy(1, "Goblin", "The Goblin Smirks", 10, 10, 10, 0.9));
        enemies.Add(new Enemy(6, "Dinosaur", "The Dino Sits", 100, 10, 15, 1.0));
    }
    
    static void DefineItems()
    {
        
    }
    
    static void DefineBasicMenus()
    {
        emptyRoomMenu = new Menu("How shall you proceed?");
        emptyRoomMenu.AddOption("Move to the next room", "move");
        emptyRoomMenu.AddOption("Inspect your character","stats");
        emptyRoomMenu.AddOption("Consume your consumable","consumable");
    }
    
    static void DefineEvents()
    {
        
    }
    
    static void DefineRooms()
    {
        emptyRoomEvent = new Room(() => {
            Console.WriteLine("You enter an empty room.");
            emptyRoomMenu.Display();
            string choice = emptyRoomMenu.GetNameFromNum(emptyRoomMenu.SelectByNum());
            if (choice.Equals("move"))
            {
                staircaseRoomEvent.Start();
            }
            else if (choice.Equals("stats"))
            {
                character.DisplayCharacterInfo();
                return true;
            }
            else if (choice.Equals("consumable"))
            {
                Console.WriteLine("You do not have any consumables right now");
                return true;
            }
            return false;
        });


        staircaseRoomEvent = new Room(() => {
            Console.WriteLine("You have found a staircase.");
            Console.WriteLine("Will you ascend the staircase? (y/n)");
            bool willAscend = Console.ReadLine().ToLower().Equals("y");
            if (willAscend)
            {
                floor++;
                Console.WriteLine($"You have ascended the staircase and are now on floor {floor}");
            }
            else
            {
                Console.WriteLine("You leave the room without doing anything");
            }
            
            if (floor == 5)
            {
                Console.WriteLine("Since you have reached floor 5 you have won! (boss not implemented yet)");
            }
            else
            {
                emptyRoomEvent.Start();
            }
            return false;
        });


        enemyRoomEvent = new Room(() => {
            Console.WriteLine("You have encountered an enemy!");
            return false;
        });
    }
    
}