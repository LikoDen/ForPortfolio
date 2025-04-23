using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerStayAction : MonoBehaviour
{
    public UnityEvent onStay;
    private bool isPlayerInTrigger = false;
    private float timeInTrigger = 0f;
    public float triggerStayTime = 2f;
    private Color initialColor;
    private Material materialToChange;

    private void Start()
    {
        materialToChange = GetComponent<Renderer>().material;
        initialColor = materialToChange.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            timeInTrigger = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            materialToChange.color = initialColor;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            timeInTrigger += Time.deltaTime;
            if (timeInTrigger >= triggerStayTime)
            {
                materialToChange.color = initialColor;
                isPlayerInTrigger = false;
                InvokeEvent();
            }
            else
            {
                float lerpValue = timeInTrigger / triggerStayTime;
                materialToChange.color = Color.Lerp(initialColor, Color.green, lerpValue);
            }
        }
    }

    public void InvokeEvent()
    {
        StartCoroutine(StartEvent());
    }

    IEnumerator StartEvent()
    {
        yield return new WaitForSeconds(0.1f);
        onStay?.Invoke();
    }
}