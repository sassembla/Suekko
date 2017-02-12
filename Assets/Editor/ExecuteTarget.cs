using UnityEngine;

public class ExecuteTarget {
	public string version;
	public bool overwrite;

	public ExecuteTarget () {
		version = "1.0.0";
	}

	public void Execute () {
		Debug.Log("log! overwrite:" + overwrite + " version:" + version);
	}

	public void NeverCollectMethod (string s) {}
}