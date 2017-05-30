using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb :Collectable {
	protected override void OnRabbitHit (HeroRabit rabit)
	{
		if (rabit.isLeveledUp) {
			rabit.levelDown ();
		}else{
		LevelController.current.onRabitDeath (rabit);
	}
		this.CollectedHide ();


}
}
