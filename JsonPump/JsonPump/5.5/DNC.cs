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
        public static void GenerateDNC()
        {
            Console.WriteLine("[DNC] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {DNC = true}, new GearSet(
                    "글쿨 2.5초 장비 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트.", "Smoked Chicken", 18664.16d,
                    new Gear("Edenmorn Chakrams", "det60", "det60"),
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
                    new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60"))),
                new("5.55 레지스탕스 BiS", "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다.", new ClassJobCategory {DNC = true}, new GearSet(
                    "글쿨 2.5초 장비 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트.", "Smoked Chicken", 18692.19d,
                    new Gear("Blade's Euphoria", "ch 523", "dh 358", "det 301"),
                    new Gear("Augmented Cryptlurker's Helm of Aiming", "dh60", "det60"),
                    new Gear("Edenmorn Coat of Aiming", "dh60", "dh60"),
                    new Gear("Augmented Cryptlurker's Vambraces of Aiming", "dh60", "det60"),
                    new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                    new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                    new Gear("Edenmorn Sabatons of Aiming", "ch60", "ch60"),
                    new Gear("Edenmorn Earrings of Aiming", "dh60", "dh60"),
                    new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                    new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                    new Gear("Edenmorn Ring of Aiming", "dh60", "det60"),
                    new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {DNC = true}, new GearSet("절 알렉산더 2.5초 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Smoked Chicken", 12823.78d,
                        new Gear("Augmented Law's Order Chakrams", "ch 452", "dh 454", "det 258", "sks 3"),
                        new Gear("Shadowless Mask of Aiming", "dh60", "det60"),
                        new Gear("Shadowless Coat of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Gloves of Aiming", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Tassets of Aiming", "dh60", "det60"),
                        new Gear("Shadowless Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Greaves of Aiming", "ch60", "dh60"),
                        new Gear("Shadowless Earrings of Aiming", "dh60"),
                        new Gear("Augmented Deepshadow Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Bracelet of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Ring of Aiming", "dh60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 0,
                            dex = 4286,
                            @int = 0,
                            mnd = 0,
                            ch = 3217,
                            dh = 2864,
                            det = 2524,
                            sks = 383,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-dnc-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}