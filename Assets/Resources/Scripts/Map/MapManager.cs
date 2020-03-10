using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    public int mapRows, mapColumns, minRoomSize, maxRoomSize;
    public GameObject floorTile;
    private GameObject[,] mapFloorPositions;

    public class DungeonDivision {
        public DungeonDivision left, right;
        public Rect rect, room = new Rect(-1, -1, 0, 0);
        public int id;

        private static int debugCounter = 0;

        public DungeonDivision(Rect mrect) {
            rect = mrect;
            id = debugCounter;
            ++debugCounter;
        }

        public bool IsDivided() {
            return !(left == null && right == null);
        }

        public bool Divide(int minRoomSize, int maxRoomSize) {
            if (IsDivided() || Mathf.Min(rect.height, rect.width) < minRoomSize)
                return false;

            if ((rect.height / rect.width) > 1.0) {
                int divideAt = Random.Range(minRoomSize, (int)(rect.width - minRoomSize));
                left = new DungeonDivision(new Rect(rect.x, rect.y, rect.width, divideAt));
                right = new DungeonDivision(new Rect(rect.x, rect.y + divideAt, rect.width, rect.height - divideAt));
            } else {
                int divideAt = Random.Range(minRoomSize, (int)(rect.height - minRoomSize));
                left = new DungeonDivision(new Rect(rect.x, rect.y, divideAt, rect.height));
                right = new DungeonDivision(new Rect(rect.x + divideAt, rect.y, rect.width - divideAt, rect.height));
            }
            return true;
        }

        public void CreateRoom() {
            if (left != null) left.CreateRoom();
            if (right != null) right.CreateRoom();

            if (!IsDivided()) {
                int roomWidth = (int) Random.Range(rect.width / 2, rect.width - 2);
                int roomHeight = (int) Random.Range(rect.height / 2, rect.height - 2);
                int roomX = (int) Random.Range(1, rect.width - roomWidth - 1);
                int roomY = (int) Random.Range(1, rect.height - roomHeight - 1);
                room = new Rect(rect.x + roomX, rect.y + roomY, roomWidth, roomHeight);
                Debug.Log("Created room " + room + " in sub-dungeon " + id + " " + rect);
            }
        }
    }

    public void GenerateRoom(DungeonDivision division) {
        if (!division.IsDivided()) {
            if (division.rect.width > maxRoomSize || division.rect.height > maxRoomSize) {
                if (division.Divide(minRoomSize, maxRoomSize)) {
                    Debug.Log("Splitted sub-dungeon " + division.id + " in "
                        + division.left.id + ": " + division.left.rect + ", "
                        + division.right.id + ": " + division.right.rect);
                    GenerateRoom(division.left);
                    GenerateRoom(division.right);
                }
            }
        }
    }

    public void DrawRooms(DungeonDivision division) {
        if (division == null) return;
        if (!division.IsDivided()) {
            for (int i = (int) division.room.x; i < division.room.xMax; i++) {
                for (int j = (int) division.room.y; j < division.room.yMax; j++) {
                    GameObject instance = Instantiate(floorTile, new Vector3(i, j, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(transform);
                    mapFloorPositions[i, j] = instance;
                }
            }
        } else {
            DrawRooms(division.left);
            DrawRooms(division.right);
        }
    }

    void Start() {
        DungeonDivision root = new DungeonDivision(new Rect(0, 0, mapRows, mapColumns));
        GenerateRoom(root);
        root.CreateRoom();
        mapFloorPositions = new GameObject[mapRows, mapColumns];
        DrawRooms(root);
    }
}
