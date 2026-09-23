using UnityEngine;

namespace Card
{
    public class PRS
    {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 scale;

        public PRS(Vector3 pos, Vector3 rot, Vector3 scale)
        {
            this.pos = pos;
            this.rot = rot;
            this.scale = scale;
        }

        public void LogPRS(string str = "")
        {
            Debug.Log(str + "|" + "Pos: " + pos + " Rot: " + rot + " Scale: " + scale);
        }
    }
}
