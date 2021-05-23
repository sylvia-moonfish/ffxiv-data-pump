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
        public static void GenerateDRG()
        {
            Console.WriteLine("[DRG] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {DRG = true},
                    new GearSet("글쿨 2.5초 추천 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 재생 영식 최적화에 가장 적합.", "Smoked Chicken",
                        22643.07d, new Gear("Edenmorn Halberd", "dh60", "dh60"),
                        new Gear("Edenmorn Mask of Maiming", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Cuirass of Maiming", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Maiming", "ch60", "det60"),
                        new Gear("Edenmorn Leather Belt of Maiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Maiming", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Maiming", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "dh60", "dh60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Slaying", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "det60")),
                    new GearSet("글쿨 2.46초 빠른 기시 세트.", "글로벌 쿨다운을 2.46초로 맞춘 장비 세트. 빠른 기시속을 선호하시는 분들께 추천.",
                        "Smoked Chicken", 22672.82d, new Gear("Edenmorn Halberd", "dh60", "det60"),
                        new Gear("Edenmorn Mask of Maiming", "det60", "det60"),
                        new Gear("Edenmorn Coat of Maiming", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Maiming", "ch60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Maiming", "ch60", "det60"),
                        new Gear("Edenmorn Hose of Maiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Maiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "det60", "sks60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Slaying", "det60", "sks60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "det60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {DRG = true}, new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Smoked Chicken", 15763.46d,
                        new Gear("Augmented Law's Order Spear", "ch 456", "dh 453", "det 258"),
                        new Gear("Shadowless Mask of Maiming", "dh60", "det60"),
                        new Gear("Edengrace Mail of Maiming", "dh60", "dh60"),
                        new Gear("Shadowless Vambraces of Maiming", "ch60", "det60"),
                        new Gear("Edengrace Tassets of Maiming", "dh60", "dh60"),
                        new Gear("Shadowless Trousers of Maiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Sollerets of Maiming", "dh60", "det60"),
                        new Gear("Augmented Deepshadow Earring of Slaying", "dh60", "dh60"),
                        new Gear("Edengrace Choker of Slaying", "dh60", "det60"),
                        new Gear("Augmented Deepshadow Bracelet of Slaying", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Slaying", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Slaying", "ch60", "det60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4479,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3773,
                            dh = 2902,
                            det = 2260,
                            sks = 380,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-drg-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}