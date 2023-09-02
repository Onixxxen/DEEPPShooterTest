using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour, IInitializer
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _clipsText;
    [SerializeField] private TMP_Text _bulletInClipText;

    public event Action Initialize;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Initialize?.Invoke();
    }

    public void SetHealthData(float health)
    {
        _healthText.text = $"{health}";
    }

    public void SetWeaponData(float clips, float bulletInClip)
    {
        _clipsText.text = $"{clips}";
        _bulletInClipText.text = $"{bulletInClip}";
    }

    public void ChangeBulletInClip(float bulletInClip)
    {
        _bulletInClipText.text = $"{bulletInClip}";
    }

    public void ChangeHealth(float health)
    {
        _healthText.text = $"{health}";
    }    
}
