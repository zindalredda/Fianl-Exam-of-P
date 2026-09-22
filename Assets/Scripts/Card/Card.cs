using Card.Enum;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour
    {
        private PRS _prs;
        public MainCardType cardType;
        public Sprite cardSprite;

        public void MoveCard(PRS prs)
        {
            _prs = prs;
        }
    }
}