using Core;
using Data.Enums;
using Data.Interface;
using DG.Tweening;
using UnityEngine;

namespace Day.DataDisplay.TimeDisplay
{
    public class TimeView : MonoBehaviour
    {
        [Header("For Debug")]
        [ReadOnly][SerializeField] private GameObject _timeHand;
        [ReadOnly][SerializeField] private GameObject _minuteHand;

        private Sequence seq;
        [ReadOnly][SerializeField] private int _currentTime;


        private void Awake()
        {
            _timeHand = transform.GetChild(0).gameObject;
            _minuteHand = transform.GetChild(1).gameObject;
        }

        public void ShowTimeHand(int _time)
        {
            if (_currentTime == _time)
                return;
            _currentTime = _time;

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