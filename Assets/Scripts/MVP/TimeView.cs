using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class TimeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private UIUnit _uiUnit;

    private StringBuilder _sb;

    private void Awake()
    {
        if (!_timeText)
        {
            if (!TryGetComponent(out _timeText))
            {
                Debug.LogWarning("[TimeView] TMP_Text 컴포넌트를 찾을 수 없습니다.");
            }
        }
        if (!_uiUnit)
        {
            if (!TryGetComponent(out _uiUnit))
            {
                Debug.LogWarning("[TimeView] UIUnit 컴포넌트를 찾을 수 없습니다.");
            }
        }

        _sb = new();
    }

    private void Update()
    {
        _sb.Clear();
        _sb.Append("Time: ");
        _sb.Append(GameManager.Instance.ElapsedTime.ToString("F2"));
        _timeText.text = _sb.ToString();
    }

    public void Hide()
    {
        if (_uiUnit)
        {
            _uiUnit.HideAnimation();
        }
    }
}
