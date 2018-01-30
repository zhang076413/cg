
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


namespace ObjTool
{
    class Programx
    {
        public static System.Drawing.Bitmap drawBitmap()
        {
            string filePath = "E:\\objModel.txt";
            string filePath2 = "E:\\objModelcopy.txt";
            //********************
            Mesh mesh = objModifier.loadMesh(filePath);

            //objModifier.saveMesh(mesh, "E:\\", "objModelcopy.txt");
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(300, 300);
            for (int x=1; x < 255;x++ )
            {
                for (int y=1; y < 255; y++)
                {
                    Color color=Color.FromArgb(x, y, 0);
                   
                    bitmap.SetPixel(x,y,color);
                }
            }
            
            return bitmap;

        }

        //oparator
        public static int operator *(face3 f3, Programx i)
        {

            return 1;
        }
        //end
    }


    class DrawingUtil{

       public static void drawPrimate(Bitmap map){
        }

    }





    class Mesh
    {
        public List<v> v;
        public List<vt> vt;
        public List<vn> vn;
        public List<face3> f3;//3边面
        public List<face4> f4;//4边面
        string s = "o";//smooth
        string g;//group
        public Mesh()
        {
            v = new List<v>();
            vt = new List<vt>();
            vn = new List<vn>();
            f3 = new List<face3>();
            f4 = new List<face4>();
        }
    }


