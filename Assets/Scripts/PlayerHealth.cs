using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int HP;
    public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        HPText.text = "HP: " + HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP < 1)
        {   
            GameObject.Find("GameManager").SendMessage("PlayerDied");
            Destroy(GameObject.Find("Player"));
        }
    }

    
    void UpdateHealth(int Damage)
    {   
        HP -= Damage;
        if(HP < 0)
            HP = 0;
        HPText.text = "HP: " + HP;
        Debug.Log(HP);
    }
}
