using System;

class Program
{

    static int floor = 1;

    static bool gameOver = false;

    public static Character player;

    static Enemy boss = new(11, "Star Of Death", "The Death Star Hugs You", 260, 50, 120, 0.9);
    static List<Enemy> enemies = [];

    static Menu mainMenu = new("Main menu");
    static Menu characterMenu = new("Choose your character!");

    static Event findItemEvent;
    static Event encounterTrapEvent;
    static Event encounterHealingPoolEvent;
    static Event characterSelectionEvent;

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
        
        Console.WriteLine($"Welcome to the game!\n");
        ShortPause();
        mainMenu.Display();

        string choice = mainMenu.GetNameFromNum(mainMenu.SelectByNum());
        if (choice.Equals("character"))
        {
            characterSelectionEvent.Start();
            MainGameLoop();
        }
        else if (choice.Equals("exit"))
        {
            Console.WriteLine($"nvm");
        }
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
        enemies.Add(new Enemy(1, "Goblin", "The Goblin Smirks", 25, 10, 10, 0.9));
        enemies.Add(new Enemy(2, "Rat Hoard", "The Rats Cuddle", 22, 0, 15, 0.8));
        enemies.Add(new Enemy(3, "Tooth Fairy", "The Fairy Pokes You Gently In The Teeth", 5, 20, 12, 0.4));
        enemies.Add(new Enemy(4, "Kitty", "The Kitty Is Cute", 18, 0, 20, 0.5));
        enemies.Add(new Enemy(5, "Textbooks", "The Textbooks Slap You Repeatedly", 42, 5, 54, 0.9));
        enemies.Add(new Enemy(6, "A Guy", "The Guy Uses Words", 68, 10, 39, 0.7));
        enemies.Add(new Enemy(7, "Living Skeleton Of Some Guy", "The Skeleton Grabs Its Head And Swings It", 79, 30, 41, 1.0));
        enemies.Add(new Enemy(8, "Dinosaur", "The Dino Sits", 150, 5, 53, 1.0));
        enemies.Add(new Enemy(9, "Depression", "You Feel A Little Worse About Yourself", 36, 55, 66, 0.7));
        enemies.Add(new Enemy(10, "Building", "The Building Falls On You", 120, 33, 90, 1.0));
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
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Generic Armor",    44), 4, 4);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Big Cards",        24), 5, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Wood Buckler",     25), 6, 6);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Glasses",          19), 6, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Stone Buckler",    30), 7, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Iron Buckler",     35), 8, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Water Bending",    31), 8, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Diamond Buckler",  40), 9, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Tiny Dry Stick",   1),  10, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Wet Dry Stick",    45), 10, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Branch",           57), 10, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Giant Dry Stick",  59), 10, 10);


        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Glue", 5), 1, 3);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Medicine", 25), 2, 5);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "First Aid Kit", 50), 4, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Challace Of Health", 60), 6, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Tear Of Beer", 200), 8, 10);

        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Garlic", Character.STAT.Strength, Item.ADDTYPE.Flat, 5), 1, 6);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Ghost Pepper", Character.STAT.Strength, Item.ADDTYPE.Multiplier, 1.5), 4, 10);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Coffee", Character.STAT.Strength, Item.ADDTYPE.Flat, 25), 5, 8);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Spinach", Character.STAT.Strength, Item.ADDTYPE.Multiplier, 2), 8, 10);

        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Peanut Butter", Character.STAT.Defense, Item.ADDTYPE.Flat, 4), 1, 5);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Bubbles", Character.STAT.Defense, Item.ADDTYPE.Flat, 8), 4, 9);
        im.AddItemToLevelRange(new Item(Item.TYPE.Consumable, "Gallium", Character.STAT.Defense, Item.ADDTYPE.Multiplier, 1.4), 8, 10);

        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Shield Sword", Character.STAT.Strength, Item.ADDTYPE.Flat, 25), 1, 5);
        im.AddItemToLevelRange(new Item(Item.TYPE.Weapon, "Sword Of Parry", Character.STAT.Defense, Item.ADDTYPE.Flat, 10), 5, 7);
        im.AddItemToLevelRange(new Item(Item.TYPE.Armor, "Plot Armor", Character.STAT.Defense, Item.ADDTYPE.Multiplier, 3.0), 8, 10);


    }
    
    static void DefineBasicMenus()
    {
        

        characterMenu.AddOption("Barbarian","barbarian");
        characterMenu.AddOption("Paladin","paladin");

        mainMenu.AddOption("choose character","character");
        mainMenu.AddOption("exit","exit");
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

            return false;
        });

        encounterTrapEvent = new(() => {
            int damageDone = Random.Shared.Next(5 * floor, 15 * floor);
            Console.WriteLine($"You encountered a trap!");
            ShortPause();
            int healthBefore = player.GetHealth();
            int damageTaken = player.Damage(damageDone);
            Console.WriteLine($"You take {damageTaken} damage ( {healthBefore} -> {Math.Max(player.GetHealth(), 0)} )");
            ShortPause();
            if (player.IsDead())
            {
                Console.WriteLine($"You died, game over");
                ShortPause();
                gameOver = true;
            }
            return false;
        });

        encounterHealingPoolEvent = new(() => {
            Console.WriteLine($"You find a glistening pool");
            ShortPause();
            Console.WriteLine($"As you wade through it you are healed to full");
            ShortPause();
            int healthBefore = player.GetHealth();
            player.HealToFull();
            Console.WriteLine($"Health ( {healthBefore} -> {player.GetHealth()} )");
            ShortPause();
            return false;
        });

        characterSelectionEvent = new(() => {
            characterMenu.Display();
            string choice = characterMenu.GetNameFromNum(characterMenu.SelectByNum());
            if (choice.Equals("barbarian"))
                player = new Barbarian();
            else if (choice.Equals("paladin"))
                player = new Paladin();
            return false;
        });
    }
    
    static void DefineRooms()
    {
        emptyRoomEvent = new Room(() => {
            Console.Clear();
            Menu emptyRoomMenu = new Menu("How shall you proceed?");
            emptyRoomMenu.AddOption("Move to the next room", "move");
            emptyRoomMenu.AddOption("Inspect your character","stats");
            emptyRoomMenu.AddOption("View your equipment", "equipment");
            if (player.HasConsumable())
                emptyRoomMenu.AddOption("Consume your consumable", "consumable");
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
            }
            return true;
        });
        roomBag.Add(emptyRoomEvent);
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
            Console.WriteLine($"You are on floor {floor}");

            string input;
            do
            {
                Console.WriteLine("Will you ascend the staircase? (y/n)");
                input = Console.ReadLine().ToLower();
            } while (!(input.Equals("y") || input.Equals("n")));

            if (input.Equals("y"))
            {
                floor++;
                Console.WriteLine($"You have ascended the staircase and are now on floor {floor}");
            }
            else if (input.Equals("n"))
            {
                Console.WriteLine("Aside from the staircase the room is empty");
                ShortPause();
                emptyRoomEvent.Start();
                return false;
            }

            Console.WriteLine();
            
            if (floor == 6)
            {
                Console.WriteLine("At the top of the stairs is a scary boss!");
                LongPause();
                enemyRoomEvent.Start();
            }
            else
            {
                Console.WriteLine("You find an empty room at the top of the stairs");
                ShortPause();
                emptyRoomEvent.Start();
            }
            return false;
        });
        roomBag.Add(staircaseRoomEvent);


        enemyRoomEvent = new Room(() => {
            Console.Clear();
            Enemy opponent;
            if (floor == 6)
            {
                opponent = boss;
                Console.WriteLine($"You enter the boss room the {opponent.GetName()} opposes you.");
                ShortPause();
            }
            else
            {
                Console.WriteLine("You have encountered an enemy!");
                List<Enemy> penemies = enemies.FindAll((e) => floor * 2 - 1 <= e.GetLevel() && e.GetLevel() <= floor * 2);
                opponent = penemies[Random.Shared.Next(penemies.Count)];
            }
                
            opponent.PrepareForBattle();
            opponent.DisplayEnemyInfo();
            while (true)
            {
                Menu battleOptions = new("What will you do?");
                battleOptions.AddOption("Attack", "attack");
                if (player.HasConsumable())
                    battleOptions.AddOption("Consume your consumable", "consumable");

                // Character's turn
                battleOptions.Display();
                string selection = battleOptions.GetNameFromNum(battleOptions.SelectByNum());
                if (selection.Equals("attack"))
                {
                    if (opponent.GetsHit())
                    {
                        int damage = player.GetAttackDamage();
                        if (player.DoesCriticalHit())
                        {
                            damage *= 2;
                            Console.WriteLine($"You do a critical hit!");
                        }
                        Console.WriteLine($"You dealt {opponent.Damage(damage)} damage to the enemy.");
                        Console.WriteLine($"The enemy now has {Math.Max(opponent.GetHealth(), 0)} left");
                    }
                    else
                    {
                        Console.WriteLine("Your attack missed");
                    }
                    ShortPause();
                }
                else if (selection.Equals("consumable"))
                {
                    player.UseConsumable();
                }

                if (opponent.IsDead())
                {
                    if (opponent == boss)
                    {
                        Console.WriteLine($"You killed the boss!");
                        ShortPause();
                        Console.WriteLine($"You win!");
                        ShortPause();
                        gameOver = true;
                        Console.WriteLine($"");
                        player.DisplayCharacterInfo();
                        ShortPause();
                        Console.WriteLine($"");
                        player.DisplayEquipment();
                        LongPause();
                        LongPause();
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("You killed the enemy!");
                        player.GetXPFromKill(opponent.GetLevel());
                        if (Random.Shared.NextDouble() < 0.3)
                            findItemEvent.Start();
                    }
                    break;
                }

                Console.WriteLine(opponent.GetAttackDescription());
                Console.WriteLine($"The {opponent.GetName()} dealt {player.Damage(opponent.GetDamage())} to you");
                Console.WriteLine($"You have {Math.Max(player.GetHealth(), 0)} left");
                ShortPause();

                if (player.IsDead())
                {
                    Console.WriteLine($"You died, game over");
                    ShortPause();
                    gameOver = true;
                    return false;
                }
                
            }
            Console.WriteLine("You move on");
            ShortPause();
            return false;
        });
        roomBag.Add(enemyRoomEvent);
        roomBag.Add(enemyRoomEvent);


        specialEventBag.Add(findItemEvent);
        specialEventBag.Add(findItemEvent);
        specialEventBag.Add(findItemEvent);
        specialEventBag.Add(encounterTrapEvent);
        specialEventBag.Add(encounterTrapEvent);
        specialEventBag.Add(encounterHealingPoolEvent);
        specialRoomEvent = new Room(() => {
            Console.Clear();
            specialEventBag.TakeOut().Start();
            return false;
        });
        roomBag.Add(specialRoomEvent);
        roomBag.Add(specialRoomEvent);
        roomBag.Add(specialRoomEvent);
        
    }
    
    public static void ShortPause()
    {
        Thread.Sleep(1000);
    }

    public static void LongPause()
    {
        Thread.Sleep(3500);
    }
}