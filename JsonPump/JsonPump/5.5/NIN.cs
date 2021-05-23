using System;
using System.IO;
using JsonPump.Models;
using JsonPump.Models.JSON;
using Newtonsoft.Json;
using Attribute = JsonPump.Models.JSON.Attribute;

namespace JsonPump._5._5
{
    public static partial class TableGenerator
    {
        public static void GenerateNIN()
        {
            Console.WriteLine("[NIN] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {NIN = true}, new GearSet(
                    "풍둔 글쿨 2.12초 장비 세트.", "최소 기시속 장비 세트.", "Smoked Chicken", 21687.31d,
                    new Gear("Edenmorn Main Gauches", "dh60", "dh60"),
                    new Gear("Augmented Cryptlurker's Mesail of Scouting", "dh60", "dh60"),
                    new Gear("Edenmorn Bolero of Scouting", "dh60", "dh60"),
                    new Gear("Edenmorn Fingerless Gloves of Scouting", "ch60", "ch60"),
                    new Gear("Augmented Cryptlurker's Belt of Scouting", "ch60", "ch60"),
                    new Gear("Edenmorn Hose of Scouting", "ch60", "ch60"),
                    new Gear("Augmented Cryptlurker's Boots of Scouting", "ch60", "det60"),
                    new Gear("Edenmorn Earrings of Aiming", "dh60", "dh60"),
                    new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                    new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                    new Gear("Edenmorn Ring of Aiming", "dh60", "det60"),
                    new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {NIN = true}, new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Smoked Chicken", 14933.49d,
                        new Gear("Augmented Law's Order Knives", "ch 467", "dh 448", "det 252"),
                        new Gear("Shadowless Mask of Scouting", "dh60", "det60"),
                        new Gear("Shadowless Coat of Scouting", "ch60", "ch60"),
                        new Gear("Shadowless Gloves of Scouting", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Tassets of Scouting", "ch60", "ch60"),
                        new Gear("Edengrace Breeches of Scouting", "dh60", "dh60"),
                        new Gear("Shadowless Sabatons of Scouting", "ch60", "ch60"),
                        new Gear("Edengrace Earring of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Bracelet of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Ring of Aiming", "dh60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 0,
                            dex = 4480,
                            @int = 0,
                            mnd = 0,
                            ch = 2938,
                            dh = 3206,
                            det = 2524,
                            sks = 380,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-nin-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}