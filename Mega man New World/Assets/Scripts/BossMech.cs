using UnityEngine;
using System.Collections;

public class BossMech : MonoBehaviour {

    public GameObject Bbullet;
    public bool CanShoot;
    public GameObject BbulletSpawn;
    public int speed;
	
	
	void Update () {

        if (CanShoot)
        {
            InvokeRepeating("Shoot", 1f, 1f);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * speed;
	}

    void Shoot()
    {
        Instantiate(Bbullet, BbulletSpawn.transform.position, Quaternion.identity);
    }
}
