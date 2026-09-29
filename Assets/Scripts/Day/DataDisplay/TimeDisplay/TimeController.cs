using Data.Enums;
using Data.Interface;
using UnityEngine;

namespace Day.DataDisplay.TimeDisplay
{
    public class TimeController : MonoBehaviour, IDataAccessible
    {
        [SerializeField] private TimeView _timeView;
        [SerializeField] private TimeTextView _timeTextView;

        private TimeTextReturner timeTextReturner = new();
        private bool isFirstTime = true;

        public void OnDataChange(DataChangeType changeType, bool booleanData, int integerData)
        {
            if (changeType == DataChangeType.Time)
            {
                _timeView.ShowTimeHand(integerData);
                _timeTextView.ShowText(timeTextReturner.ReturnText(integerData, isFirstTime));
                isFirstTime = false;
            }
            else if (changeType == DataChangeType.TimeOut)
            {
                _timeView.ShowTimeHand(24);
                _timeTextView.ForceStop();
                isFirstTime = false;
            }
        }
    }
}