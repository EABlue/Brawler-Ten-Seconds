using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Counter() {
        yield return new WaitForSeconds(10f);
        foreach (GameObject Ob in GameObject.FindGameObjectsWithTag("Player")) {
            Ob.GetComponent<PlayerScript>().ChangeCharacter;
        }
    }
}
