using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public Image bg;
    public TextMeshProUGUI sausageName;
    public TextMeshProUGUI sausageDescription;

    private void Start()
    {
        HideTooltip();
    }

    public void ShowTooltip(string name, string description)
    {
        bg.color = new Color32(40, 40, 40, 100);

        SetName(name);
        SetDescription(description);

    }

    public void HideTooltip()
    {
        bg.color = new Color32(40, 40, 40, 0);

        SetName("");
        SetDescription("");
    }

    private void SetName(string name)
    {
        sausageName.text = name;
    }
    private void SetDescription(string description)
    {
        sausageDescription.text = description;
    }

}
