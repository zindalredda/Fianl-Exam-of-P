using System.ComponentModel;

namespace Card.Enums
{
    public enum InnerCardType
    {
        [Description("전공 : 약초학")] Major_Plants,
        [Description("전공 : 변신술")] Major_Shapes,
        [Description("전공 : 마법약 제조")] Major_Potions,
        [Description("전공 : 비행술")] Major_Flying,
        [Description("전공 : 방어술")] Major_Defense,
        [Description("전공 : 소환술")] Major_Summon,
        [Description("전공 : 마법 생물학")] Major_Creatures,
        [Description("전공 : 수면학")] Major_Sleeping,
        [Description("교양 : 마법의 이해1")] Liberal_Basics1,
        [Description("교양 : 마법의 이해2")] Liberal_Basics2,
        [Description("교양 : 룬문자 회화1")] Liberal_Rune1,
        [Description("교양 : 룬문자 회화2")] Liberal_Rune2,
        [Description("교양 : 점술1")] Liberal_Fortune1,
        [Description("교양 : 점술2")] Liberal_Fortune2,
        [Description("교양 : 마법의 역사1")] Liberal_History1,
        [Description("교양 : 마법의 역사2")] Liberal_History2,
        [Description("휴식 : 고양이 쓰다듬기1")] Play_Cat1,
        [Description("휴식 : 고양이 쓰다듬기2")] Play_Cat2,
        [Description("휴식 : 사과와 놀기1")] Play_Apple1,
        [Description("휴식 : 사과와 놀기2")] Play_Apple2,
        [Description("휴식 : 종이학 접기1")] Play_Crane1,
        [Description("휴식 : 종이학 접기2")] Play_Crane2,
        [Description("휴식 : 카페 다녀오기1")] Play_Cafe1,
        [Description("휴식 : 카페 다녀오기2")] Play_Cafe2,
        [Description("휴식 : 노래방 가기1")] Play_Karaoke1,
        [Description("휴식 : 노래방 가기2")] Play_Karaoke2,
        [Description("휴식 : 게임 즐기기1")] Play_Games1,
        [Description("휴식 : 게임 즐기기2")] Play_Games2,
        [Description("알바 : 약초 물주기1")] Work_Water1,
        [Description("알바 : 약초 물주기2")] Work_Water2,
        [Description("알바 : 물약 제조1")] Work_Making1,
        [Description("알바 : 물약 제조2")] Work_Making2,
        [Description("알바 : 재료 수집")] Work_Collecting,
        [Description("알바 : 인형 눈 붙히기")] Work_EyeAttaching
    }
}