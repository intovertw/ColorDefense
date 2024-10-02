using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class player : MonoBehaviour
{
    public Material[] playerColors; 
    public GameObject bulletPrefab;
    public float range = 5f, rateOfFire = 1f;
    public LayerMask enemyMask;
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            rateOfFire += Time.fixedDeltaTime;
            if (rateOfFire >= 10f)
            {
                Debug.Log("attempting to shoot");
                shoot();
                rateOfFire = 0f;
            }
        }
    }

    bool CheckTargetIsInRange()
    {
        Debug.Log(Vector2.Distance(target.position, transform.position) <= range);
        return Vector2.Distance(target.position, transform.position) <= range;
    }

    void FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
            Debug.Log("I FOUND SOMEONE!!!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void shoot()
    {
        Debug.Log("CHECK YOSELF FOOL");
        //where all the shooting happens
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
