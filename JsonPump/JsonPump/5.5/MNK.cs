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
        public static void GenerateMNK()
        {
            Console.WriteLine("[MNK] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {MNK = true},
                    new GearSet("질풍 글쿨 1.96초 추천 세트.",
                        "무난하게 사용 가능한 추천 세트. 몽크 밸런스 패치 이후의 장비 세트이기 때문에 글쿨이 기존 장비 세트보다 살짝 느린 편. 빠른 기시속을 선호한다면 빠른 기시 세트를 참조할 것.",
                        "Smoked Chicken", 21514.22d, new Gear("Edenmorn Sainti", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Mesail of Striking", "det60", "det60"),
                        new Gear("Edenmorn Bolero of Striking", "det60", "det60"),
                        new Gear("Edenmorn Fingerless Gloves of Striking", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Striking", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking", "det60", "det60"),
                        new Gear("Edenmorn Thighboots of Striking", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "dh60", "dh60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Slaying", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "det60")),
                    new GearSet("질풍 글쿨 1.94초 빠른 기시 세트.", "빠른 기시속을 선호하시는 분들께 추천.", "Smoked Chicken", 21508.53d,
                        new Gear("Edenmorn Sainti", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Mesail of Striking", "det60", "det60"),
                        new Gear("Edenmorn Bolero of Striking", "det60", "det60"),
                        new Gear("Edenmorn Fingerless Gloves of Striking", "ch60", "dh60"),
                        new Gear("Edenmorn Leather Belt of Striking", "ch60", "det60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking", "det60", "det60"),
                        new Gear("Edenmorn Thighboots of Striking", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "dh60", "det60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Slaying", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "det60"))),
                new("5.55 레지스탕스 BiS", "패치 5.55 레지스탕스 웨폰을 채용한 BiS 리스트입니다.", new ClassJobCategory {MNK = true},
                    new GearSet("질풍 글쿨 1.96초 추천 세트.",
                        "무난하게 사용 가능한 추천 세트. 몽크 밸런스 패치 이후의 장비 세트이기 때문에 글쿨이 기존 장비 세트보다 살짝 느린 편.",
                        "Smoked Chicken", 21658.94d, new Gear("Blade's Serenity", "ch 521", "dh 504", "det 156", "sks 1"),
                        new Gear("Augmented Cryptlurker's Mesail of Striking", "det60", "det60"),
                        new Gear("Edenmorn Bolero of Striking", "dh60", "det60"),
                        new Gear("Edenmorn Fingerless Gloves of Striking", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Striking", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking", "det60", "det60"),
                        new Gear("Edenmorn Thighboots of Striking", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "dh60", "dh60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Slaying", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "det60"))),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {MNK = true},
                    new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.", "Smoked Chicken", 14719.19d,
                        new Gear("Augmented Law's Order Knuckles", "ch 461", "dh 243", "det 463"),
                        new Gear("Shadowless Mask of Striking", "ch60", "det60"),
                        new Gear("Edenmorn Bolero of Striking"),
                        new Gear("Shadowless Gloves of Striking", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Tassets of Striking", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking"),
                        new Gear("Shadowless Sabatons of Striking", "ch60", "det60"),
                        new Gear("Augmented Deepshadow Earring of Slaying", "dh60", "det60"),
                        new Gear("Edengrace Choker of Slaying", "det60", "det60"),
                        new Gear("Augmented Deepshadow Bracelet of Slaying", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Slaying", "dh60", "dh60"),
                        new Gear("Augmented Deepshadow Ring of Slaying", "ch60", "det60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 122,
                            str = 4270,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 3746,
                            dh = 2271,
                            det = 2016,
                            sks = 914,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    }, new GearSet("절 알테마 웨폰 세트.", "절 알테마 웨폰 레이드용 장비 세트.", "Smoked Chicken", 8242.76d,
                        new Gear("Augmented Law's Order Knuckles", "ch 318", "dh 318", "det 318", "sks 213"),
                        new Gear("Alliance Visor of Striking", "dh40", "det40"),
                        new Gear("Edenmorn Bolero of Striking"), new Gear("Edenmorn Fingerless Gloves of Striking"),
                        new Gear("Crystarium Belt of Striking"), new Gear("Crystarium Pantaloons of Striking"),
                        new Gear("Alliance Shoes of Striking", "dh40", "det40"),
                        new Gear("Cryptlurker's Earring of Slaying"), new Gear("Edenmorn Necklace of Slaying"),
                        new Gear("Edenmorn Wristlet of Slaying"), new Gear("Edenmorn Ring of Slaying"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying"))
                    {
                        attribute = new Attribute
                        {
                            wd = 105,
                            str = 2904,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2742,
                            dh = 1601,
                            det = 1862,
                            sks = 577,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    }, new GearSet("절 바하무트 세트.", "절 바하무트 레이드용 장비 세트.", "Smoked Chicken", 6726.90d,
                        new Gear("Augmented Law's Order Knuckles", "ch 280", "dh 280", "det 280", "sks 280"),
                        new Gear("Pacifist's Circlet +2", "ch40", "dh40"), new Gear("Edenmorn Bolero of Striking"),
                        new Gear("Edenmorn Fingerless Gloves of Striking"), new Gear("Crystarium Belt of Striking"),
                        new Gear("Crystarium Pantaloons of Striking"), new Gear("Edenchoir Sollerets of Striking"),
                        new Gear("Edenchoir Earrings of Slaying"), new Gear("Edenmorn Necklace of Slaying"),
                        new Gear("Neo-Ishgardian Wristbands of Slaying"), new Gear("Edenmorn Ring of Slaying"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying"))
                    {
                        attribute = new Attribute
                        {
                            wd = 100,
                            str = 2568,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 2464,
                            dh = 1344,
                            det = 1795,
                            sks = 577,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        }
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-mnk-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}