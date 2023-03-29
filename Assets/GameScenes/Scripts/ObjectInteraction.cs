using System.Collections;
using UnityEngine;

public abstract class ObjectInteraction : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;


    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;


    public float timeRemaining = 3f;
    private bool _isActive = false;

    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    public abstract void CommitAtGlance();

    IEnumerator Timer(float timå)
    {
        if (timå > 0 && _isActive)
        {
            timå -= 0.1f;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Timer(timå));
        }
        else if (timå <= 0)
        {
            CommitAtGlance();
            yield return null;
        }
        else if (_isActive == false)
        {
            yield return null;
        }
    }

    public void OnPointerEnter()
    {
        _isActive = true;
        StartCoroutine(Timer(timeRemaining));
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        _isActive = false;
        SetMaterial(false);
    }

    public void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
