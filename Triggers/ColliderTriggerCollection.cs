using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerCollection : MonoBehaviour
{
    [SerializeReference] private List<BaseTriggerChecker> _baseTriggerCheckers = new List<BaseTriggerChecker>(2);

    public void AddTriggerChecker(BaseTriggerChecker baseTriggerChecker)
    {
        if (_baseTriggerCheckers.Contains(baseTriggerChecker)) return;
        _baseTriggerCheckers.Add(baseTriggerChecker);
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var baseTriggerChecker in _baseTriggerCheckers)
        {
            baseTriggerChecker.OnTriggerEnter(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var baseTriggerChecker in _baseTriggerCheckers)
        {
            baseTriggerChecker.OnTriggerExit(other);
        }
    }
}