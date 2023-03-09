using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionTeleport : MonoBehaviour
{
    public Material InactiveMaterial;

    public Material GazedAtMaterial;


    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    Transform player;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;


    public float timeRemaining = 3f;
    private bool _isActive = false;

    public void Start()
    {
        player = Player.singaleton.transform;
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    IEnumerator Timer(float timå)
    {
        if (timå > 0 && _isActive)
        {
            timå -= 0.1f;
            yield return new WaitForSeconds(0.1f);
            Debug.Log(timå);
            StartCoroutine(Timer(timå));
        }
        else if (timå <= 0)
        {
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            yield return null;
        }
        else if (_isActive == false)
        {
            yield return null;
        }
    }

    public void TeleportRandomly()
    {
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
        GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
        float height = Random.Range(_minObjectHeight, _maxObjectHeight);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
                                     Mathf.Sin(angle) * distance);


        transform.parent.localPosition = newPos;

        randomSib.SetActive(true);
        gameObject.SetActive(false);
        SetMaterial(false);
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

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
