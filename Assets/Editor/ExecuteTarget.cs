using UnityEngine;

public class ExecuteTarget {
	public string version;
	public bool overwrite;

	public enum MyType {
		Steak,
		Ramen,
		Hamburg
	}
	public MyType myType;

	public ExecuteTarget () {
		version = "1.0.0";
		overwrite = true;
		myType = MyType.Hamburg;
	}

	public void Execute () {
		Debug.Log("execute! overwrite:" + overwrite + " version:" + version + " type:" + myType);
	}

	public void NeverCollectMethod (string s) {}
}