using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resistance—ontrol : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;
    [SerializeField]
    private Renderer indicator;
    [SerializeField]
    private Material ifTrueMaterial;
    [SerializeField]
    private Material ifFalseMaterial;

    public GameObject body;

    private float resistance;

    public bool completed { get; private set; }

    void Start()
    {
        resistance = (float)Math.Round(UnityEngine.Random.Range(0f,5f), 2);

        text.text = $"{resistance} ÏÂÌ„‡ ŒÏ";
    }

    public void CheckAnswer(bool answer)
    {
        if(body.activeSelf)
        {
            if (answer == isCorrectAnswer(resistance))
            {
                completed = true;
                body.GetComponent<Collider>().enabled = true;
                indicator.material = ifTrueMaterial;
            }
            else
            {
                completed = false;
                body.GetComponent<Collider>().enabled = false;
                indicator.material = ifFalseMaterial;
            }
        }
    }

    private bool isCorrectAnswer(float value)
    {
        if (0.5f <= value && 2f >= value)
            return true;
        else
            return false;

    }
}
