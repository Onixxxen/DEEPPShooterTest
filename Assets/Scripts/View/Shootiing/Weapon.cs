using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IShooter, IReloader, IInitializer
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected Transform BulletSpawner;
    [SerializeField] protected Camera PlayerCamera;
    [SerializeField] protected float Clips;
    [SerializeField] protected float ShootForce;
    [SerializeField] protected float Spread;
    [SerializeField] protected float ReloadTime;

    protected float BulletsInClip;
    protected bool IsReloading = false;

    public event Action<float, float> Initialized;
    public event Action<float> TryFired;
    public event Action<float> Reloaded;

    public virtual void Init()
    {
        BulletsInClip = Clips;
        Initialized?.Invoke(Clips, BulletsInClip);
    }

    public virtual void Shoot(float bulletsInClip)
    {
    }

    public virtual void TryFire()
    {
        TryFired?.Invoke(BulletsInClip);
    }    

    public virtual void TryReload(float BulletsInClip)
    {
        Reloaded?.Invoke(BulletsInClip);
    }

    public virtual void StartReload()
    {
        StartCoroutine(Reload());
    }

    public abstract IEnumerator Reload();

    protected Vector3 CalculateTargetPoint()
    {
        Ray raycast = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(raycast, out hit))
            return hit.point;
        else
            return raycast.GetPoint(75);
    }

    protected Vector3 CalculateDirection(bool isWithSpread, Vector3 targetPoint)
    {
        Vector3 directionWithoutSpread = targetPoint - BulletSpawner.transform.position;

        float xSpread = UnityEngine.Random.Range(-Spread, Spread);
        float ySpread = UnityEngine.Random.Range(-Spread, Spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(xSpread, ySpread, 0);

        if (isWithSpread)
            return directionWithSpread;
        else
            return directionWithoutSpread;
    }
}

public interface IShooter
{   
    public event Action<float> TryFired;    

    public void Shoot(float bulletsInClip);
    public void TryFire();
}

public interface IReloader
{
    public event Action<float> Reloaded;

    public void TryReload(float BulletsInClip);
    public void StartReload();
    public IEnumerator Reload();
}

public interface IInitializer
{
    public void Init();
}
