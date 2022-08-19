using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleBottonColorChange : MonoBehaviour
{
    public void MakeRed()
    {
        GetComponent<Image>().color = Color.red;
    }
    public void MakeWhite()
    {
        GetComponent<Image>().color = Color.white;
    }
}
