using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bloodEffect;

    private int _divisorValue = 20;

    public void PlayEffect(float value) 
    {
        _bloodEffect.Stop();

        var effect = _bloodEffect.main;
        effect.startSize = value/_divisorValue;

        _bloodEffect.Play(); 
    }
}
