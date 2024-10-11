using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBlue : enemy
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("blue"))
        {
            Destroy(gameObject);
        }
    }
}
