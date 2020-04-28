using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSkeleton : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float timeBetweenActions;
    private Animator animator;
    private GameObject player;
    private Vector3 moveDirection;
    private CharacterController cc;
    private float timer;
    public float horizontal = 1;
    public int damage;
    public delegate void Movement();
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        timer = Time.time;
        movement = MoveToPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer && player != null)
        {
            movement();
        }
    
    }

    //daca exista coliziune intre player si schelet se aplica daune playerului
    //Si se aplica si un efect de tip knockback 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time - timer > timeBetweenActions )
        {   
            float semn = 1;
            if(player.transform.position.x > this.transform.position.x)
                semn = 1;
            else
                semn = -1;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(250 * semn, 0));
            player.GetComponent<CC>().DamageTaken(damage);
            timer = Time.time;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }

    }


    //Se stabileste directia in care trebuie sa se deplaseza scheletul
    //Si apoi se muta
    public void MoveToPlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            horizontal = -1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        if (player.transform.position.x > transform.position.x)
        {
            horizontal = 1;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        horizontal *= speed;
        horizontal *= Time.deltaTime;

        transform.Translate(horizontal, 0.0f, 0.0f);

        animator.speed = 2;
    }

    public void MoveIdle()
    {

        if (GetComponent<SpriteRenderer>().flipX == true) { horizontal = -1; } else { horizontal = 1; }
        horizontal *= speed;
        horizontal *= Time.deltaTime;

        transform.Translate(horizontal, 0.0f, 0.0f);

        animator.speed = 2;
    }
}
