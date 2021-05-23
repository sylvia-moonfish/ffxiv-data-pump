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
        public static void GenerateAST()
        {
            Console.WriteLine("[AST] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS",
                    "패치 5.4 ~ 5.5 BiS 리스트입니다. 점성술사의 BiS는 신앙 스탯과 마시속에 따라 나누어져 있습니다. 신앙이 낮고 마시속이 빠를 수록 데미지 기댓값이 높지만 MP 관리가 힘들어집니다. 재생 영식 4층의 경우 요구되는 힐량과 그에 따른 MP 소모가 극심하므로 MP 관리에 어려움을 느끼고 있다면 좀 더 높은 신앙과 느린 마시속을 가진 장비 세트를 맞추는 것도 고려해보세요."
                    , new ClassJobCategory {AST = true},
                    new GearSet("신앙 682 빠른 마시 데미지 추천 세트.",
                        "글로벌 쿨다운을 2.3초로 맞춘 장비 세트. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의. 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Twilight Popoto Salad", 11663.83d, new Gear("Edenmorn Torquetum", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "sps60"),
                        new Gear("Edenmorn Gown of Healing", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "sps60", "sps60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "sps60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "dh60")),
                    new GearSet("신앙 682 데미지 세트.",
                        "글로벌 쿨다운을 2.36초로 맞춘 장비 세트. 마시속을 살짝 낮춰 운용 난이도를 완화. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의. 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Twilight Popoto Salad", 11566.09d, new Gear("Edenmorn Torquetum", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "det60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "det60")),
                    new GearSet("신앙 840 느린 마시 세트.",
                        "글로벌 쿨다운을 2.42초로 맞춘 장비 세트. 높은 신앙과 느린 마시속으로 MP 관리가 가장 쉬운 세트. 힐러 운용이 아직 미숙하거나 MP 관리가 힘드신 분들께 추천. 제작 보강 장비가 추가되는 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Smoked Chicken", 11393.71d, new Gear("Edenmorn Torquetum", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Belt of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Shoes of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Exarchic Choker of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "dh60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이후에는 극대와 의지에 스탯이 분배된 레지스탕스 웨폰을 사용하시면 됩니다.",
                    new ClassJobCategory {AST = true},
                    new GearSet("절 알렉산더 낮은 신앙 세트.", "절 알렉산더 레이드용 낮은 신앙 장비 세트.", "Smoked Chicken", 7522.46d,
                        new Gear("Edengrace Planisphere", "ch60", "ch60"),
                        new Gear("Edengrace Temple Chain of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Scale Mail of Healing", "ch60", "ch60"),
                        new Gear("Edengrace Armlets of Healing", "ch60", "ch60"),
                        new Gear("Edengrace Tassets of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Pantaloons of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Sandals of Healing", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Earring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Necklace of Healing", "ch60", "dh60"),
                        new Gear("Edengrace Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Healing", "dh60", "dh60"),
                        new Gear("Deepshadow Ring of Healing", "dh60", "dh60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 0,
                            mnd = 4229,
                            ch = 3109,
                            dh = 1220,
                            det = 2357,
                            sks = 0,
                            sps = 1023,
                            ten = 0,
                            pie = 1408
                        }
                    }, new GearSet("절 알렉산더 높은 신앙 세트.", "절 알렉산더 레이드용 높은 신앙 장비 세트.", "Smoked Chicken", 7409.65d,
                        new Gear("Edengrace Planisphere", "ch60", "ch60"),
                        new Gear("Edengrace Temple Chain of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Scale Mail of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Armguards of Healing", "ch60", "ch60"),
                        new Gear("Edengrace Tassets of Healing", "det60", "sps60"),
                        new Gear("Edengrace Pantaloons of Healing", "det60", "det60"),
                        new Gear("Edengrace Sandals of Healing", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Earring of Healing", "det60", "sps60"),
                        new Gear("Augmented Deepshadow Necklace of Healing", "ch60", "det60"),
                        new Gear("Edengrace Bracelet of Healing", "det60", "det60"),
                        new Gear("Edengrace Ring of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Healing", "dh60", "det60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 0,
                            mnd = 4241,
                            ch = 3037,
                            dh = 440,
                            det = 3034,
                            sks = 0,
                            sps = 824,
                            ten = 0,
                            pie = 1791
                        }
                    })
            };

            foreach (var table in tables) table.CalculateFlatHps(700, 30, new ClassJobCategory {AST = true});

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-ast-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}