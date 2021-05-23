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
        public static void GenerateSMN()
        {
            Console.WriteLine("[SMN] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {SMN = true},
                    new GearSet("글쿨 2.48초 장비 세트.", "글로벌 쿨다운을 2.48초로 맞춘 장비 세트.", "Smoked Chicken", 23731.76d,
                        new Gear("Edenmorn Index", "dh60", "dh60"),
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
                    new GearSet("글쿨 2.5초 석판 반지 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트.", "Smoked Chicken", 23636.04d,
                        new Gear("Edenmorn Index", "det60", "det60"),
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
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {SMN = true}, new GearSet("절 알렉산더 2.48초 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Smoked Chicken", 16280.00d,
                        new Gear("Augmented Law's Order Index", "ch 467", "dh 467", "det 233"),
                        new Gear("Augmented Deepshadow Hood of Casting", "ch60", "ch60"),
                        new Gear("Shadowless Robe of Casting", "dh60", "dh60"),
                        new Gear("Shadowless Gloves of Casting", "ch60", "ch60"),
                        new Gear("Edengrace Tassets of Casting", "dh60", "dh60"),
                        new Gear("Edengrace Breeches of Casting", "ch60", "ch60"),
                        new Gear("Shadowless Boots of Casting", "dh60", "dh60"),
                        new Gear("Edengrace Earring of Casting", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Necklace of Casting", "dh60", "det60"),
                        new Gear("Edengrace Bracelet of Casting", "dh60", "dh60"),
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
                            ch = 3428,
                            dh = 2863,
                            det = 2231,
                            sks = 0,
                            sps = 519,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-smn-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}