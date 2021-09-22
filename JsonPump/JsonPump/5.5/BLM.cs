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
        public static void GenerateBLM()
        {
            Console.WriteLine("[BLM] Generating tables...");

            Table[] tables =
            {
                new("1주차 출발 BiS", "패치 5.4 1주차 영식 공략을 위한 스타팅 BiS 리스트입니다.", new ClassJobCategory {BLM = true}, new
                    GearSet("풀금단 + 극만신 세트.", "1주차 풀금단 제작 세트에 첫 주에 획득 가능한 극만신 무기를 조합한 세트. 1~4층 트라이에 적합.",
                        "Twilight Popoto Salad", 21611.23d, new Gear("Emerald Rod", "dh60", "dh60"),
                        new Gear("Exarchic Hat of Casting", "dh60", "dh60", "dh60", "dh20", "dh20"),
                        new Gear("Exarchic Coat of Casting", "ch60", "ch60", "sps60", "ch20", "sps20"),
                        new Gear("Exarchic Gloves of Casting", "sps60", "sps60", "sps60", "ch20", "sps20"),
                        new Gear("Exarchic Plate Belt of Casting", "ch60", "sps60", "sps20", "sps20", "sps20"),
                        new Gear("Exarchic Hose of Casting", "ch60", "ch60", "dh60", "ch20", "dh20"),
                        new Gear("Exarchic Shoes of Casting", "ch60", "ch60", "ch60", "ch20", "ch20"),
                        new Gear("Exarchic Earrings of Casting", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Choker of Casting", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Bracelet of Casting", "ch60", "ch60", "ch20", "ch20", "ch20"),
                        new Gear("Exarchic Ring of Casting", "sps60", "sps60", "det20", "sps20", "sps20"),
                        new Gear("Exarchic Ring of Casting", "sps60", "sps60", "sps20", "sps20", "sps20"))),
                new("5.5 BiS",
                    "패치 5.4 ~ 5.5 BiS 리스트입니다. 빠른 마시속 세트가 시뮬레이션 상 데미지 기댓값이 더 높지만 MP 서버틱 관리가 더 불안할 수 있습니다. 본인에게 편한 마시속을 가진 장비 세트를 골라 사용하시는 것을 추천드려요."
                    , new ClassJobCategory {BLM = true},
                    new GearSet("글쿨 2.34초 극대 세트.", "글로벌 쿨다운을 2.34초로 맞춘 극대 위주 장비 세트.", "Twilight Popoto Salad",
                        23791.91d, new Gear("Edenmorn Rod", "sps60", "sps60"),
                        new Gear("Edenmorn Hat of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Gown of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Dress Sleeves of Casting", "ch60", "sps60"),
                        new Gear("Edenmorn Leather Belt of Casting", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Chausses of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Shoes of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Earring of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Necklace of Casting", "ch60", "sps60"),
                        new Gear("Edenmorn Wristlet of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Ring of Casting", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "sps60", "sps60")), new GearSet(
                        "글쿨 2.17초 마시속 세트.", "글로벌 쿨다운을 2.17초로 맞춘 마시속 위주 장비 세트.", "Zefir", 23800.90d,
                        new Gear("Augmented Cryptlurker's Rod", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Mesail of Casting", "det60", "sps60"),
                        new Gear("Augmented Cryptlurker's Robe of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Leather Belt of Casting", "dh60", "det60"),
                        new Gear("Edenmorn Chausses of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Earring of Casting", "det60", "sps60"),
                        new Gear("Augmented Cryptlurker's Choker of Casting", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Casting", "det60", "sps60"),
                        new Gear("Edenmorn Ring of Casting", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "dh60", "det60"))),
                new("5.55 레지스탕스 BiS",
                    "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다."
                    , new ClassJobCategory {BLM = true},
                    new GearSet("글쿨 2.33초 극대 세트.", "글로벌 쿨다운을 2.33초로 맞춘 극대 위주 장비 세트.", "Twilight Popoto Salad",
                        23985.05d, new Gear("Blade's Fury", "ch 525", "dh 226", "det 15", "sps 416"),
                        new Gear("Edenmorn Hat of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Gown of Casting", "ch60", "ch60"),
                        new Gear("Edenmorn Dress Sleeves of Casting", "ch60", "sps60"),
                        new Gear("Augmented Cryptlurker's Belt of Casting", "ch60", "sps60"),
                        new Gear("Augmented Cryptlurker's Chausses of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Shoes of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Earrings of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Necklace of Casting", "ch60", "sps60"),
                        new Gear("Edenmorn Wristlet of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Ring of Casting", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "sps60", "sps60")), new GearSet(
                        "글쿨 2.16초 마시속 세트.", "글로벌 쿨다운을 2.16초로 맞춘 마시속 위주 장비 세트.", "Zefir", 24087.78d,
                        new Gear("Blade's Fury", "ch 5", "dh 473", "det 202", "sps 502"),
                        new Gear("Augmented Cryptlurker's Mesail of Casting", "det60", "sps60"),
                        new Gear("Augmented Cryptlurker's Robe of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Casting", "sps60", "sps60"),
                        new Gear("Edenmorn Leather Belt of Casting", "dh60", "det60"),
                        new Gear("Edenmorn Chausses of Casting", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Casting", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Earring of Casting", "det60", "sps60"),
                        new Gear("Augmented Cryptlurker's Choker of Casting", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Casting", "det60", "sps60"),
                        new Gear("Edenmorn Ring of Casting", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Casting", "sps60", "sps60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {BLM = true}, new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Zefir",
                        16405.16d, new Gear("Augmented Law's Order Rod", "dh 467", "det 233", "sps 467"),
                        new Gear("Shadowless Petasos of Casting", "det60", "sps60"),
                        new Gear("Edengrace Jacket of Casting", "sps60", "sps60"),
                        new Gear("Shadowless Gloves of Casting", "sps60", "sps60"),
                        new Gear("Augmented Deepshadow Tassets of Casting", "sps60", "sps60"),
                        new Gear("Shadowless Bottoms of Casting", "dh60", "dh60"),
                        new Gear("Edengrace Thighboots of Casting", "dh60", "dh60"),
                        new Gear("Shadowless Earrings of Casting", "dh60"),
                        new Gear("Edengrace Choker of Casting", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Bracelet of Casting", "sps60", "sps60"),
                        new Gear("Edengrace Ring of Casting", "sps60", "sps60"),
                        new Gear("Augmented Deepshadow Ring of Casting", "sps60", "sps60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 4274,
                            mnd = 0,
                            ch = 578,
                            dh = 3012,
                            det = 2063,
                            sks = 0,
                            sps = 3389,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-blm-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}