using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : ObjectInteraction
{
    public GameObject player { get; private set; }

    public new void Start()
    {
        player = Player.singaleton.gameObject;
        base.Start();
    }

    public override void CommitAtGlance()
    {
        gameObject.SetActive(false);
        player.GetComponent<Player>().Take();
    }


}
