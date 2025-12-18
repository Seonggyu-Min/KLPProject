using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    [SerializeField] private PunchParticle _punchVFXPrefab;
    private ObjectPool<PunchParticle> _punchVFXPool;

    [SerializeField] private float _waitTime = 0.2f;
    [SerializeField] private int _waitCount = 5;

    private Coroutine _co;
    private WaitForSeconds _wait;


    private void Awake()
    {
        SingletonInit();
        SetPool();
        CacheObjects();
    }

    private void OnDisable()
    {
        if (_co != null)
        {
            StopCoroutine(_co);
            _co = null;
        }
    }


    public void SpawnPunch(Transform attachPoint)
    {
        if (!attachPoint) return;

        if (_co != null)
        {
            StopCoroutine(_co);
            _co = null;
        }
        _co = StartCoroutine(SpawnPunchContinuous(attachPoint));
    }


    private void SetPool()
    {
        _punchVFXPool = new ObjectPool<PunchParticle>(transform, _punchVFXPrefab, 100);
    }

    private void CacheObjects()
    {
        _wait = new WaitForSeconds(_waitTime);
    }

    private IEnumerator SpawnPunchContinuous(Transform attachPoint)
    {
        for (int i = 0; i < _waitCount; i++)
        {
            var punchVFX = _punchVFXPool.PopPool();
            punchVFX.transform.SetPositionAndRotation(attachPoint.position, attachPoint.rotation);
            yield return _wait;
        }

        // 테스트용 코드
        //for (int i = 0; i < _waitCount; i++)
        //{
        //    var punchVFX = _punchVFXPool.PopPool();
        //    punchVFX.transform.SetPositionAndRotation(attachPoint.position, attachPoint.rotation);
        //}
        //yield return _wait;
    }
}
