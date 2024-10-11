using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGreen : enemy
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("green"))
        {
            Destroy(gameObject);
        }
    }
}
