using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace MyFPS
{
    public class Enemy : BaseSceneObject, IDamageble
    {
       
        [SerializeField]
        private float _maxHealth;
        public float MaxHealth { get { return _maxHealth; } }
        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth { get { return _currentHealth; } }
        public bool IsAlive { get { return _currentHealth > 0; } }
        public AudioClip _deathSound;

        [SerializeField]
        private Transform _detectedTransform;
        [SerializeField]
        private float _detectedDistance = 30f;
        [SerializeField]
        private float _attackDistance = 15f;

        [SerializeField]
        private float _maxRandomWPRadius = 20f;
        [SerializeField]
        private bool _useRandomWP;
        private NavMeshAgent _agent;
        private ThirdPersonCharacter _character;
        public Vector3 _randomPos;
        private Waypoint[] _wayPoints;
        private int _currentWayPoint;
        private float _currentWayPointTimeout;
        private Transform _targetTransform;
        private bool _IsTarget;

        private BaseWeapon _weapon;              
        
        public void Update()
        {            
            if (!IsAlive)
                return;

            if (_targetTransform)
            {
                _character.Move(_agent.desiredVelocity, false, false);
                float dist = Vector3.Distance(transform.position, _targetTransform.position);
                if (dist < _attackDistance)
                {
                    _IsTarget = !IsTargetBlocked();
                    if (_IsTarget)
                    {
                        _agent.SetDestination(_targetTransform.position);
                        if(_weapon)
                        _weapon.Fire();
                    }
                }
                else if (dist < _detectedDistance)
                {                   
                    _IsTarget = !IsTargetBlocked();
                    if (_IsTarget)
                        _agent.SetDestination(_targetTransform.position);
                }
                else
                {
                    _IsTarget = false;
                }
            }

            if (_IsTarget)
                return;

            if (_useRandomWP)
            {
                _character.Move(_randomPos, false, false);
                _agent.SetDestination(_randomPos);
                if (!_agent.hasPath || _agent.remainingDistance > _maxRandomWPRadius * 2f)
                    _randomPos = GenerateRandomWP();
            }
            else
            {
                if (_wayPoints.Length > 1)
                {
                    _agent.SetDestination(_wayPoints[_currentWayPoint].transform.position);
                    if (!_agent.hasPath)
                    {
                        _currentWayPointTimeout += Time.deltaTime;
                        if (_currentWayPointTimeout >= _wayPoints[_currentWayPoint].WaitTime)
                        {
                            _currentWayPointTimeout = 0;
                            _currentWayPoint++;
                            if (_currentWayPoint >= _wayPoints.Length)
                                _currentWayPoint = 0;
                        }
                    }
                }
            }
        }

        public void SetTarget(Transform target)
        {
            _targetTransform = target;
        }

        private bool IsTargetBlocked()
        {
            RaycastHit hit;
            if (Physics.Linecast(_detectedTransform.position, _targetTransform.position, out hit))
            {
                if(hit.transform == _targetTransform)
                {
                    Debug.DrawLine(_detectedTransform.position, hit.point, Color.red);
                    return false;
                }
                
            }
            return true;
        }

        public void Initialize(Spawner spawner)
        {            
            _character = GetComponent<ThirdPersonCharacter>();
            _agent = GetComponent<NavMeshAgent>();
            _weapon = GetComponentInChildren<BaseWeapon>(true);

            _useRandomWP = spawner.UseRandomWP;

            if (_useRandomWP)
                _randomPos = GenerateRandomWP();
            else
                _wayPoints = spawner.GetComponentsInChildren<Waypoint>();

            if (Main.Instance != null)
                Main.Instance.EnemyController.AddBot(this);
        }

        private Vector3 GenerateRandomWP()
        {
            Vector3 randomPos = Random.insideUnitSphere * _maxRandomWPRadius;

            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(transform.position + randomPos, out navMeshHit, _maxRandomWPRadius * 1.5f, NavMesh.AllAreas))
                randomPos = navMeshHit.position;

            else
                return transform.position;

            return randomPos;
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
            _character.Move(Vector3.zero, true, false);
            GetComponent<AudioSource>().PlayOneShot(_deathSound);
            Destroy(gameObject, 1f);        
            Main.Instance.EnemyController.RemoveBot(this);
        }
    }
}
