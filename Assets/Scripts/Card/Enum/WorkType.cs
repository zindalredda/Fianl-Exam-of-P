using System.ComponentModel;

namespace Card.Enum
{
    public enum WorkType
    {
        [Description("약초 물주기")] Water,
        [Description("물약 제조")] Making,
        [Description("재료 수집")] Collecting,
        [Description("인형 눈 붙히기")] EyeAttaching
    }
}