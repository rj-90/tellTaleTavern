﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Fungus;
/// <summary>

//TODO:  Have to refactor code - bits and parts are repeated in this class 
/// class is too bulky might seprate tasks later on if time permits (step 1: get it to work :P) 
/// </summary>
public class Item : MonoBehaviour {

//text feilds fot the market 
	public Text Button_text;  public Text txt_stock;
	public Text txt_price;	  public Text txt_textField;
	public Text txt_quantity;
//memeber varibles for ach item 
	public string  titile;			public string discription ;
	public int stock;				public int price;
	public bool isAvailable;		public int toBuy;
//type and quality set up
	public enum quality { high, mid, low}		public quality ThisQuality;

	public enum ItemType {meat, brew, bread}	public ItemType itemType;
//getting the current time system - see awake 
	public TimeSystem dayTime;	
	public int dayUnAvaible;

	public int quantToBuy;
	public int tempGold;
	[SerializeField]
	PlayerAssets playerAsset; 
	FameSystem tavernStat;
	TempStock tmp;
    Color white = Color.white;
	bool mouceEnters = false;

	int tempStock;

	public Button addThisBtn ;
	bool entredToday = false;
	int OldDayTracker = 0;
    public Font openDyslexic;
    public Texture2D whiteFelt;

	//for styling gui later on ( THE BOX FLOAT THING)
	GUIStyle descriptStyle = new GUIStyle();

//initilize setups 
	
	
	void Awake(){

        dayTime = FindObjectOfType<TimeSystem>();
			playerAsset = FindObjectOfType<PlayerAssets>();
			tavernStat = FindObjectOfType<FameSystem>();
			tmp = FindObjectOfType<TempStock>();
			setItemData(ThisQuality);
			addThisBtn = gameObject.GetComponentInChildren<Button>();
			checkAvaiblity(dayUnAvaible);
			setupTextFeilds();
			tempStock = this.stock;



	}

	//after awake - for the box settings 
	void Start(){

		
		descriptStyle.fontSize = 14;
        descriptStyle.alignment = TextAnchor.MiddleCenter;
        descriptStyle.font = openDyslexic;
        descriptStyle.wordWrap = true;
        descriptStyle.normal.background = whiteFelt;
        descriptStyle.padding.left = 3;
        descriptStyle.padding.right = 3;
        descriptStyle.padding.top = 3;
        descriptStyle.padding.bottom = 3;
        descriptStyle.normal.textColor = white;
        /*  style.fixedWidth = 300;
          
          ;*/
    }

    //method to setup text feilds 
    public void setupTextFeilds(){
			Button_text.text = "buy " + this.titile;
			txt_stock.text = "#"+ this.stock.ToString();
			txt_price.text = this.price.ToString()+"gold";
			}


	/// <summary>
	/// updates are just for testing purposes 
	/// </summary>
	void Update(){
		if(Input.GetKeyDown(KeyCode.B)){
				Debug.Log("checking avaibility");
				checkAvaiblity(dayUnAvaible);
				buyItem();

		}
		//have to find a better way 
		if(TempStock.hasBenReset==true){
		Debug.Log("true!");
			clear();
		}

		Debug.Log(this.titile + "  has stock of :"+ stock.ToString() +" and  temp stock of :"+tempStock.ToString());
	}


	//based on the item data set the price and stock - can be played and add a rnd value 
	public  void setItemData(quality qualityValue){

		switch(qualityValue){

		//case quality.high:
		case quality.high:
			this.stock = 10;
			this.price = 300;
			break;
		case quality.mid:
			this.stock = 6;
			this.price = 50;
			break;
		 default :
			this.stock = 10;
			this.price = 10;
			break;
	}

	}

	//just a temp fix 
	public  void checkAvaiblity(int unavaibleDay){
	 // add bool later 
	//	for(int i = 0; i <=unavaibleDay.Length; i ++){

				if(dayTime.day == unavaibleDay){
					//gameObject.SetActive(false);
					ChangeColor(0);
					addThisBtn.interactable = false;
					isAvailable = false;
			
			}
				else {
					//gameObject.SetActive(true);
					isAvailable = true;
					addThisBtn.interactable = true;
					ChangeColor(1);
//					Debug.Log("item is avaible");
				}
		}
		//need to clear quantity 
	//on click add this to temp stock 
	public void AddToTemp(){
		if(this.isAvailable && tempStock>=0){
		tmp.tempList.Add(this);
		}
	}

	public void resetTempStock(){
		this.tempStock = stock;
	}

	public void increaseQuantity(){

		if(this.isAvailable && tempStock>=0){
			quantToBuy = quantToBuy+1;
			tempStock--;
			txt_quantity.text = quantToBuy.ToString();
			txt_stock.text = tempStock.ToString();}
			

	}


	/// <summary>
	///New methods 
	/// </summary>
	public void clear(){
		Debug.Log("clear was called");
		txt_quantity.text = "0";
		quantToBuy = 0;
		txt_stock.text = this.stock.ToString();

	}

