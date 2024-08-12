using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SausageIcon : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    


    public Tooltip tooltip;

    public string SausageName;
    public string SausageInfo;

    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(SausageName,SausageInfo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

}
