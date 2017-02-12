using UnityEditor;

namespace Suekko {
	public class SuekkoWindow : EditorWindow {		

		[MenuItem("Window/Suekko/Open")] public static void OpenSuekkoWindow () {
			var window = GetWindow<SuekkoWindow>();
		}



	}
}