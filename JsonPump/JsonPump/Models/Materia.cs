using System.Collections.Generic;
using JsonPump.SquareEnix.ExFiles;

namespace JsonPump.Models
{
    public static class MateriaFactory
    {
        public static IEnumerable<Materia> CreateMateriasFromRow(ExDRow row)
        {
            var baseParamName = Program.BaseParams[row.GetDataByIndex(10).GetAsTyped<byte>()].Name;

            var materias = new List<Materia>();

            for (var i = 0; i < 10; i++)
            {
                var materia = new Materia(row.GetDataByIndex(i).GetAsTyped<int>(), i + 1);
                materia.Parameters.Add(baseParamName, row.GetDataByIndex(11 + i).GetAsTyped<short>());
                materias.Add(materia);
            }

            return materias;
        }
    }

    public class Materia
    {
        public Materia(int itemKey, int tier)
        {
            ItemKey = itemKey;
            Tier = tier;
            Parameters = new Dictionary<string, short>();
        }

        public int ItemKey { get; set; }
        public int Tier { get; set; }
        public Dictionary<string, short> Parameters { get; set; }
    }
}