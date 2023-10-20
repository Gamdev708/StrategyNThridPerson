using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StructurePlaceHolder : MonoBehaviour
{
    [SerializeField] Structure structure;
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject textHolder;

    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (structure != null)
        {
            Instantiate(structure,transform.position,Quaternion.identity).transform.SetAsLastSibling();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {

        if (structure!=null)
        {
            indicator.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
            if (Input.GetMouseButtonDown(0))
            {
                structure= player.GetBuildingToBuild();
                Instantiate(structure, gameObject.transform).transform.SetAsLastSibling();
            }
        }
        else
        {
            indicator.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
            textHolder.SetActive(true);
            textHolder.GetComponentInChildren<TextMeshProUGUI>().text = "Place a tower here";
        }
    }

    private void OnMouseExit()
    {
        indicator.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255);
        textHolder.GetComponentInChildren<TextMeshProUGUI>().text =string.Empty;
        textHolder.SetActive(false);
    }
}
