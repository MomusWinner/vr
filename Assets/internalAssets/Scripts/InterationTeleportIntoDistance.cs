using UnityEngine;

public class InterationTeleportIntoDistance : InteractionTeleport
{
    [SerializeField]
    private Transform endPoint;

    public override void CommitAtGlance()
    {
        player.transform.position = endPoint.position;

    }
}
