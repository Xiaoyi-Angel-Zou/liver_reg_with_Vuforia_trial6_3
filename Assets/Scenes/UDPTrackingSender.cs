using UnityEngine;
using Vuforia;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPClient1 : MonoBehaviour
{
    public Transform targetTransform;
    private UdpClient client;
    private IPEndPoint endPoint;

    public string remoteIP = "10.71.237.140"; // python receiver's IP address
    public int remotePort = 5005;

    void Start()
    {
        client = new UdpClient();
        endPoint = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = targetTransform.position;
        //Quaternion rotation = transform.rotation;

        // construct string for sending
        string data = $"{position.x},{position.y},{position.z}";

        // code into byte[]
        byte[] bytes = Encoding.UTF8.GetBytes(data);

        // send data
        client.Send(bytes, bytes.Length, endPoint);

        // optional
        Debug.Log("Sent: " + data);
    }

    void OnApplicationQuit()
    {
        client.Close();
    }
}
