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

	//here's an enum to keep track of states:
	//the states come from the game design document
	private enum States {cell, sheets_0, mirror, lock_0, cell_mirror, hall, sheets_1,
		lock_1, freedom};

		//YOU ARE TAKING A BREAK. might need to add another state here for the hall
		//or just check the GDD for what comes next

	//create a variable to store (or change status of) each state:
	private States myState;

	// Use this for initialization
	void Start () {
		text.text = "Ugh, you're in prison You're innocent, of course.";
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		//that line will keep showing in the console
		//think it's good for tracking where you are in the code.
		//it'll change depending on what your game is doing

		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0) {
			state_sheets_0 ();
		} else if (myState == States.lock_0) {
			state_lock_0 ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror();
		} else if (myState == States.hall){
			state_hall();
		}
	}

	//you're starting your own states here.
	void state_cell ()
	{
		text.text = "You are in a prison cell and you want to escape. " +
		"Especially because it's a Turkish prison, " +
		"just like that one in Midnight Express. " +
		"There are some dirty sheets on the bed, a mirror " +
		"on the wall, and a locked door. Pretty spartan.\n\n" +
		"Press S to view sheets. Press M to view mirror. " +
		"Press L to view lock.";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}

	}

	void state_sheets_0 ()
	{
		text.text = "These sheets are threadbare and dirty. " +
		"Literally, and as a metaphor for your life these days. " +
		"They are pretty useless.\n\n" +
		"Press R to return to roaming around your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 

	}

	void state_lock_0 ()
	{
		text.text = "The door is locked. Fortunately, being " +
		"ancient, it looks like you could pick it if you had " +
		"something long and pointy.\n\n" +
		"Press R to return to roaming around your cell."; 
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 

	}

	void state_mirror ()
	{
		text.text = "Your mirror is dim and dirty. " +
		"It's also barely attached to the wall. " +
		"You could pry it loose if you tug hard.\n\n" +
		"Press R to return to roaming around your cell. " +
		"Press T to tug the mirror off the wall.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 
		else if (Input.GetKeyDown(KeyCode.T)){
			myState = States.cell_mirror;
		}

	}

	void state_cell_mirror ()
	{
		text.text = "You pry the mirror off the wall then slam it on " +
		"the floor. It shatters into several pieces, one of which " +
		"is long and slim. You use the piece to pick the door's lock\n\n" +
		"Press H to step into the hall outside your cell.";
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.hall;
		} 

	}

	void state_hall ()
	{
		text.text = "You are in the hall outside of your cell.\n\n" +
		"You will finish this later.";
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.hall;
		} 

	}


}




//this script alone won't run in Unity until...
//in Unity inspector, find the "Text Controller (Script)"
//it should have the name of your C# code in the Script block
//but the Text block will be "None"
//drag the Text file from the Hierarchy list onto that square
//that will link your C# script to the text block.

//fyi -- some errors in MonoDevelop show as red text. 
//squiggly lines seem to show character or other errors.
//BUT MonoDevelop doesn't seem to catch as many errors as VS