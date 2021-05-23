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
        public static void GenerateSCH()
        {
            Console.WriteLine("[SCH] Generating tables...");

            Table[] tables =
            {
                new("5.4 BiS",
                    "패치 5.4 BiS 리스트입니다. 학자의 BiS는 신앙 스탯에 따라 갈리게 됩니다. 본인이 자주 사망하는 편이거나 파티원들이 자주 사망해 부활로 인한 MP 소모가 클 경우 높은 신앙을 가진 장비 세트를 선택하는 것이 나을 수 있습니다. 재생 영식 4층의 경우 요구되는 힐량과 그에 따른 MP 소모가 극심하므로 MP 관리에 어려움을 느끼고 있다면 좀 더 높은 신앙의 장비 세트를 맞추는 것도 고려해보세요."
                    , new ClassJobCategory {SCH = true},
                    new GearSet("신앙 682 데미지 추천 세트.",
                        "글로벌 쿨다운을 2.33초로 맞춘 장비 세트. 낮은 신앙 장비 세트들 중 가장 무난하게 사용 가능한 추천 세트. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의. 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Twilight Popoto Salad", 14548.29d, new Gear("Edenmorn Codex", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "sps60")),
                    new GearSet("신앙 1066 추천 세트.", "글로벌 쿨다운을 2.32초로 맞춘 장비 세트. 적당한 신앙으로 MP 관리에 큰 어려움이 없는 무난한 추천 세트.",
                        "Smoked Chicken", 14369.84d, new Gear("Edenmorn Codex", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "sps60", "sps60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Belt of Healing", "sps60", "sps60"),
                        new Gear("Edenmorn Chausses of Healing", "sps60", "sps60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Earrings of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "sps60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Healing", "ch60", "dh60"))),
                new("5.45 BiS", "패치 5.45에 추가되는 보즈야 장비를 포함한 BiS 리스트입니다.", new ClassJobCategory {SCH = true}, new
                    GearSet("신앙 340 낮은 신앙 데미지 세트.",
                        "글로벌 쿨다운 2.32초의 낮은 신앙 장비 세트. 데미지 기댓값이 가장 높으나 MP 관리 역시 제일 어려우므로 주의 요망. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의. 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Twilight Popoto Salad", 14642.83d, new Gear("Edenmorn Codex", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Law's Order Hose of Healing", "dh60", "dh60", "dh60", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "sps60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "dh60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이후에는 극대와 의지에 스탯이 분배된 레지스탕스 웨폰을 사용하시면 됩니다.",
                    new ClassJobCategory {SCH = true}, new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Smoked Chicken", 9246.44d, new Gear("Word of Grace", "pie60", "pie60"),
                        new Gear("Shadowless Petasos of Healing", "sps60", "sps60"),
                        new Gear("Augmented Deepshadow Scale Mail of Healing", "ch60", "ch60"),
                        new Gear("Shadowless Gloves of Healing", "sps60", "pie60"),
                        new Gear("Edengrace Tassets of Healing", "sps60", "sps60"),
                        new Gear("Shadowless Bottoms of Healing", "pie60", "pie60"),
                        new Gear("Shadowless Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Earring of Healing", "sps60", "sps60"),
                        new Gear("Augmented Deepshadow Necklace of Healing", "ch60", "sps60"),
                        new Gear("Edengrace Bracelet of Healing", "sps60", "sps60"),
                        new Gear("Edengrace Ring of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Healing", "pie60", "pie60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 0,
                            mnd = 4278,
                            ch = 3573,
                            dh = 380,
                            det = 2230,
                            sks = 0,
                            sps = 1119,
                            ten = 0,
                            pie = 1889
                        }
                    })
            };

            foreach (var table in tables) table.CalculateFlatHps(300, 30, new ClassJobCategory {SCH = true});

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-sch-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}