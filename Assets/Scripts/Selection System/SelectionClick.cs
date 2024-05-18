using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionClick : MonoBehaviour
{
    [SerializeField] private LayerMask selectableLayer;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;    
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        
    }

    private void HandleSelection()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SelectionManager.Instance.ShiftSelect(hit.collider.gameObject);
            }
            else
            {
                SelectionManager.Instance.ClickSelect(hit.collider.gameObject);
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            SelectionManager.Instance.DeselectAll();
        }
    }
}
