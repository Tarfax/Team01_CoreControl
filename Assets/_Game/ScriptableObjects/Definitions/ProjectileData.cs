using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileName", menuName = "ScriptableObjects/Projectile Definition")]
public class ProjectileData : ScriptableObject {

    public ProjectileType ProjectileType;

    [SerializeField] public AudioSource[] EnemyShootSounds;

    [Header("AI Settings")]
    [SerializeField] public Behaviour AIProjectileSettings;

    [Header("Player Settings")]
    [SerializeField] public Behaviour PlayerProjectileSettings;

    [Serializable]
    public struct Behaviour {
        public GameObject ProjectileVisual;

        public LayerMask Target;
        [Range(1, 5)] public int ProjectileDamage;
        [Range(1f, 35f)] public float ProjectileSpeed;
        [Range(1f, 35f)] public float DistanceUntilDestroyed;
    }

}
