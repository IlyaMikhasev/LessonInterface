namespace Interface
{
    interface IAngle
    {
        public int GetNumberAngle();
    }
    interface IPerimetr
    {
        public float GetPerimetr();
    }
    interface IPrintInfo
    {
        public void PrintInfo();
    }
    public class GeoFigure
    {
        private string _name;
        public string Name { get { return _name; } }
        public GeoFigure(string name)
        {
            _name = name;
        }
    }
    public class Square : GeoFigure, IAngle, IPerimetr, IPrintInfo
    {
        private float _side;
        public Square(string name) : base(name) { }
        public Square(string name, float side) : base(name)
        {
            _side = side;
        }
        public int GetNumberAngle()
        {
            return 4;
        }
        public float GetPerimetr()
        {
            return _side * GetNumberAngle();
        }
        public void PrintInfo() {
            Console.WriteLine($"Фигура {base.Name.ToString()} имеет периметр {GetPerimetr().ToString()}");
            string filename = "output.txt";
            string info = $"Сторон {GetNumberAngle()} периметр {GetPerimetr()} имя {Name} {DateTime.Now.ToString("HH:mm:ss.fff")}";
            using (var sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(info);
            }
        }

    }
    public class Cyrcle : GeoFigure, IAngle, IPerimetr, IPrintInfo
    {
        private float _radius;
        public Cyrcle(string name) : base(name) { }
        public Cyrcle(string name, float radius) : base(name)
        {
            _radius = radius;
        }
        public int GetNumberAngle()
        {
            return 0;
        }
        public float GetPerimetr()
        {
            return (float)(_radius * 2 * Math.PI);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Фигура {base.Name.ToString()} имеет периметр {GetPerimetr().ToString()}");
            string filename = "output.txt";
            string info = $"Сторон {GetNumberAngle()} периметр {GetPerimetr()} имя {Name}";
            using (var sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(info);
            }
        }

    }
    internal class Program
    {
        
        static void TalkAboutFigure(GeoFigure figure) {
            if ((figure as Cyrcle) != null)//проверка на downcast
            {
                Console.WriteLine($"{figure.Name} круг");
                ((Cyrcle)figure).PrintInfo();
            }
            else if ((figure as Square) != null)
            {
                Console.WriteLine($"{figure.Name} квадрат");
                ((Square)figure).PrintInfo();
            }
            else {
                Console.WriteLine("фигура не является кругом и квадратом");
            }
        }
        static void Main(string[] args)
        {
            Cyrcle cyrcle = new Cyrcle("круг", 7);
            Square square = new Square("квадрат", 5);
            cyrcle.PrintInfo();
            square.PrintInfo();
            TalkAboutFigure(cyrcle);
        }
    }
}