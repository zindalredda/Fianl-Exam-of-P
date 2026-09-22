using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public class CardMover : MonoBehaviour
    {
        private List<Card> _cards = new List<Card>();
        private int _cardsCount;
        
        private PRS _leftPRS = null;
        private PRS _rightPRS = null;
        private PRS _topPRS = null;
        
        [SerializeField] private GameObject _leftCard;
        [SerializeField] private GameObject _rightCard;
        [SerializeField] private GameObject _topCard;

        private void GetCardsPRS()
        {
            _leftPRS.position = _leftCard.transform.position;
            _leftPRS.rotation = _leftCard.transform.eulerAngles;
            _leftPRS.scale = _leftCard.transform.localScale;
            
            _rightPRS.position = _rightCard.transform.position;
            _rightPRS.rotation = _rightCard.transform.eulerAngles;
            _rightPRS.scale = _rightCard.transform.localScale;
            
            _topPRS.position = _topCard.transform.position;
            _topPRS.rotation = _topCard.transform.eulerAngles;
            _topPRS.scale = _topCard.transform.localScale;
        }

        public void AddCard(Card obj)
        {
            _cards.Add(obj);
            _cardsCount = _cards.Count;
        }

        public void RemoveCard(Card obj)
        {
            _cards.Remove(obj);
            _cardsCount = _cards.Count;
        }

        private void DrawCards()
        {
            if (_cardsCount == 1)
            {
                _cards[0].MoveCard(_topPRS);
            }
            else if (_cardsCount == 2)
            {
                _cards[0].MoveCard(_leftPRS);
                _cards[1].MoveCard(_rightPRS);
            }
            else
            {
                _cards[0].MoveCard(_leftPRS);
                for (var i = 1; i < _cardsCount - 1; i++)
                {
                    
                }
            }
        }
    }
}
