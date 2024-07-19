using System;

class Program
{

    static int floor = 1;

    static bool gameOver = false;

    public static Character player = new Barbarian();

    static Enemy boss = new(11, "Star Of Death", "The Death Star Hugs You", 260, 50, 100, 1.0);
    static List<Enemy> enemies = [];

    // static Menu mainMenu;
    // static Menu characterMenu;
    static Menu emptyRoomMenu;

    // static Event gameStartEvent;
    // static Event enemyEncounterEvent;
    static Event findItemEvent;

    static Room emptyRoomEvent;
    static Room enemyRoomEvent;
    static Room specialRoomEvent;
    static Room staircaseRoomEvent;

    static RandomBag<Room> roomBag = new([]);
    static RandomBag<Event> specialEventBag = new([]);

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
            player.DoBuffDecay();
        }
    }

    static void DefineEnemies()
    {
        enemies.Add(new Enemy(1, "Goblin", "The Goblin Smirks", 10, 10, 10, 0.9));
        enemies.Add(new Enemy(2, "Rat Hoard", "The Rats Cuddle", 15, 0, 15, 0.8));
        enemies.Add(new Enemy(3, "Kitty", "The Kitty Is Cute", 5, 0, 20, 0.3));
        enemies.Add(new Enemy(4, "Tooth Fairy", "The Fairy Pokes You Gently In The Teeth", 1, 20, 8, 0.2));
        enemies.Add(new Enemy(5, "Textbooks", "The Textbooks Slap You Repeatedly", 35, 5, 45, 0.9));
        enemies.Add(new Enemy(6, "A Guy", "The Guy Uses Words", 40, 10, 35, .7));
        enemies.Add(new Enemy(7, "Living Skeleton Of Some Guy", "The Skeleton Grabs Its Head And Swings It", 30, 30, 20, 1.0));
        enemies.Add(new Enemy(8, "Dinosaur", "The Dino Sits", 100, 10, 35, 1.0));
        enemies.Add(new Enemy(9, "Depression", "You Feel A Little Worse About Yourself", 80, 30, 40, 0.7));
        enemies.Add(new Enemy(10, "Building", "The Building Loses A Wall", 120, 33, 100, 1.0));
    }
    
    static void DefineItems()
    {
        ItemManager im = ItemManager.Instance;
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Stick",           5),  1, 1);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Excalibur",       40), 1, 1);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Normal Sword",    27), 1, 2);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Big Rock",        9),  1, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Sword Handle",    3),  1, 6);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Golden Spear",    15), 2, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Spear",           25), 2, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Magic Stick",     35), 3, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Toothpick",       15), 3, 4);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Rusty Sword",     20), 3, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Pike",            32), 3, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Pickaxe",         33), 4, 5);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Tree",            39), 4, 6);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Breath Attack",   40), 4, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Generic Weapon",  55), 5, 5);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Fireball",        45), 5, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Grass",           42), 5, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Cards",           2),  5, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Platinum Glaive", 47), 6, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Perfume",         13), 7, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Rusty Glaive",    37), 7, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Flagpole",        53), 7, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Fire Bending",    68), 8, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Dry Stick",       1),  8, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Some Guy",        65), 10, 10);

        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Snuggy",           3),  1, 1);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Dapper Suit",      9),  1, 1);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Armor Stand",      7),  1, 2);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Suit",             5),  1, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Pillow",           8),  1, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Meat Shield",      13), 1, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Chair",            15), 2, 2);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Desk",             20), 3, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Piano",            21), 3, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Bathtub",          23), 3, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Mattress",         25), 3, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Painting",         9),  4, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Generic Armor",    55), 5, 5);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Big Cards",        24), 5, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Wood Buckler",     30), 6, 6);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Glasses",          20), 6, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Stone Buckler",    40), 7, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Iron Buckler",     50), 8, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Water Bending",    30), 8, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Diamond Buckler",  60), 9, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Tiny Dry Stick",   1),  10, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Wet Dry Stick",    45), 10, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Branch",           57), 10, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Giant Dry Stick",  68), 10, 10);

        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Challace Of Health", 60), 1, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Draught Of Strength", Item.STAT.Strength, Item.ADDTYPE.Multiplier, 1.5), 1, 10);

        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Plot Armor", Item.STAT.Defense, Item.ADDTYPE.Multiplier, 4.0), 8, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Sword Of Parry", Item.STAT.Defense, Item.ADDTYPE.Flat, 10), 5, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Shield Sword", Item.STAT.Strength, Item.ADDTYPE.Flat, 25), 1, 5);


    }
    
    static void DefineBasicMenus()
    {
        emptyRoomMenu = new Menu("How shall you proceed?");
        emptyRoomMenu.AddOption("Move to the next room", "move");
        emptyRoomMenu.AddOption("Inspect your character","stats");
        emptyRoomMenu.AddOption("View your equipment", "equipment");

        player.battleOptions.AddOption("Attack", "attack");
    }
    
    static void DefineEvents()
    {
        findItemEvent = new(() => {
            Console.WriteLine("You found an item on the ground");
            int rn = Random.Shared.Next(3);
            Item.TYPE chosenType = rn == 0 ? Item.TYPE.Armor : (rn == 1 ? Item.TYPE.Weapon : Item.TYPE.Consumable);
            Item chosenItem = ItemManager.Instance.GetRandomItemInLevelWithType(player.GetLevel(), chosenType);
            
            ShortPause();

            player.SwapEquipment(chosenItem);

            if (player.HasConsumable())
            {
                player.battleOptions.AddOption("Consume your consumable","consumable");
                emptyRoomMenu.AddOption("Consume your consumable","consumable");
            }
            return false;
        });
    }
    
    static void DefineRooms()
    {
        emptyRoomEvent = new Room(() => {
            Console.Clear();
            emptyRoomMenu.Display();
            string choice = emptyRoomMenu.GetNameFromNum(emptyRoomMenu.SelectByNum());
            if (choice.Equals("move"))
            {
                return false;
            }
            else if (choice.Equals("stats"))
            {
                player.DisplayCharacterInfo();
                LongPause();
            }
            else if (choice.Equals("equipment"))
            {
                player.DisplayEquipment();
                LongPause();
            }
            else if (choice.Equals("consumable"))
            {
                player.UseConsumable();
                int? con = player.battleOptions.FindOptionByName("consumable");
                if (con is not null)
                    player.battleOptions.RemoveOption((int) con);
                int? econ = emptyRoomMenu.FindOptionByName("consumable");
                if (econ is not null)
                    emptyRoomMenu.RemoveOption((int) econ);
            }
            return true;
        });
        roomBag.Add(emptyRoomEvent);


        staircaseRoomEvent = new Room(() => {
            Console.Clear();
            if (Random.Shared.Next(2) == 0)
            {
                Console.WriteLine("There is nothing but air");
                ShortPause();
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
                ShortPause();
                emptyRoomEvent.Start();
                return false;
            }

            Console.WriteLine();
            
            if (floor == 5)
            {
                Console.WriteLine("You encounter the boss!");
                LongPause();
                enemyRoomEvent.Start();
            }
            else
            {
                Console.WriteLine("The room above is empty");
                ShortPause();
                emptyRoomEvent.Start();
            }
            return false;
        });
        roomBag.Add(staircaseRoomEvent);


        enemyRoomEvent = new Room(() => {
            Console.Clear();
            Enemy opponent;
            if (floor == 5)
            {
                opponent = boss;
                Console.WriteLine($"You enter the boss room the {opponent.GetName()} opposes you.");
                ShortPause();
            }
            else
            {
                Console.WriteLine("You have encountered an enemy!");
                List<Enemy> penemies = enemies.FindAll((e) => floor * 2 - 1 <= e.GetLevel() && e.GetLevel() <= floor * 2 + 1);
                opponent = penemies[Random.Shared.Next(penemies.Count)];
            }
                
            opponent.PrepareForBattle();
            opponent.DisplayEnemyInfo();
            while (true)
            {
                // Character's turn
                player.battleOptions.Display();
                string selection = player.battleOptions.GetNameFromNum(player.battleOptions.SelectByNum());
                if (selection == "attack")
                {
                    if (opponent.GetsHit())
                    {
                        int damage = player.GetAttackDamage();
                        Console.WriteLine($"You dealt {opponent.Damage(damage)} damage to the enemy.");
                        Console.WriteLine($"The enemy now has {Math.Max(opponent.GetHealth(), 0)} left");
                    }
                    else
                    {
                        Console.WriteLine("Your attack missed");
                    }
                    ShortPause();
                }
                else if (selection == "consumable")
                {
                    player.UseConsumable();
                    int? con = player.battleOptions.FindOptionByName("consumable");
                    if (con is not null)
                        player.battleOptions.RemoveOption((int) con);
                    int? econ = emptyRoomMenu.FindOptionByName("consumable");
                    if (econ is not null)
                        emptyRoomMenu.RemoveOption((int) econ);
                }

                if (opponent.IsDead())
                {
                    Console.WriteLine("You killed it!");
                    player.GetXPFromKill(opponent.GetLevel());
                    if (Random.Shared.NextDouble() < 0.3)
                        findItemEvent.Start();
                    break;
                }

                Console.WriteLine(opponent.GetAttackDescription());
                Console.WriteLine($"The {opponent.GetName()} dealt {player.Damage(opponent.GetDamage())} to you");
                ShortPause();

                if (player.IsDead())
                {
                    Console.WriteLine($"You died, game over");
                    gameOver = true;
                    break;
                }
                
            }
            Console.WriteLine("You move on");
            ShortPause();
            return false;
        });
        roomBag.Add(enemyRoomEvent);
        roomBag.Add(enemyRoomEvent);
        roomBag.Add(enemyRoomEvent);


        specialEventBag.Add(findItemEvent);
        specialRoomEvent = new Room(() => {
            Console.Clear();
            specialEventBag.Peek().Start();
            return false;
        });
        roomBag.Add(specialRoomEvent);
        
    }
    
    static void ShortPause()
    {
        Thread.Sleep(1000);
    }

    static void LongPause()
    {
        Thread.Sleep(3500);
    }
}