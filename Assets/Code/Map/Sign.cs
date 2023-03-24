using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public Canvas SignAnnounce;
    GameObject SignAnnounceClone;
    string SignMessage;
    TextMeshProUGUI SignTextMesh;

    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();

            SignAnnounceClone = Instantiate(SignAnnounce, player.transform.position + new Vector3(0.05f, 1.32f, 0f), player.transform.rotation).gameObject;
            SignTextMesh = SignAnnounceClone.transform.Find("SignTextMesh").GetComponent<TextMeshProUGUI>();

            SignMessage = "Use Left and Right key(button) to move around";
            SignTextMesh.SetText(SignMessage);

            GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();

            SignAnnounceClone.transform.position = player.transform.position + new Vector3(0.05f, 1.32f, 0f);

            if(SignMessage == "Use Left and Right key(button) to move around" && Math.Abs(Input.GetAxis("Horizontal")) == 1) //first guide
            {
                SignMessage = "Good! Now press X to jump and Z to dash";
            }

            if (SignMessage == "Good! Now press X to jump and Z to dash" && (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Z)) ) // second guide
            {
                SignMessage = "Okayyy! Now use your power and throw a power energy by press C";
            }

            if (SignMessage == "Okayyy! Now use your power and throw a power energy by press C" && Input.GetKey(KeyCode.C)) // second guide
            {
                SignMessage = "Yay! First lesson in done! Now Use your skill to knock there Eagle";
            }
            SignTextMesh.SetText(SignMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            try
            {
                Destroy(SignAnnounceClone);

                GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 1f);

            } catch (Exception) { }
        }
        
    }

}
