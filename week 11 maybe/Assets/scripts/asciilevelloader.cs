using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class asciilevelloader : MonoBehaviour
{

    //variables

    //offset values
    public float xOffset;

    public float yOffset;

    //string to hold a filename int to hold a level
    public string filename;

    private int currentLevel = 0;


    //properly wrap currentlevel into a new loaded level

    public int CurrentLevel
    {
        get { return  currentLevel; }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }


        //prefabs needed for the level loader

        public GameObject player;
        public GameObject wall;
        public GameObject obstical;
        public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
       LoadLevel(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //make a game object that holds the level

    public GameObject levelhold;

    public void LoadLevel()
    {
        Destroy(levelhold);
        levelhold = new GameObject("Level");

        //build a level path to the current level
      string current_file_path = Application.dataPath + "/Levels/" + filename.Replace("Num", currentLevel + "");

     //pull file contents into a string array
     //take each line and make it a different item in the array

     string[] fileLines = File.ReadAllLines(current_file_path);

     //make each line a seperate item in the array

      for (int y = 0; y < fileLines.Length; y++)
      {
        //get the line of text
        string lineText = fileLines[y];

         //sperate lines into charatcers or text

       char[] characters = lineText.ToCharArray();

        for (int x = 0; x < characters.Length; x++)
        {
                //get current character

            char c = characters[x];

            //variable for a new object
             GameObject newOBJ;

            //switch statement a bunch of if statements in a row
            switch (c)
            {
                //if letter is p in text
                case 'p' : 
                //make player game object
                newOBJ = Instantiate<GameObject>(player);
                break;

                //if the letter is w
                case 'w' :
                //make a wall
                newOBJ = Instantiate<GameObject>(wall);
                break;

                //if letter is !
                case '!' :
                //make an obstical
                newOBJ = Instantiate<GameObject>(obstical);
                break;

                //if letter is *
                case '*' :
                //make a goal
                newOBJ = Instantiate<GameObject>(goal);
                break;
                //if the letters are anything else
                default:
                newOBJ = null;
                break;

            }

            //check if new object is null or the player and if it is niether make it a child of the level game object
            if(newOBJ != null)
            {
                //check if it is the player
                if(!newOBJ.name.Contains("Player"))
                {
                    //make the level object the parent of the new object
                    newOBJ.transform.parent = levelhold.transform;
                }

                newOBJ.transform.position = new Vector3(x + xOffset, -y + yOffset, 0);
            }

        }

      }

     

      }

    
    
}
