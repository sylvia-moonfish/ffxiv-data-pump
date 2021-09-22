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
        public static void GenerateDRK()
        {
            Console.WriteLine("[DRK] Generating tables...");

            Table[] tables =
            {
                new("1주차 출발 BiS", "패치 5.4 1주차 영식 공략을 위한 스타팅 BiS 리스트입니다.", new ClassJobCategory {DRK = true}, new
                    GearSet("풀금단 세트.", "1주차 풀금단 제작 세트. 1~4층 트라이에 적합.", "Chicken Fettuccine", 11649.5d,
                        new Gear("Exarchic Guillotine", "ch60", "ch60", "det60", "dh20", "dh20"),
                        new Gear("Exarchic Circlet of Fending", "dh60", "dh60", "det60", "dh20", "dh20"),
                        new Gear("Exarchic Coat of Fending", "ch60", "ch60", "dh60", "dh20", "dh20"),
                        new Gear("Exarchic Gauntlets of Fending", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Plate Belt of Fending", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Hose of Fending", "dh60", "sks60", "sks60", "sks20", "sks20"),
                        new Gear("Exarchic Sabatons of Fending", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Earrings of Fending", "ch60", "dh60", "det20", "det20", "det20"),
                        new Gear("Exarchic Choker of Fending", "ch60", "det60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Bracelet of Fending", "dh60", "sks60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Ring of Fending", "ch60", "dh60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Ring of Fending", "ch60", "dh60", "dh20", "dh20", "dh20"))),
                new("5.5 BiS",
                    "패치 5.4 ~ 5.5 BiS 리스트입니다. 암흑기사 스킬 로테이션을 위해 요구되는 최소 글로벌 쿨다운은 2.43초지만 피의 칼날 판정이 상당히 까다로우며 피의 칼날 효과가 지속되는 도중 5번의 글로벌 쿨다운 기술을 넣는 것이 매우 중요하므로 나무인형을 먼저 쳐본 후 자신의 인터넷 환경에 맞는 적정 기시를 찾는 것이 중요합니다."
                    , new ClassJobCategory {DRK = true},
                    new GearSet("글쿨 2.41초 나이트/건브 호환 추천 세트.",
                        "글로벌 쿨다운을 2.41초로 맞춘 장비 세트. 나이트와 건브레이커 BiS 장비 세트와 호환됨. 재생 영식 1 ~ 4층 전 층에서 무난하게 사용 가능한 추천 세트.",
                        "Chicken Fettuccine", 13067.6d, new Gear("Edenmorn Zweihander", "dh60", "sks60"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Coat of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60")), new GearSet(
                        "글쿨 2.38초 빠른 기시 세트.",
                        "글로벌 쿨다운을 2.38초로 맞춘 장비 세트. 특정 전투 업타임을 위해 스킬 로테이션을 조절 중이거나 빠른 기시를 선호할 경우 추천. 나이트와 건브레이커 BiS 장비 세트와도 호환됨.",
                        "Chicken Fettuccine", 13061.5d, new Gear("Edenmorn Zweihander", "dh60", "sks60"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Coat of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Hose of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60"))),
                new("5.55 레지스탕스 BiS",
                    "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다."
                    , new ClassJobCategory {DRK = true},
                    new GearSet("글쿨 2.41초 나이트/건브 호환 추천 세트.",
                        "글로벌 쿨다운을 2.41초로 맞춘 장비 세트. 나이트와 건브레이커 BiS 장비 세트와 호환됨. 재생 영식 1 ~ 4층 전 층에서 무난하게 사용 가능한 추천 세트.",
                        "Chicken Fettuccine", 13156.0d, new Gear("Blade's Justice", "ch 528", "det 518", "sks 60", "ten 76"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Coat of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60")), new GearSet(
                        "글쿨 2.38초 빠른 기시 세트.",
                        "글로벌 쿨다운을 2.38초로 맞춘 장비 세트. 특정 전투 업타임을 위해 스킬 로테이션을 조절 중이거나 빠른 기시를 선호할 경우 추천.",
                        "Chicken Fettuccine", 13110.4d, new Gear("Blade's Justice", "ch 524", "det 472", "sks 181", "ten 5"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "dh60", "det60"),
                        new Gear("Edenmorn Coat of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Hose of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Fending", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Fending", "ch60", "dh60"))),
                new("절 난이도 BiS",
                    "절 난이도 전용 BiS 리스트입니다. 최소 요구 글로벌 쿨다운은 2.43초이지만 인터넷 환경 등에 따라 달라질 수 있으므로 본인이 운용하기에 가장 편한 글로벌 쿨다운을 골라주시면 되겠습니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다."
                    , new ClassJobCategory {DRK = true},
                    new GearSet("글쿨 2.43초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 8932.6d,
                        new Gear("Augmented Law's Order Zweihander", "ch 466", "det 465", "sks 171", "ten 65"),
                        new Gear("Augmented Deepshadow Helm of Fending", "dh60", "dh60"),
                        new Gear("Shadowless Coat of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Gauntlets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Hose of Fending"),
                        new Gear("Edengrace Greaves of Fending", "dh60", "dh60"),
                        new Gear("Shadowless Earrings of Fending", "dh60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Bracelet of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4400,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3634,
                            dh = 1340,
                            det = 2244,
                            sks = 1015,
                            sps = 0,
                            ten = 1106,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.40초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Chicken Fettuccine", 8933.3d,
                        new Gear("Augmented Law's Order Zweihander", "ch 464", "det 393", "sks 310"),
                        new Gear("Augmented Deepshadow Helm of Fending", "dh60", "dh60"),
                        new Gear("Shadowless Coat of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Gauntlets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "dh60", "dh60"),
                        new Gear("Shadowless Skirt of Fending", "ch60", "ch60"),
                        new Gear("Edengrace Greaves of Fending", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Earring of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Bracelet of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4394,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3783,
                            dh = 1340,
                            det = 1559,
                            sks = 1320,
                            sps = 0,
                            ten = 1475,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.38초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Chicken Fettuccine", 8895.8d,
                        new Gear("Augmented Law's Order Zweihander", "ch 467", "det 467", "sks 233"),
                        new Gear("Augmented Deepshadow Helm of Fending", "dh60", "dh60"),
                        new Gear("Shadowless Coat of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Gauntlets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Hose of Fending"),
                        new Gear("Edengrace Greaves of Fending", "dh60", "dh60"),
                        new Gear("Shadowless Earrings of Fending", "det60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Bracelet of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4400,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3798,
                            dh = 1280,
                            det = 1693,
                            sks = 1527,
                            sps = 0,
                            ten = 1041,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.43초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Smoked Chicken", 5090.5d,
                        new Gear("Augmented Law's Order Zweihander", "ch 318", "det 318", "sks 318", "ten 213"),
                        new Gear("Neo-Ishgardian Cap of Fending"),
                        new Gear("Alliance Coat of Fending", "dh40", "dh40"),
                        new Gear("Edenchoir Gauntlets of Fending"), new Gear("Edenmorn Leather Belt of Fending"),
                        new Gear("Edenmorn Hose of Fending"), new Gear("Alliance Boots of Fending", "dh40", "dh40"),
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
                            ch = 2742,
                            dh = 524,
                            det = 2471,
                            sks = 809,
                            sps = 0,
                            ten = 577,
                            pie = 0
                        }
                    },
                    new GearSet("글쿨 2.38초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Smoked Chicken", 5099.5d,
                        new Gear("Augmented Law's Order Zweihander", "ch 318", "det 318", "sks 318", "ten 213"),
                        new Gear("Neo-Ishgardian Cap of Fending"),
                        new Gear("Alliance Coat of Fending", "dh40", "dh40"),
                        new Gear("Edenmorn Armguards of Fending"), new Gear("Alliance Belt of Fending", "ch40"),
                        new Gear("Edenmorn Hose of Fending"), new Gear("Alliance Boots of Fending", "dh40", "dh40"),
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
                            dh = 524,
                            det = 2153,
                            sks = 1127,
                            sps = 0,
                            ten = 577,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.40초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 4198.5d,
                        new Gear("Augmented Law's Order Zweihander", "ch 280", "det 280", "sks 280", "ten 280"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Abyss Gauntlets +2", "dh40", "dh40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "dh40", "dh40"),
                        new Gear("Bonewicca Earring of Fending", "dh40"), new Gear("Edenmorn Necklace of Fending"),
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
                            dh = 564,
                            det = 1983,
                            sks = 1000,
                            sps = 0,
                            ten = 644,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.38초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 4201.2d,
                        new Gear("Augmented Law's Order Zweihander", "ch 280", "det 280", "sks 280", "ten 280"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Abyss Gauntlets +2", "dh40", "dh40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "dh40", "dh40"),
                        new Gear("Bonewicca Earring of Fending", "dh40"), new Gear("Heirloom Necklace of Fending"),
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
                            dh = 564,
                            det = 1852,
                            sks = 1120,
                            sps = 0,
                            ten = 644,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-drk-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}