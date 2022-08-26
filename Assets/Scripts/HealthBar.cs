using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField]
     private float value = 1f;

     [SerializeField] private RectTransform foreBar, backBar;
     private Image barImage;
     public bool isPlayer = false;
     [SerializeField] Color playerColor, enemyColor;

     private void OnEnable()
     {
        barImage = foreBar.GetComponent<Image>();
     }

     // changes the foreBar based on the value
     public void UpdateBar()
     {
        foreBar.sizeDelta = new Vector2(backBar.rect.width*value, foreBar.sizeDelta.y);
        if (isPlayer)
        {
            barImage.color = playerColor;
        }
        else
        {
            barImage.color = enemyColor;
        }
     }

     // changes the foreBar and the value based on arguement
     public void UpdateBar(float value)
     {
        this.value = value;
        UpdateBar();
     }
}
