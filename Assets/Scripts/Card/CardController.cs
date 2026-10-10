using System;
using System.Collections.Generic;
using Card.Enums;
using Core;
using Data;
using Data.Enums;
using Data.Interface;
using UnityEngine;

namespace Card
{
    public class CardController : MonoBehaviour, IListAccessible
    {
        [Header("For Debug")]
        // 상위 데이터 박스
        [ReadOnly][SerializeField] private DataBox _dataBox; 
        // 하위 코드
        [ReadOnly][SerializeField] private CardMover _cardMover;
        [ReadOnly][SerializeField] private CardGenerator _cardGenerator;


        [ReadOnly][SerializeField] private List<string> _majorCards = new List<string>();
        [ReadOnly][SerializeField] private List<string> _liberalCards = new List<string>();
        [ReadOnly][SerializeField] private List<string> _playCards = new List<string>();
        [ReadOnly][SerializeField] private List<string> _workCards = new List<string>();
        
        [ReadOnly][SerializeField] private List<string> _randomizedCards = new List<string>();
        
        [Header("From DataBox")]
        [ReadOnly][SerializeField] private List<string> _usedCards = new List<string>();
        [ReadOnly][SerializeField] private List<string> _unUsedCards = new List<string>();
        [ReadOnly][SerializeField] private List<string> _preSelectedCards = new List<string>();
        
        private void Reset()
        {
            foreach (var value in Enum.GetValues(typeof(InnerCardType)))
            {
                if (value.ToString().Contains("Major"))
                    _majorCards.Add(value.ToString());
                else if (value.ToString().Contains("Liberal"))
                    _liberalCards.Add(value.ToString());
                else if (value.ToString().Contains("Play"))
                    _playCards.Add(value.ToString());
                else if (value.ToString().Contains("Work"))
                    _workCards.Add(value.ToString());
                else
                    Debug.LogError("Wrong SubTypes");
            }
        }

        private void DrawCard(string str)
        {
            if (str.Contains("Major"))
                _majorCards.Remove(str);
            else if (str.Contains("Liberal"))
                _liberalCards.Add(str);
            else if (str.Contains("Play"))
                _playCards.Remove(str);
            else if (str.Contains("Work"))
                _workCards.Remove(str);
            else
                Debug.LogError("Cannnot find " + str + ". Remove Fail");

            _usedCards.Add(str);
        }

        private void UseCard(string str)
        {
            
        }

        public void OnDataChange(ListType type, List<string> list)
        {
            switch (type)
            {
                case ListType.usedCards:
                    _usedCards =  list;
                    break;
                case ListType.unUsedCards:
                    _unUsedCards = list;
                    break;
                case ListType.preSelectedCards:
                    _preSelectedCards = list;
                    break;
                default:
                    break;
            }
        }
    }
}