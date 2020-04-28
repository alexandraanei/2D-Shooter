using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalugarScript : MonoBehaviour
{   
    public float offsetX;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //Setam cat are de trait acest inamic
        Destroy(this.gameObject, 7F);
    }

    void FixedUpdate()
    {
        //Schimbam pozitia inamicului pe axa x cu offsetulx odata per frame al motorului de fizica
        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x += offsetX;
        newPosition.z = -0.5F;
        transform.position = newPosition;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Daca acest inamic intra in coliziune cu playerul i se aplica 45 puncte dauna
        if (collision.gameObject.tag == "Player")
        {
              player.GetComponent<CC>().DamageTaken(45);
        }
    }

}
