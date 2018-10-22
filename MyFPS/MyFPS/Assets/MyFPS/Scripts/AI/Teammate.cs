using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace MyFPS
{
    public class Teammate : BaseSceneObject, IDamageble
    {
        [SerializeField]
        private float _maxHealth;
        public float MaxHealth { get { return _maxHealth; } }
        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth { get { return _currentHealth; } }
        public bool IsAlive { get { return _currentHealth > 0; } }

        private NavMeshAgent _agent;
        public ThirdPersonCharacter _character;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _character = GetComponent<ThirdPersonCharacter>();

            _agent.updateRotation = false;
            _agent.updatePosition = true;
        }

        public void Update()
        {
            DistanceCheck();
        }

        public void SetDestination(Vector3 pos)
        {
            _agent.SetDestination(pos);
        }

        public void DistanceCheck()
        {
            if (_agent.remainingDistance > _agent.stoppingDistance)
                _character.Move(_agent.desiredVelocity, false, false);
            else
                _character.Move(Vector3.zero, false, false);
        }

        public void GetDamage(float damage)
        {
            if (!IsAlive)
                return;

            _currentHealth -= damage;

            if (!IsAlive)
                Death();
        }

        public void Death()
        {
            Destroy(gameObject, 1f);
        }
    }
}
