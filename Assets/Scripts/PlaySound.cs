using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.playerMovement.onMove.AddListener((eventInfo) => PlayMoveSound(eventInfo));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayMoveSound(ActorMovedEventInfo eventInfo){

    }
}
