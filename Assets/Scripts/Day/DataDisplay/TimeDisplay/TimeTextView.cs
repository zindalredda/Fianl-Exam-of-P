using System;
using Core;
using Data.Enums;
using Data.Interface;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Day.DataDisplay.TimeDisplay
{
    public class TimeTextView : MonoBehaviour
    {
        [Header("For Debug")]
        [ReadOnly][SerializeField] private SpriteRenderer _spriteRenderer;
        [ReadOnly][SerializeField] private TMP_Text _text;
        private Sequence seq;

        private void Awake()
        {
            _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            _text = transform.GetChild(1).GetComponent<TMP_Text>();
        }

        public void ShowText(string str)
        {
            _text.text = str;
            var fadeInDuration = 0.5f;
            if (seq != null)
            {
                seq.Kill();
                if (_spriteRenderer.color.a < 0.99f)
                    fadeInDuration = 0.2f;
            }

            seq = DOTween.Sequence()
                .Append(_spriteRenderer.DOFade(1, fadeInDuration))
                .Join(_text.DOFade(1, fadeInDuration))
                .AppendInterval(2f)
                .Append(_spriteRenderer.DOFade(0, 0.5f))
                .Join(_text.DOFade(0, 0.5f))
                .OnComplete(() => seq = null);
        }

        public void ForceStop()
        {
            if (seq != null)
                seq.Kill();
            seq = null;
        }
    }
}