using System;

class Program
{

    Enemy dino;
    Enemy goblin;

    Menu mainMenu;
    Menu characterMenu;

    Event gameStartEvent;
    Event enemyEncounterEvent;
    Event itemSwapEvent;

    Room emptyRoomEvent;
    Room enemyRoomEvent;
    Room specialRoomEvent;
    Room staircaseRoomEvent;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
        DefineEnemies();
        DefineItems();
        DefineBasicMenus();
        DefineEvents();
        DefineRooms();
        MainGameLoop();
    }

    static void MainGameLoop()
    {
        throw new NotImplementedException();
    }

    static void DefineEnemies()
    {
        
    }
    
    static void DefineItems()
    {
        
    }
    
    static void DefineBasicMenus()
    {
        
    }
    
    static void DefineEvents()
    {
        
    }
    
    static void DefineRooms()
    {
        
    }
    
}