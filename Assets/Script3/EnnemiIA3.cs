﻿using UnityEngine;
using System.Collections;

public class EnnemiIA3 : MonoBehaviour {
	private GameObject ennemi;
	private GameObject player;
	private Vector2 speed = new Vector2(5, 5);
	private bool versRight;
	public bool modePoursuite;
	private Vector2 movement;
	private int ScoreValue=1;
	private float fireRate=1;
	private float nextFire=0;
	public GameObject shot2;
	public Transform ShotSpawn;
	private GameObject Player;
	private GameController3 gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController=gameControllerObject.GetComponent<GameController3>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
		ennemi = GameObject.FindGameObjectWithTag ("Ennemi_niv3");
		player = GameObject.FindGameObjectWithTag ("Player");
		Player = GameObject.Find ("Heros");

		versRight = false;
	}
	
	// Deplacement des ennemis
	void Update () { 
		if (transform.position.x - Player.transform.position.x > 0) {
			movement = new Vector2 (
				-speed.x,
				0);
			if (Time.time > nextFire && transform.position.x - Player.transform.position.x < 6.5) {
				Vector3 vector = new Vector3 (gameObject.transform.position.x - 2, gameObject.transform.position.y, 0);
				nextFire = Time.time + fireRate;
				Instantiate (shot2, vector, ShotSpawn.rotation);
			}
		} else {
			movement = new Vector2 (
				speed.x,
				0);
		}

	}


	
	
	void FixedUpdate()
	{
		// 5 - Déplacement
		//GetComponent<Rigidbody2D>().velocity = movement;

		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Bolt")) {
				gameController.AddScore(ScoreValue);
				Destroy (col.gameObject);
				Destroy (gameObject);
			}
			
	}

}