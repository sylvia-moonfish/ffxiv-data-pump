using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using JsonPump.Models;

namespace JsonPump
{
    public static class Utility
    {
        private static readonly string BaseUrl = "https://na.finalfantasyxiv.com";
        private static readonly string SearchPath = "/lodestone/playguide/db/item/";

        private static readonly string EquipmentQuery =
            "?patch=&db_search_category=item&category2={0}&category3={1}&difficulty=&min_item_lv={2}&max_item_lv={2}&min_gear_lv=&max_gear_lv=&min_craft_lv=&max_craft_lv=&q={3}";

        private static readonly string MealQuery =
            "?patch=&db_search_category=item&category2=5&category3=46&difficulty=&min_craft_lv=&max_craft_lv=&q={0}";

        private static readonly string MateriaQuery =
            "?patch=&db_search_category=item&category2=7&category3=58&difficulty=&min_craft_lv=&max_craft_lv=&q={0}";

        public static Dictionary<string, string> StatCodes = new()
        {
            {"Critical Hit", "ch"},
            {"Direct Hit Rate", "dh"},
            {"Determination", "det"},
            {"Skill Speed", "sks"},
            {"Spell Speed", "sps"},
            {"Tenacity", "ten"},
            {"Piety", "pie"}
        };

        public static Dictionary<string, string> StatShortNames = new()
        {
            {"Critical Hit", "극대"},
            {"Direct Hit Rate", "직격"},
            {"Determination", "의지"},
            {"Skill Speed", "기시"},
            {"Spell Speed", "마시"},
            {"Tenacity", "불굴"},
            {"Piety", "신앙"}
        };

        private static readonly string[] RaidGearNames = {"Edenmorn", "Edenchoir", "Edengrace"};

        private static readonly string[] TomestoneGearNames = {"Cryptlurker", "Crystarium", "Deepshadow"};

        private static readonly int[] RaidItemLevelTiers = {535, 505, 475};

        // Print a progress bar on the console.
        private static string prevLine = string.Empty;

        // Print a second progress bar to the right of the first progress bar.
        private static string prevSecondLine = string.Empty;

