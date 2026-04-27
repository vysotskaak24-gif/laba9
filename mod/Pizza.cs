namespace PizzaInventoryApp.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public class PizzaStore
{
    private readonly List<Pizza> _inventory = new()
    {
        new Pizza { Id = 1, Name = "Маргарита", Quantity = 10 },
        new Pizza { Id = 2, Name = "Пепероні", Quantity = 8 },
        new Pizza { Id = 3, Name = "Гавайська", Quantity = 5 }
    };

    private int _nextId = 4;

    public IReadOnlyList<Pizza> Inventory => _inventory;

    public void AddPizza(string name, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name) || quantity < 0)
        {
            return;
        }

        _inventory.Add(new Pizza { Id = _nextId++, Name = name.Trim(), Quantity = quantity });
    }

    public void UpdateQuantity(int id, int delta)
    {
        var pizza = _inventory.FirstOrDefault(x => x.Id == id);
        if (pizza is null)
        {
            return;
        }

        pizza.Quantity = Math.Max(0, pizza.Quantity + delta);
    }

    public void RemovePizza(int id)
    {
        var pizza = _inventory.FirstOrDefault(x => x.Id == id);
        if (pizza is not null)
        {
            _inventory.Remove(pizza);
        }
    }
}