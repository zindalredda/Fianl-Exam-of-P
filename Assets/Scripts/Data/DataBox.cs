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
        private List<IListAccessible> _listAccessible;

        [Header("For Debug")] [ReadOnly] [SerializeField]
        private int _time;

        [ReadOnly] [SerializeField] private int _stress = 100;

        private void Start()
        {
            if (FindObjectsByType<DataBox>().Length != 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }

        private void DataChanged(DataChangeType changeType)
        {
            switch (changeType)
            {
                case DataChangeType.Time:
                    _dataAccessibles.ForEach(_accessible =>
                        _accessible.OnDataChange(DataChangeType.Time, false, _time)); // 수정할 것
                    break;
                case DataChangeType.Stress:
                    _dataAccessibles.ForEach(accessible =>
                        accessible.OnDataChange(DataChangeType.Stress, false, _stress));
                    break;
                case DataChangeType.StressOut:
                    break;
                case DataChangeType.TimeOut:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(changeType), changeType, null);
            }
        }

        private void ListDataChanged(ListType changeType)
        {
            _listAccessible.ForEach(accessible =>
                accessible.OnDataChange(changeType, changeType switch
                {
                    ListType.unUsedCards => _db.unUsedCards,
                    ListType.usedCards => _db.usedCards,
                    ListType.preSelectedCards => _db.preSelectedCards,
                    _ => throw new ArgumentOutOfRangeException(nameof(changeType), changeType, null)
                }));
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
            _listAccessible = FindObjectsByType<MonoBehaviour>()
                .OfType<IListAccessible>()
                .ToList();
        }

        private void DataSetUp()
        {
            foreach (DataChangeType value in Enum.GetValues(typeof(DataChangeType)))
            {
                DataChanged(value);
            }

            foreach (ListType value in Enum.GetValues(typeof(ListType)))
            {
                ListDataChanged(value);
            }
        }

        public void SetList(ListType type, List<string> list)
        {
            switch (type)
            {
                case ListType.unUsedCards:
                    _db.unUsedCards = list;
                    break;
                case ListType.usedCards:
                    _db.usedCards = list;
                    break;
                case ListType.preSelectedCards:
                    _db.preSelectedCards = list;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            ListDataChanged(type);
        }


        public void SetTime(int time)
        {
            _time = time;
            DataChanged(DataChangeType.Time);
        }

        public void SetStress(int stress)
        {
            _stress = stress;
            DataChanged(DataChangeType.Stress);
        }
    }
}