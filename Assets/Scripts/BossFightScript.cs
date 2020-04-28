using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightScript : MonoBehaviour
{   
    public GameObject triggerBox;
    public Animator ceata;
    public GameObject vampir;
    public AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //functia se apeleaza deficare data cand un obiect intra in acest trigger
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //verificam daca obiectul care trece prin trigger este playerul pentru a initia lupta cu boss-ul
        if(collider.gameObject.tag == "Player")
        {   
            //Urmatoarele linii de cod schimba melodia de fundal cu cea specifica luptei cu bossu
            GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = musicClip;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();

            //Se apeleaza functia toggleFight pentru a bloca camera
            GameObject.Find("Main Camera").SendMessage("toggleFight", true);
            //Se apeleaza ToggleEnabled pentru a opri spawnerul de scheleti
            GameObject.Find("Spawner").SendMessage("ToggleEnabled", false);
            //Se porneste o animatie cetei
            ceata.SetBool("TriggerCeata", true);
            //Se instantiaza boss-ul
            Instantiate(vampir, new Vector3(130.05F, 0.64F, 0.3F), Quaternion.identity);

            //Se distruge triggerul dar si acest script din scena deoarece nu mai este nevoie de el
            Destroy(triggerBox);
            Destroy(this);
        }
    
    }
}
