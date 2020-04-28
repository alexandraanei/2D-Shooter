using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCadere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Se muta tepusa direct in jos
    void Update()
    {
        Vector3 newPosition = new Vector3();
        newPosition = transform.position;
        newPosition.x = transform.position.x;
        newPosition.y += -0.2F;
        newPosition.z = -0.5F;
        transform.position = newPosition;
    }


    //Aplica 30 puncde de dauna playerului daca il loveste
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SendMessage("UpdateHealth", 30);
          
        }

    }

}
