using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRed : enemy
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("red"))
        {
            Destroy(gameObject);
        }
    }
}
