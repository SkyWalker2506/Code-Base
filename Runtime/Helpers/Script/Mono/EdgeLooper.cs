using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EdgeLooper : MonoBehaviour
{
    [SerializeField] ScriptableFloat checkInterval;
    [SerializeField] ScriptableFloat offset;

    void Start()
    {
        CheckPassedEdge();
    }

    async void CheckPassedEdge()
    {
        while(Application.isPlaying)
        {

            var pos = transform.position;
            var yUpDiff = pos.y - (EdgeManager.Up + offset.Value);
            var yDownDiff = (EdgeManager.Down - offset.Value) - pos.y;
            var xRightDiff = pos.x-(EdgeManager.Right + offset.Value) ;
            var xLeftDiff = (EdgeManager.Left - offset.Value)- pos.x;
            if (yUpDiff > 0)
                pos.y = EdgeManager.Down - offset.Value;
            else if (yDownDiff > 0)
                pos.y = EdgeManager.Up + offset.Value;
            if (xRightDiff > 0)
                pos.x = EdgeManager.Left - offset.Value;
            else if (xLeftDiff > 0)
                pos.x = EdgeManager.Right + offset.Value;
            
            transform.position = pos;
            await Task.Delay((int)(1000 * checkInterval.Value));

        }
    }
}