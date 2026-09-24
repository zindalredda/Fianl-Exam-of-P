using Card.Enums;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour
    {
        public PRS prs;
        [ReadOnly] [SerializeField] private MainCardType cardType;
        private System.Enum subCardType;
        [ReadOnly] [SerializeField] private Sprite cardSprite;
        [SerializeField] private float duration;
        
        private Tween sequence;
        
        private void Start()
        {
            prs = new PRS();
            
            prs.pos = transform.position;
            prs.rot = transform.eulerAngles;
            prs.scale = transform.localScale;
        }

        public void SetCardType(MainCardType mainType, System.Enum subType)
        {
            cardType = mainType;
            subCardType = subType;

            ChangeSprite();
        }

        private void ChangeSprite()
        {
            cardSprite = cardType.GetCardSprite(subCardType);
            this.GetComponent<SpriteRenderer>().sprite = cardSprite;
        }

        public void MoveCard(PRS target, int index = 0)
        {
            prs = target;
            this.GetComponent<SpriteRenderer>().sortingOrder = index;
            sequence?.Kill();

            sequence = DOTween.Sequence()
                .Append(transform.DOMove(prs.pos, duration).SetEase(Ease.Linear))
                .Join(transform.DOScale(prs.scale, duration).SetEase(Ease.Linear))
                .Join(transform.DORotate(prs.rot, duration).SetEase(Ease.Linear));

        }
    }
}
