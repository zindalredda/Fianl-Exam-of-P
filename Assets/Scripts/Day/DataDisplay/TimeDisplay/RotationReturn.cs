using UnityEngine;

namespace Day.DataDisplay
{
    public static class RotationReturn
    {
        public static Vector3 ReturnRotation(this Vector3 value)
        {
            return value + new Vector3(0, 0, -10f);
        }
    }
}