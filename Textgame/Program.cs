namespace Textgame
{
    internal class Program
    {
        static void Main(string[] args) => Start();

        static void Start()
        {
            Player player = new Player("player");
            Creature monster = new Creature("Rat", 5, 6, 0);
            Combat combat = new Combat();
            

            Console.WriteLine("What is your characters name: ");
            player.Name = Console.ReadLine();

            
            combat.Fight(player, monster);
            combat.Fight(player, new Creature("Snake", 6,5,0));
            
            player.PrintStats();
            Console.ReadLine();
           

            Console.ReadKey();
        }
        
        
            
            
            
    }
}