using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PuzzleCube : MonoBehaviour
{
    void Start()
    {
        // 4x4 그리드를 위한 버텍스와 삼각형 배열 정의
        Vector3[] vertices = new Vector3[96]; // 6면 * 16 버텍스 (4x4 그리드)
        int[] triangles = new int[324]; // 6면 * 9 사각형 * 2 삼각형 * 3 인덱스

        int vIndex = 0; // 버텍스 인덱스
        int tIndex = 0; // 삼각형 인덱스

        float step = 1f / 3f; // 그리드 간격 (3x3으로 나누기)

        // 각 면 정의 (6면 순회)
        for (int face = 0; face < 6; face++)
        {
            // 면 방향 계산
            Vector3 normal = Vector3.zero;
            Vector3 up = Vector3.zero;
            Vector3 right = Vector3.zero;

            if (face == 0) { normal = Vector3.forward; up = Vector3.up; right = Vector3.right; }   // 앞면
            if (face == 1) { normal = Vector3.back; up = Vector3.up; right = Vector3.left; }      // 뒷면
            if (face == 2) { normal = Vector3.up; up = Vector3.back; right = Vector3.right; }     // 윗면
            if (face == 3) { normal = Vector3.down; up = Vector3.forward; right = Vector3.right; } // 아랫면
            if (face == 4) { normal = Vector3.right; up = Vector3.up; right = Vector3.back; }     // 오른쪽
            if (face == 5) { normal = Vector3.left; up = Vector3.up; right = Vector3.forward; }   // 왼쪽

            Vector3 origin = normal * 0.5f; // 면 중심

            // 그리드 생성
            for (int y = 0; y < 4; y++) // 4x4 그리드 (행)
            {
                for (int x = 0; x < 4; x++) // 열
                {
                    vertices[vIndex++] = origin + (x * step - 0.5f) * right + (y * step - 0.5f) * up;
                }
            }

            // 삼각형 정의 (3x3 그리드에서 각 사각형)
            int startIndex = face * 16; // 현재 면의 시작 버텍스 인덱스
            for (int y = 0; y < 3; y++) // 3x3 그리드
            {
                for (int x = 0; x < 3; x++)
                {
                    int topLeft = startIndex + y * 4 + x;
                    int topRight = topLeft + 1;
                    int bottomLeft = topLeft + 4;
                    int bottomRight = bottomLeft + 1;

                    // 첫 번째 삼각형
                    triangles[tIndex++] = topLeft;
                    triangles[tIndex++] = topRight;
                    triangles[tIndex++] = bottomRight;

                    // 두 번째 삼각형
                    triangles[tIndex++] = topLeft;
                    triangles[tIndex++] = bottomRight;
                    triangles[tIndex++] = bottomLeft;
                }
            }
        }

        // 새 Mesh 생성 및 적용
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals(); // 노멀 계산

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
