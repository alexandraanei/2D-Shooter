using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private float lastSpawner;
    public float timeBetweenSpawners;
    public GameObject mob;
    public GameObject player;
    private bool SpawnEnabled;

    // Start is called before the first frame update
    void Start()
    {
       SpawnEnabled = true;
    }

    //Se vor instantia scheleti random de-a lungul niveluilui la un interval setat dar nu imediat langa player
    void Update()
    {
        if(Time.time - lastSpawner > timeBetweenSpawners && SpawnEnabled == true )
        {   
            float x = Random.Range(-4, 128);
            float y = 5;

            if(player!=null)
            if(Mathf.Abs(x - player.transform.position.x) > 2)
            {
                Instantiate(mob, new Vector3(x, y, -1.5F), Quaternion.identity);
                lastSpawner = Time.time;
            }
        }

    }

    void ToggleEnabled(bool param)
    {
        SpawnEnabled = param;
    }


}
