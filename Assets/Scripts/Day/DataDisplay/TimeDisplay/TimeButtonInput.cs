using Core;
using UnityEngine;

namespace Day.DataDisplay.TimeDisplay
{
    public class TimeButtonInput : MonoBehaviour
    {
        [Header("For Debug")]
        [ReadOnly][SerializeField] private BoxCollider2D _boxCollider2D;
        [ReadOnly][SerializeField] private TimeController _timeController;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _timeController = GetComponent<TimeController>();
        }

        private void OnMouseDown()
        {
        }
    }
}