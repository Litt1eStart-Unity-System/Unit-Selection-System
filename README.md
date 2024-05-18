# RTS - Unit Selection System

## Overview

Welcome to the Unit Selection System for Unity! This system allows you to select, deselect, drag-select units, and interact with them, making it perfect for real-time strategy (RTS) games.

https://github.com/Litt1eStar/RTS---Unit-Selection-System/assets/90139527/85eb0b6e-5aa3-4b94-ad19-d41f467bcc5b



## Features

- **Single Click Selection**: Select individual units with a simple click.
- **Shift Click Selection**: Add or remove units from the selection with shift-click.
- **Drag Selection**: Select multiple units by dragging a selection box.
- **Unit Interaction**: Execute actions on selected units.

## Class Responsibilities

### Selection System

#### SelectionManager
**File**: `Assets/Script/Selection System/SelectionManager.cs`

**Description**: 
This singleton class handles all selection actions (`ClickSelect`, `ShiftSelect`, `DragClick`, `DeselectAll`) and maintains lists of all selectable GameObjects and currently selected GameObjects.

#### SelectionClick
**File**: `Assets/Script/Selection System/SelectionClick.cs`

**Description**: 
Detects player clicks on selectable units and determines the type of selection action (click, shift-click).

#### SelectionDrag
**File**: `Assets/Script/Selection System/SelectionDrag.cs`

**Description**: 
Creates the visual representation of the drag selection box and tracks which units are selected within the dragged area.

### Unit System

#### ISelectable
**File**: `Assets/Script/Interface/ISelectable.cs`

**Description**: 
An interface with the `OnClick()` method, serving as a template for classes that need to respond to selection actions.

#### Unit
**File**: `Assets/Script/Unit/Unit.cs`

**Description**: 
Implements the `ISelectable` interface. Contains logic for unit interaction when selected. In the provided example, it uses `NavMeshAgent` to move the unit to the clicked position.

### Input Management

#### InputManager
**File**: `Assets/Script/InputManager.cs`

**Description**: 
Handles user input and executes the `OnClick()` method on selected units.

## Setup and Usage

### Setup

1. **Layer Configuration**:
   - Ensure all units are on a layer named "Selectable".
   - Attach the `SelectionManager`, `SelectionClick`, `SelectionDrag`, and `InputManager` scripts to appropriate GameObjects in your scene.

2. **Implementing Units**:
   - Implement the `ISelectable` interface in any class that should be selectable.
   - Define the logic for the `OnClick()` method in your unit class.

### Example Usage

Here's a simple example of a unit class implementing `ISelectable`:

```csharp
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

    public void OnClick()
    {
        MoveToDestination();
    }

    private void MoveToDestination()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            agent.SetDestination(hit.point);
        }
    }
}
