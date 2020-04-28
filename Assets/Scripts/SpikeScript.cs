using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{   
    public GameObject spike;
    private float lastSpike;
    public float intervalSpike;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Tepusa se instantiaza deasupra cutiei(daca a trecut suficient timp de la ultima instantiere) si ii se seteaza durata de viata
    void Update()
    {
        if(Time.time - lastSpike > intervalSpike)
        {
            GameObject spikeDinamic =   Instantiate(spike, new Vector3(this.transform.position.x, 5, 0.3F), Quaternion.identity);
            Destroy(spikeDinamic, 4F);
            lastSpike = Time.time;

           // intervalUrlet = intervalBull - 0.5F; 
        }
    }
}
