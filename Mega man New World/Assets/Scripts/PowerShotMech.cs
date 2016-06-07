using UnityEngine;
using System.Collections;

public class PowerShotMech : MonoBehaviour {

    PlayerMech Player;
    public int speed;
    bool faceRight = true;
	
	void Start () {
        Player = GameObject.Find("Player").GetComponent<PlayerMech>();

        if (Player.faceRight == true)
        {
            if (!faceRight)
            {
                FlipSprite();
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
        }
        if (Player.faceRight == false)
        {
            if (faceRight)
            {
                FlipSprite();
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * speed;
            }
        }
    }
    void FlipSprite()
    {
        faceRight = !faceRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
