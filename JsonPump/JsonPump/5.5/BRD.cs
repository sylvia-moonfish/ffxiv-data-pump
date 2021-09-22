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
        public static void GenerateBRD()
        {
            Console.WriteLine("[BRD] Generating tables...");

            Table[] tables =
            {
                new("1주차 출발 BiS", "패치 5.4 1주차 영식 공략을 위한 스타팅 BiS 리스트입니다.", new ClassJobCategory {BRD = true}, new
                    GearSet("풀금단 + 일반 레이드 세트.", "1주차 풀금단 제작 세트에 첫 주에 획득 가능한 일반 레이드 장비를 조합한 세트.", "Smoked Chicken",
                        0d, new Gear("Exarchic Longbow", "ch60", "ch60", "det60", "ch20", "det20"),
                        new Gear("Exarchic Hood of Aiming", "dh60", "dh60", "dh60", "dh20", "dh20"),
                        new Gear("Exarchic Top of Aiming", "ch60", "ch60", "dh60", "ch20", "dh20"),
                        new Gear("Edenmete Armguards of Aiming", "dh60", "dh60"),
                        new Gear("Exarchic Sash of Aiming", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Bottoms of Aiming", "ch60", "ch60", "det60", "ch20", "det20"),
                        new Gear("Exarchic Boots of Aiming", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Earrings of Aiming", "dh60", "det60", "det20", "det20", "det20"),
                        new Gear("Exarchic Choker of Aiming", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Bracelet of Aiming", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Ring of Aiming", "dh60", "det60", "det20", "det20", "det20"),
                        new Gear("Exarchic Ring of Aiming", "dh60", "det60", "det20", "det20", "det20"))),
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {BRD = true},
                    new GearSet("글쿨 2.46초 추천 세트.", "글로벌 쿨다운을 2.46초로 맞춘 장비 세트.", "Smoked Chicken", 0d,
                        new Gear("Edenmorn Cavalry Bow", "sks60", "sks60"),
                        new Gear("Augmented Cryptlurker's Helm of Aiming", "det60", "det60"),
                        new Gear("Edenmorn Coat of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Boots of Aiming", "dh60", "dh60"),
                        new Gear("Edenmorn Earrings of Aiming", "dh60", "det60"),
                        new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Aiming", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60")), new GearSet(
                        "글쿨 2.5초 느린 기시 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 인터넷 환경이 좋지 않거나 느린 기시속을 선호하시는 분들께 추천.",
                        "Smoked Chicken", 0d, new Gear("Edenmorn Cavalry Bow", "det60", "det60"),
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
                new("5.55 레지스탕스 BiS", "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다.", new ClassJobCategory {BRD = true},
                    new GearSet("글쿨 2.46초 추천 세트.", "글로벌 쿨다운을 2.46초로 맞춘 장비 세트.", "Smoked Chicken", 0d,
                        new Gear("Blade's Muse", "ch 524", "dh 491", "det 48", "sks 119"),
                        new Gear("Augmented Cryptlurker's Helm of Aiming", "det60", "det60"),
                        new Gear("Edenmorn Coat of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Aiming", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Belt of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Hose of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Boots of Aiming", "dh60", "dh60"),
                        new Gear("Edenmorn Earrings of Aiming", "dh60", "det60"),
                        new Gear("Edenmorn Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edenmorn Wristlet of Aiming", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Aiming", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Aiming", "ch60", "dh60")), new GearSet(
                        "글쿨 2.5초 느린 기시 세트.", "글로벌 쿨다운을 2.5초로 맞춘 장비 세트. 인터넷 환경이 좋지 않거나 느린 기시속을 선호하시는 분들께 추천.",
                        "Smoked Chicken", 0d, new Gear("Blade's Muse", "ch 523", "dh 358", "det 301"),
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
                    new ClassJobCategory {BRD = true},
                    new GearSet("절 알렉산더 2.47초 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 0d,
                        new Gear("Augmented Law's Order Composite Bow", "ch 452", "dh 466", "det 218", "sks 31"),
                        new Gear("Shadowless Mask of Aiming", "dh60", "det60"),
                        new Gear("Shadowless Coat of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Gloves of Aiming", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Tassets of Aiming", "dh60", "det60"),
                        new Gear("Shadowless Hose of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Greaves of Aiming", "ch60", "dh60"),
                        new Gear("Edengrace Earring of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Necklace of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Bracelet of Aiming", "ch60", "ch60"),
                        new Gear("Edengrace Ring of Aiming", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Ring of Aiming", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 0,
                            dex = 4487,
                            @int = 0,
                            mnd = 0,
                            ch = 3135,
                            dh = 2954,
                            det = 2403,
                            sks = 609,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    }, new GearSet("절 알렉산더 2.44초 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 0d,
                        new Gear("Augmented Law's Order Composite Bow", "ch 465", "dh 387", "det 315"),
                        new Gear("Shadowless Mask of Aiming", "det60", "det60"),
                        new Gear("Shadowless Coat of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Gloves of Aiming", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Tassets of Aiming", "det60", "det60"),
                        new Gear("Shadowless Hose of Aiming", "ch60", "ch60"),
                        new Gear("Shadowless Sabatons of Aiming", "ch60", "dh60"),
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
                            dex = 4510,
                            @int = 0,
                            mnd = 0,
                            ch = 2821,
                            dh = 2696,
                            det = 2625,
                            sks = 914,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            foreach (var table in tables) table.CalculateFlatDps(750, 0, new ClassJobCategory {BRD = true});

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-brd-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}