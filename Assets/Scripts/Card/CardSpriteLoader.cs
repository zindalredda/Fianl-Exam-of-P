using System;
using Card.Enums;
using UnityEngine;

namespace Card
{
    public static class CardSpriteLoader
    {
        public static Sprite GetCardSprite(this MainCardType value, System.Enum subCardType)
        {
            var fullSprite = Resources.LoadAll<Sprite>("Card/"+value.ToString()+"_Cards");
            var subType = value switch
            {
                MainCardType.Major => typeof(MajorType),
                MainCardType.Liberal => typeof(LiberalType),
                MainCardType.Play => typeof(PlayType),
                MainCardType.Work => typeof(WorkType),
                _ => throw new Exception("Unknown card type")
            };
            
            if (subCardType.GetType()!=subType)
                throw new Exception("SubCard type is not supported");

            return fullSprite[Convert.ToInt32(subCardType)];
        }
    }
}