	//called evryday
	//ask team on toher methods of doing this - brain hurts!
	void OnEnable(){
		//add a check for end of each day liek a counter to reset it based on day and enabled 
		if(OldDayTracker == dayTime.getDayInInt()){
			OldDayTracker ++; //0 
			reStock();//
			resetTempStock();
			txt_quantity.text = "";
			txt_stock.text = this.stock.ToString();

			if(OldDayTracker >4){
				OldDayTracker = 0; // or simply reset with game over reset all data 
			}
			//entredToday = true;
		//setItemData(ThisQuality);
		}
//	if( MoveToNext.dayChanged)
		//reStock();//add something to check day changed
	}


	public void reStock(){

		switch(ThisQuality){

		//case quality.high:
		case quality.high:
			this.stock = 10;
			break;
		case quality.mid:
			this.stock = 6;
			break;
		 default :
			this.stock = 10;
			break;
	}

	}






		//run this through all items stroed in a list - the remp class ( shopping cart uses thos pne ) 
	public void buyItemNew(){
		checkAvaiblity(dayUnAvaible);

		if(isAvailable && stock>0){

			if(playerAsset.gold >= this.price){
				//add a method to check item quality - if high //increase by high amount on other method 
				updateFame();
				playerAsset.gold -= this.price;
				this.stock-=1 ;
				playerAsset.addItem(this);
				//Debug.Log(" you got the item"+ this.titile);

				if(txt_textField !=null){
					txt_stock.text = stock.ToString();
				}//increase BAR FAME or on player assets page 

			}
		}//	Debug.Log("sorry out of that item");

		} 




	/// <summary>
	/// ///////////////////////////////////////////
	/// </summary>
	///the old one uses this one --- 
		//run this through all items stroed in a list 
	public void buyItem(){
		Debug.Log("entred buy item");
		checkAvaiblity(dayUnAvaible);

		if(isAvailable && stock>0){

			if(playerAsset.gold >= this.price){
				//add a method to check item quality - if high //increase by high amount on other method 
				updateFame();
				playerAsset.gold -= this.price;
				this.stock-=1 ;
				playerAsset.addItem(this);
				Debug.Log(" you got the item"+ this.titile);

				if(txt_textField !=null){
					txt_stock.text = stock.ToString();
					txt_textField.text ="here you go, one "+this.titile+"  \n anything else dear?" ;
				}//increase BAR FAME or on player assets page 

			}
		}else if (isAvailable == false || stock <= 0){
			//GUI.Label(new Rect(10, 10, 100, 20), "Out of stock!");
				if(txt_textField !=null){
				if( isAvailable == false ){
						txt_textField.text ="sorry out of that item Today, try again another day ";
				}

				else if(playerAsset.gold<=8){

						txt_textField.text ="looks you are running short ";

				}}	Debug.Log("sorry out of that item");

		} else {
			if(txt_textField !=null){
						
						txt_textField.text =" looks liek you are short on Gold there";
						}}}



	//enter event for mouce 
	public void setEnter(){
		mouceEnters = true;
	}
	//ecit event for mouce 
	public void setExit(){
		mouceEnters = false;
	}


	//this method updates Fame of the bar based on  item stat
	public void updateFame(){
		switch(ThisQuality){
			case (quality.high):
				tavernStat.ChangeStateBare(30);
				break;
			case (quality.mid):
				tavernStat.ChangeStateBare(0);
				break;
			default:
				if(tavernStat.value > 0){
				tavernStat.ChangeStateBare(-15);
				}
				break;
		}
			
	}
	//unused 
	public void getInput(string input){
		int tempX ;
		bool canConvert = int.TryParse(input, out  tempX);
		if(canConvert){
		this.toBuy = tempX;
		}
		else 
	{
		Debug.LogError("not a number!!");
	}
		Debug.Log("you entred"+ input);
	//	this.toBuy =int.TryParse(input);
	}


	public void ChangeColor(int oFFon){
		ColorBlock tempColor = addThisBtn.colors;
		if(oFFon == 0){
		tempColor.normalColor = Color.red;
		addThisBtn.colors = tempColor;
		}
		else {
			tempColor.normalColor = Color.white;
			addThisBtn.colors = tempColor;

		}
		}
	//TODO: 
		//gui events 
		//this method os not needed ... 
	/*void OnCLick(){
			checkAvaiblity(dayUnAvaible);
			buyItem();
		}*/
	//to draw the box if mouce event is true 
	void OnGUI()
		 {
		if(mouceEnters == true){
				//have to play with these values 
			GUI.Box(new Rect(Screen.width/2 -150 ,Screen.height/2 -100, Screen.width/2, Screen.height/3), this.discription, descriptStyle);
            

				//GUI.Label(new Rect(100,100,200,30),this.discription);
				}
		 }
		 /*
	void OnMouseOver()
		{
	    	_mouseOver = true;
		}
	void OnMouseExit()
		{
	   	 _mouseOver = false;
		}


	void OnEnable(){
			//checkAvaiblity(dayAvaible);
	}
	*/


	}

