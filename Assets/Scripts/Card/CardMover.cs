using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public class CardMover : MonoBehaviour
    {
        private readonly List<Card> _cards = new List<Card>();
        
        private PRS _leftPRS;
        private PRS _rightPRS;
        private PRS _topPRS;
        
        [SerializeField] private GameObject _leftCard;
        [SerializeField] private GameObject _rightCard;
        [SerializeField] private GameObject _topCard;

        private void Awake()
        {
            GetCardsPRS();
        }

        private void GetCardsPRS()
        {
            _leftPRS = CreatePRS(_leftCard, nameof(_leftCard));
            _rightPRS = CreatePRS(_rightCard, nameof(_rightCard));
            _topPRS = CreatePRS(_topCard, nameof(_topCard));
        }

        private static PRS CreatePRS(GameObject cardSlot, string slotName)
        {
            if (cardSlot == null)
            {
                Debug.LogError($"{nameof(CardMover)} requires {slotName} to be assigned.");
                return null;
            }

            var slotTransform = cardSlot.transform;
            return new PRS
            {
                position = slotTransform.position,
                rotation = slotTransform.eulerAngles,
                scale = slotTransform.localScale
            };
        }

        public void AddCard(Card obj)
        {
            if (obj == null || _cards.Contains(obj))
            {
                return;
            }

            _cards.Add(obj);
            DrawCards();
        }

        public void RemoveCard(Card obj)
        {
            if (_cards.Remove(obj))
            {
                DrawCards();
            }
        }

        private void DrawCards()
        {
            if (_leftPRS == null || _rightPRS == null || _topPRS == null)
            {
                return;
            }

            switch (_cards.Count)
            {
                case 0:
                    return;
                case 1:
                    _cards[0].MoveCard(_topPRS);
                    return;
                case 2:
                    _cards[0].MoveCard(_leftPRS);
                    _cards[1].MoveCard(_rightPRS);
                    return;
                default:
                    for (var i = 0; i < _cards.Count; i++)
                    {
                        var ratio = (float)i / (_cards.Count - 1);
                        _cards[i].MoveCard(InterpolatePRS(_leftPRS, _rightPRS, ratio));
                    }

                    return;
            }
        }

        private static PRS InterpolatePRS(PRS from, PRS to, float ratio)
        {
            return new PRS
            {
                position = Vector3.Lerp(from.position, to.position, ratio),
                rotation = Vector3.Lerp(from.rotation, to.rotation, ratio),
                scale = Vector3.Lerp(from.scale, to.scale, ratio)
            };
        }
    }
}
