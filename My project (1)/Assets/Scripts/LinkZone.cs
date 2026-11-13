using UnityEngine;
using UnityEngine.InputSystem;
 
public class LinkZone : MonoBehaviour
{
    public GameObject prompt;   // PRESS E 글자
    private bool playerNear;

    public string webLink;
 
    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;   // 플레이 중 큐브 숨김
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerNear = true;
        prompt.SetActive(true);
    }
 
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerNear = false;
        prompt.SetActive(false);
    }
 
    private void Update()
    {
        if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
            Application.OpenURL(webLink);
    }
}
