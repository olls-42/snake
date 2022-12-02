
using UnityEngine;


namespace Game
{
    public class Food : MonoBehaviour
    {
        public int GridX {get; set;}
        public int GridY {get; set;}

        // Start is called before the first frame update
        void Start()
        {
            this.RandomPosition();
        }

        public void RandomPosition()
        {
            this.GridX = Random.Range(-Grid.Width/2, Grid.Width/2);
            this.GridY = Random.Range(-Grid.Height/2, Grid.Height/2);
            this.transform.position = Grid.GetWorldPosition(this.GridX, this.GridY);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        /*
        void OnCollisionEnter(Collision collision)
        {
            //Check for a match with the specified name on any GameObject that collides with your GameObject
            if (collision.gameObject.name == "Snake")
            {
                //If the GameObject's name matches the one you suggest, output this message in the console
                Debug.Log("Do something here");
            }

            //Check for a match with the specific tag on any GameObject that collides with your GameObject
            if (collision.gameObject.tag == "MyGameObjectTag")
            {
                //If the GameObject has the same tag as specified, output this message in the console
                Debug.Log("Do something else here");
            }
        }
        */
    }
}
