using ClonePizzaMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClonePizzaMaui.Services
{
    public class PizzaService
    {
        public readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza
            {
                Name = "Margherita",
                Image = "pizza_slice8",
                Price = 2.5,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Capricciosa",
                Image = "pizza_slice7",
                Price = 1.45,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Napoletana",
                Image = "pizza_slice6",
                Price = 3.95,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Primavera",
                Image = "pizza_slice5",
                Price = 3.5,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Diavola",
                Image = "pizza_diavola",
                Price = 2.95,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Dama Bianca",
                Image = "pizza_slice4",
                Price = 2.99,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Ortolana",
                Image = "pizza_slice3",
                Price = 4.95,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Veneziana",
                Image = "pizza_fancy_slice",
                Price = 5.99,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Bufalina",
                Image = "pizza_slice2",
                Price = 1.5,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            },
            new Pizza
            {
                Name = "Ortolana Bianca",
                Image = "pizza_slice",
                Price = 2.9,
                Description = "This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui lorem ipsum.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui.\b\n This is a random description for this pizza, so we can display pizza's detail page to check ui."
            }
        };
        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;

        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) =>
            _pizzas.OrderBy(p => Guid.NewGuid())
            .Take(count);

        public Task<IEnumerable<Pizza>> SearchPizzas(string searchTerm) =>
            Task.FromResult( // restituirà un'istanza completata immediatamente
                string.IsNullOrEmpty(searchTerm)
                ? _pizzas
                : _pizzas.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );
    }
}
