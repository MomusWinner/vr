using UnityEngine;

public class InteractionSpawnController : InteractionController
{ 

    [SerializeField]
    private GameObject controller;

    public override void CommitAtGlance()
    {
        if(player.GetComponent<Player>().isTake())
        {
            controller.SetActive(true);
            player.GetComponent<Player>().Put();
        }
    }
}
