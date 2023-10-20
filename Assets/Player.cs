using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Structure selectedBuiliding;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(Input.GetAxis("Vertical"), 0,-Input.GetAxis("Horizontal"));

        transform.Translate(vector* speed * Time.deltaTime);
    }

    public void SetBuildingToBuild(Structure structure)
    {
        selectedBuiliding=structure;
    }
    public Structure GetBuildingToBuild()
    {
        return selectedBuiliding;
    }
}
