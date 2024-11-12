using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Units;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public LayerMask selectableLayer;
    public LayerMask groundLayer;
    private List<Unit> selectedUnits = new List<Unit>();
    private Vector3 selectionStartPos;
    private bool isSelecting = false;
    private float clickTimer;
    [SerializeField]
    public string team;
    public CameraСontroller cameraСontroller;
    public Camera Camera;
    public GameObject mapTerrain;
    // private float clickThreshold = 0.01f;

    void Start()
    {
        Camera = (gameObject.GetComponent<Camera>() == Camera.main) ? gameObject.GetComponent<Camera>() : throw new ArgumentException();
        gameObject.AddComponent<CameraСontroller>();
        cameraСontroller = gameObject.GetComponent<CameraСontroller>();
        cameraСontroller.cam = Camera;
        cameraСontroller.mapBoundaryObject = GameObject.FindGameObjectWithTag("MapTerrain");
        team = "Team1";
    }

    void Update()
    {
        HandleSelection();
        HandleCommand();
    }

    private void HandleCommand()
    {
        if (Input.GetMouseButton(1))
        { // ПКМ
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                // if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                // {
                Vector3 targetPosition = hit.point;
                foreach (Unit unit in selectedUnits)
                {
                    if (unit is IMovable)
                    {
                        unit.Tasks.Clear();
                        // unit.Tasks.Enqueue(Task.task(targetPosition));
                    }
                }
                // }

                // if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                // {
                //     GameObject target = hit.collider.gameObject;
                //     foreach (GameObject unit in selectedUnits)
                //     {
                //         var attack = unit.GetComponent<AttackComponent>();
                //         if (attack != null)
                //         {
                //             attack.SetTarget(target.transform);
                //         }
                //     }
                // }
            }
        }
    }

    private void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectionStartPos = Input.mousePosition;
            isSelecting = true;
            clickTimer = Time.time;
        }

        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(selectionStartPos, Input.mousePosition) > 1f)
            {
                isSelecting = true;

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;

            if (Vector3.Distance(selectionStartPos, Input.mousePosition) < 1f)
            {
                SelectSingleUnit(selectionStartPos);
            }
            else
            {
                SelectUnitsInRectangle(selectionStartPos, Input.mousePosition);
            }
        }
    }

    private void SelectSingleUnit(Vector3 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, selectableLayer))
        {
            Unit unit = hit.collider.gameObject.GetComponent<Unit>();

            if (unit.GetComponent<IMovable>() != null)
            {
                ClearSelection();
                if (!selectedUnits.Contains(unit))
                {
                    selectedUnits.Add(unit);
                }
                HighlightUnit(unit, true);
            }
        }
    }

    private void SelectUnitsInRectangle(Vector3 startScreenPos, Vector3 endScreenPos)
    {
        ClearSelection();

        Vector3 startWorldPos = Camera.ScreenToWorldPoint(new Vector3(startScreenPos.x, startScreenPos.y, Camera.nearClipPlane));
        Vector3 endWorldPos = Camera.ScreenToWorldPoint(new Vector3(endScreenPos.x, endScreenPos.y, Camera.nearClipPlane));

        Rect selectionRect = new Rect(
            Mathf.Min(startScreenPos.x, endScreenPos.x),
            Mathf.Min(startScreenPos.y, endScreenPos.y),
            Mathf.Abs(startScreenPos.x - endScreenPos.x),
            Mathf.Abs(startScreenPos.y - endScreenPos.y)
        );

        foreach (Unit unit in FindObjectsByType<Unit>(FindObjectsSortMode.None))
        {
            Vector3 screenPosition = Camera.WorldToScreenPoint(unit.transform.position);

            if (selectionRect.Contains(screenPosition, true) && unit.GetComponent<IMovable>() != null)
            {
                selectedUnits.Add(unit);
                HighlightUnit(unit, true);
            }
        }
    }

    private void HighlightUnit(Unit unit, bool highlight)
    {
        Outline outline = unit.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = highlight;
        }
    }

    private void ClearSelection()
    {
        foreach (Unit unit in selectedUnits)
        {
            HighlightUnit(unit, false);
        }
        selectedUnits.Clear();
    }
    private void OnGUI()
    {
        if (isSelecting)
        {
            Rect rect = new Rect(
                selectionStartPos.x,
                Screen.height - selectionStartPos.y,
                Input.mousePosition.x - selectionStartPos.x,
                -(Input.mousePosition.y - selectionStartPos.y)
            );

            GUI.color = new Color(0, 1, 0, 0.3f);
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
            GUI.color = Color.white;
        }
    }

}

