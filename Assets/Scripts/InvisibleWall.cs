using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    GameObject enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject;

            collision.gameObject.GetComponent<SpriteRenderer>().flipX = !collision.gameObject.GetComponent<SpriteRenderer>().flipX;
            if(enemy) enemy.GetComponent<MeleeSkeleton>().movement = enemy.GetComponent<MeleeSkeleton>().MoveIdle;

        }

        if (collision.gameObject.tag == "Player")
        {
            if (enemy)
            {
                enemy.GetComponent<MeleeSkeleton>().movement = enemy.GetComponent<MeleeSkeleton>().MoveToPlayer;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (enemy)
            {
                enemy.GetComponent<MeleeSkeleton>().movement = enemy.GetComponent<MeleeSkeleton>().MoveToPlayer;
            }

        }
    }
}
