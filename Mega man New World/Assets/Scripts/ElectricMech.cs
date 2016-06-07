using UnityEngine;
using System.Collections;

public class ElectricMech : MonoBehaviour {

    public int speed;
    PlayerMech Player;
	
	void Start () {
        Player = GameObject.Find("Player").GetComponent<PlayerMech>();

        if (Player.faceRight == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
        }
        if (Player.faceRight == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * speed;
        }
    }
}
