using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject[] player;
    public float moveSpeed = 1f, step;

    // Update is called once per frame
    void FixedUpdate()
    {
        step = moveSpeed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player[gamemanager.colorSelected].transform.position, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            gamemanager.playerAlive = false;
        }
    }
}
