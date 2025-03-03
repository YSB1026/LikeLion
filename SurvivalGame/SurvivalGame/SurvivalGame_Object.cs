using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGame
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Stamina { get; private set; }
        public int MaxStamina { get; private set; }
        public Player(int mapSize)
        {
            X = Y = mapSize/2;
            MaxHealth = 10;
            Health = 10;
            MaxStamina = 4;
            Stamina = MaxStamina;
        }

        public void Move(int nextX, int nextY)
        {
            X = nextX; 
            Y = nextY;
            Stamina--;
        }

        public void Draw()
        {
            Console.Write("🦁");
        }
        public void IncreaseMaxStamina()
        {
            MaxStamina+=2;
        }
        public void IncreaseMaxHealth()
        {
            MaxHealth+=5;
        }
        public bool RecoveryHealth()
        {
            if (Health >= MaxHealth) return false;
            Health++;
            return true;
        }
        public bool RecoveryStamina()
        {
            if (Stamina >= MaxStamina) return false;
            Stamina++;
            return true;
        }
        public void GetDamage(int dmg)
        {
            Health-=dmg;
        }

        public void Rest()
        {
            Stamina = MaxStamina;
            Health = MaxHealth;
        }
    }

    //class WildAnimal
    //{

    //}

    //class Item
    //{

    //}
}
