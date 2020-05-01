using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightScript : MonoBehaviour
{   
    public GameObject triggerBox;
    public Animator fog;
    public GameObject boss;
    public AudioClip musicClip;

    // When the player walks through the ArrowSign -> BossFight starts
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {   
            // Change Soundtrack from Normal to BossFight
            GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = musicClip;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();

            // Block camera on player
            GameObject.Find("Main Camera").SendMessage("toggleFight", true);

            // Stop skeleton spawner
            GameObject.Find("Spawner").SendMessage("ToggleEnabled", false);

            // Start the Fog effect
            fog.SetBool("TriggerCeata", true);

            // Instantiate the Boss
            Instantiate(boss, new Vector3(130.05F, 0.64F, 0.3F), Quaternion.identity);

            // Destroy Boss Scene trigger & this script because it is no need to call it again
            Destroy(triggerBox);
            Destroy(this);
        }
    
    }
}
