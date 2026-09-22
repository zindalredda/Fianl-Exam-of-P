using System.ComponentModel;

namespace Card.Enum
{
    public enum LiberalType
    {
        [Description("마법의 이해")] Basics,
        [Description("룬문자 회화")] Rune,
        [Description("점술")] Fortune,
        [Description("마법의 역사")] History,
    }
}