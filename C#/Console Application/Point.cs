//Chris Ward
//CIDM 4360

using System;

namespace Assignment3
{
class Point
{
    int x;
    int y;
    public static int MaxX = 500;
    public static int MaxY = 600;

    public Point()
    {
        x = 0;
        y = 0;
    }
    public Point(int ix, int iy)
    {
        x = ix;
        y = iy;
    }

    public Point(string xy)
    {
        string[] coords = xy.Split(',');
        int ix = int.Parse(coords[0]);
        int iy = int.Parse(coords[1]);
        if (ix >= 0 && ix <= MaxX)
        {
            x = ix;
        }
        else
        {
            x = 0;
        }
        if (iy >= 0 && iy <= MaxY)
        {
            y = iy;
        }
        else
        {
            y = 0;
        }

    }

    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public bool setX(int ix)
    {
        if (ix >= 0 && ix <= MaxX)
        {
            x = ix;
            return true;
        }
        return false;
    }

    public bool sety(int iy)
    {
        if (iy >= 0 && iy <= MaxY)
        {
            y = iy;
            return true;
        }
        return false;
    }

    public void move(int nx, int ny)
    {
        if (nx >= 0 && nx <= MaxX)
            if (ny >= 0 && ny <= MaxY)
            {
                x = nx;
                y = ny;
            }
    }

    public void displayLocation()
    {
        //Console.WriteLine("MaxX = {0}",MaxX);
        Console.WriteLine( $"point is at ({x},{y}) ");
    }


}
}
