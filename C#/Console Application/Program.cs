//Chris Ward
//CIDM 4360

using System;
using System.Collections.Generic;

namespace Assignment3
{
    class program
    {
    
    static void Main(string[] args)
    {

        List<Point> myPoints= new List<Point>();
        List<Point> Lpts= new List<Point>();
        Lpts=myPoints;
        Point point =new Point();
        char ch;
        do
            {
        ch = menu();
        switch (ch)
                {
                    case 'a':
                    Console.WriteLine($"Enter the coordinates of the first point to be added as x,y");
                    Point p1= new Point(Console.ReadLine());
                    myPoints.Add(p1);

                    break;
                    case 'b':
                    Console.WriteLine($"Enter the index of the point you would like to delete");
                    Console.WriteLine($"The first entry is 0");
                    displayListOfPoints(myPoints);
                    int b= int.Parse(Console.ReadLine());
                    myPoints.RemoveAt(b);
                    Console.WriteLine($"Here is the new list of points");
                    displayListOfPoints(myPoints);

                    break;
                    case 'c':

                        displayListOfPoints(myPoints);
                    
                    break;
                    case 'd':

                        Console.WriteLine($"Enter the coordinates for the target point as x,y");
                        Point tp= new Point(Console.ReadLine());
                        
                        int NearestPtIndex=FindNearestPoint(tp, myPoints);
                        myPoints[NearestPtIndex].displayLocation();
                    
                    break;

                }
            } while (ch != 'x');
        }

        static double CalcDistanceOf2Ps( Point P ,  Point Q )
    {
        // get the x1,y1 for the first point as in the formula   
        int x1= P.getX();
        int y1= P.getY();
        // get the x2,y2 for the 2nd point  
        int x2= Q.getX();
        int y2= Q.getY();
    
       // calculate intermediate values as X and Y
        double X = Math.Pow(x2-x1,2); // square the difference of the x’s

        double Y = Math.Pow(y2-y1,2);// square the difference of the y’s

        double d = Math.Sqrt(X+Y); // get the square root of the total

        return d;// return the final result

    }   
    public static void displayListOfPoints(List<Point> lps){ //iterates the list to show all the results
    foreach (Point p in lps)
        {
            p.displayLocation();
        }
    }
    public static int FindNearestPoint(Point tp, List<Point> Lpts)  //calculates the nearest point
    {   double a=0;
        double b=0;
        double c=0;
        int index =0;
        int index1 =0;
        // SortPointsListOnXY(Lpts, 'x');
        foreach(var m in Lpts)      //iterates the list to see which one is lower, stores the value in index1
        {
            
            a=CalcDistanceOf2Ps(tp, m);
            if(a<=b)
               {
                   c=a;
                   index1=index;
               }
                else
                {
                    b=a;                           
                }  
                index++;
        }
            return index1;
        }
    // public static void SortPointsListOnXY(List <Point> L1, char on )
    // {
    //         if (on=='X'){
    //          L1.Sort((P,Q)=>P.getX().CompareTo(Q.getX()));              
    //         }
    //         else{
    //          L1.Sort((P,Q)=>P.getY().CompareTo(Q.getY()));    
    //         }
    // }

    //Menu method to display the choices and return selection character
    static char menu()
    {
    char ch;
    string choices = "abcdx";
    do
    {
    Console.WriteLine("\n ------ MENU --------");
    Console.WriteLine("\n a. Add a point to the list");
    Console.WriteLine("\n b. Remove a point from the list using its index");
    Console.WriteLine("\n c. Display the List");
    Console.WriteLine("\n d. Find the nearest point to a target point");
    Console.WriteLine("\n x- Exit");
    Console.WriteLine("\n -------------------");
    Console.WriteLine("\n Your choice (a or b or c or d to exit press x): ");
    ch = char.Parse(Console.ReadLine());        //waits for the user to enter their selection and press enter
    } while (choices.IndexOf(ch) < 0);
    return ch;
    }
    }
}

