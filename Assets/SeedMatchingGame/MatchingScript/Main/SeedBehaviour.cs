using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SeedBehaviour : MonoBehaviour
{
    [SerializeField] private int matchID;

    private LineRenderer lineRenderer;
    private Vector3 startPosition;
    private bool isDragging = false;
    private static SeedBehaviour activeDraggingSeed;
    private ITreeMatcher matcher;
    public static int ActiveSeedCount = 0;
    private bool isMatched = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        matcher = new TreeMatchManager(); // using a strategy for matching (Polymorphism)
    }

    private void OnEnable()
    {
        SeedInputManager.OnSeedClickDown += HandleMouseDown;
        SeedInputManager.OnSeedDrag += HandleMouseDrag;
        SeedInputManager.OnSeedClickUp += HandleMouseUp;
    }

    private void OnDisable()
    {
        SeedInputManager.OnSeedClickDown -= HandleMouseDown;
        SeedInputManager.OnSeedDrag -= HandleMouseDrag;
        SeedInputManager.OnSeedClickUp -= HandleMouseUp;
    }

    private void Start()
    {
        SetupLineRenderer();
        if (!isMatched)
        {
            ActiveSeedCount++;
        }
    }

    private void HandleMouseDown(Vector3 worldPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            activeDraggingSeed = this;

            startPosition = GetComponent<Renderer>().bounds.center;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPosition);
        }
    }

    private void HandleMouseDrag(Vector3 worldPosition) 
    {
        if (!isDragging) return;
        lineRenderer.SetPosition(1, worldPosition);
    }

    private void HandleMouseUp(Vector3 worldPosition)
    {
        if (activeDraggingSeed != this) return;
        isDragging = false;
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (matcher.TryMatch(hit, matchID, out int treeID))
        {
        
            if (hit.collider.TryGetComponent(out GetTreeID tree))
            {
                
                lineRenderer.SetPosition(1, tree.GetComponent<Renderer>().bounds.center);
            }

            OnMatched();
        }
        else
        {
            ClearLine();
        }

        activeDraggingSeed = null;
    }

    private void SetupLineRenderer()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    private void ClearLine()
    {
        lineRenderer.positionCount = 0;
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
    }

    private void OnMatched()
    {
        this.enabled = false;
        if (!isMatched)
        {
            isMatched = true;
            ActiveSeedCount--;
        }

        CheckAllSeedsMatched.instance.AllSeedsMatched();
    }


    public void ResetSeedState()
    {
        if (isMatched)
        {
            isMatched = false;
            ActiveSeedCount++;
        }

        isDragging = false;
        SetupLineRenderer();
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}