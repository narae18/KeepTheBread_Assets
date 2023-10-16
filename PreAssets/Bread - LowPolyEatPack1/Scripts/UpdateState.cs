using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateState : MonoBehaviour
{
    public enum ScriptType {
        WithAPlate = 0,
        WithoutAPlate = 1
    }
    public ScriptType scriptType = (ScriptType)0;

    public int state = 0;
    private int curentState = -1;

    public GameObject platePrefab;
    private GameObject instantiatePlateGO = null;
    public float plateHeight;

    public GameObject[] prefabStates;

    void Update() {
        if (curentState != state) {
            if (scriptType == (ScriptType)0) {
                /*
                 * state 0 = clear
                 * state 1..n-2 = cake state
                 * state n-1 = plate
                 * state n = clear
                 */
                if (state < 0) state = 0;
                else if (state > prefabStates.Length + 2) state = prefabStates.Length + 2;

                if (curentState != state) {
                    List<GameObject> gameObjects = new List<GameObject>();
                    if (state == 0 || state == prefabStates.Length + 2) {
                        instantiatePlateGO = null;
                    } else if (state == prefabStates.Length + 1) {
                        if (platePrefab != null) {
                            if (instantiatePlateGO == null) instantiatePlateGO = InstantiatePlateGO();
                            gameObjects.Add(instantiatePlateGO);
                        }
                    } else {
                        if (platePrefab != null) {
                            if(instantiatePlateGO == null) instantiatePlateGO = InstantiatePlateGO();
                            gameObjects.Add(instantiatePlateGO);
                        }
                        GameObject gameObject = InstantiateGameObjectByStateId(state - 1);
                        gameObjects.Add(gameObject);
                    }
                    DestroyOldGameObject(gameObjects);
                    curentState = state;
                }
            } else if (scriptType == (ScriptType)1) {
                /*
                * state 0 = clear
                * state 1..n-1 = cake state
                * state n = clear
                */
                if (state < 0) state = 0;
                else if (state > prefabStates.Length + 1) state = prefabStates.Length + 1;

                if (curentState != state) {
                    List<GameObject> gameObjects = new List<GameObject>();
                    if (state == 0 || state == prefabStates.Length + 1) {
                    } else {
                        GameObject gameObject = InstantiateGameObjectByStateId(state - 1);
                        gameObjects.Add(gameObject);
                    }
                    DestroyOldGameObject(gameObjects);
                    curentState = state;
                }
            }
        }
    }

    private GameObject InstantiatePlateGO() {
        GameObject newObject = Instantiate(platePrefab);
        newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        newObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        newObject.transform.SetParent(this.gameObject.transform);
        return newObject;
    }

    private GameObject InstantiateGameObjectByStateId(int id) {
        if (id < prefabStates.Length) {
            GameObject newObject = Instantiate(prefabStates[id]);
            newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (plateHeight * this.gameObject.transform.localScale.y), this.gameObject.transform.position.z);
            newObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            newObject.transform.SetParent(this.gameObject.transform);
            return newObject;
        } else return null;
    }
    

    private void DestroyOldGameObject (List<GameObject> gameObjects) {
        foreach (Transform child in this.gameObject.transform) {
            bool needDelete = true;
            foreach(GameObject gameObject in gameObjects) {
                if (child.Equals(gameObject.transform)) {
                    needDelete = false;
                    break;
                }
            }
            if (needDelete) Destroy(child.gameObject);
        }
    }
}
