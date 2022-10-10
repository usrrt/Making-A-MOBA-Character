using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    // ###############################################
    //             NAME : HongSW                      
    //             MAIL : gkenfktm@gmail.com         
    // ###############################################

    float RotateSpeed = 0.075f;
    float RotateVelocity;

    NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        // ��Ŭ���� �̵�
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            // ���콺��ġ���� �� raycast�� ��ü�� �´´ٸ�, �װ��� navmesh��������
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                // MOVEMENT
                // ��Ŭ���� ������ ������
                _agent.SetDestination(hit.point);

                // ROTATION
                Quaternion lookAtTheTarget = Quaternion.LookRotation(hit.point - transform.position);
                // ???
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookAtTheTarget.eulerAngles.y, ref RotateVelocity, RotateSpeed * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
                
            }
        }
    }
}
