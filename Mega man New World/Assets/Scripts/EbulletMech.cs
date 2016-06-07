using UnityEngine;
using System.Collections;

public class EbulletMech : MonoBehaviour {

    public float speed;
    EnemyMech Enemy;
	
	void Start () {
        Enemy = GameObject.Find("Enemy").GetComponent<EnemyMech>();

        if (Enemy.faceRight == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
        }
        if (Enemy.faceRight == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * speed;
        }
    }
	
	
	void Update () {
	
	}
}
