using UnityEngine;

[CreateAssetMenu(fileName = "VFX_", menuName = ("VFX/VFX_Data"))]
public class ParticleData : ScriptableObject {
    public ParticleEffectType ParticleEffectType;
    public GameObject ParticleEffectVisual;
    public float ParticleDuration;
}
