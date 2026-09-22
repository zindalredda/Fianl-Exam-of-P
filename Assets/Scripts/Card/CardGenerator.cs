using System.Collections.Generic;
using Card.Enum;
using UnityEngine;

namespace Card
{
    public class CardGenerator : MonoBehaviour
    {
        private static readonly MajorType[] MajorTypes =
        {
            MajorType.Plants,
            MajorType.Shapes,
            MajorType.Potions,
            MajorType.Flying,
            MajorType.Defense,
            MajorType.Summon,
            MajorType.Creatures,
            MajorType.Sleeping
        };

        [SerializeField] private List<MajorType> _majorDrawHistory = new List<MajorType>();

        /// <summary>이번 실행 중 뽑은 Major 카드 타입의 순서입니다.</summary>
        public IReadOnlyList<MajorType> MajorDrawHistory => _majorDrawHistory;

        /// <summary>Major 카드 타입 하나를 무작위로 뽑고 기록합니다.</summary>
        public MajorType DrawRandomMajorCard()
        {
            var type = MajorTypes[Random.Range(0, MajorTypes.Length)];
            _majorDrawHistory.Add(type);
            return type;
        }

        /// <summary>Major 카드 타입을 뽑아 지정한 카드에 적용하고 기록합니다.</summary>
        public MajorType DrawRandomMajorCard(Card card)
        {
            var type = DrawRandomMajorCard();

            if (card != null)
            {
                card.SetMajorType(type);
            }
            else
            {
                Debug.LogWarning($"{nameof(CardGenerator)} drew {type}, but no card was provided to receive it.");
            }

            return type;
        }

        /// <summary>뽑은 카드 기록을 비웁니다.</summary>
        public void ClearMajorDrawHistory()
        {
            _majorDrawHistory.Clear();
        }
    }
}
