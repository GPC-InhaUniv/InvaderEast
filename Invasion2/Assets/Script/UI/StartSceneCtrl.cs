using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject HelpPanel;
    [SerializeField]
    GameObject RankPanel;

    public void OnClickGameStart()
    {

    }

    public void OnClickHelp()
    {
        HelpPanel.SetActive(true);
    }

    public void OnClickRank()
    {
        RankPanel.SetActive(true);
    }

    public void OnClickExit()
    {

    }

    public void OnClickByCloseHelpPanel()
    {
        HelpPanel.SetActive(false);
    }

    public void OnClickByCloseRankPanel()
    {
        RankPanel.SetActive(false);
    }
}
