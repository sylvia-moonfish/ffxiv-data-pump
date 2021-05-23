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
        public static void GenerateSAM()
        {
            Console.WriteLine("[SAM] Generating tables...");

            Table[] tables =
            {
                new("5.5 BiS", "패치 5.4 ~ 5.5 BiS 리스트입니다.", new ClassJobCategory {SAM = true},
                    new GearSet("28 글쿨 로테이션 2.14초 추천 세트.", "28 글쿨 로테이션과 2 글쿨 필러가 가능한 장비 세트. 데미지 기댓값이 가장 높음.",
                        "Smoked Chicken", 25556.08d, new Gear("Edenmorn Samurai Blade", "dh60", "dh60"),
                        new Gear("Edenmorn Eye Mask of Striking", "ch60", "ch60"),
                        new Gear("Edenmorn Bolero of Striking", "det60", "det60"),
                        new Gear("Edenmorn Fingerless Gloves of Striking", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Striking", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking", "sks60", "sks60"),
                        new Gear("Edenmorn Thighboots of Striking", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "dh60", "det60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Ring of Slaying", "dh60", "det60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "det60")) {rotation = 28},
                    new GearSet("30 글쿨 로테이션 2초 빠른 기시 세트.", "30 글쿨 로테이션과 4 글쿨 필러가 가능한 장비 세트.", "Chicken Fettuccine",
                        25488.13d, new Gear("Edenmorn Samurai Blade", "sks60", "sks60"),
                        new Gear("Augmented Cryptlurker's Mesail of Striking", "dh60", "sks60"),
                        new Gear("Edenmorn Bolero of Striking", "sks60", "sks60"),
                        new Gear("Edenmorn Fingerless Gloves of Striking", "sks60", "sks60"),
                        new Gear("Edenmorn Leather Belt of Striking", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking", "sks60", "sks60"),
                        new Gear("Edenmorn Thighboots of Striking", "dh60", "sks60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "sks60"),
                        new Gear("Edenmorn Necklace of Slaying", "sks60", "sks60"),
                        new Gear("Augmented Cryptlurker's Bracelet of Slaying", "ch60", "sks60"),
                        new Gear("Edenmorn Ring of Slaying", "sks60", "sks60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "sks60")) {rotation = 30},
                    new GearSet("29 글쿨 로테이션 2.07초 세트.",
                        "29 글쿨 로테이션과 3 글쿨 필러가 가능한 장비 세트. 버프 리필 시간이 넉넉한 로테이션이므로 초보자에게 추천.", "Chicken Fettuccine",
                        25419.06d, new Gear("Edenmorn Samurai Blade", "dh60", "dh60"),
                        new Gear("Augmented Cryptlurker's Mesail of Striking", "det60", "sks60"),
                        new Gear("Edenmorn Bolero of Striking", "det60", "det60"),
                        new Gear("Edenmorn Fingerless Gloves of Striking", "ch60", "dh60"),
                        new Gear("Augmented Cryptlurker's Belt of Striking", "sks60", "sks60"),
                        new Gear("Augmented Cryptlurker's Hose of Striking", "sks60", "sks60"),
                        new Gear("Edenmorn Thighboots of Striking", "det60", "det60"),
                        new Gear("Augmented Cryptlurker's Earring of Slaying", "ch60", "det60"),
                        new Gear("Edenmorn Necklace of Slaying", "det60", "sks60"),
                        new Gear("Edenmorn Wristlet of Slaying", "ch60", "sks60"),
                        new Gear("Edenmorn Ring of Slaying", "sks60", "sks60"),
                        new Gear("Augmented Cryptlurker's Ring of Slaying", "ch60", "sks60")) {rotation = 29}),
                new("절 난이도 BiS", "절 난이도 전용 BiS 리스트입니다. 레지스탕스 웨폰 패치 이전에는 5.5 BiS 무기나 해당 절 레이드 보상 무기를 사용하시면 됩니다.",
                    new ClassJobCategory {SAM = true}, new GearSet("절 알렉산더 세트.", "절 알렉산더 레이드용 장비 세트.",
                        "Mist Spinach Quiche", 16607.67d,
                        new Gear("Augmented Law's Order Samurai Blade", "ch 43", "dh 452", "det 212", "sks 460"),
                        new Gear("Shadowless Mask of Striking", "dh60", "dh60"),
                        new Gear("Shadowless Coat of Striking", "sks60", "sks60"),
                        new Gear("Shadowless Gloves of Striking", "dh60", "dh60"),
                        new Gear("Edengrace Tassets of Striking", "sks60", "dh60"),
                        new Gear("Shadowless Hose of Striking", "sks60", "sks60"),
                        new Gear("Shadowless Sabatons of Striking", "sks60", "sks60"),
                        new Gear("Edengrace Earring of Slaying", "det60", "sks60"),
                        new Gear("Augmented Deepshadow Necklace of Slaying", "dh60", "dh60"),
                        new Gear("Edengrace Bracelet of Slaying", "dh60", "dh60"),
                        new Gear("Edengrace Ring of Slaying", "sks60", "sks60"),
                        new Gear("Augmented Deepshadow Ring of Slaying", "sks60", "sks60"))
                    {
                        attribute = new Attribute
                        {
                            wd = 0,
                            str = 4489,
                            dex = 0,
                            @int = 0,
                            mnd = 0,
                            ch = 1321,
                            dh = 2577,
                            det = 1965,
                            sks = 3249,
                            sps = 0,
                            ten = 0,
                            pie = 0
                        },
                        rotation = 31
                    })
            };

            using (var sw = new StreamWriter(Path.Join(OutputBasePath, "bis-sam-gear-data.json"), false))
            {
                sw.Write(JsonConvert.SerializeObject(tables, Formatting.Indented));
            }
        }
    }
}