﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Enemy
{
    private string name;
    private int life;
    private int maxLife;
    private int mana;
    private int maxMana;

    private int MinAttack;
    private int MaxAttack;
    public Enemy(string name, int maxLife, int maxMana, int minAttack, int maxAttack)
    {
        this.name = name;
        this.maxLife = maxLife;
        this.life = maxLife;
        this.maxMana = maxMana;
        this.mana = maxMana;
        this.MinAttack = minAttack;
        this.MaxAttack = maxAttack;

    }

    public BinaryWriter Save(BinaryWriter bw)
    {
        bw.Write(name);
        bw.Write(maxLife);
        bw.Write(life);
        bw.Write(maxMana);
        bw.Write(mana);
        bw.Write(MinAttack);
        bw.Write(MaxAttack);
        return bw;
    }

    public Player Attack(Player player)
    {
        Random random = new Random();
        int damage = random.Next(MinAttack, MaxAttack);
        player.DoDamage(damage);
        return player;
    }

    public string GetStatus()
    {
        string status = "";

        status += "Name: " + name + "\n";
        status += "Life: " + life + "\n";

        return status;
    }

    public void DoDamage(int amount)
    {
        life -= amount;
        if (life <= 0)
        {
            Console.WriteLine("F " + name);
        }
    }

    public bool IsDead()
    {
        return life <= 0;
    }
}

