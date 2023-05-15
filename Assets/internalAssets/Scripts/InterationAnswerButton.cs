using UnityEngine;

public class InterationAnswerButton : ObjectInteraction
{
    [SerializeField]
    private bool Answer;

    [SerializeField]
    private Resistance—ontrol resistanceControl;

    public override void CommitAtGlance()
    {
        resistanceControl.CheckAnswer(Answer);
    }
}
