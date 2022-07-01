using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOnUI : MonoBehaviour
{
    private List<GameObject> panels;

    private GameObject panel;

    void Start()
    {
        panels = new List<GameObject>();

        foreach(GameObject panel in GameObject.FindGameObjectsWithTag("UI"))
        {
            panels.Add(panel);
        }
        Debug.Log(panels.Count);
    }
    void Update()
    {
        Debug.Log(OnMouseOver());
    }
    // Update is called once per frame
    public bool OnMouseOver()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        // check if the target is in the UI

        foreach(GameObject menu in panels)
        {
            foreach (RaycastResult r in results) 
            {
                bool isUIClick = r.gameObject.transform.IsChildOf(menu.transform); 
                if (isUIClick) 
                {
                    return true;
                }
            }
        }
        return false;
    }
}
