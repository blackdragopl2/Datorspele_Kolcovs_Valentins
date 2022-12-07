using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    private Rigidbody rb;
    private int currentLevel;
    public GameObject[] levels;
    private Color customColor = new Color(1.0f, 0.5f, 0f, 1.0f);
    private Color customColorWalls = new Color(0f, 0.5f, 1.0f, 1.0f);
    private Color invisibleWalls = new Color(1.0f, 1.0f, 1.0f, 0f);
    private Renderer[] walls;
    public GameObject borderWalls;
    public Material solidMaterial;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.text = "";

        walls = borderWalls.GetComponentsInChildren<Renderer>();
        foreach(Renderer obj in walls)
        {
            obj.material.SetColor("_Color",invisibleWalls);
        }
        levels[0].GetComponent<Renderer>().material = solidMaterial;
        levels[0].GetComponent<Renderer>().material.SetColor("_Color",customColor);
        walls = levels[0].GetComponentsInChildren<Renderer>();
        foreach(Renderer obj in walls)
        {
            if(obj.tag == "wall")
            {
                obj.material = solidMaterial;
                obj.material.SetColor("_Color",customColorWalls);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Next_level")){
            other.transform.parent.gameObject.SetActive(false);
            currentLevel = currentLevel+1;
            levels[currentLevel].GetComponent<Renderer>().material = solidMaterial;
            levels[currentLevel].GetComponent<Renderer>().material.SetColor("_Color",customColor);
            walls = levels[currentLevel].GetComponentsInChildren<Renderer>();
            foreach(Renderer obj in walls)
            {
                if(obj.tag == "wall")
                {
                    obj.material = solidMaterial;
                    obj.material.SetColor("_Color",customColorWalls);
                }
            }
        }
        if(currentLevel >= 4)
        {
            winText.text = "YOU WIN!";
        }
    }

}
