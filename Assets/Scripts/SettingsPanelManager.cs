using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
