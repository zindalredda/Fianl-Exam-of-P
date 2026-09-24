using Core;
using Core.Animations;
using UnityEngine;

namespace Day.CardDrawButton
{
    public class CardDrawButtonView : MonoBehaviour
    {
        [Header("필요 스프라이트")]
        [SerializeField] private Sprite _normalDrawButton;
        [SerializeField] private Sprite _stressedDrawButton;
        
        [Header("디버그용 ")]
        [ReadOnly] [SerializeField] private SpriteRenderer _renderer;
        [ReadOnly] [SerializeField] private Vector3 _originScale;
        [ReadOnly] [SerializeField] private SpriteRenderer outlineRenderer;
        
        private static readonly Color _white = new Color(1, 1, 1, 1);
        private static readonly Color _clear = new Color(1, 1, 1, 0);
        private static readonly Color _grey = new Color(0.8f, 0.8f, 0.8f, 1);

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if(_renderer == null)
                Debug.LogError("No SpriteRenderer found");
            outlineRenderer = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            if (outlineRenderer == null)
                Debug.LogError("No SpriteRenderer found");
            
            _originScale = this.transform.localScale;
        }
        
        public void ChangeButtonAnimation(ButtonEventType eventType)
        {
            switch (eventType)
            {
                case ButtonEventType.Enter:
                    transform.localScale = _originScale.returnHoverVector3();
                    outlineRenderer.color = _white;
                    return;
                case ButtonEventType.Exit:
                    transform.localScale = _originScale;
                    outlineRenderer.color = _clear;
                    return;
                case ButtonEventType.Down:
                    transform.localScale = _originScale.returnPressedVector3();
                    _renderer.color = _grey;
                    return;
                case ButtonEventType.Up:
                    transform.localScale = _originScale;
                    _renderer.color = _white;
                    return;
                default:
                    Debug.LogError("Unknown ButtonEventType");
                    return;
            }
        }

        public void ChangeStressSprite(bool isStress)
        {
            _renderer.sprite = isStress ? _stressedDrawButton : _normalDrawButton;
        }
    }
}