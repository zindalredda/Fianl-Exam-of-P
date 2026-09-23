using Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attribute = (ShowIfAttribute)this.attribute;
            var condition = property.serializedObject.FindProperty(attribute.ConditionName);

            if (condition != null && IsConditionMet(condition, attribute.ExpectedValue))
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var attribute = (ShowIfAttribute)this.attribute;
            using var condition = property.serializedObject.FindProperty(attribute.ConditionName);

            if (condition != null && IsConditionMet(condition, attribute.ExpectedValue))
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }

            return 0;
        }

        private bool IsConditionMet(SerializedProperty property, object expectedValue)
        {
            return property.propertyType switch
            {
                SerializedPropertyType.Boolean => property.boolValue == (bool)expectedValue,
                SerializedPropertyType.Enum => property.enumValueIndex == (int)expectedValue,
                SerializedPropertyType.Integer => property.intValue == (int)expectedValue,
                SerializedPropertyType.Float => Mathf.Approximately(property.floatValue, (float)expectedValue),
                SerializedPropertyType.String => property.stringValue == (string)expectedValue,
                _ => false
            };
        }
    }
}