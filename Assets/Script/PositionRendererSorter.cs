using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 15;
    [SerializeField]
    private Renderer myRenderer;

    void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
