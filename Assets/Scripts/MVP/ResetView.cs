using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetView : MonoBehaviour
{
    [SerializeField] private Button _resetButton;

    public event Action OnResetButtonClicked;


    private void Awake()
    {
        if (!_resetButton)
        {
            if (!TryGetComponent(out _resetButton))
            {
                Debug.LogWarning("[ResetView] Reset Button 컴포넌트가 등록되지 않았습니다.");
            }
        }
    }

    public void OnClickReset()
    {
        OnResetButtonClicked?.Invoke();
    }
}
