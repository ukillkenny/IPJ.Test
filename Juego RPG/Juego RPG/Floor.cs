using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



class Floor
{
    public List<Enemy> enemies;
    public Floor(int maxEnemiesInFloor)
    {
        enemies = new List<Enemy>();
        Random random = new Random();
        int enemiesInFloor = random.Next(1, maxEnemiesInFloor);
        for (int i = 0; i < enemiesInFloor; i++)
        {
            enemies.Add(new Enemy("Goblin", 20, 5, 2, 5));
        }

    }

    public BinaryWriter Save(BinaryWriter bw)
    {
        bw.Write(enemies.Count);
        for (int i = 0; i < enemies.Count; i++)
        {
            bw = enemies[i].Save(bw);
        }
        return bw;
    }

    public Player Fight(Player player)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            player = enemies[i].Attack(player);
        }

        enemies = player.Attack(enemies);

        List<Enemy> enemiesAlive = new List<Enemy>();

        for (int i = 0; i < enemies.Count; i++)
        { 
            if (enemies[i].IsDead() == false)
            {
                enemiesAlive.Add(enemies[i]);
            }
        }

        enemies = enemiesAlive;
        return player;
    }

}

