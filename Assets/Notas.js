/*== When spawning
  NetCorrector nc = go.GetComponent<NetCorrector>();
  nc.rotation = go.transform.rotation;
  nc.scale = go.transform.localScale;
  NetworkServer.Spawn(go);


== To Update position/scaling

using UnityEngine;
using UnityEngine.Networking;
using System;

public class NetCorrector : NetworkBehaviour {
    [SyncVar]
    public Vector3 scale;
    [SyncVar]
    public Quaternion rotation;
    [SyncVar]
    public string objName;

    void Start () {
        transform.localScale = scale;
        transform.rotation = rotation;
        gameObject.name = objName;
    }
}*/