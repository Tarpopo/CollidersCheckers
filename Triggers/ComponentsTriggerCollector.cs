using System;
using UnityEngine;

namespace Triggers
{
    [Serializable]
    public class ComponentsTriggerCollector<T> : TriggerCollector<T>
    {
        public T LastInterface => _interface;
        private T _interface;

        protected override bool IsThisObject(GameObject gameObject) => gameObject.TryGetComponent(out _interface);

        protected override bool TryGetComponent(GameObject gameObject, out T component) =>
            gameObject.TryGetComponent(out component);
    }
}