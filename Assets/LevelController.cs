using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	Vector3 startingPosition;

	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}

	public void onRabitDeath(HeroRabit rabit) {
		rabit.transform.position = this.startingPosition;
	}

	public static LevelController current;
	void Awake(){
		current = this;
	}

	public void addCoin(int coins){
		Debug.Log (coins);
	}
	public void addFruit(int coins){
		Debug.Log (coins);
	}


}
