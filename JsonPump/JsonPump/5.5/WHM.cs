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
        public static void GenerateWHM()
        {
            Console.WriteLine("[WHM] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS",
                    "패치 5.4 ~ 5.5 BiS 리스트입니다. 백마도사의 BiS는 신앙 스탯에 따라 갈리게 됩니다. 본인이 자주 사망하는 편이거나 파티원들이 자주 사망해 부활로 인한 MP 소모가 클 경우 높은 신앙을 가진 장비 세트를 선택하는 것이 나을 수 있습니다. 재생 영식 4층의 경우 요구되는 힐량과 그에 따른 MP 소모가 극심하므로 MP 관리에 어려움을 느끼고 있다면 좀 더 높은 신앙의 장비 세트를 맞추는 것도 고려해보세요."
                    , new ClassJobCategory {WHM = true},
                    new GearSet("신앙 682 빠른 마시 데미지 세트.",
                        "글로벌 쿨다운 2.34초의 굉장히 빠른 마시속을 가진 장비 세트. 데미지 기댓값이 가장 높으나 MP 관리 역시 제일 어려우므로 주의 요망. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의. 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Smoked Chicken", 14476.34d, new Gear("Edenmorn Cane", "ch60", "ch60"),
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
                    new GearSet("신앙 682 데미지 세트.",
                        "글로벌 쿨다운을 2.36초로 맞춘 장비 세트. 빠른 마시 데미지 세트보다 데미지 기댓값과 마시속이 살짝 낮지만 그만큼 MP 관리에 살짝 유리함. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의. 패치 5.5 이전에는 제작 보강 장비를 금단 제작 장비로 대체.",
                        "Twilight Popoto Salad", 14472.37d, new Gear("Edenmorn Cane", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "det60")),
                    new GearSet("신앙 1066 추천 세트.",
                        "글로벌 쿨다운을 2.37초로 맞춘 장비 세트. 적당한 신앙과 마시속으로 MP 관리에 큰 어려움이 없는 무난한 추천 세트.",
                        "Twilight Popoto Salad", 14326.50d, new Gear("Edenmorn Cane", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Belt of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "sps60"),
                        new Gear("Augmented Cryptlurker's Ring of Healing", "ch60", "ch60")),
                    new GearSet("신앙 1209 높은 신앙 세트.",
                        "글로벌 쿨다운을 2.39초로 맞춘 장비 세트. 높은 신앙으로 쉬운 MP 관리가 장점인 장비 세트. 힐러 운용이 아직 미숙하거나 MP 관리가 힘드신 분들께 추천.",
                        "Smoked Chicken", 14256.96d, new Gear("Edenmorn Cane", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Dress Sleeves of Healing", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Ring of Healing", "ch60", "ch60"))),
                new("5.55 레지스탕스 BiS",
                    "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다."
                    , new ClassJobCategory {WHM = true},
                    new GearSet("신앙 682 빠른 마시 데미지 세트.",
                        "글로벌 쿨다운 2.34초의 굉장히 빠른 마시속을 가진 장비 세트. 데미지 기댓값이 가장 높으나 MP 관리 역시 제일 어려우므로 주의 요망. 제작 보강 반지로 인해 아이템 레벨과 체력이 살짝 낮은 것에 유의.",
                        "Twilight Popoto Salad", 14569.64d, new Gear("Blade's Mercy", "ch 530", "det 476", "sps 176"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "det60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "dh60")),
                    new GearSet("신앙 840 추천 세트.",
                        "글로벌 쿨다운을 2.35초로 맞춘 장비 세트. 적당한 신앙과 마시속으로 MP 관리에 큰 어려움이 없는 무난한 추천 세트.",
                        "Twilight Popoto Salad", 14513.45d, new Gear("Blade's Mercy", "ch 523", "det 427", "sps 232"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Belt of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Boots of Healing", "ch60", "ch60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "dh60")),
                    new GearSet("신앙 1051 높은 신앙 세트.",
                        "글로벌 쿨다운을 2.36초로 맞춘 장비 세트. 높은 신앙으로 쉬운 MP 관리가 장점인 장비 세트. 힐러 운용이 아직 미숙하거나 MP 관리가 힘드신 분들께 추천.",
                        "Twilight Popoto Salad", 14405.71d, new Gear("Blade's Mercy", "ch 528", "det 402", "sps 184", "pie 68"),
                        new Gear("Augmented Cryptlurker's Helm of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Gown of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Vambraces of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Leather Belt of Healing", "ch60", "ch60"),
                        new Gear("Edenmorn Chausses of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Shoes of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Healing", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Choker of Healing", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Edenmorn Ring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Exarchic Ring of Healing", "dh60", "dh60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이후에는 극대와 의지에 스탯이 분배된 레지스탕스 웨폰을 사용하시면 됩니다.",
                    new ClassJobCategory {WHM = true},
                    new GearSet("절 알렉산더 신앙 931 데미지 세트.",
                        "글로벌 쿨다운을 2.44초에 맞춘 장비 세트. 신앙이 낮은 편이므로 MP 관리가 어렵다면 높은 신앙 장비 세트를 사용하는 것을 추천.",
                        "Stuffed Highland Cabbage", 8930.70d, new Gear("Edengrace Cane", "ch60", "ch60"),
                        new Gear("Shadowless Petasos of Healing", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Scale Mail of Healing", "ch60", "ch60"),
                        new Gear("Shadowless Gloves of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Tassets of Healing", "dh60", "dh60"),
                        new Gear("Shadowless Bottoms of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Sandals of Healing", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Earring of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Choker of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Bracelet of Healing", "ch60", "ch60"),
                        new Gear("Augmented Deepshadow Ring of Healing", "dh60", "dh60"),
                        new Gear("Shadowless Ring of Healing", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 0,
                            mnd = 4276,
                            ch = 3268,
                            dh = 1160,
                            det = 2838,
                            sks = 0,
                            sps = 915,
                            ten = 0,
                            pie = 931
                        }
                    }, new GearSet("절 알렉산더 신앙 1268 추천 세트.", "글로벌 쿨다운을 2.48초로 맞춘 장비 세트. 가장 운용하기 무난한 추천 세트.",
                        "Stuffed Highland Cabbage", 8820.71d, new Gear("Edengrace Cane", "ch60", "ch60"),
                        new Gear("Shadowless Petasos of Healing", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Scale Mail of Healing", "ch60", "ch60"),
                        new Gear("Shadowless Gloves of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Tassets of Healing", "dh60", "dh60"),
                        new Gear("Shadowless Bottoms of Healing", "dh60", "dh60"),
                        new Gear("Edengrace Sandals of Healing", "ch60", "dh60"),
                        new Gear("Augmented Deepshadow Earring of Healing", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Necklace of Healing", "ch60", "dh60"),
                        new Gear("Edengrace Bracelet of Healing", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Healing", "dh60", "dh60"),
                        new Gear("Shadowless Ring of Healing", "ch60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 164,
                            str = 0,
                            dex = 0,
                            @int = 0,
                            mnd = 4276,
                            ch = 3424,
                            dh = 1340,
                            det = 2560,
                            sks = 0,
                            sps = 519,
                            ten = 0,
                            pie = 1268
                        }
                    })
            };

            foreach (var table in tables) table.CalculateFlatHps(700, 30, new ClassJobCategory {WHM = true});

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-whm-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}