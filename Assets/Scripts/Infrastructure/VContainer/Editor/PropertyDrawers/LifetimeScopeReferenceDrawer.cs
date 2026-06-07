using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Infrastructure.VContainer.Types;
using UnityEditor;
using UnityEngine;
using VContainer.Unity;

namespace ProjectB.Infrastructure.VContainer.Editor.PropertyDrawers
{
	// 모든 어셈블리에 존재하는 LifetimeScope를 상속받은 타입들을
	// 드롭다운 메뉴로 보여주고, LifetimeScopeReference.TypeName 필드에 선택된 타입의 FullName을 저장하는 커스텀 프로퍼티 드로워
	
	// 코드 패턴은 VContainer의 ParentReferencePropertyDrawer를 참고하였음!

	[CustomPropertyDrawer(typeof(LifetimeScopeReference))]
	public class LifetimeScopeReferenceDrawer : PropertyDrawer
	{
		static string[] GetAllTypeNames()
		{
			// LifetimeScope를 상속받은 타입들을 찾아서 드롭다운 메뉴로 보여줌

			return new List<string> { "None" }
				.Concat(
					TypeCache.GetTypesDerivedFrom<LifetimeScope>() // (참고: TypeCache는 모든 어셈블리에 있는 타입을 포함함)
					.Where(x => !x.IsAbstract) // 추상 클래스는 제외하여 탐색
					.Select(type => type.FullName) // 드롭다운 메뉴에는 FullName으로 보여주도록 함
					) 
				.ToArray();
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string[] typeNames = GetAllTypeNames();

			SerializedProperty typeNameProp = property.FindPropertyRelative("_typeName");

			string currentTypeName = typeNameProp.stringValue;
			
			// 현재 저장된 타입(currentTypeName)을 typeNames 배열에서 찾음
			int currentIndex = Array.IndexOf(typeNames, currentTypeName);
			
			// stringValue가 typeNames에 없으면 첫번째 요소인 "None"으로 설정
			if (currentIndex < 0)
			{
				currentIndex = 0;
			}
			
			EditorGUI.BeginProperty(position, label, property);
			
			// typeNames 배열(string[])을 GUIContent 배열로 변환
			GUIContent[] displayOptions = typeNames.Select(name => new GUIContent(name)).ToArray();
			
			// **실제로 드롭다운을 그리는 위치**
			// 실제 Inspector에서 선택된 index를 받아옴
			int selectedIndex = EditorGUI.Popup(position, label, currentIndex, displayOptions);

			// Property에 실제 값 이름을 저장
			if (selectedIndex != currentIndex) // 선택이 변경된 경우에만 업데이트
			{
				typeNameProp.stringValue = typeNames[selectedIndex];
			}
			
			EditorGUI.EndProperty();
		}
	}

}