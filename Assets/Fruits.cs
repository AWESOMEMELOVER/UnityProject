using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Collectable {

	protected override void OnRabbitHit (HeroRabit rabit)
	{
		LevelController.current.addFruit (1);
		this.CollectedHide ();
	}
}
