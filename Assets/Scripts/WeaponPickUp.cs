using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    //Cand playerul atinge torta i se seteaza arma si se distruge acest obiect din scena
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("SetWeapon", true);
            Destroy(this.gameObject);
        }
    }
}
