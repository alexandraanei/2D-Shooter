using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCadere : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    //Se muta tepusa direct in jos
    void Update()
    {
        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x = transform.position.x;
        newPosition.y += -0.1F;
        newPosition.z = -0.5F;
        transform.position = newPosition;
    }


    //Aplica 30 puncde de dauna playerului daca il loveste
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<CC>().DamageTaken(20);

        }

    }

}
