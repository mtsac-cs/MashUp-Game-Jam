using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    GameObject soundContainer;
    [SerializeField]
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        Player.instance.playerMovement.onMove.AddListener((eventInfo) => PlayMoveSound(eventInfo));
        soundContainer = Instantiate(new GameObject(), transform.position, Quaternion.identity, transform);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AudioSource.PlayClipAtPoint(playerData.attackSound, transform.position);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioSource.PlayClipAtPoint(playerData.onHitSound, transform.position);
        }
    }

    public void PlayMoveSound(ActorMovedEventInfo eventInfo)
    {
        AudioSource.PlayClipAtPoint(playerData.walkSound, transform.position);
    }
    public void PlayDeathSound(){

    }
    public void PlayAttackSound(){

    }
    public void PlayOnHitSound(){

    }
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(playerData.walkSound, transform.position);
    }
}
