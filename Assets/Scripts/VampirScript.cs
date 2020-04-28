using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampirScript : MonoBehaviour
{   
    private float lastBull;
    public float intervalBull;
    public GameObject bull;
    public AudioClip musicClip;
    public float intervalUrlet;
    private float lastUrlet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator waiter()
    {   
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {   
        //La un interval de timp sa va reda sunetul boss-ului
        if(Time.time - lastUrlet > intervalUrlet)
        {
            GetComponent<AudioSource>().Play();
            lastUrlet = Time.time;

           intervalUrlet = intervalBull - 0.5F; 
        }


        //La un interval setat de timp se va instantia taurul
        if(Time.time - lastBull > intervalBull)
           { 
                GetComponent<AudioSource>().Play();
                
                StartCoroutine(waiter());

                Instantiate(bull, new Vector3(transform.position.x,-2F, -1.5F), Quaternion.identity);
            
                lastBull = Time.time;

                if(intervalBull > 1.5F)
                    intervalBull -= 0.2F;

                
           }



    
    }


}
