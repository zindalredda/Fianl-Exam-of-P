using System.Collections.Generic;
using System.Linq;
using Data.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class DataBox : MonoBehaviour
    {
        private static DataBase _db;
        private List<IDataAccessible> _dataAccess;
        
        private void Start()
        {
            if(FindObjectsByType<DataBox>().Length != 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }
        
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _dataAccess = FindObjectsByType<MonoBehaviour>()
                .OfType<IDataAccessible>()
                .ToList();
        }

        public static DataBase ReturnData()
        {
            return _db;
        }

        public static void SetData(DataBase data)
        {
            _db = data;
        }
    }
}