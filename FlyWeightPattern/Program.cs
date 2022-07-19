namespace FlyWeightPattern;

abstract class Slider
{
    protected string? Name;
    protected string? Cheese;
    protected string? Toppings;
    protected decimal Price;

    public abstract void Display(int orderTotal);
}


class BaconMaster : Slider
{
    public BaconMaster()
    {
        Name = "Bacon Master";
        Cheese = "American";
        Toppings = "lots of bacon";
        Price = 2.39m;
    }

    public override void Display(int orderTotal)
    {
        Console.WriteLine("Slider #" + orderTotal + ": " + Name + " - topped with " +
            Cheese + " cheese and " + Toppings + "! $" + Price.ToString());
    }
}


class VeggieSlider : Slider
{
    public VeggieSlider()
    {
        Name = "Veggie Slider";
        Cheese = "Swiss";
        Toppings = "lettuce, onion, tomato, and pickles";
        Price = 1.99m;
    }

    public override void Display(int orderTotal)
    {
        Console.WriteLine("Slider #" + orderTotal + ": " + Name + " - topped with "
            + Cheese + " cheese and " + Toppings + "! $" + Price.ToString());
    }
}


class BBQKing : Slider
{
    public BBQKing()
    {
        Name = "BBQ King";
        Cheese = "American";
        Toppings = "Onion rings, lettuce, and BBQ sauce";
        Price = 2.49m;
    }

    public override void Display(int orderTotal)
    {
        Console.WriteLine("Slider #" + orderTotal + ": " + Name + " - topped with "
                          + Cheese + " cheese and " + Toppings + "! $" + Price.ToString());
    }
}


class SliderFactory
{
    private Dictionary<char, Slider> _sliders = new();

    public Slider GetSlider(char key)
    {
        Slider slider = null;

        // Slider varsa olani isledecek
        if (_sliders.ContainsKey(key))
            slider = _sliders[key];

        // Yoxdursa yenisini yaradacaq
        else
        {
            switch (key)
            {
                case 'B': slider = new BaconMaster(); break;
                case 'V': slider = new VeggieSlider(); break;
                case 'Q': slider = new BBQKing(); break;
            }
            _sliders.Add(key, slider);
        }
        return slider;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter slider order (B, V, Q): ");
        var order = Console.ReadLine();
        char[] charArray = order.ToCharArray();

        SliderFactory factory = new SliderFactory();

        int total = 0;

        foreach (var c in charArray)
        {
            total++;
            Slider character = factory.GetSlider(c);
            character.Display(total);
        }

        Console.ReadKey();
    }
}