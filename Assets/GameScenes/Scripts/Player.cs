using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player singaleton { get; private set; }

    [SerializeField]
    private GameObject controller;

    private void Awake()
    {
        singaleton = this;
    }

    public void Take()
    {
        controller.SetActive(true);
    }

    public void Put()
    {
        controller.SetActive(false);
    }

    public bool isTake()
    {
        return controller.activeSelf;
    }
}
