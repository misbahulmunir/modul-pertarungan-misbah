using UnityEngine;
using ModulPertarungan;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class TileMap : MonoBehaviour
{

    private int size_x = 34; //ukuran grid [size_x X size_y]
    private int size_y = 22;
    private float tileSize = 1.0f; //ukuran tile

    private Texture2D texTiles; //texture tile
 

    private int tileRes = 32; // resolusi tile 
    private int posX = 5; //posisi awal pulau
    private int posY = 5; //posisi awal pulau
    private int[,] dun_node;

    public int landSize = 30;// ukuran pulau
    public int landNum = 5; //jumlah pulau

    public List<GameObject> butID;
    public GameObject butObj; 
 
    // Use this for initialization
    void Start()
    {
                
    }

    void Awake()
    {
        butID = new List<GameObject>();
        BuildMesh(); //membuat mesh
    }

    Color[][] ChopUpTiles(Texture2D texTile) //memotong texture tile berdasarkan ukuran pixel
    {
        int numColumn = texTile.width / tileRes; //jumlah kolom dari tiles
        int numRows = texTile.height / tileRes; //jumlah row dari tiles

        Color[][] tiles = new Color[numColumn * numRows][]; //array untuk menampung texture

        for (int y = 0; y < numRows; y++)
        {
            for (int x = 0; x < numColumn; x++)
            {
                tiles[y * numColumn + x] = texTile.GetPixels(x * tileRes, y * tileRes, tileRes, tileRes); //mendapatkan warna tiap pixel dari texture
            }
        }

        return tiles;
    }

    private void BuildTexture()
    {
        Map map = new Map(size_x, size_y, posX, posY, landSize, landNum);//fungsi generate map    
        string tile = "Map/TextureMap/" + TextureSingleton.Instance().TextureTiles;
        Debug.Log(tile);
        texTiles = Resources.Load(tile) as Texture2D;
        int texWidth = size_x * tileRes; //ukuran texture
        int texHeight = size_y * tileRes;
        Texture2D texture = new Texture2D(texWidth, texHeight); // set texture

        Color[][] tiles = ChopUpTiles(texTiles);//mendapatkan warna tiap bagian tiles

        for (int y = 0; y < size_y; y++)
        {
            for (int x = 0; x < size_x; x++)
            {
                Color[] p = tiles[map.GetTileAt(x, y)];//mendapatkan texture dari generate map
                texture.SetPixels(x * tileRes, y * tileRes, tileRes, tileRes, p);//set texture pixel untuk ditampilkan pada layar
            }
        }

        texture.filterMode = FilterMode.Point; // filter mode --> point
        texture.wrapMode = TextureWrapMode.Clamp; // wrap mode --> clamp
        texture.Apply(); //menampilkan texture pada layar

        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>(); //init mesh render
        mesh_renderer.sharedMaterials[0].mainTexture = texture; //set texture pada mesh

        dun_node = new int[size_x, size_y];
        dun_node = map.GetButtonPos();
        int count = 0;
        for (int i = 0; i < size_x; i++)
        {
            for (int j = 0; j < size_y; j++)
            {
                if (dun_node[i, j] == 1)
                {                    
                    GameObject button = (GameObject)Instantiate(butObj, new Vector3(i, j, 0), Quaternion.identity);
                    
                    if (TextureSingleton.Instance().QuestActive[count] == true)
                    {
                        button.renderer.material.color = Color.green;
                    }
                    else
                    {
                        button.renderer.material.color = Color.red;
                    }
                    if (TextureSingleton.Instance().QuestCleared[count] == true)
                    {
                        button.name = "Button_" + count + "_clear";
                    }
                    else
                    {
                        button.name = "Button_" + count + "_unclear";
                    }
                    butID.Add(button);
                    count++;
                }
            }
        }
        
        //Debug.Log ("Done Texture!");
    }//menampilkan texture

    public void BuildMesh() //membangun grid menggunakan mesh
    {
        int numTiles = size_x * size_y; //jumlah tiles
        int numTris = numTiles * 2; // jumlah segitiga


        int vsize_x = size_x + 1; //ukuran vertex
        int vsize_z = size_y + 1;
        int numVerts = vsize_x * vsize_z; //jumlah vertex

        // Generate the mesh data
        Vector3[] vertices = new Vector3[numVerts]; //init vertex
        Vector3[] normals = new Vector3[numVerts]; //init posisi normal
        Vector2[] uv = new Vector2[numVerts]; // init uv

        int[] triangles = new int[numTris * 3];

        #region Membuat Vertex
        for (int y = 0; y < vsize_z; y++)
        {
            for (int x = 0; x < vsize_x; x++)
            {
                vertices[y * vsize_x + x] = new Vector3(x * tileSize, y * tileSize, 0);
                normals[y * vsize_x + x] = Vector3.forward;
                uv[y * vsize_x + x] = new Vector2((float)x / size_x, (float)y / size_y);
            }
        }
        //Debug.Log ("Done Verts!");
        #endregion

        #region Membuat Segitiga
        for (int y = 0; y < size_y; y++)
        {
            for (int x = 0; x < size_x; x++)
            {
                int squareIndex = y * size_x + x;
                int triOffset = squareIndex * 6;
                triangles[triOffset + 0] = y * vsize_x + x + 0;
                triangles[triOffset + 2] = y * vsize_x + x + vsize_x + 1;
                triangles[triOffset + 1] = y * vsize_x + x + vsize_x + 0;

                triangles[triOffset + 3] = y * vsize_x + x + 0;
                triangles[triOffset + 5] = y * vsize_x + x + vsize_x + 1;
                triangles[triOffset + 4] = y * vsize_x + x + 1;
            }
        }

        //Debug.Log ("Done Triangles!");
        #endregion
        // membuat mesh baru dan diisi dengan data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // set filter/renderer/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;
        mesh_collider.sharedMesh = mesh;
        //Debug.Log ("Done Mesh!");

        BuildTexture();
    }

}
