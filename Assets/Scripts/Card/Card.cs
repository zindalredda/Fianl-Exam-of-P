using Card.Enum;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Card
{
    public class Card : MonoBehaviour
    {
        [ReadOnly] [SerializeField] private PRS prs;
        [ReadOnly] [SerializeField] private MainCardType cardType;
        [ReadOnly] [SerializeField] private System.Enum subCardType;
        [ReadOnly] [SerializeField] private Sprite cardSprite;

        [SerializeField] private float duration;
        
        private Tween sequence;

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
                .Append(transform.DOMove(prs.position, duration).SetEase(Ease.Linear))
                .Join(transform.DOScale(new Vector3(1, 1, 1), duration).SetEase(Ease.Linear))
                .Join(transform.DORotate(prs.rotation, duration).SetEase(Ease.Linear));

        }
    }
}
