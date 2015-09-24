using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectBot
{
    class offsets
    {
        public static int baseAddress = 0xccf99c;
        public static int TargetBaseAddress = 0xCCF74C; 
        public static int ExpBaseAddress = 0xcceda8;
        public static int[] CurrentHP = new int[] {0x98,0x238,0x4b8 };
        public static int[] FullHP = new int[] { 0x98, 0x238, 0x504 };
        public static int[] CurrentMP = new int[] { 0x98, 0x238, 0x4bC };
        public static int[] FullMP = new int[] { 0x98, 0x238, 0x508 };
        public static int[] CurrentExp = new int[] { 0x30, 0x4c0 };
        public static int[] lvl = new int[] { 0x30, 0x4b0 };
        public static int[] Target = new int[] { 0x30, 0xD64 };
        public static int[] Meditation = new int[] { 0x30, 0x750 };
        public static int[] lutCounter = new int[] { 0x1c, 0x24, 0x14};


        public static int[] WeaponStrength = new int[] { 0x30, 0xf4c,0xc,0x0,0x74 };
        public static int[] MaxWeaponStrength = new int[] { 0x30, 0xf4c, 0xc, 0x0, 0x68 };
        
        public static int[] PosX = new int[] { 0x98, 0x238, 0x3C };
        public static int[] PosY = new int[] { 0x98, 0x238, 0x44 };
        public static int[] PosZ = new int[] { 0x98, 0x238, 0x40 };


        public static int[] TPosX = new int[] { 0x30,0x1484, 0x18C };
        public static int[] TPosY = new int[] { 0x30,0x1484, 0x188 };
        public static int[] TPosZ = new int[] { 0x30,0x1484, 0x190 };

 
        //Test
        public static int[] Test = new int[] { 0x98, 0x238, 0x1458, 0x188 }; 
         
        public static int[] Range = new int[] { 0x2C};
    }  
}
