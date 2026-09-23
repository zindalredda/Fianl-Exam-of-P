using UnityEngine;

namespace Core
{
    public class ShowIfAttribute : PropertyAttribute
    {
        public string ConditionName;
        public object ExpectedValue;

        public ShowIfAttribute(string conditionName)
        {
            ConditionName = conditionName;
            ExpectedValue = true;
        }

        public ShowIfAttribute(string conditionName, object expectedValue)
        {
            ConditionName = conditionName;
            ExpectedValue = expectedValue;
        }
    }
}