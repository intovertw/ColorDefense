using UnityEngine;

public class playerBlue : player
{
    public GameObject bulletPrefab;
    protected override void shoot()
    {
        base.shoot();
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
