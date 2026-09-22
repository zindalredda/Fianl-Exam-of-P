using System.ComponentModel;

namespace Card.Enum
{
    public enum PlayType
    {
        [Description("고양이 쓰다듬기")] Cat,
        [Description("사과와 놀기")] Apple,
        [Description("종이학 접기")] Crane,
        [Description("카페 다녀오기")] Cafe,
        [Description("노래방 가기")] Karaoke,
        [Description("게임 즐기기")] Games
    }
}