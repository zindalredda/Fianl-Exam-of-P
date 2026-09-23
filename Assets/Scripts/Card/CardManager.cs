using System;
using System.Collections.Generic;
using Card.Enums;
using Core;
using UnityEngine;

namespace Card
{
    public class CardManager : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private List<string> _majorCards  = new List<string>();
        [ReadOnly] [SerializeField] private List<string> _liberalCards = new List<string>();
        [ReadOnly] [SerializeField] private List<string> _playCards = new List<string>();
        [ReadOnly] [SerializeField] private List<string> _workCards = new List<string>();
        
        [ReadOnly] [SerializeField] private List<string> _usedCards = new List<string>();
        
        [ReadOnly] [SerializeField] private List<string> _preSelectedCards = new List<string>();
        [ReadOnly] [SerializeField] private List<string> _randomizedCards = new List<string>();
        
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
            }
        }

        private void DrawCard(string str)
        {
            if (str.Contains("Major"))
                _majorCards.Remove(str);
            else if (str.Contains("Liberal"))
                _majorCards.Add(str);
            else if (str.Contains("Play"))
                _playCards.Remove(str);
            else if (str.Contains("Work"))
                _workCards.Remove(str);
            else
                Debug.LogError("Cannnot find " + str +". Remove Fail");
            
            _usedCards.Add(str);
        }
    }
}