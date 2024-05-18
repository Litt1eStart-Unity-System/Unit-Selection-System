using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (SelectionManager.Instance.selectedList.Count > 0)
        {
            if(Input.GetMouseButtonDown(1)) 
            {
                SelectionManager.Instance.ExecutedAction();
            }
        }
    }
}
