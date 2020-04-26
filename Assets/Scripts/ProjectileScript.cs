using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Se stabileste durata de viata a proiectilului
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Daca proiectilul loveste ceva acesta se ditruge
    //Daca proiectulul loveste un inamic ii aplica daune
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.SendMessage("UpdateHealth", 15);
            Destroy(this.gameObject);
        }
        else
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
