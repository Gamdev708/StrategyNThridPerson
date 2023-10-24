using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulidingHUD : MonoBehaviour
{
    [SerializeField] List<StructureUI> structures;
    [SerializeField] GameObject structureContainer;

    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (structures != null)
        //{
        //    if (structures.Count>0)
        //    {
        //        In
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        player.SetBuildingToBuild(null);
    }
}
