using System;
using Card.Enums;
using Core;
using UnityEngine;

namespace Card
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _baseCard;
        [ReadOnly] [SerializeField] private CardMover cardMover;
        
        [Header("Next Card Setting")]
        [SerializeField] private MainCardType  _mainCardType;
        [ShowIf("_mainCardType", (int)MainCardType.Major)] [SerializeField] private MajorType _majorType;
        [ShowIf("_mainCardType", (int)MainCardType.Liberal)] [SerializeField] private LiberalType _liberType;
        [ShowIf("_mainCardType", (int)MainCardType.Play)] [SerializeField] private PlayType _playType;
        [ShowIf("_mainCardType", (int)MainCardType.Work)] [SerializeField] private WorkType _workType;
        [ReadOnly] [SerializeField] private PRS _startPRS;

        private void Start()
        {
            cardMover = FindAnyObjectByType<CardMover>();
        }
        
        [ContextMenu("Create Card")]
        public void CreateCard()
        {
            Enum _subType = _mainCardType switch
            {
                MainCardType.Major => _majorType,
                MainCardType.Liberal => _liberType,
                MainCardType.Play => _playType,
                MainCardType.Work => _workType,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            Debug.Log(_startPRS.pos); // FORDEBUG
            cardMover = FindAnyObjectByType<CardMover>();
            _startPRS = cardMover._startPRS;
            
            var temp =  Instantiate(_baseCard, _startPRS.pos, Quaternion.Euler(_startPRS.rot));
            temp.GetComponent<Card>().SetCardType(_mainCardType, _subType);
            var newCard = temp.GetComponent<Card>();
            
            cardMover.AddCard(newCard);
        }
    }
}
