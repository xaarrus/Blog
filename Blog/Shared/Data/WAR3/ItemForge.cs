using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Data.WAR3
{
    public class ItemForge
    {
        public int Id { get; set; }
        public ItemType TypeItem { get; set; }
        public string NameItem { get; set; }
        public string Description { get; set; }
        public List<int> ForgeFrom { get; set; }
        public string[] Tag { get; set; }
        public int Str { get; set; }
        public int Agi { get; set; }
        public int Int { get; set; }
        public int AllStats { get; set; }
        public int Defence { get; set; }
        public int MagRes { get; set; }
        public string DefenceTypeModeTo { get; set; }
        public string AttackTypeModeTo { get; set; }
        public int HP { get; set; }
        public int HPRegen { get; set; }
        public int MP { get; set; }
        public int MPRegen { get; set; }
        public int MoveSpeed { get; set; }
        public int DMG { get; set; }
        public int DMGPercent { get; set; }
        public int ASPD { get; set; }
        public int LifeSteal { get; set; }
        public int ReflectMeleDMG { get; set; }
        public ItemCritical CriticalChance { get; set; }
        public ItemCleave CleaveChance { get; set; }
        public ItemHeal HealChance { get; set; }
        public ItemBlock BlockChance { get; set; }
        public ItemPoison Poison { get; set; }
        public string SeeMeBonus()
        {
            string result = (Str > 0 ? $" STR + {Str}," : "")
                + (DMG > 0 ? $" DMG + {DMG}," : "")
                + (DMGPercent > 0 ? $" DMG + {DMGPercent}%," : "")
                + (Agi > 0 ? $" AGI + {Agi}," : "")
                + (Int > 0 ? $" INT + {Int}," : "")
                + (AllStats > 0 ? $" ALLSTATS + {AllStats}," : "")
                + (Defence > 0 ? $" Def + {Defence}," : "")
                + (MagRes > 0 ? $" MagRes + {MagRes}%," : "")
                + ((DefenceTypeModeTo != "" & DefenceTypeModeTo != null) ? $" Armor => {DefenceTypeModeTo}," : "")
                + ((AttackTypeModeTo != "" & AttackTypeModeTo != null) ? $" Attack => {AttackTypeModeTo}," : "")
                + (HP > 0 ? $" HP + {HP}," : "")
                + (HPRegen > 0 ? $" HP regen + {HPRegen}," : "")
                + (MP > 0 ? $" MP + {MP}," : "")
                + (MPRegen > 0 ? $" MP regen + {MPRegen}%," : "")
                + (MoveSpeed > 0 ? $" Move Speed + {MoveSpeed}," : "")
                + (ASPD > 0 ? $" ASPD + {ASPD}%," : "")
                + (ASPD < 0 ? $" ASPD {ASPD}%," : "")
                + (LifeSteal > 0 ? $" LifeSteal + {LifeSteal}%," : "")
                + (ReflectMeleDMG > 0 ? $" ReflectMeleeDMG + {ReflectMeleDMG}%," : "")
                + ((CriticalChance != null & CriticalChance != new ItemCritical()) ? $" Crit {CriticalChance.Chance}% to {CriticalChance.Modificator}x," : "")
                + ((BlockChance != null & BlockChance != new ItemBlock()) ? $" With {BlockChance.Chance}% block {BlockChance.Modificator} dmg," : "")
                + ((CleaveChance != null & CleaveChance != new ItemCleave()) ? $" Cleave {CleaveChance.Chance}% {CleaveChance.Modificator} AOE," : "")
                + ((Poison != null & Poison != new ItemPoison()) ? $" Poison {Poison.Modificator}dmg in sec/{Poison.Chance} sec," : "")
                ;
            return result;
        }
    }
    public class ItemChanceMod
    {
        public int Chance { get; set; }
        public decimal Modificator { get; set; }
    }
    public class ItemCritical : ItemChanceMod { }
    public class ItemCleave : ItemChanceMod { }
    public class ItemBlock : ItemChanceMod { }
    public class ItemPoison : ItemChanceMod { }
    public class ItemHeal : ItemChanceMod
    {
        public int RestoreHP { get; set; }
        public int RestoreMP { get; set; }
    }
    public enum ItemType
    {
        weapon,
        armor,
        jeweler
    }
}
