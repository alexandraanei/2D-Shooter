using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float scorAdaugat;
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
            // GameObject.Find("GameManager").GetComponent<GameManagerScript>().SendMessage("updateScor", scorAdaugat);
            Destroy(this.gameObject);
        }
    }

    void UpdateHealth(int Damage)
    {
        health -= Damage;
        //Debug.Log(health);
    }
}
