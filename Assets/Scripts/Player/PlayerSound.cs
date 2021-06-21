using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    GameObject soundContainer;
    [SerializeField]
    ActiveActorData activeActorData;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayMoveSound(ActorMovedEventInfo eventInfo)
    {
        AudioSource.PlayClipAtPoint(activeActorData.walkSound, transform.position);
    }
    public void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(activeActorData.onDeathSound, transform.position);
    }

    public void PlayAttackSound()
    {
        AudioSource.PlayClipAtPoint(activeActorData.attackSound, transform.position);
    }

    public void PlayOnHitSound()
    {
        AudioSource.PlayClipAtPoint(activeActorData.onHitSound, transform.position);
    }

    void PlayWalkSound()
    {
        AudioSource.PlayClipAtPoint(activeActorData.walkSound, transform.position);
    }
}
