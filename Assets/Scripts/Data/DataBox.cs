using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data.Enums;
using Data.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class DataBox : MonoBehaviour
    {
        private DataBase _db;
        private List<IDataAccessible> _dataAccessibles;

        [Header("For Debug")]
        [ReadOnly] [SerializeField] private int _time;
        [ReadOnly] [SerializeField] private int _stress = 100;
        
        private void Start()
        {
            if(FindObjectsByType<DataBox>().Length != 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }

        private void DataChanged(DataChangeType changeType)
        {
            switch (changeType)
            {
                case DataChangeType.Time:
                    _dataAccessibles.ForEach(_accessible => _accessible.OnDataChange(DataChangeType.Time,false, _time)); // 수정할 것
                    break;
                case DataChangeType.Stress:
                    _dataAccessibles.ForEach(_accessible => _accessible.OnDataChange(DataChangeType.Stress,false, _stress));
                    break;
                case DataChangeType.StressOut:
                    break;
                case DataChangeType.TimeOut:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(changeType), changeType, null);
            }
            
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
            _dataAccessibles = FindObjectsByType<MonoBehaviour>()
                .OfType<IDataAccessible>()
                .ToList();
        }

        private void DataSetUp()
        {
            
        }


        public void SetTime(int time)
        {
            _time = time;
        }

        public void SetStress(int stress)
        {
            _stress = stress;
        }
    }
}