using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public static class TagList {

	public static TaggedDebug[] tags;

	public static void Log(string tag, string log) {
		foreach(TaggedDebug td in tags) {
			if (td.TAG == tag) {
				if (td.active) {
					Debug.Log(tag + ": " + log);
				}
				
				return;
			}
		}
		Debug.Log(tag + ": " + log);
	}

	public static void AddTag() {
		System.Array.Resize(ref tags, tags.Length+1);

	}

	public static void RemoveTag() {
		System.Array.Resize(ref tags, tags.Length-1);

	}

	public static void DeleteTag(int i) {
		for(int j=i+1; j<tags.Length; j++) {
			tags[j-1] = tags[j];
		}
		System.Array.Resize(ref tags, tags.Length-1);

	}
}
