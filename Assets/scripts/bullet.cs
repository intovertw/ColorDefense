using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
