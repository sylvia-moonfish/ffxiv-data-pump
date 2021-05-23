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
        public static void GeneratePLD()
        {
            Console.WriteLine("[PLD] Generating tables...");

            var tables = new Table[]
            {
                new("1주차 출발 BiS", "패치 5.4 1주차 영식 공략을 위한 스타팅 BiS 리스트입니다.", new ClassJobCategory {PLD = true}, new
                    GearSet("풀금단 + 극만신 세트.", "1주차 풀금단 제작 세트에 첫 주에 획득 가능한 극만신 무기를 조합한 세트. 1~4층 트라이에 적합.",
                        "Chicken Fettuccine", 12483.4d, new Gear("Emerald Bastard Sword", "dh60", "det60"),
                        new Gear("Emerald Shield"),
                        new Gear("Exarchic Circlet of Fending", "dh60", "dh60", "dh60", "ten20", "sks20"),
                        new Gear("Exarchic Coat of Fending", "ch60", "ch60", "dh60", "ch20", "dh20"),
                        new Gear("Exarchic Gauntlets of Fending", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Plate Belt of Fending", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Hose of Fending", "dh60", "dh60", "dh60", "dh20", "dh20"),
                        new Gear("Exarchic Sabatons of Fending", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Earrings of Fending", "ch60", "dh60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Choker of Fending", "ch60", "dh60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Bracelet of Fending", "dh60", "dh60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Ring of Fending", "ch60", "dh60", "dh20", "dh20", "dh20"),
                        new Gear("Exarchic Ring of Fending", "ch60", "dh60", "dh20", "dh20", "dh20"))),
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {PLD = true},
                    new GearSet("글쿨 2.43초 느린 기시 세트.",
                        "글로벌 쿨다운을 2.43초로 맞춘 장비 세트. 기믹 때문에 성령을 빼 딜싸이클을 조절해야 하는 재생 영식 2, 3층 딜갱신에 효율적. 암흑기사와 건브레이커 BiS 장비 세트와도 호환됨. 음식을 치킨 페투치네로 바꿀 경우 글로벌 쿨다운이 2.42초로 낮아지며 기믹 외 업타임 로스가 없는 재생 영식 2층 등에 더 적합해짐.",
                        "Smoked Chicken", 13834.3d, new Gear("Edenmorn Bastard Sword", "dh60", "dh60"),
                        new Gear("Edenmorn Scutum"),
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
                    new GearSet("글쿨 2.41초 암기/건브 호환 추천 세트.",
                        "글로벌 쿨다운을 2.41초로 맞춘 장비 세트. 재생 영식 1 ~ 4층 전층에서 쓰기 적합하고 가장 무난한 추천 세트. 암흑기사와 건브레이커 BiS와도 호환됨.",
                        "Chicken Fettuccine", 13857.5d, new Gear("Edenmorn Bastard Sword", "dh60", "sks60"),
                        new Gear("Edenmorn Scutum"),
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
                        "글쿨 2.40초 빠른 기시 세트.",
                        "글로벌 쿨다운을 2.40초로 맞춘 장비 세트. 빠른 기시를 선호할 경우 추천. 암흑기사, 건브레이커 BiS와는 호환되지 않음.",
                        "Chicken Fettuccine", 13844.5d, new Gear("Edenmorn Bastard Sword", "dh60", "sks60"),
                        new Gear("Edenmorn Scutum"),
                        new Gear("Augmented Cryptlurker's Elmo of Fending", "dh60", "sks60"),
                        new Gear("Edenmorn Coat of Fending", "dh60", "sks60"),
                        new Gear("Edenmorn Armguards of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Hose of Fending", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Sollerets of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Fending", "dh60", "dh60"),
                        new Gear("Edenmorn Necklace of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Wristlet of Fending", "ch60", "dh60"),
                        new Gear("Edenmorn Ring of Fending", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Fending", "ch60", "ch60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {PLD = true},
                    new GearSet("글쿨 2.40초 절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Chicken Fettuccine", 9472.7d,
                        new Gear("Augmented Law's Order Bastard Sword", "ch 334", "det 334", "sks 166"),
                        new Gear("Augmented Law's Order Kite Shield", "ch 133", "det 133", "sks 67"),
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
                    }, new GearSet("글쿨 2.40초 절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Smoked Chicken", 5176.1d,
                        new Gear("Augmented Law's Order Bastard Sword", "ch 227", "det 227", "sks 227", "ten 153"),
                        new Gear("Augmented Law's Order Kite Shield", "ch 91", "det 91", "sks 82", "ten 69"),
                        new Gear("Neo-Ishgardian Cap of Fending"),
                        new Gear("Alliance Coat of Fending", "dh40", "dh40"),
                        new Gear("Alliance Armguards of Fending", "ch40", "det40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Alliance Boots of Fending", "dh40", "dh40"),
                        new Gear("Augmented Cryptlurker's Earring of Fending"),
                        new Gear("Edenmorn Necklace of Fending"), new Gear("Exarchic Bracelet of Fending"),
                        new Gear("Alliance Ring of Fending", "dh40"), new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 105,
                            str = 2972,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2686,
                            dh = 564,
                            det = 2329,
                            sks = 982,
                            sps = 0,
                            ten = 586,
                            pie = 0
                        }
                    }, new GearSet("글쿨 2.40초 절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 4253.2d,
                        new Gear("Augmented Law's Order Bastard Sword", "ch 200", "det 200", "sks 200", "ten 200"),
                        new Gear("Augmented Law's Order Kite Shield", "ch 80", "det 80", "sks 80", "ten 80"),
                        new Gear("Chivalrous Circlet +2", "ch40", "ch40"), new Gear("Edenmorn Coat of Fending"),
                        new Gear("Chivalrous Gauntlets +2", "dh40", "det40"),
                        new Gear("Edenmorn Leather Belt of Fending"), new Gear("Edenmorn Hose of Fending"),
                        new Gear("Bonewicca Protector's Sabatons", "dh40", "dh40"),
                        new Gear("Augmented Cryptlurker's Earring of Fending"),
                        new Gear("Bonewicca Necklace of Fending", "dh40"), new Gear("Exarchic Bracelet of Fending"),
                        new Gear("Bonewicca Ring of Fending", "dh40"), new Gear("Edenmorn Ring of Fending"))
                    {
                        attribute = new Attribute
                        {
                            wd = 100,
                            str = 2619,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2320,
                            dh = 564,
                            det = 2183,
                            sks = 988,
                            sps = 0,
                            ten = 644,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-pld-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}