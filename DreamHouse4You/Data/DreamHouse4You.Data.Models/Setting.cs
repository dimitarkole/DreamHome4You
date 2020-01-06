namespace DreamHouse4You.Data.Models
{
    using DreamHouse4You.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
