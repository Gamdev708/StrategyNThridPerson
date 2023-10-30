using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Structure selectedBuiliding;
    [SerializeField] float speed;

    [SerializeField] Camera ThirdPersonCamera;
    [SerializeField] Camera Overview;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera.SetupCurrent(ThirdPersonCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Camera.main== Overview)
            {
                Camera.SetupCurrent(ThirdPersonCamera);
            }
            if (Camera.main== ThirdPersonCamera)
            {
                Camera.SetupCurrent(Overview);
            }
        }


        Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));

        transform.Translate(vector* speed * Time.deltaTime);
    }

    public void SetBuildingToBuild(Structure structure)
    {
        //Debug.Log("Player took:" + structure.name);
        selectedBuiliding = structure;
    }
    public Structure GetBuildingToBuild()
    {
        return selectedBuiliding;
    }
}
