using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchParticle : PooledObject<PunchParticle>
{
    [SerializeField] private ParticleSystem _particleSystem;
    private bool _isReturned = false;

    private void Awake()
    {
        if (!_particleSystem)
        {
            if (!TryGetComponent(out _particleSystem))
            {
                Debug.LogError("ParticleSystem 컴포넌트를 찾을 수 없습니다.");
            }
        }

        if (_particleSystem)
        {
            var main = _particleSystem.main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }
    }

    private void OnEnable()
    {
        _isReturned = false;
        _particleSystem.Play();
    }


    private void OnParticleSystemStopped()
    {
        if (_isReturned) return;

        _isReturned = true;
        ReturnPool();
    }
}
