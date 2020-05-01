﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float scorAdaugat;
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Acest script este responsabil cu retinerea punctelor de viata 
    //si retinerea punctelor de scor pe care inamicul le va acorda playerului cand este omorat
    void Update()
    {
        if(health <= 0)
        {
            System.Random rnd = new System.Random();
            int nr = rnd.Next(1, 4);

            GameObject.Find("GameManager").GetComponent<GameManagerScript>().SendMessage("AddScore", scorAdaugat);
            

            if (nr == 3)
            {
                Instantiate(powerUp, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }

    void UpdateHealth(int Damage)
    {
        health -= Damage;
        //Debug.Log(health);
    }
}
