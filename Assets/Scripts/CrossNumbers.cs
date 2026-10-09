using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class CrossNumbers : MonoBehaviour, IPointerClickHandler
{

    //Theo's friend made this one!

    private Color colorOne;
    [SerializeField] Color colorTwo;
    [SerializeField] TextMeshProUGUI text;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            SwitchColor();
    }
    void SwitchColor()
    {
        if (text.color == colorOne)
            text.color = colorTwo;
        else
            text.color = colorOne;
    }
    void Start()
    {
        colorOne = text.color;
    }

}
