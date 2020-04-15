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
    private float horizontal;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer && player != null)
        {
            float dist = MoveToPlayer();
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

    }


    //Se stabileste directia in care trebuie sa se deplaseza scheletul
    //Si apoi se muta
    float MoveToPlayer()
    {
        float dist = Mathf.Abs(player.transform.position.x - transform.position.x);

        
        if(dist < 1)
        {
            if (Mathf.Abs(player.transform.position.y - transform.position.y) > 0.4F)
                return 3;
            animator.speed = 0;
            return 1;
        }

        //moveDirection = transform.position;
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

        //Mathf.Abs(moveDirection.x)
        animator.speed = 2;
        return Mathf.Abs(player.transform.position.x - transform.position.x);
    }
}
