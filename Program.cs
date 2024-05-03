using System;

class Program
{
    static void Main()
    {
        PrintWelcomeMessage(); // Welcome message to enter into code
        string playerName = GetPlayerName(); // Call string to get player name

        // Player attributes
        int playerHealth = 100;
        int playerDamage = 60;
        int enemiesDefeated = 0;

        // Enemy attributes
        int[] enemyHealth = { 40, 80, 120, 160 };
        int[] enemyDamage = { 40, 60, 80, 100 };
        bool[] enemyDefeated = { false, false, false, false };

        while (true)
        {
            Console.Clear();
            PrintPlayerInfo(playerName, playerHealth, playerDamage, enemiesDefeated); // Player attributes

            // Check if all enemies are defeated
            if (enemiesDefeated == 4)
            {
                Console.WriteLine("Congratulations! You have defeated all enemies!");
                break;
            }

            // Select a random enemy that is not defeated
            Random rand = new Random();
            int enemyIndex;
            do
            {
                enemyIndex = rand.Next(0, 4);
            } while (enemyDefeated[enemyIndex]);

            Console.WriteLine($"You are faced with Enemy {enemyIndex + 1}!");

            Console.WriteLine("What will you do? (Type 'run' or 'attack')");
            string decision = Console.ReadLine();

            Console.Clear();

            if (decision.ToLower() == "run")
            {
                Console.Clear();
                PrintPlayerInfo(playerName, playerHealth, playerDamage, enemiesDefeated); // Player attributes
                Console.WriteLine("You run away from the enemy!");
                Console.WriteLine("You receive no damage");
                ShieldASCII();
            }
            else if (decision.ToLower() == "attack")
            {
                Console.Clear();
                enemyHealth[enemyIndex] -= playerDamage;
                PrintPlayerInfo(playerName, playerHealth, playerDamage, enemiesDefeated); // Player attributes
                Console.WriteLine($"You dealt {playerDamage} damage to Enemy {enemyIndex + 1}!");

                if (enemyHealth[enemyIndex] <= 0)
                {
                    Console.Clear();
                    enemyDefeated[enemyIndex] = true;
                    enemiesDefeated++;
                    playerDamage += 40;
                    PrintPlayerInfo(playerName, playerHealth, playerDamage, enemiesDefeated); // Player attributes
                    Console.WriteLine($"You defeated Enemy {enemyIndex + 1}!");
                    DefeatedEnemy();
                }
                else
                {
                    Console.Clear();
                    playerHealth -= enemyDamage[enemyIndex];
                    PrintPlayerInfo(playerName, playerHealth, playerDamage, enemiesDefeated); // Player attributes  

                    Console.WriteLine($"Enemy {enemyIndex + 1} dealt {enemyDamage[enemyIndex]} damage to you!");
                    Console.WriteLine("The enemy escaped!");
                    EnemyAlive();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid decision. Please type 'run' or 'attack'.");
            }

            if (playerHealth <= 0)
            {
                Console.Clear();
                GameOver();
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    static void PrintWelcomeMessage()
    {
        Console.Clear();

        Console.WriteLine(@"
 __| |____________________________________________________________________________________________| |__
(__   ____________________________________________________________________________________________   __)
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                              █───█─▄▀▀─█───▄▀▀─▄▀▀▄─█▄─▄█─▄▀▀                              | |
   | |                              █───█─█───█───█───█──█─█▀▄▀█─█──                              | |
   | |                              █───█─█▀▀─█───█───█──█─█─▀─█─█▀▀                              | |
   | |                              █▄█▄█─█───█───█───█──█─█───█─█──                              | |
   | |                              ─▀─▀───▀▀──▀▀──▀▀──▀▀──▀───▀──▀▀                              | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                    PRESS ENTER TO BEGIN                                    | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
(__   ____________________________________________________________________________________________   __)
   | |                                                                                            | |
   | |                                                                                            | |-
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |
   | |                                                                                            | |

        "); // Print Welcome Sign
        Console.ReadLine();
    }


    static void PrintPlayerInfo(string playerName, int playerHealth, int playerDamage, int enemiesDefeated) // Player attributes
    {
        Console.WriteLine($"Player Name: {playerName}");
        Console.WriteLine($"Player Health: {playerHealth}");
        Console.WriteLine($"Player Damage: {playerDamage}");
        Console.WriteLine($"Enemies Defeated: {enemiesDefeated}");
        Console.WriteLine();
    }
    static string GetPlayerName() // Get player name
    {
        string playerName;
        do
        {
            Console.Clear();
            Console.WriteLine("Enter your name (up to 20 characters):");
            playerName = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(playerName) || playerName.Length > 20);

        playerName = playerName.Substring(0, 1).ToUpper() + playerName.Substring(1).ToLower(); // Capitalize first letter
        return playerName;
    }


    static void EnemyAlive() // ASCII for enemy running away
    {
        Console.WriteLine(@"
|\
        | | /|
        |  V |
        |    |              
1       |    |       1
8b      |    |      d8
88b   ,%|    |%,   d88
888b%%%%|    |%%%%d888
  Y88888[[[]]]88888Y
        [[[]]]
        [[[]]]-.
       _[[[]]]> \   _____
      (_______    -( * * )----
     (________       | Y |
     (_________    _(_____)____
      (________,_/\
        ||||||
        {{{}}}
       {{{{}}}}
        {{{}}}
          ()
        ");


    }


    static void DefeatedEnemy() // ASCII for defeating enemy
    {
        Console.WriteLine(@"
                              .___.
          /)               ,-^     ^-.
         //               /           \
.-------| |--------------/  __     __  \-------------------.__
|WMWMWMW| |>>>>>>>>>>>>> | />>\   />>\ |>>>>>>>>>>>>>>>>>>>>>>:>
`-------| |--------------| \__/   \__/ |-------------------'^^
         \\               \    /|\    /
          \)               \   \_/   /
                            |       |
                            |+H+H+H+|
                            \       /
                             ^-----^
        ");
    }

    static void ShieldASCII() // ASCII for player running away
    {
        Console.WriteLine(@"
\_________________/
|       | |       |
|       | |       |
|       | |       |
|_______| |_______|
|_______   _______|
|       | |       |
|       | |       |
 \      | |      /
  \     | |     /
   \    | |    /
    \   | |   /
     \  | |  /
      \ | | /
       \| |/
        \_/
        ");
    }

    static void GameOver() // Game over message in ASCII
    {
        Console.WriteLine(@"
  ________    _____      _____  ___________ ____________   _________________________ 
 /  _____/   /  _  \    /     \ \_   _____/ \_____  \   \ /   /\_   _____/\______   \
/   \  ___  /  /_\  \  /  \ /  \ |    __)_   /   |   \   Y   /  |    __)_  |       _/
\    \_\  \/    |    \/    Y    \|        \ /    |    \     /   |        \ |    |   \
 \______  /\____|__  /\____|__  /_______  / \_______  /\___/   /_______  / |____|_  /
        \/         \/         \/        \/          \/                 \/         \/ 
        ");
    }
}
