using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Acest script este atasat unui obiect care se afla sub nivel
    // Este responsabil pentru distrugerea oricarui obiect care a cazut de pe nivel
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
            Destroy(collision.gameObject);
    }
}
