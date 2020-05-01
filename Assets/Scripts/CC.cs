using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CC : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float airMove;
    private bool hasWeapon;
    public GameObject projectile;
    private float horizontal;
    private bool grounded;
    private Vector2 facing;
    private float lastShot;
    public float timeBetweenShots;
    public float projectileSpeed;
    public int health;
    public Slider healthBar;
    public bool invincible;
    private GameObject HPColor;
    public float startInvincibility;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        hasWeapon = false;
        facing = Vector2.right;
        lastShot = Time.time;
        invincible = false;
        HPColor = GameObject.Find("ImageHP");
    }

    private void Update()
    {
        //La fiecare frame se verifica daca playerul doreste sa sara, acesta trebuie sa atinga pamantul 
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //Aplicam forta necesara sariturii playerului
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            //Marcam ca playerul este in aer acum
            grounded = false;
        }

        //La fiecare frame se verifica daca playerul doreste sa traga, acesta trebuie sa aiba arma si sa nu fii tras prea curand
        if (Input.GetKeyDown(KeyCode.X) && hasWeapon && Time.time - lastShot > timeBetweenShots )
        {   
            //Actualizam cand s-a tras ultima data si instantiem bila de foc cu care se trage
            //bila de foc este orientada in functie de directia playerului si i se adauga o viteza setata
            lastShot = Time.time;
            GameObject go = Instantiate(projectile) as GameObject;
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);
            go.transform.position = transform.position + new Vector3(facing.x, facing.y, 0) / 3;
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.velocity = facing * projectileSpeed;
        }

        UpdateHealth();

        if (health < 1)
        {
            GameObject.Find("GameManager").SendMessage("PlayerDied");
            Destroy(GameObject.Find("Player"));
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().loseMessage.gameObject.SetActive(true);
        }

        //setam culoarea healthbar-ului in functie de statusul de invincibilitate
        if (invincible==true)
        {
            HPColor.GetComponent<Image>().color = Color.cyan;
        }
        else
        {
            HPColor.GetComponent<Image>().color = new Color(185f / 255f, 3f / 255f, 3f / 255f); ;
        }

        //invincibilitatea dureaza 10 secunde
        if (Time.time - startInvincibility > 10)
        {
            invincible = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (true)
        {
            //Aflam in ce directie se doreste deplasarea playerului
            horizontal = Input.GetAxis("Horizontal") * speed;
            horizontal *= Time.deltaTime;
        }

        //daca deplasarea este spre dreapta se orienteaza sprite-ul corespunzator si se tine minte directia in care a fost mutat playerul ultima data
        if (horizontal > 0)
        {
            facing = Vector2.right;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        if (horizontal < 0)
        {
            facing = Vector2.left;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        //se aplica deplasarea asupra playerului
        transform.Translate(horizontal, 0.0f , 0.0f);
    }


    //cand playerul atinge un obliect cu taggul ground semnalam ca acesta poate sarii din nou
    // cand playerul atinge DeathBox-ul moare
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Death")
        {
            health = 0;
        }
    }


    void SetWeapon(bool w)
    {
        hasWeapon = w;
    }

    void UpdateHealth()
    {
        healthBar.value = health;
    }

    public void DamageTaken(int damage)
    {
        //nu se aplica damage decat daca e cu plus din powerup sau playerul nu e invincibil
        if ((damage > 0 && invincible==false) || damage < 0)
        {
            health -= damage;
        }
            
        //pentru cazul cand ia power-up
        if (health >= 100) 
        {
            health = 100;
        }
    }



}
