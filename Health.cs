﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Die();
        }
	}

    public void TakeDamage (float damage) {
        health -= damage;
    }

    void Die() {
        Destroy(gameObject);
    }
}
