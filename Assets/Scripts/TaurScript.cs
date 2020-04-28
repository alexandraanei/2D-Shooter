using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaurScript : MonoBehaviour
{
    public float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        //Se stabileste durata de viata
        Destroy(this.gameObject, 4F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //se deplaseaza taurul spre stanga
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x += offsetX;
        newPosition.z = -0.5F;
        transform.position = newPosition;
        
    }

    //Se aplica daune playerului daca e cazul
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SendMessage("UpdateHealth", 50);
          //  Destroy(collision.gameObject);
        }



}

}
