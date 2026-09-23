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
        [ShowIf("_mainCardType", (int)MainCardType.Play)] [SerializeField] private LiberalType _playType;
        [ShowIf("_mainCardType", (int)MainCardType.Work)] [SerializeField] private WorkType _workType;


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
            
            Debug.Log(_subType); // FORDEBUG
            
            var temp =  Instantiate(_baseCard);
            temp.GetComponent<Card>().SetCardType(_mainCardType, _subType);
            var newCard = temp.GetComponent<Card>();
            
            cardMover.AddCard(newCard);
        }
    }
}
