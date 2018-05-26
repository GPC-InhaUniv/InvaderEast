using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreUI : MonoBehaviour {

    public ScrollRect ScrollRectItem;

    public void Start()
    {
        ScrollRectItem = gameObject.GetComponent<ScrollRect>();
    }
    public void OnMouseUp()
    {
        if (ScrollRectItem.horizontalNormalizedPosition > 0.7)
        {
            ScrollRectItem.horizontalNormalizedPosition = 1;
        }
    }
}
