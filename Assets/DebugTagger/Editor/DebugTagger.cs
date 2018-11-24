using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DebugTagger : EditorWindow {
	public static DebugTagger window;

	TaggedDebug[] tags;


	[MenuItem("Window/Debug Tagger")]
	static void Init() {
		window = (DebugTagger)EditorWindow.GetWindow(typeof(DebugTagger));
		window.Show();
	}

	void OnGUI() {
		ScriptableObject target = this;
		SerializedObject so = new SerializedObject(target);
		GUILayout.Label("Debug Tags", EditorStyles.boldLabel);
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Show Logs");
		EditorGUILayout.LabelField("Log Tag");
		EditorGUILayout.EndHorizontal();
 
		TagList.tags = tags;

		if (TagList.tags == null) {
			TagList.tags = new TaggedDebug[0];
		}
		for(int i=0; i<TagList.tags.Length; i++) {
			TagRow(i);
		}
		
		AddRemoveButtons();
		VisibilityButtons();

		tags = TagList.tags;

		
	}

	void TagRow(int i) {
		EditorGUILayout.BeginHorizontal();
		if (TagList.tags[i] == null) {
			TagList.tags[i] = new TaggedDebug();
		}
		TagList.tags[i].active = EditorGUILayout.Toggle(TagList.tags[i].active);
		TagList.tags[i].TAG = EditorGUILayout.TextField(TagList.tags[i].TAG, TagLayout());
		
		if(GUILayout.Button("X", DeleteLayout())) {
			TagList.DeleteTag(i);
		}
		EditorGUILayout.EndHorizontal();
	}

	void AddRemoveButtons() {
		if(GUILayout.Button("+")) {
			TagList.AddTag();
		}
		if(GUILayout.Button("-")) {
			TagList.RemoveTag();
		}
	}

	void VisibilityButtons() {
		EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button("Show All")) {
			foreach(TaggedDebug td in TagList.tags) {
				td.active = true;
			}
		}
		if(GUILayout.Button("Hide All")) {
			foreach(TaggedDebug td in TagList.tags) {
				td.active = false;
			}
		}
		EditorGUILayout.EndHorizontal();
	}

	GUILayoutOption[] TagLayout() {
		return null;// new GUILayoutOption[]{ GUILayout.Width(200)};
	}

	GUILayoutOption[] ToggleLayout() {
		return null;//new GUILayoutOption[]{ GUILayout.Width(EditorGUIUtility.singleLineHeight)};
	}
	GUILayoutOption[] DeleteLayout() {
		return new GUILayoutOption[]{ GUILayout.Width(EditorGUIUtility.singleLineHeight+3)};
	}

	

}
