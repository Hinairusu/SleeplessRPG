using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sleepless_Dreams
{
    public class Character
    {
        // Level
        private int level = 1;

        // Base Stats
        private int str = 8;
        private int dex = 8;
        private int con = 8;
        private int intel = 8;
        private int wis = 8;
        private int cha = 8;
        private int luck = 8;
        
        // Statuses
        private bool isAlive = true;
        private bool isMage = false;

        // HP and MP
        private int cHP = 1;
        private int mHP = 1;
        private int cMP = 0;
        private int mMP = 0;

        // Derived Stats
        private int matk = 0;
        private int mdef = 0;
        private int patk = 0;
        private int pdef = 0;

        // Damage Calculation
        public int damageCalc(int dmg)
        {
            this.cHP -= dmg;
            if (this.cHP <= 0)
            {
                this.cHP = 0;
                this.isAlive = false;
            }
            return this.cHP;
        }

#region Base Stats
        // Get, Add to, and Set Base Stats
        public int getStat(string statName, int value)
        {
            switch (statName)
            {
                case "Str":
                    return this.str;
                case "Dex":
                    return this.dex;
                case "Con":
                    return this.con;
                case "Int":
                    return this.intel;
                case "Wis":
                    return this.wis;
                case "Cha":
                    return this.cha;
                case "Luck":
                    return this.luck;
                case "Level":
                    return this.level;
            }
        }

        public void setStat(string statName, int value)
        {
            switch (statName)
            {
                case "Str":
                    this.str = value;
                case "Dex":
                    this.dex = value;
                case "Con":
                    this.con = value;
                case "Int":
                    this.intel = value;
                case "Wis":
                    this.wis = value;
                case "Cha":
                    this.cha = value;
                case "Luck":
                    this.luck = value;
                case "Level":
                    this.level = value;
            }
            updateDerivedStats();
        }

        public void addStat(string statName, int value)
        {
            switch (statName)
            {
                case "Str":
                    this.str += value;
                case "Dex":
                    this.dex += value;
                case "Con":
                    this.con += value;
                case "Int":
                    this.intel += value;
                case "Wis":
                    this.wis += value;
                case "Cha":
                    this.cha += value;
                case "Luck":
                    this.luck += value;
                case "Level":
                    this.level += value;
            }
            updateDerivedStats();
        }

        public void updateDerivedStats()
        {
            patkCalc();
            matkCalc();
            pdefCalc();
            mdefCalc();
            cHPCalc();
            mHPCalc();
            cMPCalc();
            mMPCalc();
        }
#endregion

#region Sub Stats
        // derriving sub stats from the characters base stats
        public void patkCalc() //Physcial Attack
        {
            this.patk = this.str + (this.dex / 2);
        } 

        public void matkCalc() //Magical Attack
        {
            this.matk = this.intel + ((this.wis + this.cha) / 3);
        } 

        public void pdefCalc() //Physcial Defence
        {
            this.pdef = this.dex + (this.con / 2);
        }

        public void mdefCalc() //Magical Defence
        {
            this.mdef = this.wis + ((this.cha + this.intel) / 3);
        }

        public void cHPCalc() //Current HP
        {
            this.cHP = (this.con + this.level) * 30;
        }

        public void mHPCalc() //Maximum HP
        {
            this.mHP = (this.con + this.level) * 30;
        }

        public void cMPCalc() //Current MP if the character is a mage
        {
            if (isMage)
                this.cMP = (this.level * 100) + (this.intel * 85);
            else
                this.cMP = 0;
        }

        public void mMPCalc() //Maximum MP if the character is a mage
        {
            if (isMage)
                this.mMP = (this.level * 100) + (this.intel * 85);
            else
                this.mMP = 0;
        }
#endregion
    }
}
