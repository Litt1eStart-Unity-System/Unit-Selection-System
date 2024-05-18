using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, ISelectable
{
    [SerializeField] private LayerMask groundLayer;
    private NavMeshAgent agent;
    private Camera cam;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    public void OnSelected()
    {
        MoveToDestination();
    }

    void MoveToDestination()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            agent.SetDestination(hit.point);
        }
    }


}
