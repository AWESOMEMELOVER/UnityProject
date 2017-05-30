using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	protected virtual void OnRabbitHit(HeroRabit rabit){
	}
	void OnTriggerEnter2D(Collider2D collider){
		HeroRabit rabit = collider.GetComponent<HeroRabit> ();
		if (rabit != null) {
			this.OnRabbitHit (rabit);
		}
	}

	public void CollectedHide(){
		Destroy (this.gameObject);
	}
}
