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
        public static void GenerateRDM()
        {
            Console.WriteLine("[RDM] Generating tables...");

            Table[] tables =
            {
                new("5.4 BiS", "패치 5.4 BiS 리스트입니다.", new ClassJobCategory {RDM = true},
                    new GearSet("글쿨 2.48초 장비 세트.", "글로벌 쿨다운을 2.48초로 맞춘 장비 세트.", "Smoked Chicken", 20872.33d,
                        new Gear("Edenmorn Rapier", "dh60", "dh60"),
                        new Gear("Edenmorn Hat of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Dress Sleeves of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Chausses of Casting", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Shoes of Casting", "dh60", "det60"),
                        new Gear("Edenmorn Earrings of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Casting", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Casting", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "dh60", "det60")),
                    new GearSet("글쿨 2.5초 석판 반지 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 석판 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의.", "Smoked Chicken", 20899.20d,
                        new Gear("Edenmorn Rapier", "det60", "det60"),
                        new Gear("Edenmorn Hat of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Dress Sleeves of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Chausses of Casting", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Shoes of Casting", "dh60", "det60"),
                        new Gear("Edenmorn Earrings of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Casting", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Casting", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "dh60", "det60"),
                        new Gear("Cryptlurker's Ring of Casting", "dh60", "det60"))),
                new("5.55 레지스탕스 웨폰 BiS", "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다.", new ClassJobCategory {RDM = true},
                    new GearSet("글쿨 2.49초 장비 세트.", "글로벌 쿨다운을 2.49초로 맞춘 장비 세트.", "Smoked Chicken", 21057.03d,
                        new Gear("Blade's Temperance", "ch 528", "dh 499", "det 129", "sps 26"),
                        new Gear("Edenmorn Hat of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Dress Sleeves of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Chausses of Casting", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Shoes of Casting", "dh60", "det60"),
                        new Gear("Edenmorn Earrings of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Casting", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Casting", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "dh60", "det60"),
                        new Gear("Augmented Exarchic Ring of Casting", "dh60", "det60")),
                    new GearSet("글쿨 2.48초 장비 세트.", "글로벌 쿨다운을 2.48초로 맞춘 장비 세트.", "Smoked Chicken", 21029.74d,
                        new Gear("Blade's Temperance", "ch 528", "dh 499", "det 28", "sps 127"),
                        new Gear("Edenmorn Hat of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Dress Sleeves of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Casting", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Chausses of Casting", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Shoes of Casting", "dh60", "det60"),
                        new Gear("Edenmorn Earrings of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Casting", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Casting", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "dh60", "det60"),
                        new Gear("Augmented Exarchic Ring of Casting", "dh60", "det60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {RDM = true}, new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Smoked Chicken", 14301.13d,
                        new Gear("Augmented Law's Order Rapier", "ch 467", "dh 407", "det 293"),
                        new Gear("Augmented Deepshadow Hood of Casting", "ch60", "ch60"),
                        new Gear("Shadowless Robe of Casting", "dh60", "dh60"),
                        new Gear("Shadowless Gloves of Casting", "ch60", "ch60"),
                        new Gear("Edengrace Tassets of Casting", "dh60", "dh60"),
                        new Gear("Edengrace Breeches of Casting", "ch60", "ch60"),
                        new Gear("Shadowless Boots of Casting", "dh60", "dh60"),
                        new Gear("Edengrace Earring of Casting", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Necklace of Casting", "det60", "det60"),
                        new Gear("Augmented Deepshadow Bracelet of Casting", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Casting", "dh60", "det60"),
                        new Gear("Shadowless Ring of Casting", "dh60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 4274,
                            mnd = 0,
                            ch = 3350,
                            dh = 2763,
                            det = 2549,
                            sks = 0,
                            sps = 380,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-rdm-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}