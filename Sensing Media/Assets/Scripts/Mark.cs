﻿using UnityEngine;
using System.Collections;

public class Mark : MonoBehaviour {

    public GameObject linePrefab;
    public float lineWidth;
    public float lineZPos;
    public float minDist;

    private GameObject newLine;
    private LineRenderer currentLine;
    private int vertices;
    private Camera mainCam;
    private Vector3 newPos;
    private Vector3 tempPos;

    void Start() {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        lineZPos = lineZPos - mainCam.transform.position.z;
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Return)) {
            ClearAll();
        }
        if (Input.GetMouseButtonDown(0)) {
            NewLine();
        }
        if (Input.GetMouseButton(0)) {
            if (currentLine == null) {
                NewLine();
            }
            newPos = mainCam.ScreenToViewportPoint(Input.mousePosition);

            if (Vector3.Distance(newPos, tempPos) > minDist) {
                tempPos = newPos;
                vertices++;
                currentLine.SetVertexCount(vertices);
                currentLine.SetPosition(vertices - 1, mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lineZPos)));
            }
        }
    }

    private void NewLine() {
        newLine = (GameObject)Instantiate(linePrefab);
        newLine.transform.parent = this.transform;
        vertices = 0;
        currentLine = newLine.GetComponent<LineRenderer>();
        currentLine.SetWidth(mainCam.orthographicSize / 100 * lineWidth, mainCam.orthographicSize / 100 * lineWidth);
        tempPos = mainCam.ScreenToViewportPoint(Input.mousePosition);
        vertices++;
        currentLine.SetVertexCount(vertices);
        currentLine.SetPosition(vertices - 1, mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lineZPos)));
    }

    public void ClearAll() {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}

