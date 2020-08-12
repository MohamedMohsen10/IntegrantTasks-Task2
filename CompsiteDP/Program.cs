using System;
using System.Collections.Generic;

namespace CompsiteDP
{
    class Program
    {
        static void Main(string[] args)
        {
            CompoundGraph root = new CompoundGraph();
            root.Add(new Circle(0, 0, 0));
            root.Add(new Circle(5, 5, 5));
            root.Add(new Circle(10, 10, 10));
            root.Add(new Dot(50, 50));

            CompoundGraph comp = new CompoundGraph();
            comp.Add(new Circle(0, 0, 50));
            root.Add(comp);
            root.draw();


        }

        public abstract class Graph
        {
            public abstract void move(int x, int y);
            public abstract void draw();
            public abstract void Add(Graph c);
            public abstract void Remove(Graph c);
        }

        public class Dot:Graph
        {

            public int x, y;
            public Dot(int _x,int _y)
            {
                x = _x;
                y = _y;
            }
             public override void move(int x, int y)
            {
                Console.WriteLine($"{x}, {y}");
            }

            public override void draw()
            {
                Console.WriteLine($"Dots {x}, {y}");
            }
            public override void Add(Graph c)
            {
                throw new NotImplementedException();
            }
            public override void Remove(Graph c)
            {
                throw new NotImplementedException();
            }
        }



        public class Circle:Dot
        {
            int Redius { get; set; }

            public Circle(int _x, int _y, int _r):
                base(_x,_y)
            {
                Redius = _r;
            }

            public override void draw()
            {
                Console.WriteLine($"Circle{x}, {y}, {Redius}");
            }
            public override void Add(Graph c)
            {
                Console.WriteLine("Can't add to leaf");
            }
            public override void Remove(Graph c)
            {
                Console.WriteLine("Can't Remove from leaf");
            }
        }


        public class CompoundGraph:Graph
        {
            private List<Graph> Chlidren { get; set; } = new List<Graph>();

            public override void Add(Graph c)
            {
                Chlidren.Add(c);
            }
            public override void Remove(Graph c)
            {
                Chlidren.Remove(c);
            }
            
            public override void move(int x, int y)
            {
                foreach (var item in Chlidren)
                    item.move(x, y);
            }
            public override void draw()
            {
                foreach (var item in Chlidren)
                {
                    item.draw();
                }
            }
        }




    }
}
