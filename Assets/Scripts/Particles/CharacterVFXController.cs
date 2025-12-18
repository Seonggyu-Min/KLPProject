using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVFXController : MonoBehaviour
{
    [SerializeField] private AttachPointProvider _attachPointProvider;

    public void PlayPunchVFX()
    {
        if (!_attachPointProvider || !_attachPointProvider.AttachPoint) return;
        VFXManager.Instance.SpawnPunch(_attachPointProvider.AttachPoint);
    }

    public void PlayYawnVFX() { }
    public void PlayIdleVFX() { }
}
