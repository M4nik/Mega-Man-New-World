using UnityEngine;
using System.Collections;

public class CameraMech : MonoBehaviour {

    Transform PlayerTransform;
    public bool PlayerDestroy = false;
    public GameObject Player;
	
	void Start () {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	
	void Update () { 
        if(Player == null)
        {
            PlayerDestroy = true;
        }
        if (!PlayerDestroy)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        }
	}
}
