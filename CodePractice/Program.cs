using System;


namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Singleton******\n");
            
            LoadBalancer L1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer L2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer L3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer L4 = LoadBalancer.GetLoadBalancer();

            if(L1==L2&&L2==L3 &&L3==L4){
                Console.WriteLine("Same Instance");
            }

            LoadBalancer load = LoadBalancer.GetLoadBalancer();
                for(int i = 0; i<15; i++){
                    Console.WriteLine(load.Server);
                }

            Console.WriteLine("\n******AbstractFactory******\n");

            ContinentFactory africa = new AfricaFactory();
            AnimalWorld earth = new AnimalWorld(africa);
            earth.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            earth = new AnimalWorld(america);
            earth.RunFoodChain();

            Console.WriteLine("\n******Factory******\n");

            Document[] document = new Document[2];
            document[0] = new Report();
            document[1] = new Resume();

            foreach(Document doc in document){
                Console.WriteLine(doc.GetType().Name + " contains:");
                foreach(Page page in doc.Pages){
                    Console.WriteLine("\t"+page.GetType().Name);
                }
            }
            Console.WriteLine("\n******Facade******\n");
            Mortgage mort = new Mortgage();
            Customer customer = new Customer("Chad");
            int amount = 100000;
            bool elligable = mort.IsElligable(customer, amount);
            Console.WriteLine(customer.Name + " is " + (elligable ? "elligable" : "not elligable"));

            Console.WriteLine("\n******Decorator******\n");
            Book book = new Book("George RR Martin", "A song of ice and fire",22);
            book.Display();

            Video video = new Video("Jaws","Spielberg",92,18);
            video.Display();

            Borrowable borrowableVideo = new Borrowable(video);
            borrowableVideo.BorrowItem("Sky");
            borrowableVideo.BorrowItem("Inga");
            borrowableVideo.Display();

            Console.WriteLine("\n******Prototype******\n");
            ColorManager colorManager = new ColorManager();
            colorManager["red"] = new Color(255,0,0);
            colorManager["green"] = new Color(0,255,0);
            colorManager["blue"] = new Color(0,0,255);

            colorManager["angry"] = new Color(255,54,0);
            colorManager["peace"] = new Color(128,211,128);
            colorManager["flame"] = new Color(211,34,20);

            Color color1 = colorManager["red"].Clone() as Color;
            Color color2 = colorManager["peace"].Clone() as Color;
            Color color3 = colorManager["flame"].Clone() as Color;

            Console.WriteLine("\n******Builder******\n");
            VehicleBuilder builder;

            Shop shop = new Shop();

            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorcycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            Console.WriteLine("\n******Adapter******\n");
            Compound unknown = new RichCompound("Unknown");
            unknown.Display();
            Compound water = new RichCompound("Water");
            water.Display();
            Compound benzene = new RichCompound("Benzene");
            benzene.Display();
            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();

            Console.WriteLine("\n******Bridge******\n");
            Customers customers = new Customers("Chicago");
            customers.Data = new CustomersData();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");
            customers.ShowAll();

            Console.WriteLine("\n******Composite******\n");
            CompositeElement root = new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            CompositeElement comp = new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            PrimitiveElement pe = new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            root.Display(1);

            Console.WriteLine("\n******Observer******\n");
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            Console.WriteLine("\n******Strategy******\n");
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samuel");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            /* 
            Console.WriteLine("\n******Template******\n");
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Products();
            daoProducts.Run();
            */

            Console.WriteLine("\n***Chain of Responsibility***\n");
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            Purchase p = new Purchase(2034,350.00,"Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035,32590.10,"Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036,122100.00,"Project Y");
            larry.ProcessRequest(p);

            Console.WriteLine("\n******Command******\n");
            User user = new User();

            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*',10);
            user.Compute('/',2);

            user.Undo(4);

            user.Redo(3);

            Console.ReadKey();
        }
    }
}
