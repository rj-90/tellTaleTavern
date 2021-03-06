﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
///main achivment system 

/// <summary>
/// new classs for achivmenet managment 
/// </summary>
public class AchivmentsTest : MonoBehaviour {


	private static AchivmentsTest _instance;
	public static AchivmentsTest Instance { get { return _instance; } }

	public static Dictionary < int ,AchivSystem> achivmentsTest = new Dictionary < int ,AchivSystem>();
	public Text AchivText;
	public GameObject achivPanel; 
	public DisplayAchiv laoder;
	//used to add new achivments

	public AudioSource achSound;


	public void Awake(){

		DontDestroyOnLoad(gameObject);

		//myAchivments = FindObjectOfType<AchivmentsTest>();

		if (_instance != null && _instance != this)
        {
        	Debug.Log("game objecy destroyed");
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

		
		//TODO: ADD SINGLTON PATTERN TO MAKE IT APPEAR AT THE BENING BUT SO MANY DEPENDENCIES ...AGH 
		//data base option or load and save states using player prefrs ofr something 
		//or scriptable obkects 
	
		achivPanel = GameObject.Find("achivPanel");
		achivPanel.SetActive(false);
		//AchivSystem temp = new AchivSystem("Game stared~" ,true, "you began the game");
		//achivmentsTest.Add(temp);
		InitilizeAchivments();

		laoder = FindObjectOfType<DisplayAchiv>();//finds the achiv loeader
		//loadDictionary();

		addEarnedAchiv(000);
		StartCoroutine(displayLastAciv(achivmentsTest[000], 6));

		//foreach(AchivSystem i in achivmentsTest){
		//	Debug.Log("added item "+ i.titile);
		
		achSound = GetComponent<AudioSource>();

	}
	public void Update(){

		if(Input.GetKeyDown(KeyCode.Space)){
			Debug.Log("adislay achivments");
			displayAchivmentStats();
			Debug.Log(PlayerPrefs.GetString("1"));
		//achivmentsTest.Add(temp);


		}
		if(Input.GetKeyDown(KeyCode.A)){
			Debug.Log("achivemtn a added");
			addEarnedAchiv(005);
		//	GetAchivments();
		//achivmentsTest.Add(temp);


		}
	}

	//can be used and called from fungus 
	/*public  void AddAchicv(string _Titile, string _dis, bool _lock= true ){

			Debug.Log("adding new item to achivments");
			AchivSystem temp = new AchivSystem(_Titile, _lock , _dis);
			Debug.Log(temp.titile);
		
			StartCoroutine(displayLastAciv(temp, 5));
		}*/
	
	//can be used and called from fungus 
	//to unlock the achiv 
	public void addEarnedAchiv(int ID){
		if(achivmentsTest[ID].unlockAchiv()){

			StartCoroutine(displayLastAciv(achivmentsTest[ID], 10));
			
	}

	}

	//}}

	public IEnumerator displayLastAciv (AchivSystem a, float time){
		achSound.Play();
		achivPanel.SetActive(true);
		AchivText.enabled = true;
		AchivText.text = a.titile + "Achievement unlocked! " + a.discription ;
		Debug.Log("text feild should have "+ a.titile);
   	 	yield return new WaitForSeconds(time);
		AchivText.enabled = false;
		achivPanel.SetActive(false);
		
					
	}


	//add all achivments here - achivment name 0 titile - keep it at false here - discription - points worth 
	public void InitilizeAchivments(){
		Debug.Log("initilizing achivments");
		achivmentsTest.Add(000, new AchivSystem("Adventure began!~" ,false, "you began the game",10));
		achivmentsTest.Add(001, new AchivSystem("Game stared~" ,false, "you began the game",10));
		achivmentsTest.Add(002, new AchivSystem("Damn those Dukes!~" ,false, "you're enemies with the Dukes",10));
		achivmentsTest.Add(003, new AchivSystem("Here come the Dukes~" ,false, "you're friends with the Dukes",10));
		achivmentsTest.Add(004, new AchivSystem("Have a drink!" ,false, "Entered the Brewery",10));
		achivmentsTest.Add(005, new AchivSystem("cishetmuch?~" ,false, "tell Wilma to marry the Prince",10));
		achivmentsTest.Add(006, new AchivSystem("Game stared~" ,false, "you began the game",10));
		achivmentsTest.Add(007, new AchivSystem("Friends in high places~" ,false, "become Royal Brewmaster",10));
		achivmentsTest.Add(008, new AchivSystem("Drop the bass~" ,false, "tavern is turned into a discotheque",10));
		achivmentsTest.Add(009, new AchivSystem("What's in a name?~" ,false, "Get the Aurora rose",10));
		achivmentsTest.Add(010, new AchivSystem("Goin' to the chapel, aaaaand we're...~" ,false, "give the Aurora rose to the Dukes",10));
		achivmentsTest.Add(011, new AchivSystem("Wedding Crasher~" ,false, "keep the Aurora rose for yourself",10));
		achivmentsTest.Add(012, new AchivSystem("Excuse me while I kiss this guy~" ,false, "Dukes marry the Prince",10));
		achivmentsTest.Add(333, new AchivSystem("Make it rain, but not really ouch coins hurt" ,false, "Acquire 3000 gold.",10));
        achivmentsTest.Add(013, new AchivSystem("Viking Punks, F*ck off~", false, "finish game with shitty bar", 10));
        achivmentsTest.Add(014, new AchivSystem("Sticky...~", false, "finish game with a middle-low bar", 10));
        achivmentsTest.Add(015, new AchivSystem("You're the averagest~", false, "finish game with a normal bar", 10));
        achivmentsTest.Add(016, new AchivSystem("Scotch and Cigars", false, "finish game with a middle-high bar", 10));
        achivmentsTest.Add(017, new AchivSystem("Monocles and Cognac~", false, "finish game with a fancy bar", 10));
        achivmentsTest.Add(018, new AchivSystem("F*ck off~", false, "made a character so angry they left", 10));
        achivmentsTest.Add(019, new AchivSystem("The Loveable Thief", false, "Convince Sasha to return the necklace", 10));
        achivmentsTest.Add(020, new AchivSystem("Queer as Folkheroes~", false, "tell William to marry the Prince", 10));
        achivmentsTest.Add(021, new AchivSystem("AYYYYYEEEEE", false, "Sell 69 items.", 10));
        achivmentsTest.Add(022, new AchivSystem("Blaze it", false, "Have 420 coins", 10));
        achivmentsTest.Add(023, new AchivSystem("Master of the House", false, "Talk to all 4 characters in the game.", 10));
        achivmentsTest.Add(024, new AchivSystem("The Kids will Love it!", false, "You helped El get the snapdragon peas.", 10));
        achivmentsTest.Add(025, new AchivSystem("Clifford the Big Red Plant thing", false, "you began the game", 10));
        achivmentsTest.Add(026, new AchivSystem("Antventure", false, "The Dukes go on El's ant adventure", 10));
        achivmentsTest.Add(027, new AchivSystem("Immoral", false, "Sasha has stolen Quinn's necklace.", 10));
        achivmentsTest.Add(028, new AchivSystem("Cat companion", false, "you became friends with Ellington", 10));
        achivmentsTest.Add(029, new AchivSystem("Steal your heart", false, "you became friends with Sasha", 10));
        achivmentsTest.Add(030, new AchivSystem("Friendship is disassembling systems of oppression", false, "you became friends with Lady Quinn", 10));
        achivmentsTest.Add(031, new AchivSystem("A kitty scorned", false, "you became enemies with Ellington", 10));
        achivmentsTest.Add(032, new AchivSystem("You have f*cked up now", false, "you became enemies with Sasha", 10));
        achivmentsTest.Add(033, new AchivSystem("Hell hath no fury", false, "you became enemies with Lady Quinn", 10));
        achivmentsTest.Add(034, new AchivSystem("Queerbaiting", false, "Sasha and Lady Quinn start a romance", 10));
        achivmentsTest.Add(035, new AchivSystem("Rebel without a cause", false, "Lady Quinn leaves to become a thief", 10));
        achivmentsTest.Add(036, new AchivSystem("One trick pony", false, "Only talked to one character the whole time.", 10));
        achivmentsTest.Add(037, new AchivSystem("Suspiciously Neutral", false, "finished with at least one character at friendly=0", 10));
        achivmentsTest.Add(038, new AchivSystem("Sloppy Bar Tender~", false, "Offered patron a beverage you didn’t have in stock", 10));
        achivmentsTest.Add(039, new AchivSystem("Fake Lillies~", false, "You found out about the fake lillies", 10));
        achivmentsTest.Add(040, new AchivSystem("Hooligan corner? More like politically organized youths corner~", false, "You see the evolution of your rabble rousing youth from hooligans in to disciplined political operatives.", 10));
        achivmentsTest.Add(041, new AchivSystem("Nasty Expose~", false, "Your behavior prompted someone to write a damning expose about you.", 10));
        achivmentsTest.Add(042, new AchivSystem("Quite sexist aren't we?", false, "Think about your life, think about your choices. Perhaps telling outspoken women that they are troubblemakers isn't your best move.", 10));
        achivmentsTest.Add(043, new AchivSystem("Most Wonderful Time of the Year", false, "The festival was a great sucess.", 10));
        achivmentsTest.Add(044, new AchivSystem("Where Have all the Lillies Gone~", false, "Festival fails. #wherehaveallthelilliesgone?", 10));
        achivmentsTest.Add(045, new AchivSystem("Gnome Revolution~", false, "The gnome strike is a sucess.", 10));
        achivmentsTest.Add(046, new AchivSystem("Evil Uncle Moneybags", false, "You called in the Uncle.", 10));
        achivmentsTest.Add(047, new AchivSystem("Call the Mayor~", false, "Look, this is the mayor's job. I don't want no trouble in my place.", 10));
        achivmentsTest.Add(048, new AchivSystem("Multi-beving~", false, "Welcome to Bevmo home of the Bev.", 10));
        achivmentsTest.Add(049, new AchivSystem("Let Them Eat All the Cakes~", false, "Bought one of each bread", 10));
        achivmentsTest.Add(050, new AchivSystem("Meat, 'Murica ~", false, "First trip to the butcher", 10));
        achivmentsTest.Add(051, new AchivSystem("F*ck Off~", false, "Made a character so angry they left", 10));
        achivmentsTest.Add(052, new AchivSystem("Finished a Game~", false, "you finished", 10));
        achivmentsTest.Add(053, new AchivSystem("Lone Wolf~", false, "You didn't get into this business to talk to people. You got into this business to take invetory, wipe down coutners and get people drunk.", 10));
        achivmentsTest.Add(054, new AchivSystem("Pauper", false, "Lose ALLLL your money", 10));
		achivmentsTest.Add(055, new AchivSystem("Beautiful carbs", false, "visit the bakery", 10));
		achivmentsTest.Add(056, new AchivSystem("But I don't like spam!", false, "visit butcher", 10));
        achivmentsTest.Add(057, new AchivSystem("What's new pussycat?", false, "Talked to Ellington", 10));
        achivmentsTest.Add(058, new AchivSystem("Getting to know you~", false, "Learned more about Ellington's past", 10));
        achivmentsTest.Add(059, new AchivSystem("I knew you were trouble when you walked in.", false, "Talked to Sasha", 10));
        achivmentsTest.Add(060, new AchivSystem("Blame it on the alcohol", false, "Got a fairy drunk so you could get tips, you monster.", 10));
        achivmentsTest.Add(061, new AchivSystem("Captain of the Loveboat", false, "Get flirty with Sasha", 10));
        achivmentsTest.Add(062, new AchivSystem("Social Butterfly", false, "Talked to everyone day 1", 10));
        achivmentsTest.Add(063, new AchivSystem("One Friend", false, "Look at you! You talked to your first customer!", 10));
        achivmentsTest.Add(064, new AchivSystem("Deflation", false, "You couldn't even pretend to be impressed?", 10));
        achivmentsTest.Add(065, new AchivSystem("Hot and cold", false, "A little inconsistent.", 10));
        achivmentsTest.Add(066, new AchivSystem("This Provincial Life", false, "We've got an adventure seeker on our hands.", 10));
        achivmentsTest.Add(067, new AchivSystem("Eat the Rich!", false, "... even if they are your family.", 10));
        achivmentsTest.Add(068, new AchivSystem("Don't want no Trouble in my Place", false, "First time in your bar", 10));
    }


    //for dedbugging - woot works!
    public void displayAchivmentStats(){

		foreach( var  item in achivmentsTest){
			
			Debug.Log("ID"+ item.Key+" VALUE"+item.Value.unlocked);
		}
	}


	/// <summary>
	/// saving data across scene
	/// </summary>
	///this is not realistic at all idealy we will have them saved onto a json or xml file and parse from there
	/// this is just for proof of concept for now - will update later with time
	public static void SaveData(){

	//	foreach( var  item in achivmentsTest){
		int Lockedcount = 0;
		int UnlockedCOUNT = 0;
		foreach ( var item in achivmentsTest){
			if(item.Value.unlocked){

				//Debug.Log("ID"+ item.Key+" VALUE has been unlocked ");
				UnlockedCOUNT++;
				string achiv = item.Value.titile;
				//PlayerPrefs.SetString( item.Key.ToString() , achiv);
				PlayerPrefs.SetString( UnlockedCOUNT.ToString() , achiv);
				//PlayerPrefs.SetString( UnlockedCOUNT.ToString() , achiv);	
				Debug.Log("UnlockedCOUNT" + UnlockedCOUNT);
				Debug.Log(PlayerPrefs.GetString(UnlockedCOUNT.ToString()) + " SAVED");
			}
			if(! item.Value.unlocked){
				Lockedcount ++;
				//Debug.Log("ID"+ item.Key+" VALUE IS LOCKED ");
			}

			//	Debug.Log("ID"+ item.Key+" VALUE"+item.Value.unlocked);
		}	PlayerPrefs.SetInt("Lockedcount", Lockedcount);
			PlayerPrefs.SetInt("UnlockedCOUNT", UnlockedCOUNT);
			Debug.Log(PlayerPrefs.GetInt("Lockedcount"));
			PlayerPrefs.Save();


//		foreach ( int key in achivmentsTest.Keys){
//
//			Debug.Log(" for key "+ key.ToString() + " has the avhimcent " + achivmentsTest.Values.ToString());
//		}
	}

/// <summary>
/// retrives and gets the achivments 
/// </summary>
/// <returns>The save date.</returns>



	public Dictionary <string, string> GetAchivmentsAsString(){

		int Lockedcount = 0;
		int UnlockedCOUNT = 0;

		Dictionary <string, string> tempUnlokcedAchiv = new Dictionary <string, string>();;
		 
		foreach ( var item in achivmentsTest){

			if(item.Value.unlocked){
				UnlockedCOUNT++;
				tempUnlokcedAchiv.Add(item.Value.titile, item.Value.discription);

		}
			if(! item.Value.unlocked){
				Lockedcount ++;
				//Debug.Log("ID"+ item.Key+" VALUE IS LOCKED ");
			}

		}

		foreach ( var item in tempUnlokcedAchiv){

			Debug.Log(item.Key.ToString() + " titile was unlocked and had a discrioton of "+ item.Value.ToString() + "you have unlocked : " + UnlockedCOUNT); 
		}
		return 	tempUnlokcedAchiv;


		
	}



	/// <summary>
	/// returns a dictionary of ubnlokced achivmenrs
	/// </summary>
	/// <returns>The achivments as achiv.</returns>

	///loads them back in and checks them aout gain  - prob with this it will play an aniamtion 
	public void loadDictionary(){

		if( laoder!= null){
		foreach( var i in laoder.MovingAchiv) {
				//unlockAchiv check 
			//	addEarnedAchiv(i.Key);
				achivmentsTest[i.Key].unlockAchiv();
			Debug.Log(" readding already earned achiv "+ i.Key);
		}}

			
	}



	public Dictionary <int , AchivSystem> GetAchivmentsAsAchiv(){

		int Lockedcount = 0;
		int UnlockedCOUNT = 0;

		Dictionary <int, AchivSystem> tempUnlokcedAchiv = new Dictionary <int, AchivSystem>();;

		foreach ( var item in achivmentsTest){

			if(item.Value.unlocked){
				UnlockedCOUNT++;
				tempUnlokcedAchiv.Add(item.Key, item.Value);

		}
			if(! item.Value.unlocked){
				Lockedcount ++;
				//Debug.Log("ID"+ item.Key+" VALUE IS LOCKED ");
			}

		}

		foreach ( var item in tempUnlokcedAchiv){

			Debug.Log(item.Key.ToString() + " titile was unlocked and had a discrioton of "+ item.Value.ToString() + "you have unlocked : " + UnlockedCOUNT); 
		}
		return 	tempUnlokcedAchiv;


		
	}


}
