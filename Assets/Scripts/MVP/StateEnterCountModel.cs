using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEnterCountModel
{
    private Dictionary<NPCStateType, int> _counts = new();


    public void Increment(NPCStateType stateType)
    {
        if (_counts.ContainsKey(stateType))
        {
            _counts[stateType]++;
        }
        else
        {
            _counts[stateType] = 1;
        }
    }

    public void Reset() => _counts.Clear();
    public IReadOnlyDictionary<NPCStateType, int> Counts => _counts;
}
