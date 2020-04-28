using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    // private GameObject camera;
    private GameObject player;
    public float delay;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //Se stabileste durata de viata a obiectului
        startTime = Time.time;
        // camera = GameObject.Find("Main Camera");
        Destroy(this.gameObject, 2F);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //se asteapta un timp stabilit pentru a avertiza playerul
        if(startTime + delay > Time.time)
            return;

        //Apoi fantoma se deplaseaza spre pozitia initiala a playerului
        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x += offsetX;
        newPosition.y += offsetY;
        newPosition.z = -0.5F;
        transform.position = newPosition;
        
    }


    //Daca loveste playerul i se aplica daunele
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<CC>().DamageTaken(30);
        }
    }
}
