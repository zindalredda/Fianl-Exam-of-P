using System.ComponentModel;

namespace Card.Enums
{
    public enum MajorType
    {
        [Description("약초학")] Plants,
        [Description("변신술")] Shapes,
        [Description("마법약 제조")] Potions,
        [Description("비행술")] Flying,
        [Description("방어술")] Defense,
        [Description("소환술")] Summon,
        [Description("마법 생물학")] Creatures,
        [Description("수면학")] Sleeping
    }
}