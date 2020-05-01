using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float scorAdaugat;
    public GameObject powerUp;
    public GameObject invinciblepowerUp;

    // If an enemy dies it will spawn an PowerUp: Health Refill (50%) or Invincibility (10s)
    void Update()
    {
        if(health <= 0)
        {
            System.Random rnd = new System.Random();
            int nr = rnd.Next(1, 5);

            GameObject.Find("GameManager").GetComponent<GameManagerScript>().SendMessage("AddScore", scorAdaugat);
            

            if (nr == 3)
            {
                Instantiate(powerUp, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            }

            int nr2 = rnd.Next(1, 9);

            if (nr2 == 6 && nr != 3)
            {
                Instantiate(invinciblepowerUp, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            }

            Destroy(this.gameObject);

        }
    }

    void UpdateHealth(int Damage)
    {
        health -= Damage;
    }
}
