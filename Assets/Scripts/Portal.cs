using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Vector3 destination_POS;    

    [SerializeField] GameObject destination_Portal;
    [SerializeField] bool teleportPlayer = true;
    [SerializeField] bool teleportTeleporter = false;
    [SerializeField] bool singleUse = false;
    [SerializeField] AudioSource warpSFX;
    [SerializeField] AudioSource activeSFX;

    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        destination_POS = destination_Portal.transform.position;
        ps = GetComponent<ParticleSystem>();
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (teleportPlayer == true)
            {
                StartCoroutine(TeleportPlayer(other));
            }
            else if (teleportTeleporter == true)
            {
                Invoke("TeleportTeleporter", warpSFX.clip.length);
            }
            warpSFX.PlayOneShot(warpSFX.clip, 1);
            if (singleUse == true)
            {
                GetComponent<CapsuleCollider>().enabled = false;
                ps.Stop();
                activeSFX.Stop();
                
            }
        }
    }

    private IEnumerator TeleportPlayer(Collider other)
    {
        yield return new WaitForSeconds(warpSFX.clip.length);
        other.transform.position = destination_POS;
    }

    void TeleportTeleporter()
    {
        this.transform.position = destination_POS;
    }
}
