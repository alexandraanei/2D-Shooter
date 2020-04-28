using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject player;
    private GameObject bg;
    public GameObject calugar;
    public GameObject ghost;
    private AudioSource muzica;
    private float lastSpawned;
    private float lastSpawnedGhost;
    public float timeBetweenSpawns;
    public float timeBetweenSpawnsGhost;
    private bool bossFight;

    // Start is called before the first frame update
    void Start()
    {   
        //retinem obiectul player
        player = GameObject.Find("Player");
        //retinem fundalul
        bg = GameObject.Find("Background");
        //retinem valoarea timpului curent
        lastSpawned = Time.time;
    }

    void Update()
    {
        //retinem componenta responsabila cu muzica de fundal
        muzica = GetComponent<AudioSource>();
        muzica.volume = 0.5F;

        if (bossFight == false && player != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = player.transform.position.x;
            transform.position = newPosition;

            //Iar backgroundul va urmarii camera
            newPosition = bg.transform.position;
            newPosition.x = player.transform.position.x;
            bg.transform.position = newPosition;

        }


        //Daca a trecut timpul dintre instantierile calugarului
        //Instantiem din nou calugarul in functie de pozitia camerei
        if (Time.time - lastSpawned > timeBetweenSpawns)
        {
            Instantiate(calugar, new Vector3(transform.position.x - 14, Random.Range(1, 4) * 1.20F - 2.5F, -1.5F), Quaternion.identity);
            lastSpawned = Time.time;
        }

        //Daca a trecut timpul dintre instantierile fantomei dar playerul este pe pamant
        //Instantiem din nou fantoma in functie pe pozitia playerului
        if(player!=null)
        if (Time.time - lastSpawnedGhost > timeBetweenSpawnsGhost && player.transform.position.y <= -1.89F)
        {
            Instantiate(ghost, new Vector3(player.transform.position.x + 3.5F, 3.5F, -1.5F), Quaternion.identity);
            lastSpawnedGhost = Time.time;
        }
    }

    //Folosim aceasta functie pentru a bloca cadrul la lupta cu boss-ul
    void toggleFight(bool toggler)
    {

        bossFight = toggler;

    }

    //Pentru schimbare volumului cu ajutorul sliderului din meniul de optiuni
    public void changeVolume(float newVal)
    {

        muzica.volume = newVal;
    }

}
