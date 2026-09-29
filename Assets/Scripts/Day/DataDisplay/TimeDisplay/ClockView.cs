using Core;
using Data.Enums;
using Data.Interface;
using DG.Tweening;
using UnityEngine;

namespace Day.DataDisplay
{
    public class ClockView : MonoBehaviour, IDataAccessible
    {
        [ReadOnly] [SerializeField] private GameObject _timeHand;
        [ReadOnly] [SerializeField] private GameObject _minuteHand;

        private Sequence seq;
        [ReadOnly] [SerializeField] private int _currentTime;


        private void Awake()
        {
            _timeHand = transform.GetChild(0).gameObject;
            _minuteHand = transform.GetChild(1).gameObject;
        }

        public void OnDataChange(DataChangeType changeType, bool booleanData, int integerData)
        {
            switch (changeType)
            {
                case DataChangeType.Time:
                    _currentTime = integerData;
                    AddAnimation(_currentTime);
                    break;
                case DataChangeType.TimeOut:
                    _currentTime = 24;
                    AddAnimation(_currentTime);
                    break;
            }
        }

        private void AddAnimation(int _time)
        {
            if (seq == null)
                seq = DOTween.Sequence();
            

            seq.Append(_timeHand.transform.DORotate(new Vector3(0, 0, -15f * _time), 0.5f))
                .Join(_minuteHand.transform.DORotate(new Vector3(0, 0, 360), 0.5f))
                .OnComplete(() =>
                {
                    _minuteHand.transform.rotation = Quaternion.Euler(0, 0, 0);
                    seq = null;
                });
        }
    }
}