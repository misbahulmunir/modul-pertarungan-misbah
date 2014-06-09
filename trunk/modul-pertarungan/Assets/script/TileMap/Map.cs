using UnityEngine;
using System.Collections.Generic;

public class Map
{
    private int size_x;
    private int size_y;
    private int[,] map_data;
    private int[,] button_data;
    private Dictionary<int, int[,]> rules;
    private List<int> usedValue;
    #region Rules
    int[,] rules2;
    int[,] rules3;
    int[,] rules4;
    int[,] rules5;
    int[,] rules6;
    int[,] rules7;
    int[,] rules8;
    int[,] rules9;
    int[,] rules10;
    int[,] rules11;
    int[,] rules12;
    int[,] rules13;
    int[,] rules14;
    int[,] rules15;
    int[,] rules16;
    int[,] rules17;
    #endregion
    #region Init
    public Map(int size_x, int size_y, int posx, int posy, int landSize, int landNum)
    {
        int landPos = size_x / landNum;
        this.size_x = size_x;
        this.size_y = size_y;

        map_data = new int[size_x, size_y];
        button_data = new int[size_x, size_y];
        InitMap();
        for (int i = 0; i < landNum; i++)
        {
            posy = Random.Range(4, 18);
            int land = Random.Range(landSize - 5, landSize + 6);
            MakeLand(posx, posy, land);
            button_data[posx, posy] = 1;
            posx += landPos;
        }
        LandFilling();
        SetRules();
        SetBorder();
    }
    private void InitMap()
    {
        for (int i = 0; i < size_x; i++)
        {
            for (int j = 0; j < size_y; j++)
            {
                map_data[i, j] = 2;
            }
        }
    }
    private void SetRules()
    {
        rules = new Dictionary<int, int[,]>();

        rules2 = new int[3, 3] { { 0, 0, 0 }, { 0, 99, 0 }, { 0, 0, 0 } };
        rules3 = new int[3, 3] { { 1, 1, 1 }, { 1, 99, 1 }, { 1, 1, 1 } };

        rules4 = new int[3, 3] { { 1, 1, 1 }, { 1, 99, 1 }, { 1, 1, 0 } };
        rules5 = new int[3, 3] { { 1, 1, 1 }, { 1, 99, 1 }, { 0, 1, 1 } };
        rules6 = new int[3, 3] { { 0, 1, 1 }, { 1, 99, 1 }, { 1, 1, 1 } };
        rules7 = new int[3, 3] { { 1, 1, 0 }, { 1, 99, 1 }, { 1, 1, 1 } };

        rules8 = new int[3, 3] { { 1, 1, 0 }, { 1, 99, 0 }, { 1, 1, 0 } };
        rules9 = new int[3, 3] { { 0, 1, 1 }, { 0, 99, 1 }, { 0, 1, 1 } };
        rules10 = new int[3, 3] { { 1, 1, 1 }, { 1, 99, 1 }, { 0, 0, 0 } };
        rules11 = new int[3, 3] { { 0, 0, 0 }, { 1, 99, 1 }, { 1, 1, 1 } };

        rules12 = new int[3, 3] { { 0, 1, 1 }, { 0, 99, 1 }, { 0, 0, 0 } };
        rules13 = new int[3, 3] { { 1, 1, 0 }, { 1, 99, 0 }, { 0, 0, 0 } };
        rules14 = new int[3, 3] { { 0, 0, 0 }, { 0, 99, 1 }, { 0, 1, 1 } };
        rules15 = new int[3, 3] { { 0, 0, 0 }, { 1, 99, 0 }, { 1, 1, 0 } };

        rules16 = new int[3, 3] { { 1, 1, 0 }, { 1, 99, 1 }, { 0, 1, 1 } };
        rules17 = new int[3, 3] { { 0, 1, 1 }, { 1, 99, 1 }, { 1, 1, 0 } };

        rules.Add(2, rules2);
        rules.Add(3, rules3);
        rules.Add(4, rules4);
        rules.Add(5, rules5);
        rules.Add(6, rules6);
        rules.Add(7, rules7);
        rules.Add(8, rules8);
        rules.Add(9, rules9);
        rules.Add(10, rules10);
        rules.Add(11, rules11);
        rules.Add(12, rules12);
        rules.Add(13, rules13);
        rules.Add(14, rules14);
        rules.Add(15, rules15);
        rules.Add(16, rules16);
        rules.Add(17, rules17);
    }
    #endregion
    #region RandomGenerator
    public int UniqueRandom(int min, int max)
    {
        int val = Random.Range(min, max);
        if (usedValue.Contains(val))
        {
            val = UniqueRandom(min, max);
        }
        usedValue.Add(val);
        return val;
    }
    #endregion
    #region GetTiling
    public int GetTileAt(int x, int y)
    {
        return map_data[x, y];
    }
    public int[,] GetButtonPos()
    {
        return button_data;
    }
    #endregion
    #region Make Land
    private void MakeLand(int posx, int posy, int landSize)
    {
        map_data[posx, posy] = 3;
        landSize -= 1;
        while (landSize > 0)
        {
            #region Middle
            if ((posx > 0 && posx < size_x - 1) && (posy > 0 && posy < size_y - 1))
            {
                //move bot 
                if ((map_data[posx, posy + 1] != 3 && map_data[posx + 1, posy] != 3 && map_data[posx, posy - 1] != 3 && map_data[posx - 1, posy] != 3) ||
                    (map_data[posx, posy + 1] != 3 && map_data[posx + 1, posy] != 3 && map_data[posx, posy - 1] != 3 && map_data[posx - 1, posy] == 3) ||
                    (map_data[posx, posy + 1] == 3 && map_data[posx + 1, posy] != 3 && map_data[posx, posy - 1] != 3 && map_data[posx - 1, posy] == 3))
                {
                    map_data[posx, posy - 1] = 3;
                    posy--;
                }
                //move left
                else if ((map_data[posx, posy + 1] == 3 && map_data[posx + 1, posy] != 3 && map_data[posx, posy - 1] != 3 && map_data[posx - 1, posy] != 3) ||
                         (map_data[posx, posy + 1] == 3 && map_data[posx + 1, posy] == 3 && map_data[posx, posy - 1] != 3 && map_data[posx - 1, posy] != 3))
                {
                    map_data[posx - 1, posy] = 3;
                    posx--;
                }
                //move up
                else if ((map_data[posx, posy + 1] != 3 && map_data[posx + 1, posy] == 3 && map_data[posx, posy - 1] != 3 && map_data[posx - 1, posy] != 3) ||
                         (map_data[posx, posy + 1] != 3 && map_data[posx + 1, posy] == 3 && map_data[posx, posy - 1] == 3 && map_data[posx - 1, posy] != 3))
                {
                    map_data[posx, posy + 1] = 3;
                    posy++;
                }
                //move right
                else if ((map_data[posx, posy + 1] != 3 && map_data[posx + 1, posy] != 3 && map_data[posx, posy - 1] == 3 && map_data[posx - 1, posy] != 3) ||
                         (map_data[posx, posy + 1] != 3 && map_data[posx + 1, posy] != 3 && map_data[posx, posy - 1] == 3 && map_data[posx - 1, posy] == 3))
                {
                    map_data[posx + 1, posy] = 3;
                    posx++;
                }
            }
            #endregion
            landSize--;
        }
    }
    #endregion
    #region Border Rules
    private bool CheckBorderRules(int right, int bot, int left, int top, int val, int flag)
    {
        //Debug.Log("top " + top + " bot " + bot + " right " + right + " left " + left); 
        int[,] north = new int[3, 3];
        int[,] east = new int[3, 3];
        int[,] south = new int[3, 3];
        int[,] west = new int[3, 3];

        int[,] compares = new int[3, 3];

        int topCount = 0;
        int botCount = 0;
        int rightCount = 0;
        int leftCount = 0;

        #region Rules
        if (rules.ContainsKey(right))
        {
            east = rules[right];
        }
        if (rules.ContainsKey(bot))
        {
            south = rules[bot];
        }
        if (rules.ContainsKey(left))
        {
            west = rules[left];
        }
        if (rules.ContainsKey(top))
        {
            north = rules[top];
        }

        if (rules.ContainsKey(val))
        {
            compares = rules[val];
        }

        #endregion
        #region Middle
        if (top > 1 && bot > 1 && right > 1 && left > 1)
        {
            for (int i = 0; i < 3; i++)
            {
                if (north[2, i] == compares[0, i])
                {
                    topCount++;
                }
                if (south[0, i] == compares[2, i])
                {
                    botCount++;
                }
                if (east[i, 0] == compares[i, 2])
                {
                    rightCount++;
                }
                if (west[i, 2] == compares[i, 0])
                {
                    leftCount++;
                }
            }

            if (flag == 1 && (rightCount == 3 || rightCount == 1) && (leftCount == 3 || leftCount == 1) &&
            (topCount == 3 || topCount == 1 || topCount == 0) && (botCount == 3 || botCount == 1 || botCount == 0))
            {
                return true;
            }
            else if (flag == 2 && (leftCount == 3 || leftCount == 1 || leftCount == 0) &&
            (rightCount == 3 || rightCount == 1 || rightCount == 0) && botCount == 3 && topCount == 3)
            {
                return true;
            }
            else if (flag == 3 && leftCount == 3 && rightCount == 3 && topCount == 3 && botCount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        return false;
    }
    #endregion
    #region Land Filling
    private void LandFilling()
    {
        for (int y = 1; y < size_y - 1; y++)
        {
            for (int x = 1; x < size_x - 1; x++)
            {
                if (map_data[x, y] == 2 && x < size_x - 1 && y < size_y - 1)
                {
                    if ((map_data[x - 1, y] == 3 && map_data[x + 1, y] == 3) || (map_data[x, y + 1] == 3 && map_data[x, y - 1] == 3))
                    {
                        map_data[x, y] = 3;
                    }
                    else if (map_data[x - 1, y] == 3 && map_data[x, y - 1] != 3 && map_data[x, y + 1] != 3 && (map_data[x + 1, y + 1] == 3 || map_data[x + 1, y - 1] == 3))
                    {
                        map_data[x, y] = 3;
                    }
                }
            }
        }
    }
    #endregion
    #region Set Border
    private void SetBorder()
    {
        int posTop = 0;
        int posBot = 0;
        int posRight = 0;
        int posLeft = 0;
        int val = 0;
        int flag = 0;
        bool check;
        int c = 10000;
        #region Left To Right Checking
        for (int y = 1; y < size_y - 1; y++)
        {
            for (int x = 1; x < size_x - 1; x++)
            {
                if (map_data[x, y] == 2 && x < size_x - 1 && y < size_y - 1)
                {
                    if (map_data[x - 1, y] == 3 || map_data[x + 1, y] == 3)
                    {
                        if (map_data[x, y + 1] == 3 || map_data[x, y - 1] == 3)
                        {
                            usedValue = new List<int>();
                            while (c > 0)
                            {
                                posTop = map_data[x, y + 1];
                                posBot = map_data[x, y - 1];
                                posRight = map_data[x + 1, y];
                                posLeft = map_data[x - 1, y];
                                flag = 1;
                                //val = Random.Range(4, 8);
                                val = UniqueRandom(4, 8);
                                check = CheckBorderRules(posRight, posBot, posLeft, posTop, val, flag);
                                if (check == true)
                                {
                                    map_data[x, y] = val;
                                    usedValue.Clear();
                                    break;
                                }
                                c--;
                            }
                        }
                        else
                        {
                            usedValue = new List<int>();
                            while (c > 0)
                            {
                                posTop = map_data[x, y + 1];
                                posBot = map_data[x, y - 1];
                                posRight = map_data[x + 1, y];
                                posLeft = map_data[x - 1, y];
                                flag = 1;
                                //val = Random.Range(8, 12);
                                val = UniqueRandom(8, 12);
                                check = CheckBorderRules(posRight, posBot, posLeft, posTop, val, flag);
                                //Debug.Log("b x: " + x + " y: " + y + " val " + val + " bool " + check + " top " + posTop + " right " + posRight + " left " + posLeft + " bot " + posBot);
                                if (check == true)
                                {
                                    map_data[x, y] = val;
                                    usedValue.Clear();
                                    break;
                                }
                                c--;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Bot To Top Checking
        for (int x = 1; x < size_x - 1; x++)
        {
            for (int y = 1; y < size_y - 1; y++)
            {
                if (map_data[x, y] == 2 && x < size_x - 1 && y < size_y - 1)
                {
                    if (map_data[x, y + 1] == 3 || map_data[x, y - 1] == 3)
                    {
                        usedValue = new List<int>();
                        while (c > 0)
                        {
                            posTop = map_data[x, y + 1];
                            posBot = map_data[x, y - 1];
                            posRight = map_data[x + 1, y];
                            posLeft = map_data[x - 1, y];
                            flag = 2;
                            //val = Random.Range(4, 12);
                            val = UniqueRandom(4, 12);
                            check = CheckBorderRules(posRight, posBot, posLeft, posTop, val, flag);
                            if (check == true)
                            {
                                map_data[x, y] = val;
                                usedValue.Clear();
                                break;
                            }
                            c--;
                        }
                    }
                }
            }
        }

        #endregion
        #region Border Corner
        for (int y = 1; y < size_y - 1; y++)
        {
            for (int x = 1; x < size_x - 1; x++)
            {
                if (map_data[x, y] == 2 && x < size_x - 1 && y < size_y - 1)
                {
                    if ((map_data[x + 1, y] != 2 && map_data[x, y + 1] != 2) || (map_data[x + 1, y] != 2 && map_data[x, y - 1] != 2) ||
                    (map_data[x - 1, y] != 2 && map_data[x, y + 1] != 2) || (map_data[x - 1, y] != 2 && map_data[x, y - 1] != 2))
                    {
                        usedValue = new List<int>();
                        while (c > 0)
                        {
                            posTop = map_data[x, y + 1];
                            posBot = map_data[x, y - 1];
                            posRight = map_data[x + 1, y];
                            posLeft = map_data[x - 1, y];
                            flag = 3;
                            //val = Random.Range(2, 18);
                            val = UniqueRandom(2, 18);
                            check = CheckBorderRules(posRight, posBot, posLeft, posTop, val, flag);
                            if (check == true)
                            {
                                map_data[x, y] = val;
                                usedValue.Clear();
                                break;
                            }
                            c--;
                        }
                    }

                }
            }
        }

        #endregion
    }
    #endregion
}