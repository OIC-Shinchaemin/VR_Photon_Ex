using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunUI : MonoBehaviour
{
    public GameObject start;
    public GameObject win;
    public GameObject lost;

    public void StartActive()
    {
        start.SetActive(true);
    }
    public void StartInactive()
    {
        start.SetActive(false);
    }
    public bool IsStartActive()
    {
        return start.activeSelf;
    }

    public void WinActive()
    {
        win.SetActive(true);
    }
    public void WinInactive()
    {
        win.SetActive(false);
    }
    public bool IsWinActive()
    {
        return win.activeSelf;
    }

    public void LostActive()
    {
        lost.SetActive(true);
    }
    public void LostInactive()
    {
        lost.SetActive(false);
    }
    public bool IsLostActive()
    {
        return lost.activeSelf;
    }
}
