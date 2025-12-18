using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    #region Fields & Properties & Events

    private IState _currentState;

    private IdleState _idleState;
    private PunchState _punchState;
    private YawnState _yawnState;

    private Animator _animator;

    public event Action<IState> OnStateEntered;

    #endregion


    #region Unity Methods

    private void Awake()
    {
        Init();
        CacheStates();
    }
    private void OnEnable() => ToIdle();
    private void Update() => _currentState?.Update();

    #endregion


    #region Public Methods

    public void ToIdle() => ChangeState(_idleState);
    public void ToPunch() => ChangeState(_punchState);
    public void ToYawn() => ChangeState(_yawnState);
    public void ChangeAnim(int param) => _animator.SetTrigger(param);
    public void RequestPunch() => ToPunch();

    #endregion


    #region Animation Event Methods

    public void FinishYawn() => ToIdle();
    public void FinishPunch() => ToIdle();

    #endregion


    #region Private Methods

    private void Init()
    {
        if (!_animator)
        {
            if (!TryGetComponent(out _animator))
            {
                Debug.LogWarning("[NPC] Animator 컴포넌트를 찾지 못했습니다.");
            }
        }
    }

    private void CacheStates()
    {
        _idleState = new IdleState(this);
        _punchState = new PunchState(this);
        _yawnState = new YawnState(this);
    }

    private void ChangeState(IState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();

        OnStateEntered?.Invoke(nextState);
    }

    #endregion
}
