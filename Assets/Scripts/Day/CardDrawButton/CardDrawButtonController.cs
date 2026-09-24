using Core;
using Core.Animations;
using Data.Enums;
using Data.Interface;
using UnityEngine;

namespace Day.CardDrawButton
{
    public class CardDrawButtonController : MonoBehaviour, IDataAccessible
    {
        [Header("Components")]
        [SerializeField] private CardDrawButtonInput _input;
        [SerializeField] private CardDrawButtonView  _view;
        
        [Header("Debugs")]
        [ReadOnly] [SerializeField] private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            if(_boxCollider2D == null)
                Debug.LogError("No BoxCollider2D found");
        }
        
        public void RenderButton(ButtonEventType eventType)
        {
            _view.ChangeButtonAnimation(eventType);
        }
        
        public void OnDataChange(DataChangeType changeType, bool booleanData, int integerData)
        {
            switch (changeType)
            {
                case DataChangeType.Stress:
                    _view.ChangeStressSprite(integerData < 12);
                    break;
                case DataChangeType.StressOut:
                case DataChangeType.Time:
                case DataChangeType.TimeOut:
                    _boxCollider2D.enabled = false;
                    break;
                default:
                    Debug.LogError("WrongDataChangeType");
                    return;
            }
        }
    }
}