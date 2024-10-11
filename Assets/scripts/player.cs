using UnityEngine;

public class player : MonoBehaviour
{
    float range = 5f, rateOfFire;
    public LayerMask enemyMask;
    public Animator animator;

    private Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
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
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 1, 0.0f);
            transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));

            rateOfFire += Time.fixedDeltaTime;
            if (rateOfFire >= 1f)
            {
                Debug.Log("attempting to shoot");
                animator.SetTrigger("isShoot");
                shoot();
                rateOfFire = 0f;
            }
        }
    }

    protected bool CheckTargetIsInRange()
    {
        Debug.Log(Vector2.Distance(target.position, transform.position) <= range);
        return Vector2.Distance(target.position, transform.position) <= range;
    }

    protected void FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
            Debug.Log("I FOUND SOMEONE!!!");
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    protected virtual void shoot()
    {
        Debug.Log("CHECK YOSELF FOOL");
        //where all the shooting happens
    }
}
