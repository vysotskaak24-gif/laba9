using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaInventoryApp.Models;

namespace PizzaInventoryApp.Pages;

public class IndexModel : PageModel
{
    private readonly PizzaStore _store;

    public IndexModel(PizzaStore store)
    {
        _store = store;
    }

    [BindProperty]
    public string NewPizzaName { get; set; } = string.Empty;

    [BindProperty]
    public int NewPizzaQuantity { get; set; } = 1;

    [BindProperty]
    public int Id { get; set; }

    public IReadOnlyList<Pizza> Pizzas => _store.Inventory;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        _store.AddPizza(NewPizzaName, NewPizzaQuantity);
        return RedirectToPage();
    }

    public IActionResult OnPostIncrease()
    {
        _store.UpdateQuantity(Id, 1);
        return RedirectToPage();
    }

    public IActionResult OnPostDecrease()
    {
        _store.UpdateQuantity(Id, -1);
        return RedirectToPage();
    }

    public IActionResult OnPostRemove()
    {
        _store.RemovePizza(Id);
        return RedirectToPage();
    }
}