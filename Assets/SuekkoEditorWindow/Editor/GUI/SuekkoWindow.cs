using System;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Suekko {
	public class SuekkoWindow : EditorWindow {
		/*
			target type instance.
		*/
		static ExecuteTarget target = new ExecuteTarget();


		[MenuItem("Window/Suekko/Open")] public static void OpenSuekkoWindow () {
			var window = GetWindow<SuekkoWindow>();
			window.titleContent = new GUIContent("TypedWindow");
			window.Setup(target);
			Debug.LogError("target.overwrite:" + target.overwrite);
		}

		private ExecuteTarget instance;

		private void Setup<T> (T target) {
			/*
				パブリックプロパティとかメソッドとかを適当に漁って、それらを適当なボタンにする。
			*/
			var fields = target.GetType().GetFields();// プロパティを漁って、セットできるか。
			foreach (var field in fields) {
				
				var fieldHolder = target.GetType().GetField(field.Name, BindingFlags.Public | BindingFlags.Instance);
				Debug.LogError("field:" + fieldHolder.Name);
				object val = true;

				if (fieldHolder != null) {
					switch (field.FieldType.ToString()) {
						case "System.Boolean": {
							fieldHolder.SetValue(target, (bool)val);
							break;
						}
						case "System.String": {
							// fieldHolder.SetValue(target, (string)val);
							break;
						}
						default: {
							Debug.LogError("property.FieldType.ToString():" + field.FieldType.ToString());
							break;
						}
					}
					
				}
			}
		}

		public T GetTypedInstance<T> () where T : new() {
			return new T();
		}

		/*
			欲しい機能は、
			・ボタンを置く -> 特定のメソッドを実行する -> その実行結果を特殊なコンソールに出す というやつ。
			で、これはロガーと、コンソールビューと、ボタンでできそう。
		*/

		private string myString = "test";
		private bool groupEnabled;
		private bool myBool;
		private float myFloat;
		void OnGUI () {
			/*
				型を与えて、その型がもつパラメータを適当にボタンとかにする。
				んでインスタンス作って、適当なメソッドの数だけボタンを出す。

				というかんじでひとつ。
				ログだけどうしようかな。Debug.Logをかっさらうか。
			*/
			GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
			myString = EditorGUILayout.TextField ("Text Field", myString);

			if (GUILayout.Button("execute")) {
				Log("fmm");
			}

			groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
			myBool = EditorGUILayout.Toggle ("Toggle", myBool);
			myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
			EditorGUILayout.EndToggleGroup ();
		}

		/*
			logger
			なんか勝手にDebug.Logを奪って、かつ内容がこのインスタンスだったらっていう区切りでいい気がする。
		*/
		private void Log (string message) {
			
		}

		private StringBuilder b = new StringBuilder();
	}
}

public class ExecuteTarget {
	public string version;
	public bool overwrite;

	public void Execute () {
		Debug.Log("log!");
	}


}