﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 MoveBy;
	public float Speed = 2f;
	public float WaitTime = 0.5f;

	bool going_to_a = false;
	float time_to_wait = 0;

	Vector3 pointA;
	Vector3 pointB;

	// Use this for initialization
	void Start()
	{
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;
	}

	// Update is called once per frame
	void Update () {
		time_to_wait -= Time.deltaTime;
		if (time_to_wait > 0)
		{
			return;
		}

		Vector3 target;

		if (going_to_a) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}

		Vector3 my_pos = this.transform.position;

		if (isArrived(target, my_pos)) {
			going_to_a = !going_to_a;
			time_to_wait = this.WaitTime;
		} else {
			Vector3 destination = target - my_pos;

			float move = this.Speed + Time.deltaTime;
			float distance = Vector3.Distance(destination, my_pos);

			Vector3 move_vec = destination.normalized * Mathf.Min(move, distance);
			this.transform.position += move_vec;
		}
	}

	bool isArrived(Vector3 pos, Vector3 target)
	{
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}

}
