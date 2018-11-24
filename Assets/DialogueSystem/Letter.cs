using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter {
	public string letter;
	public bool bold = false, italic = false;
	public int ?size = null;
	public string color = null;
	
	public Letter(string letter, string color, int size, bool bold, bool italic) {
		this.letter = letter;
		this.color = color;
		this.size = size;
		this.bold = bold;
		this.italic = italic;
	}

	public override string ToString() {
		return OpenTags() + letter + CloseTags();
	}

	string OpenTags() {
		return (bold?"<b>":"")+(italic?"<i>":"")+(color!=null?"<color="+color+">":"")+(size!=null&&size!=0?"<size="+size+">":"");
	}
	string CloseTags() {
		return (size!=null&&size!=0?"</size>":"") + (color!=null?"<color>":"") + (italic?"</i>":"") + (bold?"<b>":"");
	}
}
