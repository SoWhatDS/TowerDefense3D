using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;
using JoostenProductions;

namespace Game
{
    public class BulletView : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _direction;
        private float _distanceThisFrame;
        private float _bulletSpeed;
        private IViewServices _viewServices;
        private int _bulletDamage;
        private GameObject _bulletImpact;

        public void Init(float bulletSpeed, IViewServices viewServices,int bulletDamage,GameObject bulletImpact)
        {
            _bulletSpeed = bulletSpeed;
            _viewServices = viewServices;
            _bulletDamage = bulletDamage;
            _bulletImpact = bulletImpact;
            UpdateManager.SubscribeToUpdate(BulletDirection);
        }

        public void TakeTarget(Transform target)
        {
            _target = target;
        }

        public void BulletDirection()
        {
            if (_target == null)
            {
                _viewServices.Destroy(gameObject);
                return;
            }

            _direction = _target.position - transform.position;
            _distanceThisFrame = _bulletSpeed * Time.deltaTime;

            if (_direction.magnitude <= _distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(_direction.normalized * _distanceThisFrame, Space.World);

        }

        private void HitTarget()
        {
            GameObject go = Instantiate(_bulletImpact, _target.position, Quaternion.identity);
            _viewServices.Destroy(gameObject);
            gameObject.transform.position = new Vector3(100,100,100); 
            EnemyView enemy = _target.gameObject.GetComponent<EnemyView>();
            enemy.TakeDamage(_bulletDamage);
            Destroy(go, 0.5f);
            return;
        }
    }
}
