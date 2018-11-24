using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DialogueManager : MonoBehaviour {
	public static DialogueManager instance;
	

	public TextMeshProUGUI dialogueText;
	public TextMeshProUGUI nameText;
	public float lettersPerSec=0.06f;

	private Letter[] _txt;
	private int _cursorLocation;
	private Queue<string> _sentences;

	void Start() {
		_sentences = new Queue<string>();
		instance = GetComponent<DialogueManager>();
	}

	public void StartDialogue(Dialogue dialogue) {
		TagList.Log("dialogue", "Starting conversation with "+ dialogue.name);
		_sentences.Clear();
		nameText.text = dialogue.name;
		foreach(string sentence in dialogue.sentences) {
			_sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence() {
		if (_sentences.Count == 0) {
			EndDialogue();
			return;
		}
		string sentence = _sentences.Dequeue();
		dialogueText.text = HideText(sentence);
		StartCoroutine(RevealText());
		TagList.Log("dialogue",sentence);
	}

	void EndDialogue() {
		TagList.Log("dialogue","End of conversation.");
	}

	string HideText(string text) {
		string newString = "";
		_txt = new Letter[text.Length];
		for (int i=0; i<text.Length; i++) {
			_txt[i] = new Letter(text[i].ToString(), null, 0, false, false);
			newString+=_txt[i].ToString();
		}
		return newString;
	}

	public string ChangeMarkup(string tag, string value, string text) {
		return "<" + tag + (value==null || value.Length==0?"":("="+value)) + ">" + text + "</" + tag + ">";
	}

	IEnumerator RevealText() {
		for (int i=0; i<_txt.Length; i++) {
			_cursorLocation=i;
			UpdateText();
			yield return new WaitForSeconds(lettersPerSec);
		}
	}

	void UpdateText(){
		string newString = "";
		for (int i=0; i<_txt.Length; i++) {
			
			newString+=_txt[i].ToString();
			if(i==_cursorLocation) {
				newString+="<color=#00000000>";
			}
		}
		newString+="</color>";
		dialogueText.text = newString;
	}
}
