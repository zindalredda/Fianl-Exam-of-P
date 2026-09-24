using Core;
using Data;
using Data.Enums;
using Data.Interface;
using UnityEngine;

namespace Day
{
    public class CardDrawButton : MonoBehaviour, IDataAccessible
    {
        [SerializeField] private Sprite _normalDrawButton;
        [SerializeField] private Sprite _stressedDrawButton;
        
        
        // ForDebug
        [Header("디버그용 ")]
        [ReadOnly] [SerializeField] private SpriteRenderer _renderer;
        [ReadOnly] [SerializeField] private Material _material;
        [ReadOnly] [SerializeField] private BoxCollider2D  _boxCollider2D;
        [ReadOnly] [SerializeField] private DataBox _dataBox;
        [ReadOnly] [SerializeField] private Vector3 _originScale;
        [ReadOnly] [SerializeField] private Vector3 _hoverScale;
        [ReadOnly] [SerializeField] private Vector3 _pressedScale;
        
        private void Awake()
        {
            _dataBox = FindAnyObjectByType<DataBox>();
            
            _renderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            
            _originScale = this.transform.localScale;
            _hoverScale = this.transform.localScale + new Vector3(0.3f, 0.3f, 0.3f);
            _pressedScale = this.transform.localScale - new Vector3(0.3f, 0.3f, 0.3f);
        }
        
        private void OnMouseEnter()
        {
            transform.localScale =  _hoverScale;
        }

        private void OnMouseExit()
        {
            transform.localScale = _originScale;
        }

        private void OnMouseDown()
        {
            
        }

        private void OnMouseUp()
        {
            
        }
        
        public void OnDataChange(DataChangeType changeType, bool boolean, int integer)
        {
            switch (changeType)
            {
                case DataChangeType.Stress:
                    _renderer.sprite = integer >= 12 ? _normalDrawButton : _stressedDrawButton;
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