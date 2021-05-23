using System.ComponentModel.DataAnnotations;

namespace DataPump.Memory.Models
{
    public class ParameterValueModel : ParameterValueBaseModel
    {
        [Key]
        public int Key { get; set; }
    }

    public class ParameterValueBaseModel
    {
        public BaseParamModel BaseParam { get; set; }
        public short ParamValue { get; set; }
    }
}
