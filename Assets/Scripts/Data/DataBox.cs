using UnityEngine;

namespace Data
{
    public class DataBox : MonoBehaviour
    {
        private static DataBase _db;
        
        private void Start()
        {
            if(FindObjectsByType<DataBox>().Length != 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }

        public static DataBase ReturnDataBase()
        {

            return _db;
        }
    }
}