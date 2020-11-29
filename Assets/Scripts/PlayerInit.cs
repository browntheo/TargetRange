using Mirror;
using UnityEngine;

public class PlayerInit : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;
    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        //else
        //{
        //    //Camera.main.gameObject.SetActive(false);
        //    //sceneCamera = Camera.main;
        //    //if(sceneCamera != null)
        //    //{
        //    //    sceneCamera.gameObject.SetActive(false);
        //    //}
        //}
    }
    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
