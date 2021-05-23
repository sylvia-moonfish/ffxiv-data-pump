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
        public static void GenerateGNB()
        {
            Console.WriteLine("[GNB] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {GNB = true},
                    new GearSet("글쿨 2.41초 나이트/암기 호환 추천 세트.",
                        "글로벌 쿨다운을 2.41초로 맞춘 장비 세트. 나이트와 암흑기사 BiS 장비 세트와 호환됨. 재생 영식 1 ~ 4층 전 층에서 무난하게 사용 가능한 추천 세트.",
                        "Chicken Fettuccine", 13808.7d, new Gear("Edenmorn Gunblade", "dh60", "sks60"),
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
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60")),
                    new GearSet("글쿨 2.40초 빠른 기시 세트.",
                        "글로벌 쿨다운을 2.40초로 맞춘 장비 세트. 특정 전투 업타임을 위해 스킬 로테이션을 조절 중이거나 빠른 기시를 선호할 경우 추천.",
                        "Chicken Fettuccine", 13804.3d, new Gear("Edenmorn Gunblade", "dh60", "sks60"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "dh60", "sks60"),
                        new Gear("Edenmorn Coat of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "sks60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {GNB = true},
                    new GearSet("글쿨 2.40초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Chicken Fettuccine", 9445.4d,
                        new Gear("Augmented Law's Order Manatrigger", "ch 467", "det 467", "sks 233"),
                        new Gear("Augmented Deepshadow Helm of Fending", "dh60", "det60"),
                        new Gear("Shadowless Coat of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Gauntlets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Tassets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Breeches of Fending", "ch60", "ch60"),
                        new Gear("Shadowless Greaves of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Earring of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Necklace of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Bracelet of Fending", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Fending", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Fending", "ch60", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4371,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3765,
                            dh = 1220,
                            det = 2122,
                            sks = 1325,
                            sps = 0,
                            ten = 1041,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.40초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Chicken Fettuccine", 5590.5d,
                        new Gear("Augmented Law's Order Manatrigger", "ch 311", "det 308", "sks 309", "ten 239"),
                        new Gear("Neo-Ishgardian Cap of Fending"),
                        new Gear("Alliance Coat of Fending", "dh40", "dh40"),
                        new Gear("Alliance Armguards of Fending", "ch40", "dh40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Alliance Boots of Fending", "dh40", "dh40"),
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
                            ch = 2642,
                            dh = 580,
                            det = 2779,
                            sks = 998,
                            sps = 0,
                            ten = 577,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.40초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 4499.0d,
                        new Gear("Augmented Law's Order Manatrigger", "ch 280", "det 280", "sks 280", "ten 280"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Bonewicca Protector's Gauntlets", "ch40", "dh40"),
                        new Gear("Neo-Ishgardian Plate Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "dh40", "det40"),
                        new Gear("Exarchic Earrings of Fending"), new Gear("Edenmorn Necklace of Fending"),
                        new Gear("Exarchic Bracelet of Fending"), new Gear("Exarchic Ring of Fending"),
                        new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 100,
                            str = 2619,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2352,
                            dh = 444,
                            det = 1949,
                            sks = 988,
                            sps = 0,
                            ten = 364,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-gnb-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}