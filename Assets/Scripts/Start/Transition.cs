using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] private Button start;
    [SerializeField] private Button exit;

    void Start()
    {
        start.onClick.AddListener(TaskOnClickStart);
        exit.onClick.AddListener(TaskOnClickExit);
    }

    private void OnDestroy()
    {
        start.onClick.RemoveListener(TaskOnClickStart);
        exit.onClick.RemoveListener(TaskOnClickExit);
    }

    void TaskOnClickStart()
    {
        SceneManager.LoadScene(1);
    }
    void TaskOnClickExit()
    {
        Application.Quit();
    }
}
