using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class Fine : ActionTask
{
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        EndAction(true);
    }
}
