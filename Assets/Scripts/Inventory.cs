using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Movement movement;
    public Rigidbody2D StonePrefab;
    public int stones = 10;
    public float throwingForce = 100f;
    private bool canPickUpStone = false;
    private bool isTorchInHand = false;
    private bool canPickUpTorch = false;
    Collider2D StoneColl = null;
    Collider2D TorchColl = null;
    public SpriteRenderer torchRenderLayer;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {

    }
    void Update()
    {

        PickingUpStone();
        ThrowingStone();
        PickingUpTorch();
    }
    void ThrowingStone()
    {


        if (Input.GetKeyDown(KeyCode.F) && stones > 0 && Input.mousePosition.x > 0 && Input.mousePosition.y > 0)
        {

            Rigidbody2D stoneInstance;
            stoneInstance = Instantiate(StonePrefab, GameObject.Find("HandCenter").transform.position, Quaternion.Euler(0, 0, 0));
            //Vector2 stoneDirection1 = (movement.isFacingRight == false ? new Vector2(-Mathf.Sqrt(3) / 2, 0.5f) : new Vector2(Mathf.Sqrt(3) / 2, 0.5f));
            Vector2 stoneDirection = new Vector2(Input.mousePosition.x - movement.characterScreenPos.x, Input.mousePosition.y - movement.characterScreenPos.y).normalized;
            //Vector2 stoneDirection2 = new Vector2(Input.mousePosition.x - Screen.width / 2 +transform.position.x%(Screen.width / 2), Input.mousePosition.y - Screen.height / 2+transform.position.y%(Screen.width / 2)).normalized;
            stoneInstance.AddForce(stoneDirection * throwingForce);
            stones--;
            Debug.Log(stoneDirection);
            // Vector2 stoneDirection2 = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2).normalized;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Stone"))
        {
            StoneColl = col;
            canPickUpStone = true;
        }

        if (col.gameObject.CompareTag("Torch"))
        {
            TorchColl = col;
            canPickUpTorch = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Stone"))
        {
            StoneColl = null;
            canPickUpStone = false;
        }
        if (col.gameObject.CompareTag("Torch"))
        {
            TorchColl = null;
            canPickUpTorch = false;
        }
    }
    void PickingUpStone()
    {
        if (canPickUpStone)
        {
            Debug.Log("InStone");

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(PickingUpStoneCourutine());

            }
        }
    }
    private IEnumerator PickingUpStoneCourutine()
    {
        animator.Play("New_pickup");
        movement.IsCharacterCanWalk = false;
        yield return new WaitForSeconds(0.7f);

        if (StoneColl)
        {
            Destroy(StoneColl.transform.root.gameObject);
            stones++;
        }
        movement.IsCharacterCanWalk = true;
    }
    void PickingUpTorch()
    {

        if (canPickUpTorch && !isTorchInHand)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                torchRenderLayer = TorchColl.GetComponent<SpriteRenderer>();
                //Debug.Log(torchRenderLayer.sortingOrder);
                torchRenderLayer.sortingLayerName = "Torch";
                // TorchColl.gameObject.transform.position = GameObject.Find("HandCenter").transform.position;
                TorchColl.gameObject.transform.SetParent(GameObject.Find("HandCenter").transform);
                TorchColl.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                TorchColl.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                // TorchColl.gameObject.transform.localPosition = new Vector3(TorchColl.gameObject.transform.localPosition.x + 1.15f, TorchColl.gameObject.transform.localPosition.y + 2.67f, 0);
                // TorchColl.gameObject.transform.localEulerAngles -= new Vector3(0, 0, 60f);
                isTorchInHand = true;
            }
        }

    }


}