        public static EquipmentSource GetEquipmentSource(Equipment equipment)
        {
            var itemLevelTier = RaidItemLevelTiers.Where(tier => tier >= equipment.ItemLevel).Min();

            if (equipment.EquipSlotCategory.IsWeapon || equipment.EquipSlotCategory.OffHand)
            {
                if (equipment.ItemLevel == itemLevelTier)
                {
                    if (equipment.Rarity == 4)
                    {
                        return new EquipmentSource("레지스탕스 웨폰", "레지스탕스 웨폰");
                    }
                    else
                    {
                        if (equipment.ClassJobCategory.PLD)
                        {
                            if (equipment.EquipSlotCategory.IsWeapon)
                                return new EquipmentSource("영웅 레이드", "4층 낱장 x 5");
                            if (equipment.EquipSlotCategory.OffHand) return new EquipmentSource("영웅 레이드", "4층 낱장 x 3");
                        }
                        else
                        {
                            return new EquipmentSource("영웅 레이드", "4층 낱장 x 8");
                        }
                    }
                }
                else if (equipment.ItemLevel == itemLevelTier - 5)
                {
                    if (equipment.Rarity == 4)
                        return new EquipmentSource("레지스탕스 웨폰", "레지스탕스 웨폰");
                    if (equipment.Rarity == 3)
                        return new EquipmentSource("석판 보강", "석판 1000개\n무기 석판\n강화약\n(3층 낱장 x 4)");
                }
                else if (equipment.ItemLevel == itemLevelTier - 10 || equipment.ItemLevel == itemLevelTier - 20)
                {
                    if (equipment.Rarity == 4) return new EquipmentSource("레지스탕스 웨폰", "레지스탕스 웨폰");

                    if (equipment.Rarity == 3)
                    {
                        if (equipment.ClassJobCategory.PLD)
                        {
                            if (equipment.EquipSlotCategory.IsWeapon)
                                return new EquipmentSource("극만신", "우상 x 7");
                            if (equipment.EquipSlotCategory.OffHand) return new EquipmentSource("극만신", "우상 x 3");
                        }
                        else
                        {
                            return new EquipmentSource("극만신", "우상 x 10");
                        }
                    }
                }
                else if (equipment.ItemLevel == itemLevelTier - 15)
                {
                    if (equipment.Rarity == 3)
                    {
                        if (equipment.ClassJobCategory.PLD)
                        {
                            if (equipment.EquipSlotCategory.IsWeapon)
                                return new EquipmentSource("석판", "석판 700개\n무기 석판");
                            if (equipment.EquipSlotCategory.OffHand) return new EquipmentSource("석판", "석판 300개");
                        }
                        else
                        {
                            return new EquipmentSource("석판", "석판 1000개\n무기 석판");
                        }
                    }
                    else if (equipment.Rarity == 2)
                    {
                        return new EquipmentSource("제작 보강", "제작 보강");
                    }
                }
                else if (equipment.ItemLevel == itemLevelTier - 25)
                {
                    if (equipment.Rarity == 4)
                        return new EquipmentSource("레지스탕스 웨폰", "레지스탕스 웨폰");
                    if (equipment.Rarity == 2) return new EquipmentSource("제작", "제작");
                }
            }
            else if (equipment.EquipSlotCategory.IsArmor || equipment.EquipSlotCategory.IsAcc)
            {
                if (equipment.ItemLevel == itemLevelTier || equipment.ItemLevel == itemLevelTier - 20)
                    return new EquipmentSource("던전", "던전");

                if (equipment.ItemLevel == itemLevelTier - 5)
                {
                    if (RaidGearNames.FirstOrDefault(raidGearName => equipment.NameEn.Contains(raidGearName)) != null)
                    {
                        if (equipment.EquipSlotCategory.Head || equipment.EquipSlotCategory.Gloves ||
                            equipment.EquipSlotCategory.Feet)
                            return new EquipmentSource("영웅 레이드", "2층 낱장 x 6");
                        if (equipment.EquipSlotCategory.Body)
                            return new EquipmentSource("영웅 레이드", "4층 낱장 x 8");
                        if (equipment.EquipSlotCategory.Waist)
                            return new EquipmentSource("영웅 레이드", "1층 낱장 x 6");
                        if (equipment.EquipSlotCategory.Legs)
                            return new EquipmentSource("영웅 레이드", "3층 낱장 x 8");
                        if (equipment.EquipSlotCategory.IsAcc) return new EquipmentSource("영웅 레이드", "1층 낱장 x 4");
                    }
                    else if (TomestoneGearNames.FirstOrDefault(tomestoneGearName =>
                        equipment.NameEn.Contains(tomestoneGearName)) != null)
                    {
                        if (equipment.EquipSlotCategory.Head || equipment.EquipSlotCategory.Gloves ||
                            equipment.EquipSlotCategory.Feet)
                            return new EquipmentSource("석판 보강", "석판 495개\n강화섬유\n(3층 낱장 x 4)");
                        if (equipment.EquipSlotCategory.Body || equipment.EquipSlotCategory.Legs)
                            return new EquipmentSource("석판 보강", "석판 825개\n강화섬유\n(3층 낱장 x 4)");
                        if (equipment.EquipSlotCategory.Waist || equipment.EquipSlotCategory.IsAcc)
                            return new EquipmentSource("석판 보강", "석판 375개\n경화약\n(2층 낱장 x 4)");
                    }
                }
                else if (equipment.ItemLevel == itemLevelTier - 15)
                {
                    if (equipment.Rarity == 3)
                    {
                        if (TomestoneGearNames.FirstOrDefault(tomestoneGearName =>
                            equipment.NameEn.Contains(tomestoneGearName)) != null)
                        {
                            if (equipment.EquipSlotCategory.Head || equipment.EquipSlotCategory.Gloves ||
                                equipment.EquipSlotCategory.Feet)
                                return new EquipmentSource("석판", "석판 495개");
                            if (equipment.EquipSlotCategory.Body || equipment.EquipSlotCategory.Legs)
                                return new EquipmentSource("석판", "석판 825개");
                            if (equipment.EquipSlotCategory.Waist || equipment.EquipSlotCategory.IsAcc)
                                return new EquipmentSource("석판", "석판 375개");
                        }
                        else
                        {
                            return new EquipmentSource("24인 레이드", "24인 레이드");
                        }
                    }
                    else if (equipment.Rarity == 2)
                    {
                        return new EquipmentSource("제작 보강", "제작 보강");
                    }
                }
                else if (equipment.ItemLevel == itemLevelTier - 25)
                {
                    if (equipment.Rarity == 3)
                    {
                        if (equipment.EquipSlotCategory.Head)
                            return new EquipmentSource("일반 레이드", "머리 x 2");
                        if (equipment.EquipSlotCategory.Body)
                            return new EquipmentSource("일반 레이드", "몸통 x 4");
                        if (equipment.EquipSlotCategory.Gloves)
                            return new EquipmentSource("일반 레이드", "손 x 2");
                        if (equipment.EquipSlotCategory.Waist)
                            return new EquipmentSource("일반 레이드", "허리 x 1");
                        if (equipment.EquipSlotCategory.Legs)
                            return new EquipmentSource("일반 레이드", "다리 x 4");
                        if (equipment.EquipSlotCategory.Feet)
                            return new EquipmentSource("일반 레이드", "발 x 2");
                        if (equipment.EquipSlotCategory.IsAcc) return new EquipmentSource("일반 레이드", "반지 x 1");
                    }
                    else if (equipment.Rarity == 2 && equipment.CanBeHq)
                    {
                        return new EquipmentSource("제작", "제작");
                    }
                }
            }

            if (equipment.NameEn.Contains("Law's Order"))
                return new EquipmentSource("보즈야", "보즈야");
            if (equipment.NameEn.Contains("Idealized"))
                return new EquipmentSource("극만신", "극만신");
            if (equipment.NameEn.Contains("Chivalrous") || equipment.NameEn.Contains("Brutal") ||
                equipment.NameEn.Contains("Abyss") || equipment.NameEn.Contains("Pacifist"))
                return new EquipmentSource("에우레카", "에우레카");
            if (equipment.NameEn.Contains("Bonewicca") || equipment.NameEn.Contains("Alliance"))
                return new EquipmentSource("던전", "던전");
            if (equipment.NameEn.Contains("Blade's"))
                return new EquipmentSource("자드노르", "자드노르");

            return null;
        }

