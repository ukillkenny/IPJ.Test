using System;



class Program
{
    static void Main(string[] args)
    {
        bool gameOpen = true;

        Game game = new Game();

        do
        {
            gameOpen = game.Play();

        } while (gameOpen);
       
       


    }
}

