using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    Rigidbody2D MovingRBD;
    public int speed;
	
	void Start () {
        MovingRBD = GetComponent<Rigidbody2D>();
        MovingRBD.velocity = new Vector2(1, 0) * speed;
    }
	
	
	void Update () { 
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground1")
        {
            MovingRBD.velocity = new Vector2(-1, 0) * speed;
        }
    }
}
