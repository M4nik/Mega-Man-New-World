using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMechs : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 10;
    public float minSpeed = 3;
    public float origSpeed = 5;

    Rigidbody2D playerRbd;
    public float xMin, xMax, yMin, yMax;

    public int maxHealth;
    public int minHealth;
    public int health;

    public bool power;
    public bool power2;

    public Sprite[] powerupSprites;
    SpriteRenderer sprites;

    bool statRise;
    public bool attack;
    public bool defense;
    public bool speedy;

    float moveHorizontal;
    float moveVertical;

    public int killedEnemies;

    public GameObject PlayerBullet;
    public GameObject explosion;
    public GameObject Missile;
    public GameObject doublepbullet;
    public GameObject pbulletu;
    public GameObject pbrd;
    public GameObject pbld;
    public GameObject dpbu;
    public GameObject pbldu;
    public GameObject pbrdu;
    public GameObject dpbu2;
    public GameObject pbldu2;
    public GameObject pbrdu2;
    public GameObject pbulletu2;
    public GameObject dpbu3;
    public GameObject pbldu3;
    public GameObject pbrdu3;
    public GameObject pbulletu3;
    public GameObject metalBlade;
    public GameObject flameSword;
    public GameObject skullBarrier;

    PlayerStats pts;
    int bombs;

    void Start()
    {
        playerRbd = GetComponent<Rigidbody2D>();
        pts = FindObjectOfType<PlayerStats>();
        power = false;
        power2 = false;
        sprites = GetComponent<SpriteRenderer>();
        health = 3;
    }

    void FixedUpdate()
    {
        moveVertical = Input.GetAxis("Vertical");
        playerRbd.AddForce(speed * moveVertical * -transform.right);

        moveHorizontal = Input.GetAxis("Horizontal");
        playerRbd.AddForce(speed * moveHorizontal * transform.up);
    }

    void Update()
    {
        Clamp();
        shoot();
        statuses();
        death();

        if (speed > maxSpeed)
        {
            speed = 10;
        }

        if (speed < minSpeed)
        {
            speed = 3;
        }

        if (health > maxHealth)
        {
            health = 5;
        }

        if (health < minHealth)
        {
            health = 1;
        }

        if (power)
        {
            powershot();
        }

        if (power2)
        {
            megashot();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "eship")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            health = health - 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ebullet")
        {
            health = health - 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DropBomb")
        {
            bombs++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "attack" && statRise == false)
        {
            statRise = true;
            attack = true;
            Destroy(other.gameObject);
            health = 1;
        }

        if (other.gameObject.tag == "defense" && statRise == false)
        {
            statRise = true;
            defense = true;
            Destroy(other.gameObject);
            health = health + 2;
        }

        if (other.gameObject.tag == "speed" && statRise == false)
        {
            statRise = true;
            speedy = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "attack" && statRise)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "defense" && statRise)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "speed" && statRise)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DropLaser")
        {
            power = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DropLaser2")
        {
            power2 = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DropLaser" && power == true)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DropLaser2" && power2 || power == true)
        {
            Destroy(other.gameObject);
        }

        /*if (other.gameObject.tag == "portal")
        {
            SceneManager.LoadScene()
        }*/
    }

    void Clamp()
    {
        playerRbd.position = new Vector3
            (
            Mathf.Clamp(playerRbd.position.x, xMin, xMax),
            Mathf.Clamp(playerRbd.position.y, yMin, yMax),
            0f
            );
    }

    void death()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1") && pts.currentlvl <= 3 && power == false && power2 == false && attack == false)
        {
            Instantiate(PlayerBullet, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 4 && pts.currentlvl <= 5 && power == false && power2 == false && attack == false)
        {
            Instantiate(pbulletu, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 6 && pts.currentlvl <= 7 && power == false && power2 == false && attack == false)
        {
            Instantiate(pbulletu2, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 8 && power == false && power2 == false && attack == false)
        {
            Instantiate(pbulletu3, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire2") && bombs >= 1)
        {
            Instantiate(Missile, transform.position, Quaternion.identity);
            bombs--;
        }
    }

    void permapower()
    {
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 6 && pts.currentlvl <= 7)
        {
            Instantiate(dpbu2, transform.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 4 && pts.currentlvl <= 5)
        {
            Instantiate(dpbu, transform.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl <= 3)
        {
            Instantiate(doublepbullet, transform.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 8)
        {
            Instantiate(dpbu3, transform.position, Quaternion.identity);
        }
    }

    void powershot()
    {
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 6 && pts.currentlvl <= 7 && power)
        {
            Instantiate(dpbu2, transform.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 4 && pts.currentlvl <= 5 && power)
        {
            Instantiate(dpbu, transform.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl <= 3 && power)
        {
            Instantiate(doublepbullet, transform.position,Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 8 && power)
        {
            Instantiate(dpbu3, transform.position, Quaternion.identity);
        }

        Invoke("powerdown", 20);
    }
    void megashot()
    {
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 8 && power2)
        {
            Instantiate(dpbu3, transform.position, Quaternion.identity);
            Instantiate(pbldu3, transform.position, Quaternion.identity);
            Instantiate(pbrdu3, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 6 && pts.currentlvl <= 7 && power2)
        {
            Instantiate(dpbu2, transform.position, Quaternion.identity);
            Instantiate(pbldu2, transform.position, Quaternion.identity);
            Instantiate(pbrdu2, transform.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl >= 4 && pts.currentlvl <= 5 && power2)
        {
            Instantiate(dpbu, transform.position, Quaternion.identity);
            Instantiate(pbldu, transform.position, Quaternion.identity);
            Instantiate(pbrdu, transform.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1") && pts.currentlvl <= 3 && power2)
        {
            Instantiate(doublepbullet, transform.position, Quaternion.identity);
            Instantiate(pbld, transform.position, Quaternion.identity);
            Instantiate(pbrd, transform.position, Quaternion.identity);
        }

        Invoke("powerdown", 20);
    }

        void powerdown()
    {
        power = false;
        power2 = false;
    }

    void statuses()
    {

        if (statRise == false)
        {
            attack = false;
            speedy = false;
            defense = false;
            sprites.sprite = powerupSprites[0];
        }

        if (Input.GetKeyDown("l") && speedy)
        {
            statRise = false;
            speed = speed - 6;
        }

        if (Input.GetKeyDown("l") && attack)
        {
            statRise = false;
            health = 3;
        }

        if (Input.GetKeyDown("l") && defense)
        {
            statRise = false;
            health = 3;
            speed = speed + 3; 
        }
    

        if  (Input.GetKeyDown("n") && attack == true)
          {
            Instantiate(flameSword, transform.position, Quaternion.identity);
          }

        if (Input.GetKeyDown("n") && defense == true)
        {
            Instantiate(skullBarrier, transform.position, Quaternion.identity);
        }

        if  (Input.GetKeyDown("n") && speedy == true)
        {
            Instantiate(metalBlade, transform.position, Quaternion.identity);
        }

        if (speedy)
        {
            sprites.sprite = powerupSprites[2];
            speed ++;
        }

        if (attack)
        {
            sprites.sprite = powerupSprites[1];
            permapower();  
        }

        if (defense)
        {
            sprites.sprite = powerupSprites[3];
            speed--;
        }

    }

}