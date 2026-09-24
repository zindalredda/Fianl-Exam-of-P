using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public class DataBase
    {
        public List<string> unUsedCards = new List<string>();
        public List<string> usedCards = new List<string>();
        public List<string> preSelectedCards = new List<string>();

        public int majorCount;
        public int liberalCount;
        public int playCount;
        public int workCount;
    }
}