using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

	protected override void OnRabbitHit (HeroRabit rabit)
	{
		LevelController.current.addCoin (1);
		this.CollectedHide ();
	}


}
