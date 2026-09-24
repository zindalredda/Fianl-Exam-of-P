using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public class DataBase
    {
        public List<string> unUsedCards;
        public List<string> usedCards;
        public List<string> preSelectedCards;

        public int majorCount;
        public int liberalCount;
        public int playCount;
        public int workCount;

        public int day;
        public bool isDay;
        
        public int burstCount;
        public bool isBurst;

        public DataBase()
        {
            unUsedCards = new List<string>();
            usedCards = new List<string>();
            preSelectedCards = new List<string>();
            
            majorCount = 0;
            liberalCount = 0;
            playCount = 0;
            workCount = 0;

            day = 1;
            isDay = false;
            
            burstCount = 0;
            isBurst = false;
        }
    }
}