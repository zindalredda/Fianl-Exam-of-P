using Card.Enum;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour
    {
        private PRS _prs;
        public MainCardType cardType;
        public MajorType majorType;
        public Sprite cardSprite;

        public void SetMajorType(MajorType type)
        {
            cardType = MainCardType.Major;
            majorType = type;
        }

        public void MoveCard(PRS prs)
        {
            _prs = prs;
        }
    }
}
