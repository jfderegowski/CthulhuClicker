using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private List<ButtonsAndPanels> _buttonsAndPanelsList;

    private void Awake()
    {
        foreach (var i in _buttonsAndPanelsList)
        {
            i.Button.onClick.AddListener(delegate
            {
                ClosePanels(_buttonsAndPanelsList);
                i.Panel.SetActive(true);
            });
        }
    }
    
    private void ClosePanels(List<ButtonsAndPanels> buttonsAndPanelsList)
    {
        foreach (var i in buttonsAndPanelsList)
        {
            i.Panel.SetActive(false);
        }
    }
}

[Serializable]
public class ButtonsAndPanels
{
    public Button Button
    {
        get => _button;
        set
        {
            if (value.GetComponent<Button>())
            {
                _button = value;
            }
        }
    }
    public GameObject Panel
    {
        get => _panel;
        set
        {
            if (value.GetComponent<RectTransform>())
            {
                _panel = value;
            }
        }
    }

    [SerializeField] private Button _button;
    [SerializeField] private GameObject _panel;
}