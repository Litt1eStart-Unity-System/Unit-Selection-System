using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionDrag : MonoBehaviour
{
    [SerializeField] private RectTransform boxVisual;
    private Camera cam;

    private Rect selectionBox;
    private Vector2 startPos;
    private Vector2 endPos;

    private void Start()
    {
        cam = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        DrawVisual();
    }

    private void Update()
    {
        //Start Clicked
        if(Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }

        //Dragging
        if (Input.GetMouseButton(0))
        {
            UpdateDrag();
        }

        //Release Click
        if(Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void StartDrag()
    {
        startPos = Input.mousePosition;
        selectionBox = new Rect();
        DrawVisual();
    }

    private void UpdateDrag()
    {
        endPos = Input.mousePosition;
        DrawVisual();
        UpdateSelectionBox();
    }

    private void EndDrag()
    {
        SelectUnitsWithinBox();
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        DrawVisual();
    }

    private void DrawVisual()
    {
        Vector2 boxStart = startPos;
        Vector2 boxEnd = endPos;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        boxVisual.sizeDelta = boxSize;
    }

    private void UpdateSelectionBox()
    {
        selectionBox.xMin = Mathf.Min(startPos.x, endPos.x);
        selectionBox.xMax = Mathf.Max(startPos.x, endPos.x);
        selectionBox.yMin = Mathf.Min(startPos.y, endPos.y);
        selectionBox.yMax = Mathf.Max(startPos.y, endPos.y);
    }

    
    private void SelectUnitsWithinBox()
    {
        foreach(var unit in SelectionManager.Instance.allSelectable)
        {
            if (selectionBox.Contains(cam.WorldToScreenPoint(unit.transform.position)))
            {
                SelectionManager.Instance.DragClick(unit);
            }
        }
    }
}
