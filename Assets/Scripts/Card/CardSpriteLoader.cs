using Card.Enum;
using UnityEngine;

namespace Card
{
    public class CardSpriteLoader : MonoBehaviour
    {
        private static readonly System.Collections.Generic.Dictionary<MainCardType, Sprite[]> SpriteCache = new();

        public Sprite GetCardSprite(MainCardType mainCardType, System.Enum subCardType)
        {
            var (resourcePath, enumType) = mainCardType switch
            {
                MainCardType.Major => ("Card/Major_Cards", typeof(MajorType)),
                MainCardType.Liberal => ("Card/Liberal_Cards", typeof(LiberalType)),
                MainCardType.Play => ("Card/Play_Cards", typeof(PlayType)),
                MainCardType.Work => ("Card/Work_Cards", typeof(WorkType)),
                _ => throw new System.ArgumentOutOfRangeException(nameof(mainCardType), mainCardType, null)
            };

            if (subCardType == null || subCardType.GetType() != enumType)
                throw new System.ArgumentException($"{mainCardType}에는 {enumType.Name} 값을 사용해야 합니다.", nameof(subCardType));

            if (!SpriteCache.TryGetValue(mainCardType, out var sprites))
            {
                // Multiple로 분할된 PNG의 모든 타일(Sprite)을 읽습니다.
                sprites = Resources.LoadAll<Sprite>(resourcePath);
                SpriteCache.Add(mainCardType, sprites);
            }

            var spriteIndex = System.Convert.ToInt32(subCardType);
            var spriteName = $"{resourcePath[(resourcePath.LastIndexOf('/') + 1)..]}_{spriteIndex}";
            var sprite = System.Array.Find(sprites, item => item.name == spriteName);

            if (sprite == null)
                throw new System.ArgumentOutOfRangeException(nameof(subCardType), subCardType,
                    $"'{resourcePath}'에서 '{spriteName}' 스프라이트를 찾을 수 없습니다.");

            return sprite;
        }
    }
}
