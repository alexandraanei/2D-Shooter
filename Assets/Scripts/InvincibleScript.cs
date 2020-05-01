using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleScript : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cand playerul atinge power-up ul i se dau 10 sec de invincibilitate si se distruge acest obiect din scena
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<CC>().invincible = true;
            player.GetComponent<CC>().startInvincibility = Time.time;
            Destroy(this.gameObject);
        }
    }
}
