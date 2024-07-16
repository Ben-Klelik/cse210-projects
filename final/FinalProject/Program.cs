using System;

class Program
{

    static int floor = 1;

    static bool gameOver = false;

    static Character player = new Barbarian();

    static Enemy boss = new(11, "Star Of Death", "The Death Star Hugs You", 600, 90, 90, 1.0);
    static List<Enemy> enemies = [];

    // static Menu mainMenu;
    // static Menu characterMenu;
    static Menu emptyRoomMenu;

    // static Event gameStartEvent;
    // static Event enemyEncounterEvent;
    // static Event itemSwapEvent;

    static Room emptyRoomEvent;
    static Room enemyRoomEvent;
    static Room specialRoomEvent;
    static Room staircaseRoomEvent;

    static RandomBag<Room> roomBag = new([]);

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
        while (!gameOver)
        {
            roomBag.TakeOut().Start();
        }
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
        enemies.Add(new Enemy(2, "Rat Hoard", "The Rats Cuddle", 15, 0, 15, 0.8));
        enemies.Add(new Enemy(3, "Kitty", "The Kitty Is Cute", 5, 0, 20, 0.3));
        enemies.Add(new Enemy(4, "Tooth Fairy", "The Fairy Pokes You Gently In The Teeth", 1, 20, 1, 0.2));
        enemies.Add(new Enemy(5, "Textbooks", "The Textbooks Slap You Repeatedly", 35, 5, 20, 0.9));
        enemies.Add(new Enemy(6, "A Guy", "The Guy Uses Words", 40, 10, 35, .7));
        enemies.Add(new Enemy(7, "Living Skeleton Of Some Guy", "The Skeleton Grabs Its Head And Swings It", 30, 30, 20, 1.0));
        enemies.Add(new Enemy(8, "Dinosaur", "The Dino Sits", 100, 10, 15, 1.0));
        enemies.Add(new Enemy(9, "Depression", "You Feel A Little Worse About Yourself", 80, 30, 40, 0.7));
        enemies.Add(new Enemy(10, "Building", "The Building Loses A Wall", 200, 60, 10, 1.0));
    }
    
    static void DefineItems()
    {
        ItemManager im = ItemManager.Instance;
        im.AddItemToLevelRange(new Item("Stick", Item.TYPE.Weapon, 5), 1, 1);
        im.AddItemToLevelRange(new Item("Excalibur", Item.TYPE.Weapon, 40), 1, 1);
        im.AddItemToLevelRange(new Item("Normal Sword", Item.TYPE.Weapon, 27), 1, 2);
        im.AddItemToLevelRange(new Item("Big Rock", Item.TYPE.Weapon, 9), 1, 3);
        im.AddItemToLevelRange(new Item("Sword Handle", Item.TYPE.Weapon, 3), 1, 6);
        im.AddItemToLevelRange(new Item("Golden Spear", Item.TYPE.Weapon, 15), 2, 3);
        im.AddItemToLevelRange(new Item("Spear", Item.TYPE.Weapon, 25), 2, 3);
        im.AddItemToLevelRange(new Item("Magic Stick", Item.TYPE.Weapon, 35), 3, 3);
        im.AddItemToLevelRange(new Item("Toothpick", Item.TYPE.Weapon, 15), 3, 4);
        im.AddItemToLevelRange(new Item("Rusty Sword", Item.TYPE.Weapon, 20), 3, 7);
        im.AddItemToLevelRange(new Item("Pike", Item.TYPE.Weapon, 32), 3, 7);
        im.AddItemToLevelRange(new Item("Pickaxe", Item.TYPE.Weapon, 33), 4, 5);
        im.AddItemToLevelRange(new Item("Tree", Item.TYPE.Weapon, 39), 4, 6);
        im.AddItemToLevelRange(new Item("Breath Attack", Item.TYPE.Weapon, 40), 4, 8);
        im.AddItemToLevelRange(new Item("Generic Weapon", Item.TYPE.Weapon, 55), 5, 5);
        im.AddItemToLevelRange(new Item("Fireball", Item.TYPE.Weapon, 45), 5, 7);
        im.AddItemToLevelRange(new Item("Grass", Item.TYPE.Weapon, 42), 5, 8);
        im.AddItemToLevelRange(new Item("Cards", Item.TYPE.Weapon, 2), 5, 10);
        im.AddItemToLevelRange(new Item("Platinum Glaive", Item.TYPE.Weapon, 47), 6, 7);
        im.AddItemToLevelRange(new Item("Perfume", Item.TYPE.Weapon, 13), 7, 7);
        im.AddItemToLevelRange(new Item("Rusty Glaive", Item.TYPE.Weapon, 37), 7, 10);
        im.AddItemToLevelRange(new Item("Flagpole", Item.TYPE.Weapon, 53), 7, 10);
        im.AddItemToLevelRange(new Item("Fire Bending", Item.TYPE.Weapon, 68), 8, 9);
        im.AddItemToLevelRange(new Item("Dry Stick", Item.TYPE.Weapon, 1), 8, 10);
        im.AddItemToLevelRange(new Item("Some Guy", Item.TYPE.Weapon, 65), 10, 10);

        im.AddItemToLevelRange(new Item("Snuggy", Item.TYPE.Armor, 3), 1, 1);
        im.AddItemToLevelRange(new Item("Dapper Suit", Item.TYPE.Armor, 9), 1, 1);
        im.AddItemToLevelRange(new Item("Armor Stand", Item.TYPE.Armor, 7), 1, 2);
        im.AddItemToLevelRange(new Item("Suit", Item.TYPE.Armor, 5), 1, 3);
        im.AddItemToLevelRange(new Item("Pillow", Item.TYPE.Armor, 8), 1, 3);
        im.AddItemToLevelRange(new Item("Meat Shield", Item.TYPE.Armor, 13), 1, 9);
        im.AddItemToLevelRange(new Item("Chair", Item.TYPE.Armor, 15), 2, 2);
        im.AddItemToLevelRange(new Item("Desk", Item.TYPE.Armor, 20), 3, 8);
        im.AddItemToLevelRange(new Item("Piano", Item.TYPE.Armor, 21), 3, 8);
        im.AddItemToLevelRange(new Item("Bathtub", Item.TYPE.Armor, 23), 3, 8);
        im.AddItemToLevelRange(new Item("Mattress", Item.TYPE.Armor, 25), 3, 8);
        im.AddItemToLevelRange(new Item("Painting", Item.TYPE.Armor, 9), 4, 10);
        im.AddItemToLevelRange(new Item("Generic Armor", Item.TYPE.Armor, 55), 5, 5);
        im.AddItemToLevelRange(new Item("Big Cards", Item.TYPE.Armor, 24), 5, 10);
        im.AddItemToLevelRange(new Item("Wood Buckler", Item.TYPE.Armor, 30), 6, 6);
        im.AddItemToLevelRange(new Item("Glasses", Item.TYPE.Armor, 20), 6, 9);
        im.AddItemToLevelRange(new Item("Stone Buckler", Item.TYPE.Armor, 40), 7, 7);
        im.AddItemToLevelRange(new Item("Iron Buckler", Item.TYPE.Armor, 50), 8, 8);
        im.AddItemToLevelRange(new Item("Water Bending", Item.TYPE.Armor, 30), 8, 9);
        im.AddItemToLevelRange(new Item("Diamond Buckler", Item.TYPE.Armor, 60), 9, 9);
        im.AddItemToLevelRange(new Item("Tiny Dry Stick", Item.TYPE.Armor, 1), 10, 10);
        im.AddItemToLevelRange(new Item("Wet Dry Stick", Item.TYPE.Armor, 45), 10, 10);
        im.AddItemToLevelRange(new Item("Branch", Item.TYPE.Armor, 57), 10, 10);
        im.AddItemToLevelRange(new Item("Giant Dry Stick", Item.TYPE.Armor, 68), 10, 10);

        im.AddItemToLevelRange(new Item("Challace Of Health", Item.TYPE.Consumable, 60), 1, 10);

        im.AddItemToLevelRange(new Item("Plot Armor", Item.TYPE.Weapon, Item.STAT.Defense, Item.ADDTYPE.Multiplier, 4.0), 8, 10);
        im.AddItemToLevelRange(new Item("Sword Of Parry", Item.TYPE.Armor, Item.STAT.Defense, Item.ADDTYPE.Flat, 10), 5, 7);
        im.AddItemToLevelRange(new Item("Shield Sword", Item.TYPE.Armor, Item.STAT.Strength, Item.ADDTYPE.Flat, 25), 1, 5);


    }
    
    static void DefineBasicMenus()
    {
        emptyRoomMenu = new Menu("How shall you proceed?");
        emptyRoomMenu.AddOption("Move to the next room", "move");
        emptyRoomMenu.AddOption("Inspect your character","stats");
        emptyRoomMenu.AddOption("Consume your consumable","consumable");

        player.BattleOptions.AddOption("Attack", "attack");
    }
    
    static void DefineEvents()
    {
        
    }
    
    static void DefineRooms()
    {
        emptyRoomEvent = new Room(() => {
            emptyRoomMenu.Display();
            string choice = emptyRoomMenu.GetNameFromNum(emptyRoomMenu.SelectByNum());
            if (choice.Equals("move"))
            {
                return false;
            }
            else if (choice.Equals("stats"))
            {
                player.DisplayCharacterInfo();
            }
            else if (choice.Equals("consumable"))
            {
                Console.WriteLine("You do not have any consumables right now");
            }
            return true;
        });
        roomBag.Add(emptyRoomEvent);


        staircaseRoomEvent = new Room(() => {
            if (Random.Shared.Next(2) == 0)
            {
                emptyRoomEvent.Start();
                return false;
            }
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
                Console.WriteLine("Aside from the staircase the room is empty");
            }
            
            if (floor == 5)
            {
                Console.WriteLine("Since you have reached floor 5 you have won! (boss not implemented yet)");

            }
            else
            {
                Console.WriteLine("The room above is empty");
                emptyRoomEvent.Start();
            }
            return false;
        });
        roomBag.Add(staircaseRoomEvent);


        enemyRoomEvent = new Room(() => {
            Console.WriteLine("You have encountered an enemy!");
            List<Enemy> penemies = enemies.FindAll((e) => floor * 2 - 1 <= e.GetLevel() && e.GetLevel() <= floor * 2 + 1);
            Enemy opponent = penemies[Random.Shared.Next(penemies.Count)];
            opponent.PrepareForBattle();
            opponent.DisplayEnemyInfo();
            while (true)
            {
                // Character's turn
                player.BattleOptions.Display();
                string selection = player.BattleOptions.GetNameFromNum(player.BattleOptions.SelectByNum());
                if (selection == "attack")
                {
                    if (opponent.GetsHit())
                    {
                        int damage = player.GetAttackDamage();
                        Console.WriteLine($"You dealt {opponent.Damage(damage)} damage to the enemy.");
                        Console.WriteLine($"The enemy now has {opponent.GetHealth()} left");
                    }
                    else
                    {
                        Console.WriteLine("Your attack missed");
                    }
                }

                if (opponent.IsDead())
                    break;

                Console.WriteLine(opponent.GetAttackDescription());
                Console.WriteLine($"The {opponent.GetName()} dealt {player.Damage(opponent.GetDamage())} to you");

                if (player.IsDead())
                    break;
                
            }
            return false;
        });
        roomBag.Add(enemyRoomEvent);
        roomBag.Add(enemyRoomEvent);
        roomBag.Add(enemyRoomEvent);


        specialRoomEvent = new Room(() => {
            Console.WriteLine("You found an item on the ground");
            int rn = Random.Shared.Next(3);
            Item.TYPE chosenType = rn == 0 ? Item.TYPE.Armor : (rn == 1 ? Item.TYPE.Weapon : Item.TYPE.Consumable);
            Item treasure = ItemManager.Instance.GetRandomItemInLevelWithType(player.GetLevel(), chosenType);
            return false;
        });
        roomBag.Add(specialRoomEvent);
        roomBag.Add(specialRoomEvent);
        
    }
    
    static void ShortPause()
    {
        Thread.Sleep(1000);
    }

    static void LongPause()
    {
        Thread.Sleep(2500);
    }
}