using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Card
{
    public class CardMover : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private readonly List<Card> _cards = new List<Card>();
        
        [ReadOnly] [SerializeField] private PRS _leftPRS;
        [ReadOnly] [SerializeField] private PRS _rightPRS;
        [ReadOnly] [SerializeField] private PRS _topPRS;
        [ReadOnly] [SerializeField] private PRS _startPRS;
        
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
            return _cards.Count switch
            {
                1 => _topPRS,
                2 => index == 1 ? _leftPRS : _rightPRS,
                3 => Cal(index),
                _ => throw new System.NotImplementedException()
            };
        }

        private PRS Cal(int index)
        {
            var t = (float)index / (_cards.Count - 1);

            var leftTop = Vector3.Lerp(_leftPRS.pos, _topPRS.pos, t);
            var topRight = Vector3.Lerp(_topPRS.pos, _rightPRS.pos, t);
            var position = Vector3.Lerp(leftTop, topRight, t);

            var leftRotation = Vector3.Lerp(_leftPRS.pos, _topPRS.pos, t);
            var rightRotation = Vector3.Lerp(_topPRS.pos, _rightPRS.pos, t);
            var rotation = Vector3.Lerp(leftRotation, rightRotation, t);

            var prs = new PRS(position, rotation, _topPRS.scale);
            prs.LogPRS(index.ToString());
            
            return prs;
        }
    }
}
