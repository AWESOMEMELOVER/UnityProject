using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : MonoBehaviour {

	Rigidbody2D orcBody;
	SpriteRenderer spriteRenderer;
	public float speed=1;
	public float distance=5;
	Vector3 pointA;
	Vector3 pointB;
	bool collidedWithRabit;

		protected enum Mode
		{
			GoToA,
			GoToB,
			Attack,
			Die
		}
	Mode mode;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		orcBody = this.GetComponent<Rigidbody2D> ();
		pointA = this.transform.position;
		pointB.x = pointA.x + distance;
		mode = Mode.GoToB;

	}

	void FixedUpdate(){
		Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
		Vector3 my_pos = this.transform.position;
		float value = this.getDirection ();
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = orcBody.velocity;
			vel.x = value * speed;
			orcBody.velocity = vel;
		}
		if (value < 0)
			spriteRenderer.flipX = false;
		else
			spriteRenderer.flipX = true;

		if (mode == Mode.Die)
			StartCoroutine (die ());
	}

	float getDirection(){
		Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
		Vector3 my_pos = this.transform.position;
		if (mode == Mode.Die)
			return 0;

		//triggered
		if (rabit_pos.x > Mathf.Min (pointA.x, pointB.x) && rabit_pos.x < Mathf.Max (pointA.x, pointB.x)) {
			mode = Mode.Attack;
		}	

		if (mode == Mode.Attack) {
			if (my_pos.x < rabit_pos.x)
				return 1;
			else
				return-1;
		}

		if (mode == Mode.GoToB) {
			if (my_pos.x >= pointB.x)
				this.mode = Mode.GoToA;
		}
		else if (mode == Mode.GoToA) {
			if (my_pos.x <= pointA.x)
				this.mode = Mode.GoToB;
		}

		if (this.mode == Mode.GoToB) {
			if (my_pos.x <= pointB.x)
				return 1;
			else
				return -1;
		}else if (this.mode == Mode.GoToA){
			if (my_pos.x <= pointA.x)
				return 1;
			else
				return -1;
		}

		return 0;
	}






	void OnCollisionEnter2D(Collision2D col){
		Vector3 rabit_pos = HeroRabit.lastRabit.transform.position;
		Vector3 my_pos = this.transform.position;
		if (Mathf.Abs (rabit_pos.y - my_pos.y) > 1.0f) {
			mode = Mode.Die;
		}

	}

	void OnTriggerEnter2D(Collider2D coll){
		StartCoroutine (die ());
	}
	private IEnumerator die(){
		if (mode == Mode.Die) {
			this.GetComponent<BoxCollider2D> ().isTrigger = true;
			yield return new WaitForSeconds (1.0f);
			Destroy (this.gameObject);
		}
	}
}
