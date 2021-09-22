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
        public static void GenerateWAR()
        {
            Console.WriteLine("[WAR] Generating tables...");

            Table[] tables =
            {
                new("1주차 출발 BiS", "패치 5.4 1주차 영식 공략을 위한 스타팅 BiS 리스트입니다.", new ClassJobCategory {WAR = true}, new
                    GearSet("풀금단 + 극만신 세트.", "1주차 풀금단 제작 세트에 첫 주에 획득 가능한 극만신 무기를 조합한 세트. 1~4층 트라이에 적합.",
                        "Chicken Fettuccine", 11735.4d, new Gear("Emerald Battleaxe", "det60", "det60"),
                        new Gear("Exarchic Circlet of Fending", "det60", "det60", "det60", "det20", "det20"),
                        new Gear("Exarchic Coat of Fending", "ch60", "ch60", "sks60", "ch20", "sks20"),
                        new Gear("Exarchic Gauntlets of Fending", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Plate Belt of Fending", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Hose of Fending", "det60", "det60", "det60", "det20", "det20"),
                        new Gear("Exarchic Sabatons of Fending", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Earrings of Fending", "ch60", "det60", "det20", "det20", "det20"),
                        new Gear("Exarchic Choker of Fending", "ch60", "det60", "det20", "det20", "det20"),
                        new Gear("Exarchic Bracelet of Fending", "det60", "sks60", "sks20", "sks20", "sks20"),
                        new Gear("Exarchic Ring of Fending", "ch60", "sks60", "sks20", "sks20", "sks20"),
                        new Gear("Exarchic Ring of Fending", "ch60", "sks60", "sks20", "sks20", "ten20"))),
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {WAR = true},
                    new GearSet("글쿨 2.43초 느린 기시 세트.",
                        "글로벌 쿨다운을 2.43초로 맞춘 장비 세트. 폭풍의 눈 버프 패치로 인해 글쿨 제한이 풀리면서 가능해진 시뮬레이션상 최고 BiS. 재생 영식 1 ~ 4층 모든 층에서 좋은 효율을 보여주나 운용 난이도가 조금 더 어려울 수 있음.",
                        "Smoked Chicken", 13056.4d, new Gear("Edenmorn Battleaxe", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "det60", "det60"),
                        new Gear("Edenmorn Coat of Fending", "det60", "det60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Leather Belt of Fending", "det60", "ten60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "det60", "ten60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "ten60", "ten60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "ten60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Fending", "det60", "ten60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60")),
                    new GearSet("글쿨 2.37초 빠른 기시 세트.", "글로벌 쿨다운을 2.37초로 맞춘 장비 세트. 운용 난이도가 쉽지만 그만큼 시뮬레이션상 DPS가 낮음.",
                        "Chicken Fettuccine", 13031.1d, new Gear("Edenmorn Battleaxe", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "det60", "det60"),
                        new Gear("Edenmorn Coat of Fending", "det60", "det60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Leather Belt of Fending", "det60", "ten60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "det60", "sks60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "det60", "sks60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "sks60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Fending", "ch60", "ch60"),
                        new Gear("Edenmorn Ring of Fending", "ten60", "sks60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60"))),
                new("5.55 레지스탕스 BiS", "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다.", new ClassJobCategory {WAR = true},
                    new GearSet("글쿨 2.43초 느린 기시 세트.",
                        "글로벌 쿨다운을 2.43초로 맞춘 장비 세트. 폭풍의 눈 버프 패치로 인해 글쿨 제한이 풀리면서 가능해진 시뮬레이션상 최고 BiS. 재생 영식 1 ~ 4층 모든 층에서 좋은 효율을 보여주나 운용 난이도가 조금 더 어려울 수 있음.",
                        "Smoked Chicken", 13410.0d, new Gear("Blade's Valor", "ch 530", "det 475", "ten 177"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "det60", "det60"),
                        new Gear("Edenmorn Coat of Fending", "det60", "det60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Leather Belt of Fending", "det60", "ten60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "det60", "ten60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "det60", "ten60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "ten60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Fending", "det60", "ten60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60")),
                    new GearSet("글쿨 2.37초 빠른 기시 세트.", "글로벌 쿨다운을 2.37초로 맞춘 장비 세트. 운용 난이도가 쉽지만 그만큼 시뮬레이션상 DPS가 낮음.",
                        "Chicken Fettuccine", 13397.2d, new Gear("Blade's Valor", "ch 525", "det 476", "sks 166", "ten 15"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "det60", "det60"),
                        new Gear("Edenmorn Coat of Fending", "det60", "det60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Leather Belt of Fending", "det60", "sks60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "det60", "sks60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "det60", "sks60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "sks60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Fending", "det60", "sks60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60"))),
                new("절 난이도 BiS",
                    "절 난이도 전용 BiS 리스트입니다. 전사의 경우 폭풍의 눈 버프 패치로 인해 글로벌 쿨다운의 제약이 풀리면서 좀 더 느린 기술 시전 속도를 가진 장비 세트 역시 운용 가능하게 되었습니다. 본인이 운용하기에 가장 편한 글로벌 쿨다운을 골라주시면 되겠습니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다."
                    , new ClassJobCategory {WAR = true},
                    new GearSet("글쿨 2.43초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 8972.0d,
                        new Gear("Augmented Law's Order Labrys", "ch 461", "det 442", "sks 31", "ten 233"),
                        new Gear("Shadowless Mask of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Coat of Fending", "det60", "det60"),
                        new Gear("Edengrace Gauntlets of Fending", "det60", "ten60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "det60", "det60"),
                        new Gear("Shadowless Skirt of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Greaves of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Earring of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "det60", "det60"),
                        new Gear("Edengrace Bracelet of Fending", "ten60", "ten60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4411,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3548,
                            dh = 380,
                            det = 2574,
                            sks = 1015,
                            sps = 0,
                            ten = 1970,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.38초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Chicken Fettuccine", 8944.4d,
                        new Gear("Augmented Law's Order Labrys", "ch 456", "det 444", "sks 251", "ten 16"),
                        new Gear("Shadowless Mask of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Coat of Fending", "det60", "det60"),
                        new Gear("Edengrace Gauntlets of Fending", "det60", "sks60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "det60", "det60"),
                        new Gear("Shadowless Skirt of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Greaves of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Earring of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "det60", "det60"),
                        new Gear("Edengrace Bracelet of Fending", "sks60", "sks60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4411,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3614,
                            dh = 380,
                            det = 2397,
                            sks = 1523,
                            sps = 0,
                            ten = 1573,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.37초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Chicken Fettuccine", 8945.8d,
                        new Gear("Augmented Law's Order Labrys", "ch 452", "det 451", "sks 205", "ten 59"),
                        new Gear("Shadowless Mask of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Coat of Fending", "det60", "det60"),
                        new Gear("Edengrace Gauntlets of Fending", "det60", "sks60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "det60", "det60"),
                        new Gear("Shadowless Skirt of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Greaves of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Earring of Fending", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "det60", "sks60"),
                        new Gear("Edengrace Bracelet of Fending", "sks60", "sks60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "sks60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4411,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3620,
                            dh = 380,
                            det = 2295,
                            sks = 1624,
                            sps = 0,
                            ten = 1568,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.43초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Smoked Chicken", 5173.9d,
                        new Gear("Augmented Law's Order Labrys", "ch 317", "det 308", "sks 291", "ten 251"),
                        new Gear("Neo-Ishgardian Cap of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Edenchoir Gauntlets of Fending"), new Gear("Edenmorn Leather Belt of Fending"),
                        new Gear("Edenmorn Hose of Fending"),
                        new Gear("Alliance Boots of Fending", "det40", "det40"),
                        new Gear("Augmented Cryptlurker's Earring of Fending"),
                        new Gear("Edenmorn Necklace of Fending"), new Gear("Exarchic Bracelet of Fending"),
                        new Gear("Exarchic Ring of Fending"), new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 105,
                            str = 2987,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2741,
                            dh = 364,
                            det = 2629,
                            sks = 782,
                            sps = 0,
                            ten = 615,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.38초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Smoked Chicken", 5155.6d,
                        new Gear("Augmented Law's Order Labrys", "ch 310", "det 303", "sks 307", "ten 247"),
                        new Gear("Neo-Ishgardian Cap of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Alliance Armguards of Fending", "ch40", "det40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Alliance Boots of Fending", "det40", "det40"),
                        new Gear("Exarchic Earrings of Fending"), new Gear("Edenmorn Necklace of Fending"),
                        new Gear("Exarchic Bracelet of Fending"), new Gear("Exarchic Ring of Fending"),
                        new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 105,
                            str = 2987,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2719,
                            dh = 364,
                            det = 2346,
                            sks = 1116,
                            sps = 0,
                            ten = 611,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.37초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Chicken Fettuccine", 5161.8d,
                        new Gear("Augmented Law's Order Labrys", "ch 318", "det 315", "sks 266", "ten 261"),
                        new Gear("Neo-Ishgardian Cap of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Alliance Armguards of Fending", "ch40", "det40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Alliance Boots of Fending", "det40", "det40"),
                        new Gear("Exarchic Earrings of Fending"), new Gear("Edenmorn Necklace of Fending"),
                        new Gear("Exarchic Bracelet of Fending"), new Gear("Exarchic Ring of Fending"),
                        new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 105,
                            str = 2987,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2798,
                            dh = 364,
                            det = 2179,
                            sks = 1182,
                            sps = 0,
                            ten = 625,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.43초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 4257.7d,
                        new Gear("Augmented Law's Order Labrys", "ch 280", "det 280", "sks 280", "ten 280"),
                        new Gear("Neo-Ishgardian Cap of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Brutal Gauntlets +2", "det40", "ten40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "det40", "sks40"),
                        new Gear("Augmented Cryptlurker's Earring of Fending"),
                        new Gear("Edenmorn Necklace of Fending"), new Gear("Exarchic Bracelet of Fending"),
                        new Gear("Exarchic Ring of Fending"), new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 100,
                            str = 2634,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2472,
                            dh = 364,
                            det = 2343,
                            sks = 796,
                            sps = 0,
                            ten = 684,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.38초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 4243.1d,
                        new Gear("Augmented Law's Order Labrys", "ch 280", "det 280", "sks 280", "ten 280"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Brutal Gauntlets +2", "det40", "sks40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "det40", "sks40"),
                        new Gear("Exarchic Earrings of Fending"), new Gear("Edenmorn Necklace of Fending"),
                        new Gear("Exarchic Bracelet of Fending"), new Gear("Exarchic Ring of Fending"),
                        new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 100,
                            str = 2634,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2472,
                            dh = 364,
                            det = 2063,
                            sks = 1116,
                            sps = 0,
                            ten = 644,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.37초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Chicken Fettuccine", 4244.4d,
                        new Gear("Augmented Law's Order Labrys", "ch 280", "det 280", "sks 280", "ten 280"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Brutal Gauntlets +2", "det40", "sks40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "det40", "ten40"),
                        new Gear("Exarchic Earrings of Fending"), new Gear("Edenmorn Necklace of Fending"),
                        new Gear("Exarchic Bracelet of Fending"), new Gear("Exarchic Ring of Fending"),
                        new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 100,
                            str = 2634,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2543,
                            dh = 364,
                            det = 1884,
                            sks = 1183,
                            sps = 0,
                            ten = 684,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-war-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}