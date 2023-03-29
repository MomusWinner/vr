using UnityEngine;

public class InteractionTeleport : ObjectInteraction
{
    public Transform player { get; private set; }

    public new void Start()
    {
        player = Player.singaleton.transform;
        base.Start();
    }

    public override void CommitAtGlance()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z);
    }
}
