using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace develop_neko
{
    public class ChaseAIController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            // �ǐՂ��s��
            _agent.SetDestination(_target.transform.position);
        }

    }
}