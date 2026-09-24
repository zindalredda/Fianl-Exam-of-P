using System;
using Card.Enums;
using UnityEngine;

namespace Card
{
    public static class CardDataLoader
    {
        public static int GetTime(this MainCardType cardType, Enum subCardType)
        {
            return cardType switch
            {
                MainCardType.Major => 4,
                MainCardType.Liberal => 2,
                MainCardType.Play => subCardType switch
                {
                    PlayType.Cat => 1,
                    PlayType.Apple => 2,
                    PlayType.Crane => 3,
                    PlayType.Cafe => 3,
                    PlayType.Karaoke => 4,
                    PlayType.Games => 5,
                    _ => throw new Exception("Unknown card type")
                },
                MainCardType.Work => 6,
                _ => throw new Exception("Unknown card type")
            };
        }

        public static int GetStress(this MainCardType cardType, Enum subCardType)
        {
            return cardType switch
            {
                MainCardType.Major => 3,
                MainCardType.Liberal => 3,
                MainCardType.Play => -4,
                MainCardType.Work => 6,
                _ => throw new Exception("Unknown card type")
            };
        }
    }
}