using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    GameObject soundContainer;
    [SerializeField]
    GameObject[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        Player.instance.playerMovement.onMove.AddListener((eventInfo) => PlayMoveSound(eventInfo));
        soundContainer = Instantiate(new GameObject(),transform.position,Quaternion.identity,transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            PlaySound(0);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            PlaySound(1);
        }
    }

    void PlayMoveSound(ActorMovedEventInfo eventInfo){
        
    }
    void PlaySound(int index){

    }
    void PlaySound(AudioClip audioClip){
        GameObject temp = new GameObject();
        var audioObject = Instantiate(temp,transform.position,Quaternion.identity,soundContainer.transform);
        AudioSource audioSource = audioObject.GetOrAddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
