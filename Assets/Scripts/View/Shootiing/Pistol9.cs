using System.Collections;
using UnityEngine;

public class Pistol9 : Weapon
{   
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsReloading)
            TryFire();

        if (Input.GetKeyDown(KeyCode.R) && !IsReloading)
            StartCoroutine(Reload());
    }

    public override void Shoot(float bulletsInClip)
    {
        BulletsInClip = bulletsInClip;

        Vector3 targetPoint = CalculateTargetPoint();
        Vector3 direction = CalculateDirection(false, targetPoint);

        Bullet bullet = Instantiate(Bullet, BulletSpawner.position, Quaternion.identity);
        bullet.Init(direction, ShootForce);
    }

    public override IEnumerator Reload()
    {
        IsReloading = true;

        yield return new WaitForSeconds(ReloadTime);

        BulletsInClip = Clips;
        TryReload(BulletsInClip);
        IsReloading = false;
    }
}
