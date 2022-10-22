namespace Textgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            Player player = new Player("player", 10, 15, 0);
            Creature monster = new Creature("Rat", 5, 12, 0);
            Combat combat = new Combat();

            Console.WriteLine("Vad heter du?");
            player.Name = Console.ReadLine();

            combat.Fight(player, monster);

            player.Attack();
            monster.Defend(player.attack);

            Console.ReadKey();

            
        }
        
        
            
            
            
    }
}