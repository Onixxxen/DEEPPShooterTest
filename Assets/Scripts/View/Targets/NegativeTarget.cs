using UnityEngine;

public class NegativeTarget : Target
{
    [SerializeField] private float _removeHealth;

    public override void TakeHit()
    {
        TryHit(_removeHealth, false);
        gameObject.SetActive(false);
    }
}
