using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractionMovementScene : ObjectInteraction
{
    [SerializeField]
    private int sceneNumber;

    public override void CommitAtGlance()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
