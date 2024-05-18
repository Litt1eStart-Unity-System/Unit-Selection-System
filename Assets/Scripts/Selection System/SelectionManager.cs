using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public List<GameObject> allSelectable = new List<GameObject>();
    public List<GameObject> selectedList = new List<GameObject>();
    [SerializeField] private Material selectedMat;
    [SerializeField] private Material defaultMat;

    private static SelectionManager instance;
    public static SelectionManager Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance != null || instance == this)
        {
            Destroy(this.gameObject);
            return;
        }
             
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Start()
    {
        allSelectable = GameObjectUtils.GetGameObjectByLayerName("Selectable");

    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        SelectUnit(unitToAdd);
    }

    public void ShiftSelect(GameObject unitToAdd)
    {
        if (selectedList.Contains(unitToAdd))
        {
            DeselectUnit(unitToAdd);
        }
        else
        {
            SelectUnit(unitToAdd);
        }
    }

    public void DragClick(GameObject unitToAdd)
    {
        if (!selectedList.Contains(unitToAdd))
        {
            SelectUnit(unitToAdd);
        }
    }

    public void DeselectAll()
    {
        foreach (GameObject unit in allSelectable)
        {
            unit.GetComponent<Renderer>().material = defaultMat;
        }
        selectedList.Clear();
    }

    private void SelectUnit(GameObject unit)
    {
        selectedList.Add(unit);
        unit.GetComponent<Renderer>().material = selectedMat;
    }

    private void DeselectUnit(GameObject unit)
    {
        selectedList.Remove(unit);
        unit.GetComponent<Renderer>().material = defaultMat;
    }

    public void ExecutedAction()
    {
        foreach (GameObject selectedGO in selectedList)
        {
            selectedGO.GetComponent<ISelectable>().OnSelected();
        }
    }
}
