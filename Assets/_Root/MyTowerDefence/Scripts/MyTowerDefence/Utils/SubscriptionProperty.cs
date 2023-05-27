using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Utils
{
    internal class SubscriptionProperty<TValue> : ISubscriptionProperty<TValue>
    {
        private TValue _value;
        private Action<TValue> _onChangeValue;

        public TValue Value
        {
            get => _value;

            set
            {
                _value = value;
                _onChangeValue?.Invoke(_value);
            }
        }

        public void SubscribeOnChange(Action<TValue> subscriptionAction)
        {
            _onChangeValue += subscriptionAction;
        }

        public void UnSubcribeOnChange(Action<TValue> unsubscriptionAction)
        {
            _onChangeValue -= unsubscriptionAction;
        }
    }
}
