using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Acest script este atasat unui obiect care se afla sub nivel
    //Este responsabil pentru distrugerea oricarui obiect care a cazut de pe nivel
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(collision.gameObject);
    }
}
