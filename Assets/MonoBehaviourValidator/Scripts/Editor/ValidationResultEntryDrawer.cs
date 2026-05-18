using UnityEditor;
using UnityEngine;

namespace MonoBehaviourValidator
{
	[CustomPropertyDrawer(typeof(ValidationResultEntry))]
	public class ValidationResultEntryDrawer : PropertyDrawer
	{
		private const float PADDING = 6f;
		private const float ICON_SIZE = 20f;
		private const float LINE_HEIGHT = 18f;
		private const float LINE_SPACING = 2f;
		private const float BOX_OUTLINE_WIDTH = 2f;
		private const int LINE_COUNT = 3;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float innerHeight = LINE_COUNT * LINE_HEIGHT + (LINE_COUNT - 1) * LINE_SPACING;
			return innerHeight + PADDING * 2 + BOX_OUTLINE_WIDTH * 2;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// 각 변수를 받아옴
			SerializedProperty isValidProp = property.FindPropertyRelative("isValid");
			SerializedProperty nameProp = property.FindPropertyRelative("name");
			SerializedProperty prefabProp = property.FindPropertyRelative("prefab");
			SerializedProperty hierarchyProp = property.FindPropertyRelative("hierarchyPath");

			bool isValid = isValidProp.boolValue;
			
			// 검증 결과에 따라 테두리 색이 달라짐
			Color borderColor = isValid ? new Color(0.35f, 0.75f, 0.35f) : new Color(0.85f, 0.25f, 0.25f);
			DrawBorderedBox(position, borderColor); // 테두리 그리기(아래에 private method로 구현되어있음)

			// rect 계산
			Rect inner = new Rect(
				position.x + BOX_OUTLINE_WIDTH + PADDING,
				position.y + BOX_OUTLINE_WIDTH + PADDING,
				position.width - (BOX_OUTLINE_WIDTH + PADDING) * 2,
				position.height - (BOX_OUTLINE_WIDTH + PADDING) * 2
			);
			
			// title, icon 배치
			Rect titleLineRect = new Rect(inner.x, inner.y, inner.width, LINE_HEIGHT);

			Rect iconRect  = new Rect(titleLineRect.x, titleLineRect.y, ICON_SIZE, ICON_SIZE);
			Rect titleRect = new Rect(titleLineRect.x + ICON_SIZE + 4f, titleLineRect.y,
			                          titleLineRect.width - ICON_SIZE - 4f, LINE_HEIGHT);

			GUIContent icon = isValid
				? EditorGUIUtility.IconContent("TestPassed")
				: EditorGUIUtility.IconContent("console.erroricon"); // 유니티 에러 아이콘 (에디터 버전에 따라 icon name이 달라질 수 있음)
			GUI.Label(iconRect, icon);

			GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel) { fontSize = 12 };
			GUI.Label(titleRect, nameProp.stringValue, titleStyle);

			
			// 프리팹 필드
			Rect prefabRect = new Rect(inner.x, titleLineRect.yMax + LINE_SPACING, inner.width, LINE_HEIGHT);

			using (new EditorGUI.DisabledScope(true))
			{
				EditorGUI.ObjectField(prefabRect, "Prefab", prefabProp.objectReferenceValue, typeof(GameObject), false);
			}

			// Validatable의 Hierarchy 상 위치(hierarchyPath) 표시
			Rect pathRect = new Rect(inner.x, prefabRect.yMax + LINE_SPACING, inner.width, LINE_HEIGHT);

			GUIStyle pathStyle = new GUIStyle(EditorStyles.miniLabel)
			{
				wordWrap  = false,
				clipping  = TextClipping.Clip,
				fontStyle = FontStyle.Italic,
			};
			EditorGUI.LabelField(pathRect, "Path", hierarchyProp.stringValue, pathStyle);
		}

		static void DrawBorderedBox(Rect rect, Color borderColor)
		{
			// 배경 색
			Color bg = EditorGUIUtility.isProSkin
				? new Color(0.22f, 0.22f, 0.22f)
				: new Color(0.88f, 0.88f, 0.88f);
			EditorGUI.DrawRect(rect, bg);
			
			// 테두리 그리기
			EditorGUI.DrawRect(new Rect(rect.x, rect.y, rect.width, BOX_OUTLINE_WIDTH), borderColor);
			EditorGUI.DrawRect(new Rect(rect.x, rect.yMax - BOX_OUTLINE_WIDTH, rect.width, BOX_OUTLINE_WIDTH), borderColor);
			EditorGUI.DrawRect(new Rect(rect.x, rect.y, BOX_OUTLINE_WIDTH, rect.height), borderColor);
			EditorGUI.DrawRect(new Rect(rect.xMax - BOX_OUTLINE_WIDTH, rect.y, BOX_OUTLINE_WIDTH, rect.height), borderColor);
		}
	}
}
