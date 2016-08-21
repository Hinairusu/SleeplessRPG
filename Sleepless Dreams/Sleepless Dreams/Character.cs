using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sleepless_Dreams
{
    public class Character
    {

        //fixed stats imported elsewhere
        public int str = 8;
        public int dex = 8;
        public int con = 8;
        public int intel = 8;
        public int wis = 8;
        public int cha = 8;
        public int luck = 8;
        public int level = 1;
        public bool isAlive = true;
        public bool isMage = false;

        //below here starts at 0, [calculated later]
        public int matk = 0;
        public int mdef = 0;
        public int patk = 0;
        public int pdef = 0;
        public int cHP = 1;
        public int cmHP = 1;
        public int cMP = 0;
        public int cmMP = 0;

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

        // derriving sub stats from the characters base stats
        #region Sub Stats

        public int patkCalc() //Physcial Attack
        {
            this.patk = this.str + (this.dex / 2);

            return this.patk;
        } 

        public int matkCalc() //Magical Attack
        {
            this.matk = this.intel + ((this.wis + this.cha) / 3);

            return this.matk;
        } 

        public int pdefCalc() //Physcial Defence
        {
            this.pdef = this.dex + (this.con / 2);

            return this.pdef;
        }

        public int mdefCalc() //Magical Defence
        {
            this.mdef = this.wis + ((this.cha + this.intel) / 3);

            return this.mdef;
        }

        public int cHPCalc() //Current HP
        {
            this.cHP = (this.con + this.level) * 30;

            return this.cHP;
        }

        public int cmHPCalc() //Maximum HP
        {
            this.cmHP = (this.con + this.level) * 30;

            return this.cmHP;
        }

        public int mageMP() //Current MP if the character is a mage
        {
            if (isMage == true)
            {
                this.cMP = (this.level * 100) + (this.intel * 85);

                return this.cMP;
            }
            else
            {
                this.cMP = 0;
                return this.cMP;
            }
        }

        public int magemMP() //Maximum MP if the character is a mage
        {
            if (isMage == true)
            {
                this.cmMP = (this.level * 100) + (this.intel * 85);

                return this.cmMP;
            }
            else
            {
                this.cmMP = 0;
                return this.cmMP;
            }


        }





        #endregion
    }
}
