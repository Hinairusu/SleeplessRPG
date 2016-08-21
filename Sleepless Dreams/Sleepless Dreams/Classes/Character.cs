using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sleepless_Dreams
{
    public class Character
    {
        // Character Name
        private String name = "";

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

        // Get, Add to, and Set Base Stats
        #region Base Stats
        /* Call when you want one of the character's stats for whatever reason
         *      statname sets which stat it will return.
         */
        public int getStat(string statName)
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
                default:
                    return -1;
            }
        }

        /* Call when you want to set a stat to a specific amount.
         *      statName is which stat to affect
         *      value is what it will be set to
         */
        public void setStat(string statName, int value)
        {
            switch (statName)
            {
                case "Str":
                    this.str = value;
                    break;
                case "Dex":
                    this.dex = value;
                    break;
                case "Con":
                    this.con = value;
                    break;
                case "Int":
                    this.intel = value;
                    break;
                case "Wis":
                    this.wis = value;
                    break;
                case "Cha":
                    this.cha = value;
                    break;
                case "Luck":
                    this.luck = value;
                    break;
                case "Level":
                    this.level = value;
                    break;
                default:
                    break;
            }
            updateDerivedStats();
        }

        /* Call when you want to add or subtract from a stat.
         *      statName is which stat to affect
         *      value is the amount to add (passing a negative value will subtract the value)
         */
        public void addStat(string statName, int value)
        {
            switch (statName)
            {
                case "Str":
                    this.str += value;
                    break;
                case "Dex":
                    this.dex += value;
                    break;
                case "Con":
                    this.con += value;
                    break;
                case "Int":
                    this.intel += value;
                    break;
                case "Wis":
                    this.wis += value;
                    break;
                case "Cha":
                    this.cha += value;
                    break;
                case "Luck":
                    this.luck += value;
                    break;
                case "Level":
                    this.level += value;
                    break;
                default:
                    break;
            }
            updateDerivedStats();
        }

        /* Call to set the update all derived stats after a Base Stat has been updated
         * Could be upgraded to only change those that are needed to update
         */
        private void updateDerivedStats()
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

        /* Set all Derived Stat calculation classes to private as they shouldn't need to be called from outside
         *      Also should only be called when the stats that affect them are changed.
         *      Added a class to return specific Derived Stats when called.
         */
        // derriving sub stats from the characters base stats
        #region Sub Stats
        /* Call when you want one of the character's Derived Stats for whatever reason
         *      statname sets which stat it will return.
         */
        public int getSubStat(string statName)
        {
            switch (statName)
            {
                case "pAtk":
                    return this.patk;
                case "pDef":
                    return this.pdef;
                case "mAtk":
                    return this.matk;
                case "mDef":
                    return this.mdef;
                case "cHP":
                    return this.cHP;
                case "mHP":
                    return this.mHP;
                case "cMP":
                    return this.cMP;
                case "mMP":
                    return this.mMP;
                default: 
                    return -1;
            }
        }

        private void patkCalc() //Physcial Attack
        {
            this.patk = this.str + (this.dex / 2);
        } 

        private void matkCalc() //Magical Attack
        {
            this.matk = this.intel + ((this.wis + this.cha) / 3);
        } 

        private void pdefCalc() //Physcial Defence
        {
            this.pdef = this.dex + (this.con / 2);
        }

        private void mdefCalc() //Magical Defence
        {
            this.mdef = this.wis + ((this.cha + this.intel) / 3);
        }

        private void cHPCalc() //Current HP
        {
            this.cHP = (this.con + this.level) * 30;
        }

        private void mHPCalc() //Maximum HP
        {
            this.mHP = (this.con + this.level) * 30;
        }

        private void cMPCalc() //Current MP if the character is a mage
        {
            if (isMage)
                this.cMP = (this.level * 100) + (this.intel * 85);
            else
                this.cMP = 0;
        }

        private void mMPCalc() //Maximum MP if the character is a mage
        {
            if (isMage)
                this.mMP = (this.level * 100) + (this.intel * 85);
            else
                this.mMP = 0;
        }
        #endregion

        #region Statuses
        /* Call when you want one of the character's statuses for whatever reason
         *      statname sets which stat it will return.
         */
        public bool getStatus(string statName)
        {
            switch (statName)
            {
                case "Mage":
                    return this.isMage;
                case "Alive":
                    return this.isAlive;
                default:
                    return false;
            }
        }

        /* Call when you want to set a status to a specific amount.
         *      statName is which status to affect
         *      value is what it will be set to
         */
        public void setStat(string statName, bool value)
        {
            switch (statName)
            {
                case "Mage":
                    this.isMage = value;
                    break;
                case "Alive":
                    this.isAlive = value;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
