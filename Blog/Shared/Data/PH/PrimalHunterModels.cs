using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Data.PH
{
    public class PrimalHunterModels
    {
        public class PrimalHunterItemModel
        {
            public int item_id { get; set; }
            public string item_name { get; set; } = string.Empty;
        }
        
        public class PrimalHunterSaveModel
        {
            public int avatar { get; set; }
            public Collectable collectable { get; set; } = new();
            public int d_v { get; set; }
            public double health { get; set; }
            public List<Inventory> inventory { get; set; } = new();
            public Kills kills { get; set; } = new();
            public string lang { get; set; } = string.Empty;
            public object persistent { get; set; } = new();
            public Position position { get; set; } = new();
            public bool seen_intro { get; set; }
            public int tokens { get; set; }
            public List<int> unlocked_items { get; set; } = new();//{1017,1008,1010,1019,1018,1016,1009}
            public World world { get; set; } = new();
            public string world_map { get; set; } = string.Empty;
            public double xp { get; set; }
            public class Collectable
            {
                public object rock { get; set; } = new();
            }

            public class Inventory
            {
                public string guid { get; set; } = string.Empty;
                [Range(-2, 9999)]
                public int health { get; set; }
                public int item_id { get; set; }
                [Range(1, 24)]
                public int slot { get; set; } // 1 backpack, 2 weaponOne, 3 weaponSecond, 4 weaponCut, 5,6 ForScope, 8,9 ForBullet, 11 four, 12 five, 18 body, 19 pants, 20 boots, 21 head, 22 gloves, 24 eye
            }

            public class Kills
            {
                public object quetzalcoatlus { get; set; } = new();
                public object t_rex { get; set; } = new();
                public object triceratops { get; set; } = new();
                public object utahraptor { get; set; } = new();
                public object velociraptor { get; set; } = new();
            }

            public class Position
            {
                public double x { get; set; }
                public double y { get; set; }
                public double yaw { get; set; }
                public double z { get; set; }
            }
            public class World
            {
                public double severity { get; set; }
                public double time_of_day { get; set; }
                public double weather_time { get; set; }
            }
        }
    }
}
