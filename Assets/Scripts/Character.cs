using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Relation relation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GUIHandler.AquiringTargets)
        {
            if(GUIHandler.TargetAquisition.RelationRequirement == relation)
            {
                GUIHandler.TargetAquisition.AddTarget(this);
            }
            else
            {
                ErrorHandler.ThrowError("Invalid target");
            }
        }
    }
}

public enum Relation
{
    ANY,
    FRIENDLY,
    UNFRIENDLY
}
