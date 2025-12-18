using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControlView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private UIUnit _uiUnit;

    public event Action OnPunchButtonClicked;


    private void Awake()
    {
        if (!_button)
        {
            if (!TryGetComponent(out _button))
            {
                Debug.LogWarning("[NPCControlView] 버튼 컴포넌트를 찾을 수 없습니다.");
            }
        }
        if (!_uiUnit)
        {
            if (!TryGetComponent(out _uiUnit))
            {
                Debug.LogWarning("[NPCControlView] UIUnit 컴포넌트를 찾을 수 없습니다.");
            }
        }
    }

    public void OnClickPunch()
    {
        OnPunchButtonClicked?.Invoke();
    }

    public void Hide()
    {
        if (_uiUnit)
        {
            _uiUnit.HideAnimation();
        }
    }
}
