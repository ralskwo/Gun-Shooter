using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObjects/WeaponSO", order = 1)]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject HitVFXPrefab;
    public bool IsAutomatic = false;
    public bool IsZoomable = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = .3f;
    public int MagazineSize = 12;
    public AudioClip FireSoundClip;
}
