using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEnterPresenter : MonoBehaviour
{
    [SerializeField] private NPC _npc;
    [SerializeField] private StateEnterCountView _countView;
    [SerializeField] private NPCControlView _controlView;
    [SerializeField] private TimeView _timeView;
    [SerializeField] private ResetView _resetView;

    private StateEnterCountModel _countModel;
    

    private void Awake() => Init();
    private void Start() => InitActive();
    private void OnEnable() => HandleSubscribe();
    private void OnDisable() => HandleUnsubscribe();


    private void Init()
    {
        _countModel = new StateEnterCountModel();

        if (!_countView) Debug.LogWarning("[StateEnterPresenter] StateEnterCountView 컴포넌트가 등록되지 않았습니다.");
        if (!_controlView) Debug.LogWarning("[StateEnterPresenter] NPCControlView 컴포넌트가 등록되지 않았습니다.");
    }

    private void InitActive()
    {
        if (_timeView) _timeView.gameObject.SetActive(true);
        if (_controlView) _controlView.gameObject.SetActive(true);
        if (_countView) _countView.gameObject.SetActive(false);
    }

    private void HandleSubscribe()
    {
        if (_npc) _npc.OnStateEntered += HandleStateEntered;
        if (_controlView) _controlView.OnPunchButtonClicked += HandlePunchClicked;
        if (GameManager.TryGetInstance(out GameManager gm)) gm.OnGameOver += HandleGameOver;
        if (_resetView) _resetView.OnResetButtonClicked += HandleGameReset;
    }

    private void HandleUnsubscribe()
    {
        if (_npc) _npc.OnStateEntered -= HandleStateEntered;
        if (_controlView) _controlView.OnPunchButtonClicked -= HandlePunchClicked;
        if (GameManager.TryGetInstance(out GameManager gm)) gm.OnGameOver -= HandleGameOver;
        if (_resetView) _resetView.OnResetButtonClicked -= HandleGameReset;
    }

    private void HandleStateEntered(IState state)
    {
        _countModel.Increment(state.StateType);
    }

    private void HandlePunchClicked()
    {
        if (_npc) _npc.RequestPunch();
    }

    private void HandleGameOver()
    {
        if (_timeView) _timeView.Hide();
        if (_controlView) _controlView.Hide();
        if (_countView)
        {
            _countView.gameObject.SetActive(true);
            _countView.Render(_countModel.Counts);
        }
    }

    private void HandleGameReset()
    {
        _countModel.Reset();
        GameManager.Instance.ResetGame();
        InitActive();
    }
}
