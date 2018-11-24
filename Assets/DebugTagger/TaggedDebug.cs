using UnityEditor;

[System.Serializable]
public class TaggedDebug {
    public string TAG;
    public bool active;

    public TaggedDebug() {
        this.TAG = "";
        this.active = true;
    }

    public TaggedDebug(string TAG) {
        this.TAG = TAG;
        this.active = true;

    }

    public void OnGUI() {
        TAG = EditorGUILayout.TextField("Tag", TAG);
		active = EditorGUILayout.Toggle("Active", active);
    }
}