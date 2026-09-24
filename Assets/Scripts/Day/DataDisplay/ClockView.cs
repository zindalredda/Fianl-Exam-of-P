using Core;
using Data.Enums;
using Data.Interface;
using UnityEngine;

namespace Day.DataDisplay
{
    public class ClockView : MonoBehaviour, IDataAccessible
    {
        [ReadOnly] [SerializeField] private GameObject _timeHand;
        [ReadOnly] [SerializeField] private GameObject _minuteHand;


        public void OnDataChange(DataChangeType changeType, bool booleanData, int integerData)
        {
            
        }
    }
}