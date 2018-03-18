using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this line is added. we need it for the Text type.
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	//this makes a variable called text of the type Text:
	public Text text;
	//public allows it to be viewed and changed in Unity
	//Text is a type
	//text is the variable name. It could be a different word.


	// Use this for initialization
	void Start () {
		text.text = "Hello World.";
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{text.text = "Space key pressed.";}
	}
}

//this script alone won't run in Unity until...
//in Unity inspector, find the "Text Controller (Script)"
//it should have the name of your C# code in the Script block
//but the Text block will be "None"
//drag the Text file from the Hierarchy list onto that square
//that will link your C# script to the text block.

//fyi -- errors in MonoDevelop show as red text. No squiggly lines.