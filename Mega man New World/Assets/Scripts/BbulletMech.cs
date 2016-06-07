using UnityEngine;
using System.Collections;

public class BbulletMech : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * speed;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
