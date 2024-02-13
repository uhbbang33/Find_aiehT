using UnityEngine;

public class test : MonoBehaviour
{

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GameManager.Instance.Player.transform.position = new Vector3(-5, 0, 0);
            LoadingSceneController.LoadScene(SceneName.VillageScene);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            GameManager.Instance.Player.transform.position = new Vector3(5, 0, 8);
            LoadingSceneController.LoadScene(SceneName.TycoonScene);
        }


        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GameManager.Instance.Player.transform.position = new Vector3(0, 0, 0);
            LoadingSceneController.LoadScene(SceneName.DungeonScene);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            GameManager.Instance.Player.transform.position = new Vector3(-2, 0, 25);
            LoadingSceneController.LoadScene(SceneName.Field);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameManager.Instance.Player.transform.position = new Vector3(0, 0, 0);
            LoadingSceneController.LoadScene("KJW");
        }



        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManager.Instance.Player.GetComponent<Rigidbody>().AddForce(Vector3.up * 5+Vector3.forward*5, ForceMode.Impulse);
        }

    }
}
