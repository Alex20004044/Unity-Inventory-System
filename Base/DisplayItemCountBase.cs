using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace HS
{
    public class DisplayItemCountBase<T> : MonoBehaviour, IObservable<int>
    {
        [SerializeField]
        T itemKey;

        [ReadOnly]
        [ShowInInspector]
        ReactiveProperty<int> value = new ReactiveProperty<int>();

        public void Init(IInventory<T> inventory)
        {
            inventory.Where((x) => x.Key.Equals(itemKey)).Subscribe((x) => value.Value = x.Value).AddTo(this);
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            return value.Subscribe(observer);
        }
    }
}