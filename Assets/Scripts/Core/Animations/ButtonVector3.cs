using UnityEngine;

namespace Core.Animations
{
    public static class ButtonVector3
    {
        public static Vector3 returnHoverVector3(this Vector3 value)
        {
            return value + new Vector3(0.1f, 0.1f, 0.1f);
        }

        public static Vector3 returnPressedVector3(this Vector3 value)
        {
            return  value - new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}