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
        public static void GenerateMCH()
        {
            Console.WriteLine("[MCH] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {MCH = true},
                    new GearSet("글쿨 2.5초 영식 몸통 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 영식 몸통 장비를 사용함.", "Smoked Chicken",
                        20818.45d, new Gear("Edenmorn Pistol", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Helm of Aiming", "det60", "det60"),
                        new Gear("Edenmorn Coat of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Sabatons of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Aiming", "dh60", "det60"),
                        new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60")),
                    new GearSet("글쿨 2.5초 석판 보강 몸통 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 석판 보강 몸통 장비를 사용함.",
                        "Smoked Chicken", 20817.6d, new Gear("Edenmorn Pistol", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Helm of Aiming", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Corselet of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Sabatons of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Aiming", "dh60", "det60"),
                        new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60"))),
                new("5.55 레지스탕스 BiS", "패치 5.55 레지스탕스 웨폰 BiS 리스트입니다.", new ClassJobCategory {MCH = true},
                    new GearSet("글쿨 2.5초 영식 몸통 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 영식 몸통 장비를 사용함.", "Smoked Chicken",
                        20954.10d, new Gear("Blade's Ingenuity", "ch 523", "dh 185", "det 474"),
                        new Gear("Augmented Cryptlurker's Helm of Aiming", "det60", "det60"),
                        new Gear("Edenmorn Coat of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Sabatons of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Aiming", "dh60", "det60"),
                        new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60")),
                    new GearSet("글쿨 2.5초 석판 보강 몸통 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 석판 보강 몸통 장비를 사용함.",
                        "Smoked Chicken", 20958.92d, new Gear("Blade's Ingenuity", "ch 517", "dh 154", "det 511"),
                        new Gear("Augmented Cryptlurker's Helm of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Corselet of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Sabatons of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Aiming", "dh60", "det60"),
                        new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {MCH = true},
                    new GearSet("절 알렉산더 2.5초 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 14328.15d,
                        new Gear("Augmented Law's Order Revolver", "ch 467", "dh 467", "det 233"),
                        new Gear("Shadowless Mask of Aiming", "det60", "det60"),
                        new Gear("Shadowless Coat of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Gloves of Aiming", "dh60", "det60"),
                        new Gear("Augmented Deepshadow Tassets of Aiming", "det60", "det60"),
                        new Gear("Shadowless Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Greaves of Aiming", "ch60", "dh60"),
                        new Gear("Shadowless Earrings of Aiming", "det60"),
                        new Gear("Augmented Deepshadow Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Bracelet of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Ring of Aiming", "det60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 0,
                            dex = 4287,
                            @int = 0,
                            mnd = 0,
                            ch = 3232,
                            dh = 2578,
                            det = 2799,
                            sks = 380,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    }, new GearSet("절 알렉산더 2.44초 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 14099.51d,
                        new Gear("Augmented Law's Order Revolver", "ch 467", "dh 467", "det 233"),
                        new Gear("Shadowless Mask of Aiming", "det60", "det60"),
                        new Gear("Shadowless Coat of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Gloves of Aiming", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Tassets of Aiming", "det60", "det60"),
                        new Gear("Shadowless Hose of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Sabatons of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Earrings of Aiming", "det60"),
                        new Gear("Augmented Deepshadow Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Bracelet of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Ring of Aiming", "det60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 0,
                            dex = 4303,
                            @int = 0,
                            mnd = 0,
                            ch = 2903,
                            dh = 2458,
                            det = 2724,
                            sks = 914,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-mch-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}