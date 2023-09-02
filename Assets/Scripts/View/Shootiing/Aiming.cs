using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour
{
    [SerializeField] private Image _aimImage;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _aimImage.enabled = false;
            _animator.SetBool("isAiming", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            _aimImage.enabled = true;
            _animator.SetBool("isAiming", false);
        }
    }
}
