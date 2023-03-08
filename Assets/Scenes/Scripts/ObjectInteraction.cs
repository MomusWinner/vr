using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{
    public Material InactiveMaterial;

    public Material GazedAtMaterial;

    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 700f;
    private const float _minObjectHeight = 0.1f;
    private const float _maxObjectHeight = 10f;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;


    public float timeRemaining = 3f;
    private bool _isActive = false;

    public void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    IEnumerator Timer(float timå)
    {
        if(timå > 0 && _isActive) { 
            timå -= 1f;
            yield return new WaitForSeconds(1);
            Debug.Log(timå);
            StartCoroutine(Timer(timå));
        }
        else if(timå <= 0)
        {
            SceneManager.LoadScene("MainScene");
            yield return null;
        }
        else if(_isActive == false)
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

    public void OnPointerEnter() { 
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
