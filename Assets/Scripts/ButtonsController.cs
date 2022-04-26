using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<GameObject> _panels;

    private void Awake()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            int y = i;
            _buttons[y].onClick.AddListener(delegate
            {
                ClosePanels(_panels);
                _panels[y].SetActive(true);
            });
        }
    }

    private void OpenPanel(GameObject gameObject, List<GameObject> gameObjects)
    {
        ClosePanels(gameObjects);
        gameObject.SetActive(true);
    }
    
    private void ClosePanels(List<GameObject> gameObjects)
    {
        foreach (var i in gameObjects)
        {
            i.SetActive(false);
        }
    }
}