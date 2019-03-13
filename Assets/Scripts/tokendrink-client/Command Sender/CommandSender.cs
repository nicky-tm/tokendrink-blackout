using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class CommandSender : MonoBehaviour {

    MqttHandler mqtt;

    public string ip = "127.0.0.1";
    public int port = 1337;

    public GameObject commandForm, connectionForm;

    string msg;

    private void Start () {
        mqtt = FindObjectOfType<MqttHandler>();

        commandForm.SetActive(true);
        commandForm.SetActive(false);
    }

    public void MakeConnection () {
        mqtt.Connect(IPAddress.Parse(ip), port);

        connectionForm.SetActive(false);
        commandForm.SetActive(true);
    }

    public void UpdateMsg (string msg) {
        this.msg = msg;
    }

    public void UpdateIP (string ip) {
        this.ip = ip;
    }

    public void UpdatePort ( string portString ) {
        this.port = int.Parse(portString);
    }

    public void Send () {
        mqtt.Publish("blackout", msg);
    }

}