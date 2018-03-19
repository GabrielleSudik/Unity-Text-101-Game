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
	private enum States {cell, sheets_0, mirror, lock_0, cell_mirror, hall_0, 
		sheets_1, lock_1, stairs_0, closet_0, floor_0, stairs_1, closet_1, hall_1, 
		stairs_2, hall_2, courtyard, gate
		};

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

		//note to self: you originally used (eg) States.cell and state_cell
		//but during refactoring, you removed all the "state_" from the names
		//of the methods, and therefore, from this list.
		//don't confuse, eg, States.mirror of the enum list with
		//the mirror() that is a method.
		//personally, I liked the old way of writing the code better. it avoided confusion.
		if (myState == States.cell) {
			cell ();
		} else if (myState == States.sheets_0) {
			sheets_0 ();
		} else if (myState == States.lock_0) {
			lock_0 ();
		} else if (myState == States.mirror) {
			mirror ();
		} else if (myState == States.cell_mirror) {
			cell_mirror();
		} else if (myState == States.hall_0){
			hall_0();
		} else if (myState == States.sheets_1){
			sheets_1();
		} else if (myState == States.lock_1){
			lock_1();
		}else if (myState == States.stairs_0){
			stairs_0();
		} else if (myState == States.closet_0){
			closet_0();
		} else if (myState == States.floor_0){
			floor_0();
		} 
		//		else if (myState == States.stairs_1){
//			stairs_1();
		//		} else if (myState == States.closet_1){
//			closet_1();
//		} 
		else if (myState == States.lock_1){
			hall_1();
		} 
		//		else if (myState == States.hall_2){
//			hall_2();
		//		} else if (myState == States.hall_2){
//			stairs_2();
		//		} else if (myState == States.courtyard){
//			courtyard();
		//		} else if (myState == States.courtyard){
//			gate();
//		}

	}

	//you're starting your own states here.
	void cell ()
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

	void sheets_0 ()
	{
		text.text = "These sheets are threadbare and dirty. " +
		"Literally, and as a metaphor for your life these days. " +
		"They are pretty useless.\n\n" +
		"Press R to return to roaming around your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 

	}

	void lock_0 ()
	{
		text.text = "The door is locked. Fortunately, being " +
		"ancient, it looks like you could pick it if you had " +
		"something long and pointy.\n\n" +
		"Press R to return to roaming around your cell."; 
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		} 

	}

	void mirror ()
	{
		text.text = "Your mirror is dim and dirty. " +
		"It's also barely attached to the wall. " +
		"You pry it loose with your hands. It falls and shatters, " +
		"and one of the pieces is long and slim. You take it.\n\n" +
		"Press R to return to roaming around your cell ";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		} 

	}

	void cell_mirror ()
	{
		text.text = "You are still in your dingy prison cell, " +
		"but now you are holding a shard of broken mirror. \n\n" +
		"Press L to check the lock. " +
		"Press S to inspect the sheets.";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_1;
		} 
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_1;
		}

	}

	void sheets_1 ()
	{
		text.text = "These sheets are still threadbare and dirty. " +
		"In a fit of rage, you use the mirror shard to rip them to shreds. " +
		"They are now even more useless.\n\n" +
		"Press R to return to roaming around your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		} 

	}


	void lock_1 ()
	{
		text.text = "You check the lock, then insert the " +
		"long shard of mirror, wiggling it until you hear a click. " +
		"The door unlocks!\n\n" +
		"Press H to step into the hall outside your cell.";
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.hall_0;
		} 

	}


	void hall_0 ()
	{
		text.text = "You are in the hall outside of your cell. There are some " +
		"stairs here, a closet door, and the floor is littered with... well, " +
		"litter.\n\n" +
		"Press S to go up the stairs. Press C to open the closet. " +
		"Press L to look through the litter.";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_0;
		} 
		else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.closet_0;
		} 
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.floor_0;
		} 

	}

	void stairs_0 ()
	{
		text.text = "You start to climb the stairs, but the " +
		"sound of guards' voices makes you turn back.\n\n" +
		"Press H to return to the hall.";
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.hall_0;
		} 

	}

	void closet_0 ()
	{
		text.text = "You turn the closet handle but it is locked. " +
		"You notice a tiny keyhole. Perhaps if you had something tiny?\n\n" +
		"Press H to return to the hall.";
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.hall_0;
		} 

	}

	void floor_0 ()
	{
		text.text = "You quietly rummage through the litter on the floor. " +
		"Your fingers touch on a bobby pin (in a Turkish prison!) " +
		"and you pick it up.\n\n" +
		"Press H to return to the hall.";
		if (Input.GetKeyDown (KeyCode.H)) {
			myState = States.hall_1;
		} 

	}

	void hall_1 ()
	{
		text.text = "You are back in the hall. The stairs and the closet " +
		"are as you left them. The litter is not worth searching again.\n\n" +
		"Press S to go up the stairs. Press C to open the closet.";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.stairs_1;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.closet_1;
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