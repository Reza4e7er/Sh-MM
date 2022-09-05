using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    int PoolingID{ get; set;}
    GameObject ThisGameObject{get;}
    void ResetComponents();
}