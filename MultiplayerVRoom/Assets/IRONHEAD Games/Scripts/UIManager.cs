using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UI_VRMenuGameobject;
    public GameObject UI_OpenWorldsGameobject;

    // Start is called before the first frame update
    void Start()
    {
        UI_VRMenuGameobject.SetActive(false);
        UI_OpenWorldsGameobject.SetActive(false);

    }

    // Update is called once per frame
    public void OnWorldsButtonClicked()
    {
        Debug.Log("Worlds button is clicked.");
        if(UI_OpenWorldsGameobject != null)
        {
            UI_OpenWorldsGameobject.SetActive(true);
        }
    }

    public void OnGoHomeButtonClicked()
    {
        Debug.Log("GoHome button is clicked.");
    }

    public void OnChangeAvaterButtonClicked()
    {
        Debug.Log("Change_Avater button is clicked.");
        AvatarSelectionManager.Instance.ActivateAvatarSelectionPlatform();
    }
}
