using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour {

    public MovementScript Move;
    bool touching;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move.touching = touching;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
    }
}
