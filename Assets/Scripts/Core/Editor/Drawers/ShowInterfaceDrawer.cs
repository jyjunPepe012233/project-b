using ProjectB.Core.Attributes;
using UnityEditor;
using UnityEngine;

namespace ProjectB.Core.Editor.Drawers
{

	[CustomPropertyDrawer(typeof(ShowInterfaceAttribute))]
	public class ShowInterfaceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var attr = (ShowInterfaceAttribute)attribute;

			if (property.isArray && property.propertyType == SerializedPropertyType.Generic)
			{
				DrawArray(position, property, label, attr.InterfaceType);
				return;
			}

			DrawSingleField(position, property, label, attr.InterfaceType);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (property.isArray && property.propertyType == SerializedPropertyType.Generic)
			{
				if (!property.isExpanded)
					return EditorGUIUtility.singleLineHeight;

				int lines = 2 + property.arraySize;
				return lines * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
			}

			return EditorGUIUtility.singleLineHeight;
		}

		static void DrawSingleField(Rect position, SerializedProperty property, GUIContent label, System.Type interfaceType)
		{
			EditorGUI.BeginDisabledGroup(true);

			if (property.objectReferenceValue != null)
			{
				var typeName = GetInterfaceDisplayName(property.objectReferenceValue, interfaceType);
				label.text = $"{label.text} ({typeName})";
			}

			EditorGUI.ObjectField(position, property, label);
			EditorGUI.EndDisabledGroup();
		}

		static void DrawArray(Rect position, SerializedProperty property, GUIContent label, System.Type interfaceType)
		{
			// 펼칠 수 있도록 Foldout 생성
			property.isExpanded = EditorGUI.Foldout(
				new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
				property.isExpanded, label, true);

			if (!property.isExpanded) return;

			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.indentLevel++;
			float y = position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

			// 인터페이스 크기 표시 (Size 필드에서 표시)
			var sizeRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
			EditorGUI.IntField(sizeRect, "Size", property.arraySize);
			y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

			// 각 요소 표시
			for (int i = 0; i < property.arraySize; i++)
			{
				var elementRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
				var element = property.GetArrayElementAtIndex(i);
				var elementLabel = new GUIContent($"Element {i}");
				
				if (element.objectReferenceValue != null)
				{
					var typeName = GetInterfaceDisplayName(element.objectReferenceValue, interfaceType);
					elementLabel.text = $"Element {i} ({typeName})";
				}

				EditorGUI.ObjectField(elementRect, element, elementLabel);
				y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
			}

			EditorGUI.indentLevel--;
			EditorGUI.EndDisabledGroup();
		}

		static string GetInterfaceDisplayName(Object obj, System.Type interfaceType)
		{
			if (interfaceType.IsAssignableFrom(obj.GetType()))
				return interfaceType.Name;

			if (obj is GameObject go)
			{
				if (go.TryGetComponent(interfaceType, out _))
					return interfaceType.Name;
			}

			// Object가 타입에 맞지 않으면 Missing 표시
			return "Missing " + interfaceType.Name;
		}
	}

}
