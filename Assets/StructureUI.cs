using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUI : MonoBehaviour
{
    [SerializeField] Structure structure;
    [SerializeField] Image image;

    public Structure GetStructure()
    {
     

        return structure;
    }
}
