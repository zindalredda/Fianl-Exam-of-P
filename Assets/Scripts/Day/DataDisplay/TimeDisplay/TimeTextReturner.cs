using System.Collections.Generic;
using UnityEngine;

namespace Day.DataDisplay
{
    public class TimeTextReturner
    {
        private readonly List<string> StartText = new List<string>
        {
            "지금은 {time}시야.\n내가 아니면 안되겠구만."
        };
        private readonly List<string> GoodText = new List<string>
        {
            "{time}시...\n흥, 시간 관리 못하는 사람이랑은 얘기하고 싶지 않은데~",
            "내 시계는 정확해.\n{time}시야.",
            "시간은 금보다 귀해. 넌 이해 못하겠지만.\n{time}시라는 걸 알아둬.",
            "벌써 {time}시네~\n시간낭비는 너의 특기인가봐?"
        };
        private readonly List<string> NormalText = new List<string>
        {
            "와~ 꼴이 엉망진창인데?\n벌써 시간이 {time}신데...", 
            "야! 시끄러워! 몇 신지 알아?\n{time}시라고!",
            "{time}시라는 시간을 보고도 웃음이 나오나보네.",
            "{time}시.\n이렇게 말해주는 것도 시간낭비야."
        };
        private readonly List<string> BadText = new List<string>
        {
            "...시계 숫자도 못 읽는거야?\n흥, {time}시라고.",
            "성실한거야? 멍청한거야?\n{time}시라고 말만 해둘게.",
            "몇 번을 말해줘야 해? {time}시라고!"
        };

        public string ReturnText(TimeTextReturnType type, int time)
        {
            return type switch
            {
                TimeTextReturnType.Start => StartText[0].Replace("{time}", time.ToString()),
                TimeTextReturnType.Good => GoodText[Random.Range(0, GoodText.Count)].Replace("{time}", time.ToString()),
                TimeTextReturnType.Normal => NormalText[Random.Range(0, NormalText.Count)]
                    .Replace("{time}", time.ToString()),
                TimeTextReturnType.Bad => BadText[Random.Range(0, BadText.Count)].Replace("{time}", time.ToString()),
                _ => throw new System.NotImplementedException()
            };
        }
    }
}