using UnityEngine;

public class playerRed : player
{
    public GameObject bulletPrefab;
    protected override void shoot()
    {
        base.shoot();
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
