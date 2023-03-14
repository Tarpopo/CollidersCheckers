using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class TriggerCollector<T> : BaseTriggerChecker
{
    public event Action<T> OnObjectEnter;
    public event Action<T> OnObjectExit;
    public event Action OnAllExit;
    public bool HaveElements => _elements.Count > 0;
    public IEnumerable<T> Elements => _elements;
    private readonly HashSet<T> _elements = new HashSet<T>(20);

    protected override bool IsThisObject(GameObject gameObject) => false;

    protected override void OnEnter(GameObject gameObject)
    {
        if (TryGetComponent(gameObject, out var component) == false || _elements.Contains(component)) return;
        _elements.Add(component);
        OnObjectEnter?.Invoke(component);
    }

    protected override void OnExit(GameObject gameObject)
    {
        if (TryGetComponent(gameObject, out var component) == false || _elements.Contains(component) == false) return;
        _elements.Remove(component);
        OnObjectExit?.Invoke(component);
        if (HaveElements == false) OnAllExit?.Invoke();
    }

    protected abstract bool TryGetComponent(GameObject gameObject, out T component);
}