using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject movingItem;
    
    private Vector2 originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (movingItem == null)
        {
            return;
        }
        
        Vector2 mousePos = Input.mousePosition;
        movingItem.transform.position = mousePos;
    }

    public void SetMovingItem(GameObject objectMove)
    {
        Debug.LogError("SetMovingItem");
        movingItem = objectMove;
        originalPosition = objectMove.transform.position;
    }

    public void RemoveMovingItem()
    {
        if (movingItem != null)
        {
            movingItem.transform.position = originalPosition;
        }
        
        movingItem = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogError("OnPointerDown");
        SetMovingItem(movingItem);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.LogError("OnPointerUp");
        RemoveMovingItem();
    }
}
