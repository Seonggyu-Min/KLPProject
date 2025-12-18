using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class StateEnterCountView : MonoBehaviour
{
    [SerializeField] private GameObject _informationObj;
    [SerializeField] private TMP_Text _informationText;
    [SerializeField] private TMP_Text _idleText;
    [SerializeField] private TMP_Text _yawnText;
    [SerializeField] private TMP_Text _punchText;
    [SerializeField] private GameObject _resetButton;

    [SerializeField] private UIUnit _uiUnit;

    private StringBuilder _informationSB;
    private StringBuilder _idleSB;
    private StringBuilder _yawnSB;
    private StringBuilder _punchSB;


    private void Awake()
    {
        _informationSB = new();
        _idleSB = new();
        _yawnSB = new();
        _punchSB = new();

        if (!_idleText) Debug.LogWarning("[StateEnterCountView] TMP_Text _idleText 컴포넌트를 찾을 수 없습니다.");
        if (!_yawnText) Debug.LogWarning("[StateEnterCountView] TMP_Text _yawnText 컴포넌트를 찾을 수 없습니다.");
        if (!_punchText) Debug.LogWarning("[StateEnterCountView] TMP_Text _punchText 컴포넌트를 찾을 수 없습니다.");
        if (!_uiUnit)
        {
            if (!TryGetComponent(out _uiUnit))
            {
                Debug.LogWarning("[StateEnterCountView] UIUnit 컴포넌트를 찾을 수 없습니다.");
            }
        }
    }

    private void OnDisable()
    {
        if (_informationObj) _informationObj.SetActive(false);
        //if (_informationText) _informationText.gameObject.SetActive(false);
        if (_idleText) _idleText.gameObject.SetActive(false);
        if (_yawnText) _yawnText.gameObject.SetActive(false);
        if (_punchText) _punchText.gameObject.SetActive(false);
        if (_resetButton) _resetButton.SetActive(false);
    }


    public void Render(IReadOnlyDictionary<NPCStateType, int> counts)
    {
        _informationSB.Clear();
        _idleSB.Clear();
        _yawnSB.Clear();
        _punchSB.Clear();

        _informationSB.AppendLine("상태 전환 횟수");

        int idleCount = 0;
        int yawnCount = 0;
        int punchCount = 0;

        if (counts != null)
        {
            counts.TryGetValue(NPCStateType.Idle, out idleCount);
            counts.TryGetValue(NPCStateType.Yawn, out yawnCount);
            counts.TryGetValue(NPCStateType.Punch, out punchCount);
        }

        _idleSB.AppendLine($"Idle 상태 전환 횟수: {idleCount}");
        _yawnSB.AppendLine($"Yawn 상태 전환 횟수: {yawnCount}");
        _punchSB.AppendLine($"Punch 상태 전환 횟수: {punchCount}");

        _informationText.text = _informationSB.ToString();
        _idleText.text = _idleSB.ToString();
        _yawnText.text = _yawnSB.ToString();
        _punchText.text = _punchSB.ToString();
    }

    public void Hide()
    {
        if (_uiUnit)
        {
            _uiUnit.HideAnimation();
        }
    }
}
