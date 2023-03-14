using System;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class TagTriggerCollector : TriggerCollector<GameObject>
{
    [SerializeField, Tag] private string _tag;
    protected override bool IsThisObject(GameObject gameObject) => gameObject.tag.Equals(_tag);

    protected override bool TryGetComponent(GameObject gameObject, out GameObject component)
    {
        component = gameObject;
        return true;
    }
}