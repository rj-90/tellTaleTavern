﻿using UnityEngine;
using System.Collections;
using Fungus;
public class FameSystem : MonoBehaviour {

//for now fame system gets modified based on whatyou buy \
	public static FameSystem _instance;

	public enum TavernState { fancypants, high, mid, low, trash}
	public TavernState tavernSatte;

	public int value;

	//singlton pattern incase we wanted to move it across scenes / might do the same with the player manager 
	public void Awake(){
		tavernSatte = TavernState.mid;
//		Debug.Log("string value is "+ 	tavernSatte.ToString());
/*
		if(!_instance){
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else 
			Destroy(gameObject);

	}*/}


	public void Update(){
//		Debug.Log("the bar's status us "+ this.tavernSatte.ToString());
	}
	/// <summary>
	/// Change the state of the tavern.
	/// </summary>
	/// <param name="value">increase/decrease teh value to affect the state of the bar .</param>
	public void ChangeStateBare(int _value){

			this.value += _value;
			setBarStatus(this.value);
		

	}

	void setBarStatus(int val){
		// not using a switch here - faster if value is a range/ not index 
//		Debug.Log("updated value of bar");
			if( val >= 201 ){//greater tahn 100 points - wow  A garade
				tavernSatte = TavernState.fancypants;

			}else if ( val <201 && val >= 121){ //between 80-100 b grade bar 

				tavernSatte = TavernState.high;

			}else if ( val < 121 && val >= 81){ 
				tavernSatte = TavernState.mid;

			} else  if (val >= 21){

				tavernSatte = TavernState.low;
			}
			else {
				tavernSatte = TavernState.trash;
	

			}

}

	public string getStateInString(){

			string temp = 	tavernSatte.ToString();
			return temp;

	}

	//public Fungus.StringData ReturnString(){

//		 Fungus.StringData  data = "high";
//		 return tavernSatte.ToString();
//}
}