using RPG.Attribute;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] bool isHoming = true;
        [SerializeField] GameObject hitEffect = null;
        [SerializeField] float maxLifeTime = 10f;
        [SerializeField] GameObject[] destroyOnHit = null;
        [SerializeField] float lifeAfterImpact = 2f;

        Health target = null;
        GameObject instigator = null;
        float damage = 0;

        ParticleSystem particle;

        void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        void Update()
        {
            if (target == null) return;

            if (isHoming && !target.IsDead())
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * Time.deltaTime * speed);  
        }

        public void SetTarget(Health target, GameObject instigator, float damage)
        {
            this.target = target;
            this.damage = damage;
            this.instigator = instigator;

            Destroy(gameObject, maxLifeTime);
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if(targetCapsule == null)
            {
                return target.transform.position; 
            }
            return target.transform.position + Vector3.up * (targetCapsule.height / 2 + 0.2f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != target) return;
            if (target.IsDead()) return;
            
            target.TakeDamage(instigator, damage);

            speed = 0;

            if (hitEffect != null)
            {
                Instantiate(hitEffect, GetAimLocation(), transform.rotation);
            }

            foreach(GameObject toDestroy in destroyOnHit)
            {
                Destroy(toDestroy);
            }

            Destroy(gameObject, lifeAfterImpact);
        }
    }
}
