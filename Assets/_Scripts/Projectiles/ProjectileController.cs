using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Gameplays;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Projectiles
{
    public abstract class ProjectileController : MonoBehaviour
    {
        [field: SerializeField] public float ExistTime { get; private set; }
        [field: SerializeField] public EProjectile ProjectileType { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        private bool _isDestroyed;

        public virtual void Init()
        {
            gameObject.SetActive(true);
            _isDestroyed = false;

            StartCoroutine(DestroyProj());

            IEnumerator DestroyProj()
            {
                yield return new WaitForSeconds(ExistTime);
                if (!_isDestroyed)
                {
                    DestroyProjectile();
                }
            }
        }

        public void DestroyProjectile()
        {
            _isDestroyed = true;
            Rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);

            ProjectilePooling.Instance.RemoveProjectile(this);
        }
    }
}
