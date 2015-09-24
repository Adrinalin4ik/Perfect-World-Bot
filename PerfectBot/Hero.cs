using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectBot
{
    class Hero
    {
        public static int CurrentHp;
        public static int CurrentMp;
        public static int FullHp;
        public static int FullMp;
        public static int PosX, PosY, PosZ;
        public static int CurrentExp;
        public static int lvl;
        public static int WeaponStrength;
        public static int MaxWeaponStrength;
        public static int targetId;
        

        public static int Test;  

        public static int TPosX, TPosY, TPosZ;
         
        public static bool target = false;
        public static bool Meditation;  
        public static string Status;
        public static int lutCounter; 

        public static int ExpCount = 0;
        public static int SaveExp = 0;
        public static int GainExp = 0;
        public static int MobCounter = 0;
        public static void ExpCounter()
        {

            if (SaveExp > 0)
            {
                
                GainExp = Hero.CurrentExp - SaveExp;
                if (GainExp > 0)
                {
                    ExpCount += GainExp;
                    MobCounter++;
                }
            }
            SaveExp = Hero.CurrentExp;
        }



        public static int[] MobId = new int[]{};
        public static int i = 1;
        public static void SaveMobs()
        {
            MobId[i++] = Hero.targetId;
        }
        public static bool GoodMob()
        {
            if (MobId.Length > 0)
            {
                for (int i = 0; i <= MobId.Length; i++)
                {
                    if (Hero.targetId == MobId[i])
                    {
                        return true;
                    }

                }
            }
            else return true;
            return false;
        }

    }
}
