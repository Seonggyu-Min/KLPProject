using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPointProvider : MonoBehaviour
{
    [SerializeField] private Transform _attachPoint;
    public Transform AttachPoint => _attachPoint;


    public void Awake()
    {
        if (!_attachPoint)
        {
            Debug.LogWarning("[AttachPointProvider] AttachPoint가 등록되지 않았습니다.");
        }
    }
}
