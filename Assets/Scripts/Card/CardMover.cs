using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Card
{
    public class CardMover : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private List<Card> _cards = new List<Card>();
        
        [ReadOnly] [SerializeField] private PRS _leftPRS;
        [ReadOnly] [SerializeField] private PRS _rightPRS;
        [ReadOnly] [SerializeField] private PRS _topPRS;
        public PRS _startPRS;
        
        [SerializeField] private Card _leftCard;
        [SerializeField] private Card _rightCard;
        [SerializeField] private Card _topCard;
        [SerializeField] private Card _startCard;

        private void Start()
        {
            GetCardPRS();
        }
        
        private void GetCardPRS()
        {
            _startPRS = _startCard.prs;
            _leftPRS = _leftCard.prs;
            _rightPRS = _rightCard.prs;
            _topPRS = _topCard.prs;
        }

        public void AddCard(Card card)
        {
            GetCardPRS();
            _cards.Add(card);
            DrawCard();
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        private void DrawCard()
        {
            if (_cards.Count == 0)
                Debug.Log("DrawCard() : No Cards. Wrong Call"); // ForDebug
            else
                for (var i = 0; i < _cards.Count; i++)
                    _cards[i].MoveCard(CalculateCardPRS(i), i);

        }

        private PRS CalculateCardPRS(int index)
        {
            return _cards.Count == 1 ? _topPRS : Cal(index);
        }

        private PRS Cal(int index)
        {
            var t = (float)index / (_cards.Count - 1);

            var leftTop = Vector3.Lerp(_leftPRS.pos, _topPRS.pos, t);
            var topRight = Vector3.Lerp(_topPRS.pos, _rightPRS.pos, t);
            var position = Vector3.Lerp(leftTop, topRight, t);

            // Interpolate directly between the left and right rotations so the
            // cards turn evenly along the fan, including across 0/360 degrees.
            var rotation = new Vector3(
                Mathf.LerpAngle(_leftPRS.rot.x, _rightPRS.rot.x, t),
                Mathf.LerpAngle(_leftPRS.rot.y, _rightPRS.rot.y, t),
                Mathf.LerpAngle(_leftPRS.rot.z, _rightPRS.rot.z, t));

            var prs = new PRS(position, rotation, _topPRS.scale);
            prs.LogPRS(index.ToString());
            
            return prs;
        }
    }
}
