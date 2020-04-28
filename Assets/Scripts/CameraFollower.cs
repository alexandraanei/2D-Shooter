using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject player;
    private GameObject bg;
    private AudioSource muzica;

    // Start is called before the first frame update
    void Start()
    {   
        //retinem obiectul player
        player = GameObject.Find("Player");
        //retinem fundalul
        bg = GameObject.Find("Background");
    }

    void Update()
    {
        //retinem componenta responsabila cu muzica de fundal
        muzica = GetComponent<AudioSource>();
        muzica.volume = 0.5F;

        //camera va urmarii jucatorul pe axa Ox
        Vector3 newPosition = transform.position;
        if(player !=null)
            newPosition.x = player.transform.position.x;
            transform.position = newPosition;
        
            //Iar backgroundul va urmarii camera
            newPosition = bg.transform.position;

        if (player != null)
            newPosition.x = player.transform.position.x;
            bg.transform.position = newPosition;
    }

    //Pentru schimbare volumului cu ajutorul sliderului din meniul de optiuni
    public void changeVolume(float newVal)
    {

        muzica.volume = newVal;
    }

}