    struct v
    {
        public double x;
        public double y;
        public double z;
        public v(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    struct vt
    {
        public double u;
        public double v;
        public vt(double u, double v)
        {
            this.u = u;
            this.v = v;
        }
    }
    struct vn
    {
        public double x;
        public double y;
        public double z;
        public vn(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    struct point
    {
        public double x;
        public double y;
        public double z;
        public point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    struct face3
    {
        public int point1;
        public int point2;
        public int point3;
        public int ut1;
        public int ut2;
        public int ut3;
        public int vn1;
        public int vn2;
        public int vn3;
        public face3(int point1, int point2, int point3, int uv1, int uv2, int uv3, int vn1, int vn2, int vn3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
            this.ut1 = uv1;
            this.ut2 = uv2;
            this.ut3 = uv3;
            this.vn1 = vn1;
            this.vn2 = vn2;
            this.vn3 = vn3;
        }
    }
    struct face4
    {
        public int point1;
        public int point2;
        public int point3;
        public int point4;
        public int ut1;
        public int ut2;
        public int ut3;
        public int ut4;
        public int vn1;
        public int vn2;
        public int vn3;
        public int vn4;
        public face4(int point1, int point2, int point3, int point4, int uv1, int uv2, int uv3, int uv4, int vn1, int vn2, int vn3, int vn4)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
            this.point4 = point4;
            this.ut1 = uv1;
            this.ut2 = uv2;
            this.ut3 = uv3;
            this.ut4 = uv4;
            this.vn1 = vn1;
            this.vn2 = vn2;
            this.vn3 = vn3;
            this.vn4 = vn4;
        }
    }

    class camera
    {

        public string name = "";
        public point cameraPosition = new point(0, 0, 0);
        public double ratioX = 45;
        public double ratioY = 45;
        public double cameraScreenDistance = 1;
        public point lookAtposition;
        public camera(string name, point cameraPosition, double distace, double ratioX, double ratioY)
        {
            this.name = name;
            this.cameraPosition = cameraPosition;
            this.cameraScreenDistance = distace;
            this.ratioX = ratioX;
            this.ratioY = ratioY;
        }

        //
        public void LookAt(point position, Mesh mesh)
        {
            if (mesh != null)
            {

                List<v> vs = mesh.v;
                for (int i = 0; i < vs.Count; i++)
                {
                    v v = vs[i];
                }
            }
            else
            {
                lookAtposition = position;
            }
        }

    }


    class Light
    {
        public struct color
        {
            double R; double G; double B;
        }
        public struct position
        {
            double x;
            double y;
            double z;
        }

    }

    //
    class objModifier
    {
        //load mesh
        public static Mesh loadMesh(string objFilePath)
        {
            Mesh mesh = new Mesh();
            //
            StreamReader sr = new StreamReader(objFilePath, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                line.TrimStart();
                //v
                if (line.IndexOf('v') == 0 && line.IndexOf(' ') == 1)
                {
                    string[] tempArray = line.Split(new char[] { 'v', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                    mesh.v.Add(new v(Double.Parse(tempArray[0]), Double.Parse(tempArray[1]), Double.Parse(tempArray[2])));
                }
                //vt
                if (line.IndexOf('v') == 0 && line.IndexOf('t') == 1)
                {
                    string[] tempArray = line.Split(new char[] { 'v', 't', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                    mesh.vt.Add(new vt(Double.Parse(tempArray[0]), Double.Parse(tempArray[1])));
                }
                //vn
                if (line.IndexOf('v') == 0 && line.IndexOf('n') == 1 && line.IndexOf(' ') == 2)
                {
                    string[] tempArray = line.Split(new char[] { 'v', 'n', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                    mesh.vn.Add(new vn(Double.Parse(tempArray[0]), Double.Parse(tempArray[1]), Double.Parse(tempArray[2])));
                }
                //f3 
                if (line.IndexOf('f') == 0)
                {
                    string[] tempArray = line.Split(new char[] { 'f', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

                    if (tempArray.Length == 3)
                    {
                        string[] VertexInfo0 = tempArray[0].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                        string[] VertexInfo1 = tempArray[1].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                        string[] VertexInfo2 = tempArray[2].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);


                        face3 face3_ = new face3(int.Parse(VertexInfo0[0]), int.Parse(VertexInfo1[0]), int.Parse(VertexInfo2[0]),
                                                 int.Parse(VertexInfo0[1]), int.Parse(VertexInfo1[1]), int.Parse(VertexInfo2[1]),
                                                 int.Parse(VertexInfo0[2]), int.Parse(VertexInfo1[2]), int.Parse(VertexInfo2[2]));

                        mesh.f3.Add(face3_);
                    }
                    else if (tempArray.Length == 4)
                    {
                        string[] VertexInfo1 = tempArray[0].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                        string[] VertexInfo2 = tempArray[1].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                        string[] VertexInfo3 = tempArray[2].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
                        string[] VertexInfo4 = tempArray[3].Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);


                        face4 face4_ = new face4(int.Parse(VertexInfo1[0]), int.Parse(VertexInfo2[0]), int.Parse(VertexInfo3[0]), int.Parse(VertexInfo4[0]),
                                                  int.Parse(VertexInfo1[1]), int.Parse(VertexInfo2[1]), int.Parse(VertexInfo3[1]), int.Parse(VertexInfo4[1]),
                                                  int.Parse(VertexInfo1[2]), int.Parse(VertexInfo2[2]), int.Parse(VertexInfo3[2]), int.Parse(VertexInfo4[2]));


                        mesh.f4.Add(face4_);
                    }
                    else
                    {
                        //************有非3边和4边面**************



                    }
                }
            }
            return mesh;
        }
        //save mesh
        public static void saveMesh(Mesh mesh, string objFilePath,string fileName)
        {
            string line = "g default \r\n";
            objFilePath = objFilePath + "/" + fileName ;
            List<v> vertes=mesh.v;
            for (int i = 0; i < vertes.Count;i++ ) {                
                      line = line+"v " + vertes[i].x + "  " + vertes[i].y + "  " + vertes[i].z+"\r\n";
            }
            List<vt> vts = mesh.vt;
            for (int i = 0; i < vts.Count; i++)
            {
                line = line + "vt " + vts[i].u + "  " + vts[i].v + "  " + "\r\n";
            }
            List<vn> vns = mesh.vn;
            for (int i = 0; i < vns.Count; i++)
            {
                line = line + "vn " + vns[i].x + "  " + vns[i].y + "  " + vns[i].z + "\r\n";
            }
            List<face3> face3 = mesh.f3;
            for (int i = 0; i < face3.Count; i++)
            {
                line = line + "f " + face3[i].point1+"/"+face3[i].ut1 +"/"+face3[i].vn1+ "  "
                            +face3[i].point2+"/"+face3[i].ut2 +"/"+face3[i].vn2+"  "
                            +face3[i].point3+"/"+face3[i].ut3 +"/"+face3[i].vn3+"\r\n" ;
            }
            List<face4> face4 = mesh.f4;
            for (int i = 0; i < face4.Count; i++)
            {
                line = line + "f " + face4[i].point1 + "/" + face4[i].ut1 + "/" + face4[i].vn1 + "  "
                            + face4[i].point2 + "/" + face4[i].ut2 + "/" + face4[i].vn2 + "  "
                            + face4[i].point3 + "/" + face4[i].ut3 + "/" + face4[i].vn3 + "  "
                              + face4[i].point4 + "/" + face4[i].ut4 + "/" + face4[i].vn4 +  "\r\n";
            }
            FileUtil.Write(objFilePath, line);
        }
    }



}
