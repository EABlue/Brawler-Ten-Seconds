using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public bool touching;
    public float MovementSpeed;
    float gravity;
    public float gravityMultiplier;

	// Use this for initialization
	void Start () {
        touching = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 MovementVector  = new Vector2(0, 0);

        if (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))) {
            if (Input.GetKey(KeyCode.A)) {
                MovementVector.x = -1 * MovementSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                MovementVector.x = MovementSpeed;
            }
        }

        if (touching) {
            MovementVector.y = 0;
        } else {
            if (!(gravity >= 1)) {
                gravity += Time.deltaTime;
            }
            MovementVector.y = gravity * gravityMultiplier;
        }

        transform.Translate(MovementVector);
	}
}