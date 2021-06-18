﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class Player
{
    private string name;
    private int life;
    private int maxLife;
    private int mana;
    private int maxMana;

    private Location location;

    public Player(string name, int maxLife, int maxMana, Location spawnPoint)
    {
        this.name = name;
        this.maxLife = maxLife;
        this.life = maxLife;
        this.maxMana = maxMana;
        this.mana = maxMana;
        location = spawnPoint;

    }

    public BinaryWriter Save(BinaryWriter bw)
    {
        bw.Write(name);
        bw.Write(maxLife);
        bw.Write(life);
        bw.Write(maxMana);
        bw.Write(mana);
        bw.Write((int)location);
        return bw;

    }

    public void RestoreMana()
    {
        mana = maxMana;
    }

    public void RestoreMana(int amount)
    {
        mana += amount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    public void Heal()
    {
        life = maxLife;
    }

    public void Heal(int amount)
    {
        life += amount;
        if (life > maxLife)
        {
            life = maxLife;
        }
    }

    public Location GetLocation()
    {
        return location;
    }


    public void GoToTower()
    {
        location = Location.Tower;
    }

    public void GoToInn()
    {
        location = Location.Inn;
    }


    public void DoDamage(int amount)
    {
        life -= amount;
        if (life <= 0)
        {
            Console.WriteLine("F");
        }
    }

    public List<Enemy> Attack(List<Enemy> enemies)
    {
        Console.WriteLine("Select an enemy");

        for (int i = 0; i < enemies.Count; i++)
        {
            Console.WriteLine("Enemy N°: " + i);
            Console.WriteLine(enemies[i].GetStatus());
        }

        Console.WriteLine("Attack!");
        Console.WriteLine("Select an index from 0 to " + (enemies.Count - 1));

        int input = Convert.ToInt32(Console.ReadLine());

        if (input >0 && input < enemies.Count)
        {
            enemies[input].DoDamage(10);
        }
        else
        {
            Console.WriteLine("Miss!");
        }

        return enemies;
    }

}
