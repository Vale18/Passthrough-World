using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatEventHandler : MonoBehaviour
{
    public CatActionController actionController;
    public Vector3 position;
    public string wandererNavMeshArea;
    void Start()
    {
        // Aktionen zur Warteschlange hinzufügen
        actionController.EnqueueAction(new GoToTarget(),position);
        actionController.EnqueueAction(new WandererAction(),4f,3f,wandererNavMeshArea);
        StartCoroutine(Wait10s());
        /*actionController.EnqueueAction(new FollowTarget())*/
    }

    IEnumerator Wait10s()
    {
        yield return new WaitForSeconds(15);
        actionController.FinishCurrentAction();
    }
}