        public static string GetEquipmentTypeName(Equipment equipment)
        {
            if (equipment.EquipSlotCategory.IsWeapon) return "무기";
            if (equipment.EquipSlotCategory.OffHand && equipment.ClassJobCategory.PLD) return "방패";
            if (equipment.EquipSlotCategory.Head) return "머리";
            if (equipment.EquipSlotCategory.Body) return "몸통";
            if (equipment.EquipSlotCategory.Gloves) return "손";
            if (equipment.EquipSlotCategory.Waist) return "허리";
            if (equipment.EquipSlotCategory.Legs) return "다리";
            if (equipment.EquipSlotCategory.Feet) return "발";
            if (equipment.EquipSlotCategory.Ears) return "귀걸이";
            if (equipment.EquipSlotCategory.Neck) return "목걸이";
            if (equipment.EquipSlotCategory.Wrists) return "팔찌";
            if (equipment.EquipSlotCategory.Ring) return "반지";

            return null;
        }

        public static string GetImage(Item item)
        {
            var iconPath = GetIconPath(item);
            var iconAbsolutePath = Path.Combine(GetBasePath(), iconPath);

            if (!File.Exists(iconAbsolutePath))
            {
                var html = new HtmlDocument();

                Thread.Sleep(100);

                html.LoadHtml((string) TryGetContent(BaseUrl + SearchPath + GetQueryString(item)));
                var itemPath = html.DocumentNode.SelectSingleNode($"//a[text()=\"{item.NameEn}\"]").Attributes["href"]
                    .Value;

                Thread.Sleep(100);

                html.LoadHtml((string) TryGetContent(BaseUrl + itemPath));
                var iconUrl = html.DocumentNode.SelectSingleNode($"//img[contains(@class, '{GetIconClassName(item)}')]")
                    .Attributes["src"].Value;

                Thread.Sleep(100);

                Directory.CreateDirectory(Path.GetDirectoryName(iconAbsolutePath));
                File.WriteAllBytes(iconAbsolutePath, (byte[]) TryGetContent(iconUrl, true));
            }

            return "/" + iconPath.Replace("\\\\", "\\").Replace("\\", "/");
        }

        private static object TryGetContent(string url, bool asBytes = false)
        {
            object response = null;

            while (response == null)
                try
                {
                    var httpResponseMessageTask = new HttpClient().GetAsync(url);
                    httpResponseMessageTask.Wait();

                    var httpResponseMessage = httpResponseMessageTask.Result;
                    httpResponseMessage.EnsureSuccessStatusCode();

                    if (asBytes)
                    {
                        var byteArrayTask = httpResponseMessage.Content.ReadAsByteArrayAsync();
                        byteArrayTask.Wait();

                        return byteArrayTask.Result;
                    }

                    var stringTask = httpResponseMessage.Content.ReadAsStringAsync();
                    stringTask.Wait();

                    return stringTask.Result;
                }
                catch
                {
                    Thread.Sleep(100);
                }

            return response;
        }

        private static string GetQueryString(Item item)
        {
            var type = item.GetType();

            if (type == typeof(Equipment))
            {
                var category2 = string.Empty;

                if (item.EquipSlotCategory.IsWeapon) category2 = "1";
                else if (item.EquipSlotCategory.IsArmor) category2 = "3";
                else if (item.EquipSlotCategory.IsAcc) category2 = "4";

                return string.Format(EquipmentQuery, category2, item.ItemUICategory.RowKey, item.ItemLevel,
                    item.NameEn);
            }

            if (type == typeof(Meal))
                return string.Format(MealQuery, item.NameEn);
            if (type == typeof(MateriaItem)) return string.Format(MateriaQuery, item.NameEn);

            return null;
        }

