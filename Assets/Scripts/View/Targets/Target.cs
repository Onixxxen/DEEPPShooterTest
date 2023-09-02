using System;
using System.Collections;
using UnityEngine;

public abstract class Target : MonoBehaviour, ITarget
{
    [SerializeField] private float _targetLife;

    public event Action<float, bool> Hit;

    private void OnEnable()
    {
        StartCoroutine(DisableTarget());
    }

    public virtual void ActivateTarget(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        gameObject.SetActive(true);
    }    

    public virtual IEnumerator DisableTarget()
    {
        yield return new WaitForSeconds(_targetLife);
        gameObject.SetActive(false);
    }    

    protected void TryHit(float changeHealth, bool isAddHealth)
    {
        Hit?.Invoke(changeHealth, isAddHealth);
    }

    public abstract void TakeHit();
}

public interface ITarget
{
    public void ActivateTarget(Vector3 spawnPoint);
    public void TakeHit();
    public IEnumerator DisableTarget();
}
