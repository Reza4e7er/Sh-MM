using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class characterMovemtn : MonoBehaviour
{
    public NavMeshAgent playernavmeshagent;
    public Camera mycam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myray = mycam.ScreenPointToRay(Input.mousePosition);
            RaycastHit myraycasthit;
            if (Physics.Raycast(myray, out myraycasthit))
            {
                playernavmeshagent.SetDestination(myraycasthit.point);
            }
        }
    }
}