        private static string GetIconClassName(Item item)
        {
            var type = item.GetType();

            if (type == typeof(Equipment))
                return $"sys_{(((Equipment) item).CanBeHq ? "hq" : "nq")}_element";
            if (type == typeof(Meal))
                return "sys_hq_element";
            if (type == typeof(MateriaItem)) return "sys_nq_element";

            return null;
        }

        private static string GetBasePath()
        {
            return Program.ImageBasePath;
        }

        private static string GetIconPath(Item item)
        {
            var basePath = Path.Combine("icons", "items");

            var type = item.GetType();

            if (type == typeof(Equipment))
            {
                if (((Equipment) item).CanBeHq) basePath = Path.Combine(basePath, "hq");

                return Path.Combine(basePath, GetKebabCaseName(item.NameEn) + ".png");
            }

            if (type == typeof(Meal))
            {
                basePath = Path.Combine(basePath, "hq");

                return Path.Combine(basePath, GetKebabCaseName(item.NameEn) + ".png");
            }

            if (type == typeof(MateriaItem)) return Path.Combine(basePath, GetKebabCaseName(item.NameEn) + ".png");

            return null;
        }

        private static string GetKebabCaseName(string name)
        {
            return name.ToLower().Replace("'", "").Replace(" ", "-");
        }

        public static string GetCamelCaseName(string name)
        {
            var words = name.Replace("'", "").Split(" ");

            var sb = new StringBuilder();

            for (var i = 0; i < words.Length; i++)
            for (var j = 0; j < words[i].Length; j++)
            {
                var c = words[i][j];

                if (j == 0)
                {
                    if (i == 0)
                        c = c.ToString().ToLower()[0];
                    else
                        c = c.ToString().ToUpper()[0];
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        public static void ReportProgress(double progress)
        {
            // Remove the progress bar that was printed on the previous step, if it exists.
            if (!string.IsNullOrEmpty(prevLine))
            {
                // Create a blank line that has the same length as the previous progress bar.
                var cleanLine = string.Empty;
                while (cleanLine.Length != prevLine.Length) cleanLine += " ";

                // Print carriage return to move cursor to the front.
                Console.Write("\r");

                // Overwrite blank line on top of the previous progress bar.
                Console.Write(cleanLine);
            }

            // Print carriage return to move cursor to the front.
            Console.Write("\r");

            // Create and print progress bar line.
            var progressBar = "[";

            for (var i = 1; i <= 20; i++)
                if (i <= progress * 20)
                    progressBar += "#";
                else
                    progressBar += " ";

            progressBar += $"] {Math.Round(progress * 100)}%";

            Console.Write(progressBar);

            // If this is the last step...
            if (Math.Floor(progress) == 1)
            {
                prevLine = string.Empty;
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                prevLine = progressBar;
            }
        }

        public static void ReportInnerProgress(double progress)
        {
            // Remove the progress bar that was printed on the previous step, if it exists.
            var lineCleanLength = -1;

            // If second progress bar was already printed, remove that.
            if (!string.IsNullOrEmpty(prevSecondLine)) lineCleanLength = prevSecondLine.Length;

            // Else, just remove the first progress bar if it exists.
            else if (!string.IsNullOrEmpty(prevLine)) lineCleanLength = prevLine.Length;

            if (lineCleanLength > 0)
            {
                // Create a blank line that has the same length as the previous progress bar.
                var cleanLine = string.Empty;
                while (cleanLine.Length != lineCleanLength) cleanLine += " ";

                // Print carriage return to move cursor to the front.
                Console.Write("\r");

                // Overwrite blank line on top of the previous progress bar.
                Console.Write(cleanLine);
            }

            // Print carriage return to move cursor to the front.
            Console.Write("\r");

            // Create and print progress bar line.
            var progressBar = $"{prevLine} => [";

            for (var i = 1; i <= 20; i++)
                if (i <= progress * 20)
                    progressBar += "#";
                else
                    progressBar += " ";

            progressBar += $"] {Math.Round(progress * 100)}%";

            Console.Write(progressBar);

            // If this is the last step...
            if (Math.Floor(progress) == 1)
            {
                // Mark the whole line as previous line that should be cleaned.
                prevLine = progressBar;
                prevSecondLine = string.Empty;
            }
            else
            {
                prevSecondLine = progressBar;
            }
        }

        public class EquipmentSource
        {
            public EquipmentSource(string from, string required)
            {
                From = from;
                Required = required;
            }

            public string From { get; set; }
            public string Required { get; set; }
        }
    }
}