﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2(20,0)*speed;
	}
}
