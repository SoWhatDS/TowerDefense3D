
using UnityEngine;
using System;

namespace Utils
{
    internal interface ISubscriptionProperty<out TValue>
    {
        TValue Value { get; }

        void SubscribeOnChange(Action<TValue> subscriptionAction);

        void UnSubcribeOnChange(Action<TValue> unsubscriptionAction);
    }
}
