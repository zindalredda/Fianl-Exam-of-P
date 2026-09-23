using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Card
{
    public class CardManager : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private List<string> _majorCards  = new List<string>();
        [ReadOnly] [SerializeField] private List<Card> _liberalCards = new List<Card>();
        [ReadOnly] [SerializeField] private List<Card> _playCards = new List<Card>();
        [ReadOnly] [SerializeField] private List<Card> _workCards = new List<Card>();

        private void Reset()
        {
            
        }
    }
}