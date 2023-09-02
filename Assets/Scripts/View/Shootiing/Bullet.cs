using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _shootForce;

    public void Init(Vector3 direction, float shootForce)
    {
        _direction = direction;
        _shootForce = shootForce;
    }

    private void Start()
    {
        transform.forward = _direction.normalized;
        GetComponent<Rigidbody>().AddForce(_direction.normalized * _shootForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Target target))
            target.TakeHit();

        Destroy(gameObject);
    }
}
